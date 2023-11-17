# Introduction to the Revit Adapter

The Revit Adapter is the heart of the data exchange process between BHoM and Revit. No interaction can happen without it, therefore activating it should be the first step to take when working with Revit_Toolkit. In order to activate, you need to:
- [Set up the Revit_Adapter in Revit](Adapter-setup-in-Revit)
- Set up the Revit_Adapter in one or more of the UIs:
    - [Set up in Grasshopper](Adapter-Setup-in-Grasshopper)
    - [Set up in Excel](Adapter-Setup-in-Excel)

Both ends of the Adapter communicate with each other based on Sockets - it is important to set same socket ports on both ends (otherwise they will not _see each other_). There should be only one Revit instance open per each port couple, therefore, if one wants to work with more than one instance of Revit at the same time, it is recommended to change ports. In case of only one Revit instance running, default ports (14128, 14129) are suggested.

## Adapter actions
Once the Adapter is successfully set up, adapter actions can be performed:
- [Pull elements from Revit](Pull-from-Revit-basics)
- [Push BHoM objects to Revit](Push-to-Revit-basics)
- [Remove elements from Revit](Remove-from-Revit-basics)

Push and Pull include [conversion](Revit-BHoM-conversion) from and to Revit, which is being triggered on the fly - it is highly recommended to read this section carefully in order to understand all aspects of this process.

## Settings
There is a range of settings that can be specified in `RevitSettings` for each adapter instance. These are:
- `ConnectionSettings` - socket connection settings for Revit Adapter
- `FamilyLoadSettings` - Revit family load settings for Revit Adapter
- `MappingSettings` - [relationships between property names of BHoM types and parameter names of correspondent Revit elements](Handling-of-Parameters#parameter-mapping) as well as [relationships between Revit family names and BHoM types to explicitly convert them to on Pull](Explicit-mapping-Revit-families-to-BHoM-types-on-Pull)
- `DistanceTolerance` - used in geometry processing
- `AngleTolerance` - used in geometry processing

If `RevitSettings` are not set, default settings will be used (which should be perfectly fine in most cases).

### Revit Family library

`FamilyLibrary` is a settings object allowing for loading missing Families and Family Types to the project. It can be attached to `RevitAdapter` by setting `RevitSettings.FamilyLoadSettings.FamilyLibrary` property. On `Push`, if a requested Family or Family or Family Type is not loaded to the project, the adapter will parse the specified library in search for it. Once found, it will be loaded on the fly.

Following order will be considered when seeking requested Family or Family Type:
1. Families already loaded into the project
2. Families found in `FamilyLibrary` provided

The script below shows how to supply families from _C:\Desktop\MyLibrary_ folders to the adapter, so that it could load them automatically.

![Family Library Script](https://user-images.githubusercontent.com/26874773/102645648-14b66e80-4163-11eb-9345-4f09039736fd.png)

`FamilyLibrary` also helps querying the .rfa files present in the folder. Once created, it contains a collection of `RevitFilePreview` objects that contain basic information about the family contained in each file: category, family name, names of family types etc. All this information can be easily extracted by using a sequence of `Explode` components.

![Query Family Files](https://user-images.githubusercontent.com/26874773/102646256-0157d300-4164-11eb-882f-c5bb331f8394.png)

## Programmers and coders: advanced details
Code mechanics of the Revit_Adapter is explained in [Adapter Details section](Revit-Adapter-Details).