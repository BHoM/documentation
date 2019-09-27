
"Adding template-builder" | Write-Output

# TODO: These should be passed in, not declared here
$importLabel = "TemplateBuilder"
$targetsPropertyName = "TemplateBuilderTargets"
$targetsFileToAddImport = "ligershark.templates.targets";

# When this package is installed we need to add a property
# to the current project, which points to the
# .targets file in the packages folder

function RemoveExistingKnownPropertyGroups($projectRootElement){
    # if there are any PropertyGroups with a label of "$importLabel" they will be removed here
    $pgsToRemove = @()
    foreach($pg in $projectRootElement.PropertyGroups){
        if($pg.Label -and [string]::Compare($importLabel,$pg.Label,$true) -eq 0) {
            # remove this property group
            $pgsToRemove += $pg
        }
    }

    foreach($pg in $pgsToRemove){
        $pg.Parent.RemoveChild($pg)
    }
}

# TODO: Revisit this later, it was causing some exceptions
function CheckoutProjFileIfUnderScc(){
    param(
        $project = (Get-Project)
    ) 
    CheckoutIfUnderScc -filePath $project.FullName
}

function CheckoutIfUnderScc(){
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $filePath,

        $project = (Get-Project)
    )
    "`tChecking if file is under source control, [{0}]" -f $filePath| Write-Verbose
    # http://daltskin.blogspot.com/2012/05/nuget-powershell-and-tfs.html
    $sourceControl = Get-Interface $project.DTE.SourceControl ([EnvDTE80.SourceControl2])
    if($sourceControl -and $sourceControl.IsItemUnderSCC($filePath) -and $sourceControl.IsItemCheckedOut($filePath)){
        "`tChecking out file [{0}]" -f $filePath | Write-Host
        $sourceControl.CheckOutItem($filePath)
    }
}

function EnsureProjectFileIsWriteable(){
    param(
        $project = (Get-Project)
    )
    $projItem = Get-ChildItem $project.FullName
    if($projItem.IsReadOnly) {
        "The project file is read-only. Please checkout the project file and re-install this package" | Write-Host -ForegroundColor Red
        throw;
    }
}

function ComputeRelativePathToTargetsFile(){
    param($startPath,$targetPath)   

    # we need to compute the relative path
    $startLocation = Get-Location

    Set-Location $startPath.Directory | Out-Null
    $relativePath = Resolve-Path -Relative $targetPath.FullName

    # reset the location
    Set-Location $startLocation | Out-Null

    return $relativePath
}

function GetSolutionDirFromProj{
    param($msbuildProject)

    if(!$msbuildProject){
        throw "msbuildProject is null"
    }

    $result = $null
    $solutionElement = $null
    foreach($pg in $msbuildProject.PropertyGroups){
        foreach($prop in $pg.Properties){
            if([string]::Compare("SolutionDir",$prop.Name,$true) -eq 0){
                $solutionElement = $prop
                break
            }
        }
    }

    if($solutionElement){
        $result = $solutionElement.Value
    }

    return $result
}

function AddImportElementIfNotExists(){
    param($projectRootElement)

    $foundImport = $false
    $importsToRemove = @()
    foreach($import in $projectRootElement.Imports){
        $importStr = $import.Project
        if(!$importStr){
            $importStr = ""
        }

        $currentLabel = $import.Label
        if(!$currentLabel){
            $currentLabel = ""
        }

        if([string]::Compare($importLabel,$currentLabel.Trim(),$true) -eq 0){
            # found the import no need to continue
            $foundImport = $true
            break
        }
    }

    if(!$foundImport){
        # the import is not in the project, add it
        # <Import Project="$(VsixCompressImport)" Condition="Exists('$(VsizCompressTargets)')" Label="VsixCompress" />
        $importToAdd = $projectRootElement.AddImport("`$($targetsPropertyName)");
        $importToAdd.Condition = "Exists('`$($targetsPropertyName)')"
        $importToAdd.Label = $importLabel 
    }        
}

