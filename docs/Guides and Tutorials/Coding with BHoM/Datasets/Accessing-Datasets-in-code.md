## How to access BHoM Datasets programmatically
Accessing various datasets, such as material or section datasets, can be useful when coding for BHoM. For example, you may need datasets when coding C# Unit Tests, or when programming some particular Engine function. 

Access BHoM Datasets from a C# program, you need to ensure the correct dependencies are added to your project. The following steps will guide you through the process of adding the appropriate dependencies and demonstrate a few methods for accessing your desired dataset.

### Step 1: Access Reference Manager
Access the Reference Manager in the C# project where you want to add the dependency.

<!-- ![ProjectFolderReference](../../../Images/Datasets/CallDatasetFromVS/ProjectFolderReference.png) -->
![ProjectFolderReference](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/ProjectFolderReference.png)

### Step 2: Browse for the DLL
Go to the "Browse" tab and click the "Browse" button in the bottom-right corner.

<!-- ![BrowseTab](../../../Images/Datasets/CallDatasetFromVS/BrowsTab.PNG) -->
![BrowseTab](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/BrowsTab.png)


Navigate to the BHoM assemblies folder using the File Explorer window. The folder is usually located at C:\ProgramData\BHoM\Assemblies. Select Data_oM.dll and press "Add."

<!-- ![addDataEngineDLL](../../../Images/Datasets/CallDatasetFromVS/addDataEngineDLL.PNG) -->
![addDataEngineDLL](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/addDataEngineDLL.png)

### Step 3: Add Dependency
Make sure to check the box next to Data_oM.dll in the Reference Manager window and press "OK."

<!-- ![CheckBoxAndOK](../../../Images/Datasets/CallDatasetFromVS/CheckBoxAndOK.PNG) -->
![CheckBoxAndOK](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/CheckBoxAndOK.png)

### Step 4: Modify File Path
Open the project file of your specific C# project by double-clicking it with the left mouse button. Locate the line responsible for loading Data_oM.dll and modify the file path as shown in the image below.

<!-- ![ModifyPathInProjectFile](../../../Images/Datasets/CallDatasetFromVS/ModifyPathInProjectFile.PNG) -->
![ModifyPathInProjectFile](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/ModifyPathInProjectFile.png)


### Step 5: Get the Dataset data
The following example demonstrates how to access the Section Library from BHoM, specifically the .

To access the library, use the `Match` method as shown in the example below. This returns the `HE1000M` section defined in the `EU_SteelSectionLibrary` dataset.

```csharp
var steelSection = BH.Engine.Library.Query.Match("EU_SteelSections", "HE1000M", true, true) as ISteelSection;
```

The Match method takes four arguments:

1. Library Name: "EU_SteelSections"
2. Object Name: "HE1000M"
3. Case Sensitivity: true or false
4. Consider Spaces: true or false

The boolean values allow you to specify whether your search should be case-sensitive and whether to consider spaces within the object name.

### Find Existing Libraries

If you're unsure about the available datasets, check the [BHoM_Datasets](https://github.com/BHoM/BHoM_Datasets) repository. 

Under BHoM_Datasets\DataSets, you'll find multiple folders and subfolders containing numerous `json` files. Each json is a dataset, and each folder acts as a dataset library. 

For example, in the folder `[BHoM_Datasets repo folder]\BHoM_Datasets\DataSets\Structure\SectionProperties\EU_SteelSections
` you will find the following json files:

<!-- ![jsonFilesSteelSections](../../../Images/Datasets/CallDatasetFromVS/jsonFilesSteelSections.PNG) -->
![jsonFilesSteelSections](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/CallDatasetFromVS/jsonFilesSteelSections.png)


These .json files contain multiple objects. To extract objects from these datasets, you'll need the name of the desired object. This can be found as an attribute within the .json file. To locate these names, you can open the .json file in an editor like Visual Studio Code and search for the object name you need.

## Compliance

Compliance regulations for Datasets are outlined in [IsValidDataset](/documentation/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/IsValidDataset).

### Source

For users of the data to be able to verify where it is coming from, it is important to populate the [Source](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Source.cs) object for the dataset. As many of the properties of the source as available should generally be populated, with an emphasis on the following:

#### Title
The title of the publication/paper/website/... from which the data has been taken.

#### SourceLink
An HTTP link to the source. Important to allow users of the data to easily identify where the data is coming from.

#### Confidence
Level of confidence both in the data source and in how well the serialised data in the BHoM dataset has been ensured to match the source. It should be noted that, independent of the confidence level on the Dataset, all Datasets distributed with the BHoM are subject to the [General Disclaimer](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Query/GeneralDisclaimer.cs).

The confidence is split into 5 distinct categories, and the creator/distributor/maintainer of the dataset should always aim for the highest level of confidence achievable.


##### Undefined
Default value - assume no fidelity and no source.

Should generally be avoided when adding a new Dataset for distribution with the BHoM - one of the levels below should be explicitly defined.

##### None
The Dataset may not have a reliable source and/or fidelity to the source has not been tested.

To be used for prototype Datasets where no reliable data is available, and not for general distribution within the BHoM. 
##### Low
The Dataset comes from an unreliable source, but the data matches the source based on initial checks.

For cases where no reliable source for the data type is available. Can be allowed to be distributed with the BHoM in circumstances where no reliable source can be found and the data still can be deemed useful.
##### Medium
The Dataset comes from a reliable source and matches the source based on initial checks.

For most cases the minimum required level of confidence for distribution of a Dataset with the BHoM. To reach this level of confidence, the Source object should be properly filled in, and a substantial spot checking of the data should have been made. If at all possible, maintainers of a Medium confidence level Dataset should strive to fulfil the requirements of High confidence.
##### High
The Dataset comes from a reliable source and matches the source based on extensive review and testing.

Highest level of confidence for BHoM datasets, and should generally be the aspiration for all Datasets included with the BHoM.

To achieve this, a clear testing procedure should generally be in place, which outlines how _all_ of the data points in the Dataset have been checked against the source data and/or verified by other means to be correct.
