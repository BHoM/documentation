### Introduction
Adapter is the heart of information exchange process between BHoM and Revit. No interaction can happen without it, therefore activating it should be the first step to take when working with Revit_Toolkit. In order to activate, you need to:
- [Set up the Revit_Adapter in Revit](Adapter-setup-in-Revit)
- Set up the Revit_Adapter in one or more of the UIs:
    - [Set up in Grasshopper](Adapter-Setup-in-Grasshopper)
    - [Set up in Excel](Adapter-Setup-in-Excel)

Both ends of the Adapter communicate with each other based on Sockets - it is important to set same socket ports on both ends (otherwise they will not _see each other_). There should be only one Revit instance open per each port couple, therefore, if one wants to work with more than one instance of Revit at the same time, it is recommended to change ports. In case of only one Revit instance running, default ports (14128, 14129) are suggested.

### Adapter actions
Once the Adapter is successfully set up, adapter actions can be performed:
- [Pull elements from Revit](Pull-from-Revit-basics)
- [Push BHoM objects to Revit](Push-to-Revit-basics)
- [Remove elements from Revit](Remove-from-Revit-basics)

Push and Pull include [conversion](Revit-BHoM-conversion) from and to Revit, which is being triggered on the fly - it is highly recommended to read this section carefully in order to understand all aspects of this process.

### Settings
There is a range of settings that can be specified in `RevitSettings` for each adapter instance. These are:
- `ConnectionSettings` - socket connection settings for Revit Adapter
- `FamilyLoadSettings` - Revit family load settings for Revit Adapter
- `MappingSettings` - [relationships between property names of BHoM types and parameter names of correspondent Revit elements](Handling-of-Parameters#parameter-mapping) as well as [relationships between Revit family names and BHoM types to explicitly convert them to on Pull](Explicit-mapping-Revit-families-to-BHoM-types-on-Pull)
- `DistanceTolerance` - used in geometry processing
- `AngleTolerance` - used in geometry processing

If `RevitSettings` are not set, default settings will be used (which should be perfectly fine in most cases).

### Details
Code mechanics of the Revit_Adapter is explained in [Adapter Details section](Revit-Adapter-Details).