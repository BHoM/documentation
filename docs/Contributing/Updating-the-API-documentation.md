# Updating the API documentation

## General

The [BHoM API](https://bhom.xyz/api/oM/) documentation is built using mkdocs, which is the same documentation library that is used to generate the general documentation. For more information about this, please see [Editing the documentation](../Editing-the-documentation).

The [BHoM API](https://bhom.xyz/api/oM/) built up automatically [generated markdown pages](#api-generation), one per class. The md files are stored in the [api repo](https://github.com/BHoM/api) under the [docs/oM](https://github.com/BHoM/api/tree/main/docs/oM) folder. The api website is automatically being updated via github actions as soon as any changes to the files is pushed to the main branch on the repository.

### Including a repository to be documented

The repositories and projects to be documented is controlled via the [categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) csv file as well as the [Repos](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/Repos.txt).

To get a project included:
- Ensure the repo it belongs to is in the [Repos](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/Repos.txt). If not, add it, and make sure to put it after all repos it depends on for building
- Add it to the list of projects in the [categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) file. Make sure you use one of the pre-exiting categorisations, and make sure that the last field is set to true. If you repo contains more than one oM and you just want one of them to be documented, then please add it to the list and set the "To be documented" flag to false.

### Including example JSON

For some classes, in particular for classes that are to be shared, it can be useful to show an example of how a BHoM JSON looks. To enable this for a particular class, please do the following:

- Generate a JSON file with a single object for the type you want to display, and name the file with the name of the type. Should generally be an as simple example as possible, that still highlights the potential complexity of the type.
- Add the file to the [Json examples](https://github.com/BHoM/api/tree/main/APIGenerator/APIGenerator/JsonExamples) page, under the folder corresponding to the name of the dll hosting the type.
- Raise a pullrequest to min with the changes.

## API generation

The api docs will be automatically be updated by [github actions](https://github.com/BHoM/api/actions/workflows/generation.yml) using the [APIGenerator](#apigenerator) project described in more detail below.

The github action triggers every week on the night between saturday and sunday UTC, and creates a pull request if any changes are detected. For the changes to affect the live website, this PR needs to be merged. To view open PRs please see [Pull Requests](https://github.com/BHoM/api/pulls). Once the PR is merged, the website will be [automatically updated](#general).

### Steps to update the docs manually

If you want to update the api docs manually, please follow the steps below

1. Clone the [api](https://github.com/BHoM/api) repo
1. Ensure you have all code built and up to date in your BHoM assemblies folder.
    - This could either be done by runnign an up to date installer or cloning and building all the code from source
    - If this is done via the means of an installer, make sure any repos listed in the [categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) file is cloned and built manually
1. Clone all listed repos in the [categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) file into the 'Repositories' folder in the root folder of the api solution.
    - If the folder does not exist, create it
    - Reason the repos need to be cloned into the repository if for the github actions to function as it requires everything to be contain in the currently running repository
1. Remove all subfolders in the 'docs/oM' folders, as well as their content. Be sure to _not_ delete index.md file.
    - Reason for removing all files is to make sure that and class no lonbger present is also removed from the docs. This includes renaming a class or its namespace, as that technically will mean a new file added and the old one hence needs to be removed.
1. Open and build the [APIGenerator solution](https://github.com/BHoM/api/tree/main/APIGenerator)
1. Run the resulting exe
    - Could be run by just hitting f5 in the solution in visual studio
    - Inspect any messaging display for any issues
1. Inspect the changes to the files locally, recomended to inspect in github desktop
1. Raise a pullrequest to main with the changes


### APIGenerator

The for the app to function, it should be run ina subfolder of the solution file. If you simply build it and run and run it from the build location, or just hit f5 from the solution this will be the case. The reason this is required is due to the fact that the app requires access to settings files as well as the example jsons, which are linked through via finding the repo root folder, and then accessed via those paths.

#### Overview
The APIGenerator solution is a single projectconsole app, generating a .exe app that when run generates all the markdown files. Given the prerequisite [steps](#steps-to-update-the-docs-manually) has been set up, it willgenerate a .md file per .cs file in the oMs. To do this, it makes use of data from multiple sources:
  - Compiled oM dlls to extract:
    - Name and namespace of the type
    - Defining properties
    - Class and interface heirachy
  - Compiled Engine dlls to extract:
    - Derived properties (extension methods)
  - [Categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) csv file to extract
    - Categoriesation of the oM into the main defined categories
  - Cloned files to extract:
    - File heirachy to be matched for generated .md files
  - [BHoM JSON Schema](https://github.com/BHoM/BHoM_JSONSchema) to extract:
    - JSON schema of the obejcts
  - Json examples
    - Only availible for types where it has been explicitly added. See [Including example JSON](#including-example-json)


#### Program steps

##### Load settings
Parses the oM_categorisation.csv file to check for oMs to be documented

##### Load Engine assemblies
Loads up all Engine dlls from the programdata folder that are in the BHoM organisation. To check the organisation, it checks the AssemblyDescriptionAttribute for the link, and makes sure it links over to a github repository in the BHoM organisation. If your Engine methods does not show up in there, please ensure your project file has been [set up properly](/docs/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/Project-References-and-Build-Paths/#assembly-information).

##### Extract extention methods
This step extracts all extention methods that could be seen as Derived properties. The methods captured by this step are methods that fullfill the following conditions:

1. Are Query methods
1. fullfuls one of the following:
    - Have a single input parameter
    - Have more than one input parameter, but all but the first have default values (optional).

All methods that match this criteria will be added as derived properties to the class matching the first input parameter.

##### Load oM assemblies
Loads up all Engine dlls from the programdata folder that are in the BHoM organisation and also listed in the [Categorisation](https://github.com/BHoM/api/blob/main/APIGenerator/APIGenerator/oM_categorisation.csv) csv file. To check the organisation, it checks the AssemblyDescriptionAttribute for the link, and makes sure it links over to a github repository in the BHoM organisation. If your objects does not show up, please ensure it is listed in the csv file and please ensure your project file has been [set up properly](/docs/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/Project-References-and-Build-Paths/#assembly-information).

##### Map types:
Maps the inheritance heirachy between the types. Stores information both about all base types (classes as well as interfaces) for the type, and also adds itself as a subtype to all of its base types.

##### Generate markdown
Loops through all files and generates a .md file per type in all the oM assemblies loaded in the [previous step](#load-om-assemblies), that fullfills the following conditions:
1. Is _not_ abstract AND sealed (filters out autogenerated types)
1. Is assignable from IObject OR an enum 

#### Program structure

The program has been split into multiple files, trying to categorise by similar actions. A full description of all files will not be given here, but the code can be reviewed in place.

The entry point for the overall run can be found in the Program.cs file. The entrypoint for the markdown generation for each type can be found in the TypeToMarkdown file.