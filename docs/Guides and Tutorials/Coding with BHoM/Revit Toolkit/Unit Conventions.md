### Unit conventions
Revit_Toolkit follows the [BHoM unit conventions](https://github.com/BHoM/documentation/wiki/BHoM-Units-conventions). All Revit units are being converted to BHoM SI units with `BH.Revit.Engine.Core.Convert.FromSI` and `BH.Revit.Engine.Core.Convert.ToSI` methods. Please note that in order to account for [the breaking changes in unit handling in Revit API](https://www.revitapidocs.com/2021.1/news?section=toc18), it is recommended to use the following to work with Revit units in BHoM to avoid applying preprocessor directives:

| Action | Revit 2020 and below | Revit 2021 and above |
|----------------|----------------|----------------|
| Get unit type of parameter Definition | `BH.Revit.Engine.Core.Query.GetSpecTypeId` | `Autodesk.Revit.DB.Definition.GetSpecTypeId` |
| Get display unit type of Parameter | `BH.Revit.Engine.Core.Query.GetUnitTypeId` | `Autodesk.Revit.DB.Parameter.GetUnitTypeId` |
| Get unit type by name | `BH.Revit.Engine.Core.SpecTypeId` | `Autodesk.Revit.DB.SpecTypeId` |
| Get display unit type by name | `BH.Revit.Engine.Core.UnitTypeId` | `Autodesk.Revit.DB.UnitTypeId` |