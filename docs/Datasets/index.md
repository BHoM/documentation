# BHoM Datasets


Datasets are a way to store and distribute BHoMObjects for use by others. For example, a list of standard [structural materials](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets/Materials) or [section properties](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets/SectionProperties) as well as [global warming potential](https://github.com/BHoM/LifeCycleAssessment_Toolkit/tree/main/DataSets) for various materials.

The data should be serialised in a [Dataset](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Dataset.cs) object, and the relevant .csproj file in the repo, in which the Dataset is stored, should have a post build event implemented that ensures that the Dataset is copied to the C:\ProgramData\BHoM\Datasets folder. This will allow it to be picked up by the `Library_Engine`.

# Generate a new dataset

To generate a new dataset to be used with the BHoM the following steps should be taken.

1. Generate the objects to be stored in the new Dataset. This means creating the BHoMObject of the correct type in any of the supported UIs. See below for an example of how to create a handful of standard European steel materials in Grasshopper. Remember to give the created objects an easily identifiable name as the name is what will show up when using the data in the dropdowns. **Remember that all BHoM objects should be defined in [SI units](/BHoM-Units-conventions).**

![Create Steel](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/Example%20generate%20data.PNG)

2. Store the created objects in a [Dataset](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Dataset.cs) object and give the dataset an appropriate name. This is the name for the dataset - the name that appears in the UI is described the next step.

![Assign objects to dataset](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/AssignObejctsToDataset.PNG)

3. Populate the source object and assign it to the dataset. See guidance [below](#Source) regarding the source.

![Assign source](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/AssignSourceToDataset.PNG)

4. Convert the dataset object and store it to a single line json file. This is easiest done using the [FileAdapter](https://github.com/BHoM/File_Toolkit). The library engine relies on the json files to be a single line per object, while the default json output from the FileAdapter is putting the json over multiple lines. To make sure the produced json file is in the correct format for the library engine, provide a [FIle.PushConfig](https://github.com/BHoM/File_Toolkit/blob/main/File_oM/Config/PushConfig.cs) with `UseDatasetSerialization` set to true and `BeautifyJson` set to false to the push command. Name the file something clearly identifiable, as the name of the file will be what is used to identify the dataset by the library engine, and will be what it is called in the UI menu.

![Store json to file](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/SaveDatasetToFile.PNG)

5. For personal use, do one of the following:
   1. Place the file in the relevant subfolder of the C:\ProgramData\BHoM\Datasets folder. If no relevant subfolder already exists, a new one can be added. The folder will be used to generate the menus used to find the dataset in the menu system, and also makes a whole folder searchable using the [Library method.](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Query/Library.cs) Remember that running an installer will reset the datasets folder so for this option backup the json file, or use option ii.
   2. Place the json file in a subfolder of a folder of your own choice and use the [custom dataset folder](#Custom-dataset-folder) outlined below.
6. For distribution of the Dataset to the BHoM community do the following:
   1. Store the dataset in the appropriate repository folder:
      - For a general dataset, such as standard materials etc, place the json file in an appropriate subfolder folder in [BHoM_Datasets](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets).
      - For a toolkit specific dataset put the json file in a Dataset folder in the root folder of the toolkit to host the dataset. If no such folder exist, it should be created. Make sure that the oM project in the toolkit has the following post-build event code: `xcopy "$(SolutionDir)DataSets\*.*" "C:\ProgramData\BHoM\DataSets" /Y /I /E` that ensures that the dataset is copied over to the C:\ProgramData\BHoM\Datasets folder.
   2. Raise a Pull request on github and ask for review from relevant parties.


# Custom dataset folder

By default the Library_Engine scans the C:\ProgramData\BHoM\Datasets for all json files and loads them up to be queryable by the UI and the methods in the library engine. This location is reset with each BHoM install to make sure all datasets are up to date and that any modifications or fixes correctly are applied to the data. For some cases it can be also useful to have your own datasets stored in your own folder for example on a network drive to share during work on a particular project.

For these reasons it is possible to get the Library_Engine to scan other folders for datasets as well. This can easily be controlled via the [AddUserPath](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Compute/AddUserPath.cs) and [RemoveUserPath](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Compute/RemoveUserPath.cs) commands that can be called from any UI. After the AddUserPath command has been run _once_ for a particular folder, the library engine will store the information about this folder in its settings and will keep on looking in subfolders of that location for any json files to be used as dataset.

![Add user path](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/AddUserPath.PNG)

To stop the Library_Engine from looking in this particular folder, use the RemoveUserPath command, providing a link to the folder you no longer want to be scanned by the Library_Engine.

![Remove user path](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Datasets/RemoveUserPath.PNG)

Remember that the menu system of the Dataset dropdown components are built up using the subfolders, so even if only a single dataset is placed in this custom folder it might be a good idea to still put your json file in an appropriate subfolder.

# Compliance

Compliance regulations for Datasets are outlined in /IsValidDataset

# Source

For users of the data to be able to verify where it is coming from, it is important to populate the [Source](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Source.cs) object for the dataset. As many of the properties of the source as available should generally be populated, with an emphasis on the following:

### Title
The title of the publication/paper/website/... from which the data has been taken.

### SourceLink
A http link to the source. Important to allow users of the data to easily identify where the data is coming from.

### Confidence
Level of confidence both in the source as well as how well the serialised data in the BHoM dataset has been ensured to match the source. It should be noted that, independent of the confidence level on the Dataset, all Datasets distributed with the BHoM are subject to the [General Disclaimer](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Query/GeneralDisclaimer.cs).

The confidence is split into 5 distinct categories, and the creator/distributor/maintainer of the dataset should always aim for the highest level of confidence as is achievable.


#### Undefined
Default value - assume no fidelity and no source.

Should generally be avoided when adding a new Dataset for distribution with the BHoM - one of the levels below should be explicitly defined.

#### None
The Dataset may not have a reliable source and/or fidelity to the source has not been tested.

To be used for prototype Datasets where no reliable data is available, and not for general distribution within the BHoM. 
#### Low
The Dataset comes from an unreliable source but the data matches the source based on initial checks.

For cases where no reliable source for the data type is available. Can be allowed to be distributed with the BHoM in circumstances where no reliable source can be found and the data still can be deemed useful.
#### Medium
The Dataset comes from a reliable source and matches the source based on initial checks.

For most cases the minimum required level of confidence for distribution of a Dataset with the BHoM. To reach this level of confidence, the Source object should be properly filled in, and a substantial spot checking of the data should have been made. If at all possible, maintainers of a Medium confidence level Dataset should strive to fulfil the requirements of High confidence.
#### High
The Dataset comes from a reliable source and matches the source based on extensive review and testing.

Highest level of confidence for BHoM datasets, and should generally be the aspiration for all Datasets included with the BHoM.

To achieve this, a clear testing procedure should generally be in place, which outlines how _all_ of the data points in the Dataset have been checked against the source data and/or verified by other means to be correct.