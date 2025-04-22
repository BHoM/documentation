# Conversion from Revit
Due to multidisciplinarity of both BHoM and Revit, conversion from Revit is not always a singular problem: some elements can be converted into multiple BHoM types, depending on user's discipline preference set in [`RevitPullConfig`](../Action Config). Table below contains a matrix of possible converts organized by discipline.

| <div style="width:250px">Revit Category</div> | <div style="width:250px">Revit Type</div> | <div style="width:250px">BHoM Physical</div> | <div style="width:250px">BHoM Structural</div> | <div style="width:250px">BHoM Envinronments</div> | <div style="width:250px">BHoM Architecture</div> | <div style="width:250px">BHoM Facade</div> |
|----------------|----------------|----------------|------------------|---------------------|-------------------|-------------------|
| Grids | `Autodesk.Revit.DB.Grid` | `BH.oM.Geometry.SettingOut.Grid` | `BH.oM.Geometry.SettingOut.Grid` | `BH.oM.Geometry.SettingOut.Grid` | `BH.oM.Geometry.SettingOut.Grid` | `BH.oM.Geometry.SettingOut.Grid` |
| Levels | `Autodesk.Revit.DB.Level` | `BH.oM.Geometry.SettingOut.Level` | `BH.oM.Geometry.SettingOut.Level` | `BH.oM.Geometry.SettingOut.Level` | `BH.oM.Geometry.SettingOut.Level` |`BH.oM.Geometry.SettingOut.Level` |
| Walls | `Autodesk.Revit.DB.Wall` | `BH.oM.Physical.Elements.Wall` | `BH.oM.Structure.Elements.Panel` | `BH.oM.Environment.Elements.Panel` | `BH.oM.Physical.Elements.Wall` |`BH.oM.Facade.Elements.CurtainWall` |
| Floors / Foundation Slabs | `Autodesk.Revit.DB.Floor` | `BH.oM.Physical.Elements.Floor` | `BH.oM.Structure.Elements.Panel` | `BH.oM.Environment.Elements.Panel` | `BH.oM.Physical.Elements.Floor` | `BH.oM.Physical.Elements.Floor` |
| Roofs | `Autodesk.Revit.DB.RoofBase` | `BH.oM.Physical.Elements.Roof` | `BH.oM.Structure.Elements.Panel` | `BH.oM.Environment.Elements.Panel` | `BH.oM.Physical.Elements.Roof` |`BH.oM.Physical.Elements.Roof` |
| Structural Columns | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.Physical.Elements.Column` | `List<BH.oM.Structure.Elements.Bar>` |  | `BH.oM.Physical.Elements.Column` |  |
| Structural Framing | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.Physical.Elements.Beam` / `BH.oM.Physical.Elements.Bracing` | `List<BH.oM.Structure.Elements.Bar>` |  | `BH.oM.Physical.Elements.Beam` / `BH.oM.Physical.Elements.Bracing` |  |
| Windows | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.Physical.Elements.Window` |  | `BH.oM.Physical.Elements.Window` | `BH.oM.Physical.Elements.Window` | `BH.oM.Facade.Elements.Opening` |
| Doors | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.Physical.Elements.Door` |  | `BH.oM.Physical.Elements.Door` | `BH.oM.Physical.Elements.Door` | `BH.oM.Facade.Elements.Opening` |
| Curtain Panels | `Autodesk.Revit.DB.Panel` | `BH.oM.Physical.Elements.Window` |  | `BH.oM.Physical.Elements.Window` | `BH.oM.Physical.Elements.Window` | `BH.oM.Facade.Elements.Opening` |
| Ceilings | `Autodesk.Revit.DB.Ceiling` | `BH.oM.Architecture.Elements.Ceiling` |  | `BH.oM.Environment.Elements.Panel` | `BH.oM.Architecture.Elements.Ceiling` |`BH.oM.Architecture.Elements.Ceiling` |
| Spaces / Rooms | `Autodesk.Revit.DB.SpatialElement` | `BHoM.Architecture.Elements.Room` |  | `BH.oM.Environment.Elements.Space` | `BHoM.Architecture.Elements.Room` |`BHoM.Architecture.Elements.Room` |
| Project Information | `Autodesk.Revit.DB.ProjectInfo` |  |  | `BH.oM.Environment.Elements.Building` |  |  |
| Analytical Surfaces | `Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace` | `BH.oM.Environment.Elements.Space` |  | `BH.oM.Environment.Elements.Space` | `BH.oM.Environment.Elements.Space` | `BH.oM.Environment.Elements.Space` |
| Interior, Exterior, Shades | `Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface` | `BH.oM.Environment.Elements.Panel` |  | `BH.oM.Environment.Elements.Panel` | `BH.oM.Environment.Elements.Panel` | `BH.oM.Environment.Elements.Panel` |
| Opening | `Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening` | `BH.oM.Environment.Elements.Panel` |  | `BH.oM.Environment.Elements.Panel` | `BH.oM.Environment.Elements.Panel` |`BH.oM.Environment.Elements.Panel` |
| Families | `Autodesk.Revit.DB.Family` | `BH.oM.Adapters.Revit.Elements.Family` | `BH.oM.Adapters.Revit.Elements.Family` | `BH.oM.Adapters.Revit.Elements.Family` | `BH.oM.Adapters.Revit.Elements.Family` | `BH.oM.Adapters.Revit.Elements.Family` |
| Materials | `Autodesk.Revit.DB.Material` | `BH.oM.Physical.Materials.Material` | `BH.oM.Structure.MaterialFragments.IMaterialFragment` | `BH.oM.Environment.MaterialFragments.SolidMaterial` | `BH.oM.Physical.Materials.Material` | `BH.oM.Physical.Materials.Material` |
| Sheets | `Autodesk.Revit.DB.Sheet` | `BH.oM.Adapters.Revit.Elements.ViewSheet` | `BH.oM.Adapters.Revit.Elements.ViewSheet` | `BH.oM.Adapters.Revit.Elements.ViewSheet` | `BH.oM.Adapters.Revit.Elements.ViewSheet` | `BH.oM.Adapters.Revit.Elements.ViewSheet` |
| Viewports | `Autodesk.Revit.DB.Viewport` | `BH.oM.Adapters.Revit.Elements.Viewport` | `BH.oM.Adapters.Revit.Elements.Viewport` | `BH.oM.Adapters.Revit.Elements.Viewport` | `BH.oM.Adapters.Revit.Elements.Viewport` | `BH.oM.Adapters.Revit.Elements.Viewport` |
| Views (Plan) | `Autodesk.Revit.DB.ViewPlan` | `BH.oM.Adapters.Revit.Elements.ViewPlan` | `BH.oM.Adapters.Revit.Elements.ViewPlan` | `BH.oM.Adapters.Revit.Elements.ViewPlan` | `BH.oM.Adapters.Revit.Elements.ViewPlan` | `BH.oM.Adapters.Revit.Elements.ViewPlan` |
| Ducts | `Autodesk.Revit.DB.Mechanical.Duct` | `BH.oM.MEP.System.Duct` |  | `BH.oM.MEP.System.Duct` | `BH.oM.MEP.System.Duct` |  |
| Pipes | `Autodesk.Revit.DB.Plumbing.Pipe` | `BH.oM.MEP.System.Pipe` |  | `BH.oM.MEP.System.Pipe` | `BH.oM.MEP.System.Pipe` |  |
| Wires | `Autodesk.Revit.DB.Electrical.Wire` | `BH.oM.MEP.System.Wire` |  | `BH.oM.MEP.System.Wire` | `BH.oM.MEP.System.Wire` |  |
| Cable Trays| `Autodesk.Revit.DB.Electrical.CableTray` | `BH.oM.MEP.System.CableTray` |  | `BH.oM.MEP.System.CableTray` | `BH.oM.MEP.System.CableTray` |  |
| Fittings | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.MEP.System.Fittings.Fitting` |  | `BH.oM.MEP.System.Fittings.Fitting` | `BH.oM.MEP.System.Fittings.Fitting` |  |
| Builders Work Openings | `Autodesk.Revit.DB.FamilyInstance` | `BH.oM.Architecture.BuildersWork.Opening` |  |  | `BH.oM.Architecture.BuildersWork.Opening` |  |
| Mullions | `Autodesk.Revit.DB.Mullion` |  |  |  |  | `BH.oM.Facade.Elements.FrameEdge` |

In case of conversion to structural BHoM types, Revit element is first queried for its analytical model, and its physical representation is used only if the former does not exist.

If a Revit element is requested to be pulled and there is no explicit convert method for its type and given discipline, it will get converted into a `ModelInstance`, `DraftingInstance` or `InstanceProperties`, which are generic BHoM wrappers for Revit elements. If that fails too, a `BHoMObject` with only basic information is returned. The conversion procedure is shown in the flowchart below.

[![Revit to BHoM conversion](https://user-images.githubusercontent.com/26874773/78885047-326ff780-7a5c-11ea-97a1-dcbfa70fcfa0.png)](https://user-images.githubusercontent.com/26874773/78885047-326ff780-7a5c-11ea-97a1-dcbfa70fcfa0.png)

Every time a Revit element is converted, its element type is converted along it. The information about the latter can be stored in 2 ways:

- in defining BHoM property, e.g. `Construction` of `Wall` - the characteristics of the element type as well as its parameters are converted and attached to this property (`Wall.Construction` contains the information about the Revit wall type and its parameters)
- in `RevitTypeFragment` attached to the BHoM object representing the element (in case the BHoM object does not have a defining property that could correspond to the Revit element type, e.g. `Architecture.Room`) - only parameters of the element type are converted and stored in the fragment to allow querying and updating them

To find out where is the Revit element type information stored inside a particular BHoM object, it is recommended to call `GetRevitElementType`.