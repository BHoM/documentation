# Revit family library

`FamilyLibrary` is a settings object allowing for loading missing Families and Family Types to the project. It can be attached to `RevitAdapter` by setting `RevitSettings.FamilyLoadSettings.FamilyLibrary` property. On `Push`, if a requested Family or Family or Family Type is not loaded to the project, the adapter will parse the specified library in search for it. Once found, it will be loaded on the fly.

Following order will be considered when seeking requested Family or Family Type:

1. Families already loaded into the project
2. Families found in `FamilyLibrary` provided

The script below shows how to supply families from _C:\Desktop\MyLibrary_ folders to the adapter, so that it could load them automatically.

![Family Library Script](https://user-images.githubusercontent.com/26874773/102645648-14b66e80-4163-11eb-9345-4f09039736fd.png)

`FamilyLibrary` also helps querying the .rfa files present in the folder. Once created, it contains a collection of `RevitFilePreview` objects that contain basic information about the family contained in each file: category, family name, names of family types etc. All this information can be easily extracted by using a sequence of `Explode` components.

![Query Family Files](https://user-images.githubusercontent.com/26874773/102646256-0157d300-4164-11eb-882f-c5bb331f8394.png)