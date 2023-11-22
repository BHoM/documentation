# Creation of Datasets


Datasets are a way to store and distribute BHoMObjects for use by others. For example, a list of standard [structural materials](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets/Materials) or [section properties](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets/SectionProperties) as well as [global warming potential](https://github.com/BHoM/LifeCycleAssessment_Toolkit/tree/main/DataSets) for various materials.

The data should be serialised in a [Dataset](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Dataset.cs) object, and the relevant `.csproj` file in the repo, in which the Dataset is stored, should have a post build event implemented that ensures that the Dataset is copied to the `C:\ProgramData\BHoM\Datasets folder`. This will allow it to be picked up by the `Library_Engine`.

## Generate a new dataset

To generate a new dataset to be used with the BHoM the following steps should be taken.

1. Generate the objects to be stored in the new Dataset. This means creating the BHoMObject of the correct type in any of the supported UIs. See below for an example of how to create a handful of standard European steel materials in Grasshopper. Remember to give the created objects an easily identifiable name as the name is what will show up when using the data in the dropdowns. **Remember that all BHoM objects should be defined in [SI units](/documentation/BHoM-Units-conventions).**

    ![Create Steel](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/Example%20generate%20data.PNG)

2. Store the created objects in a [Dataset](https://github.com/BHoM/BHoM/blob/main/Data_oM/Library/Dataset.cs) object and give the dataset an appropriate name. This is the name for the dataset - the name that appears in the UI is described the next step.

    ![Assign objects to dataset](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/AssignObejctsToDataset.PNG)

3. Populate the source object and assign it to the dataset. See guidance [below](#Source) regarding the source.

    ![Assign source](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/AssignSourceToDataset.PNG)

4. Convert the dataset object and store it to a single line json file. This is easiest done using the [FileAdapter](https://github.com/BHoM/File_Toolkit). The library engine relies on the json files to be a single line per object, while the default json output from the FileAdapter is putting the json over multiple lines. To make sure the produced json file is in the correct format for the library engine, provide a [File.PushConfig](https://github.com/BHoM/File_Toolkit/blob/main/File_oM/Config/PushConfig.cs) with `UseDatasetSerialization` set to true and `BeautifyJson` set to `false` to the push command. Name the file something clearly identifiable, as the name of the file will be what is used to identify the dataset by the library engine, and will be what it is called in the UI menu.

    ![Store json to file](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/SaveDatasetToFile.PNG)

5. For personal use, do one of the following:
    1. Place the file in the relevant subfolder of the C:\ProgramData\BHoM\Datasets folder. If no relevant subfolder already exists, a new one can be added. The folder will be used to generate the menus used to find the dataset in the menu system, and also makes a whole folder searchable using the [Library method.](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Query/Library.cs) Remember that running an installer will reset the datasets folder so for this option backup the json file, or use option ii.
    2. Place the json file in a subfolder of a folder of your own choice and use the [custom dataset folder](#Custom-dataset-folder) outlined below.
6. For distribution of the Dataset to the BHoM community do the following:
    1. Store the dataset in the appropriate repository folder:
        - For a general dataset, such as standard materials etc., place the json file in an appropriate subfolder folder in [BHoM_Datasets](https://github.com/BHoM/BHoM_Datasets/tree/main/DataSets).
        - For a toolkit specific dataset put the json file in a Dataset folder in the root folder of the toolkit to host the dataset. If no such folder exist, it should be created. Make sure that the oM project in the toolkit has the following post-build event code: `xcopy "$(SolutionDir)DataSets\*.*" "C:\ProgramData\BHoM\DataSets" /Y /I /E` that ensures that the dataset is copied over to the C:\ProgramData\BHoM\Datasets folder.
    2. Raise a Pull request on GitHub and ask for review from relevant parties.


## Custom dataset folder

By default, the Library_Engine scans the C:\ProgramData\BHoM\Datasets for all json files and loads them up to be queryable by the UI and the methods in the library engine. This location is reset with each BHoM install to make sure all datasets are up-to-date and that any modifications or fixes correctly are applied to the data. For some cases it can be also useful to have your own datasets stored in your own folder for example on a network drive to share during work on a particular project.

For these reasons it is possible to get the Library_Engine to scan other folders for datasets as well. This can easily be controlled via the [AddUserPath](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Compute/AddUserPath.cs) and [RemoveUserPath](https://github.com/BHoM/BHoM_Engine/blob/main/Library_Engine/Compute/RemoveUserPath.cs) commands that can be called from any UI. After the AddUserPath command has been run _once_ for a particular folder, the library engine will store the information about this folder in its settings and will keep on looking in subfolders of that location for any json files to be used as dataset.

![Add user path](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/AddUserPath.PNG)

To stop the Library_Engine from looking in this particular folder, use the RemoveUserPath command, providing a link to the folder you no longer want to be scanned by the Library_Engine.

![Remove user path](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Datasets/RemoveUserPath.PNG)

Remember that the menu system of the Dataset dropdown components are built up using the subfolders, so even if only a single dataset is placed in this custom folder it might be a good idea to still put your json file in an appropriate subfolder.