function UpdateVsixManifest(){
    param(
        $project = (Get-Project)
    )
    # we will look for any file in the project which ends with .vsixmanifest and add
    # <Assets>
    #   <Asset Type="Microsoft.VisualStudio.ItemTemplate" Path="Output\ItemTemplates"/>
    # </Assets>

    $vsixManifestFiles = @()
    # search for any file in the project which ends with .vsixmanifest
    foreach ($projItem in $project.ProjectItems){ 
        if( ($projItem -and $projItem.Name -and $projItem.Name.EndsWith('.vsixmanifest'))) {
            "`tFound manifest [{0}], getting fullpath" -f $projItem.Name | Write-Verbose
            $vsixManifestFiles += $projItem.Properties.Item("FullPath").Value
        }
    }

    try{
        # add asset tag if it doesn't
        foreach($vsixManifestFile in $vsixManifestFiles){
            [xml]$vsixXml = Get-Content $vsixManifestFile
            AddAssetTagsForTemplates -vsixXml $vsixXml -vsixFilePathToUpdate $vsixManifestFile
        }
    }
    catch{
        "Unable to update the .vsixmanifest file. You may need to add the Asset elements yourself. See the readme which has just opened up.`nError: [{0}]" -f ($_.Exception) | Write-Warning
    }
}
function AddAssetTagsForTemplates{
    [cmdletbinding()]
    param(
        [Parameter(Mandatory=$true,Position=0)]
        [xml]$vsixXml,
        [Parameter(Mandatory=$true,Position=1)]
        [string]$vsixFilePathToUpdate
    )
    process{
        $modifiedXml = $false
        $assetTag = GetOrCreateAssetsElement -vsixXml $vsixXml
        # add the item template tag if it's missing
        if( ($vsixXml.PackageManifest.Assets.Asset | Where-Object {$_.Path -eq 'Output\ItemTemplates'}) -eq $null){
            $itemElement= $vsixXml.CreateElement('Asset', $vsixXml.DocumentElement.NamespaceURI)
            $itemElement.SetAttribute('Type', 'Microsoft.VisualStudio.ItemTemplate') | Out-Null
            $itemElement.SetAttribute('Path', 'Output\ItemTemplates') | Out-Null

            if($assetTag){
                $assetTag.AppendChild($itemElement) | Out-Null
                $modifiedXml = $true
            }
            else{
                'Unable to add item template Asset tags to the .vsixmanifest file, please add them manually' | Write-Warning
            }
        }

        # add the project template tag if it's missing
        if( ($vsixXml.PackageManifest.Assets.Asset | Where-Object {$_.Path -eq 'Output\ProjectTemplates'}) -eq $null ){
            # create the element here
            $projElement = $vsixXml.CreateElement('Asset', $vsixXml.DocumentElement.NamespaceURI)
            $projElement.SetAttribute('Type', 'Microsoft.VisualStudio.ProjectTemplate') | Out-Null
            $projElement.SetAttribute('Path', 'Output\ProjectTemplates') | Out-Null

            if($assetTag){
                $assetTag.AppendChild($projElement) | Out-Null
                $modifiedXml = $true
            }
            else{
                'Unable to add project template Asset tags to the .vsixmanifest file, please add them manually' | Write-Warning
            }
        }

        if($modifiedXml){
            CheckoutIfUnderScc -filePath $vsixFilePathToUpdate | Out-Null
            $vsixXml.Save($vsixFilePathToUpdate) | Out-Null
        }
    }
}
function GetOrCreateAssetsElement(){
    param(
        [Parameter(Mandatory=$true)]
        [xml]$vsixXml
    )

    # see if the assets tag is there or not, if not add it
    [System.Xml.XmlElement]$assetTag = $null

    if($vsixXml.GetElementsByTagName('Assets')){
        $assetTag = $vsixXml.GetElementsByTagName('Assets')[0]
    }

    if($assetTag -eq $null){
        $assetTag = $vsixXml.CreateElement('Assets', $vsixXml.DocumentElement.NamespaceURI)
        $vsixXml.PackageManifest.AppendChild($assetTag) | Out-Null
    }

    # return the element
    $assetTag
}

# just for debugging, should be removed
Export-ModuleMember -function *



