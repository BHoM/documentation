# Revit-BHoM conversion compatibility

Revit_Toolkit provides bi-directional conversion between Revit and BHoM. This conversion is an integral part of Push and Pull Adapter actions - besides simply translating Revit elements into BHoM objects, it ensures [correctness of the units](Conventions#unit-conventions) and, in general, allows representing Revit objects outside of Revit context.

Sections below explain the practicalities of that process, while its code mechanics is discussed in [Push details](Push-to-Revit-details) and [Pull details](Pull-from-Revit-details) sections.

### Conversion from Revit
Due to multidisciplinarity of both BHoM and Revit, conversion from Revit is not always a singular problem: some elements can be converted into multiple BHoM types, depending on user's discipline preference set in [`RevitPullConfig`](Pull-from-Revit-basics#action-config). Table below contains a matrix of possible converts organized by discipline.

| Revit Category | Revit Type     | BHoM Physical  |  BHoM Structural |  BHoM Envinronments |  BHoM Architecture|  BHoM Facade|
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

If a Revit element is requested to be pulled and there is no explicit convert method for its type and given discipline, it will get converted into a [`ModelInstance`, `DraftingInstance` or `InstanceProperties`](Revit-BHoM-conversion#modelinstance-draftinginstance-and-instanceproperties). If that fails too, a `BHoMObject` with only basic information is returned. The conversion procedure is shown in the flowchart below.

[![Revit to BHoM conversion](https://user-images.githubusercontent.com/26874773/78885047-326ff780-7a5c-11ea-97a1-dcbfa70fcfa0.png)](https://user-images.githubusercontent.com/26874773/78885047-326ff780-7a5c-11ea-97a1-dcbfa70fcfa0.png)

Every time a Revit element is converted, its element type is converted along it. The information about the latter can be stored in 2 ways:
- in defining BHoM property, e.g. `Construction` of `Wall` - the characteristics of the element type as well as its parameters are converted and attached to this property (`Wall.Construction` contains the information about the Revit wall type and its parameters)
- in `RevitTypeFragment` attached to the BHoM object representing the element (in case the BHoM object does not have a defining property that could correspond to the Revit element type, e.g. `Architecture.Room`) - only parameters of the element type are converted and stored in the fragment to allow querying and updating them

To find out where is the Revit element type information stored inside a particular BHoM object, it is recommended to call `GetRevitElementType`.

### Conversion to Revit
Conversion from BHoM to Revit is rather simple: the BHoM object is coming through `BH.Revit.Engine.Core.Convert.IToRevit`, which points it to the appropriate `ToRevit` method that creates an element in the active Revit document. Table below contains a list of BHoM types that can be converted, together with their relevant Revit types. As a general rule, analytical objects (of types that belong to namespaces `BH.oM.Structure` or `BH.oM.Environment`) are not allowed to be pushed to Revit - their physical equivalents (objects of types from `BH.oM.Physical` namespace) should be used instead. So far, the only exception from that rule is `BH.oM.Environment.Elements.Space`.

| BHoM type      | Revit Category     | Revit Type     |
|----------------|----------------|----------------|
| `BH.oM.Geometry.SettingOut.Grid` | Grids | `Autodesk.Revit.DB.Grid` |
| `BH.oM.Geometry.SettingOut.Level` | Levels | `Autodesk.Revit.DB.Level` |
| `BH.oM.Physical.Elements.Wall` | Walls | `Autodesk.Revit.DB.Wall` |
| `BH.oM.Physical.Elements.Floor` | Floors / Structural Foundations | `Autodesk.Revit.DB.Floor` |
| `BH.oM.Physical.Elements.Roof` | Roofs | `Autodesk.Revit.DB.RoofBase` |
| `BH.oM.Physical.Elements.Column` | Structural Columns | `Autodesk.Revit.DB.FamilyInstance` |
| `BH.oM.Physical.Elements.Beam` | Structural Framing| `Autodesk.Revit.DB.FamilyInstance` |
| `BH.oM.Physical.Reinforcement.IReinforcingBar` | Structural Rebar| `Autodesk.Revit.DB.Structure.Rebar` |
| `BH.oM.Environment.Elements.Space` | Spaces | `Autodesk.Revit.DB.Mechanical.Space` |
| `BH.oM.Adapters.Revit.Elements.ViewPlan` | Views (Plan) | `Autodesk.Revit.DB.ViewPlan` |
| `BH.oM.Adapters.Revit.Elements.Viewport` | Viewports | `Autodesk.Revit.DB.Viewport` |
| `BH.oM.Adapters.Revit.Elements.ViewSheet` | Sheets | `Autodesk.Revit.DB.Sheet` |
| `BH.oM.MEP.System.Duct` | Ducts | `Autodesk.Revit.DB.Mechanical.Duct` |
| `BH.oM.MEP.System.Pipe` | Pipes | `Autodesk.Revit.DB.Plumbing.Pipe` |
| `BH.oM.MEP.System.CableTray` | Cable Trays | `Autodesk.Revit.DB.Electrical.CableTray` |
| `BH.oM.Adapters.Revit.Parameters.ParameterDefinition` | - | `Autodesk.Revit.DB.ParameterElement` |
| `BH.oM.Adapters.Revit.Elements.Family` | - | `Autodesk.Revit.DB.Family` |
| `BH.oM.Adapters.Revit.Elements.InstanceProperties` | - | `Autodesk.Revit.DB.ElementType` |

Conversion of BHoM object properties such as `Construction` or `FramingProperties` to Revit is currently not supported - Revit element type is applied based on name matching with defining property of a BHoM object (e.g. `Construction` of a wall or `Property` of a beam). Therefore, to create a Revit element of given family type, one needs to set BHoM object's property name to same value. Example of Push using this approach is available in [examples](Push-examples#pushing-elements).

A limited ability to create Revit types is provided by `BH.oM.Adapters.Revit.ClonedType` object - pushing it creates a clone of an existing Revit element type with a new name, which then can be updated freely.

The last two rows of the table, `Family` and `InstanceProperties`, correspond to an action of loading the families or chosen types to the model - this works only in combination with [FamilyLibrary](https://github.com/BHoM/Revit_Toolkit/wiki/FamilyLibrary).

It is possible to push almost any Revit element using `ModelInstance` and `DraftingInstance`, explained in more detail below.

### ModelInstance, DraftingInstance and InstanceProperties
There are three powerful generic types in Revit_Adapter that can wrap any Revit element. These are:
- `ModelInstance` - any Revit view independent element that has `Location` property
- `DraftingInstance` - any Revit view dependent element that has `Location` property
- `InstanceProperties` - any Revit `ElementType` or `GraphicsStyle `

The above types can be used on Push to create Revit elements that do not have a correspondent BHoM type, e.g. mechanical equipment, generic annotations or filled regions - examples of these can be found in [examples](Push-examples#modelinstances-and-draftinginstances).

The usage of `ModelInstance`, `DraftingInstance` and `InstanceProperties` on Pull has been explained in [Conversion from Revit](Revit-BHoM-conversion#conversion-from-revit) paragraph.

### Geometry conversion
The table below presents geometry conversion methods offered by Revit_Toolkit.

| Revit type      | Supported conversion direction | BHoM type     |
|----------------|:--------------:|----------------|
| `Autodesk.Revit.DB.XYZ` | < - > | `BH.oM.Geometry.Point` |
| `Autodesk.Revit.DB.XYZ` | < - > | `BH.oM.Geometry.Vector` |
| `Autodesk.Revit.DB.Plane` | < - > | `BH.oM.Geometry.CoordinateSystem.Cartesian` |
| `Autodesk.Revit.DB.Line` | < - > | `BH.oM.Geometry.Line` |
| `Autodesk.Revit.DB.Arc` | < - > | `BH.oM.Geometry.Arc` / `BH.oM.Geometry.Circle` |
| `Autodesk.Revit.DB.Ellipse` | < - > | `BH.oM.Geometry.Ellipse` |
| `Autodesk.Revit.DB.NurbSpline` | < - > | `BH.oM.Geometry.NurbsCurve` |
| `Autodesk.Revit.DB.HermiteSpline` |   - > | `BH.oM.Geometry.NurbsCurve` |
| `Autodesk.Revit.DB.Analysis.Polyloop` |  - > | `BH.oM.Geometry.Polyline` |
| `Autodesk.Revit.DB.PolyLine` |  - > | `BH.oM.Geometry.Polyline` |
| `Autodesk.Revit.DB.CurveLoop` | < - > | `BH.oM.Geometry.PolyCurve` |
| `Autodesk.Revit.DB.Solid` | < -  | `BH.oM.Geometry.ISurface` |
| `Autodesk.Revit.DB.Solid` | < -  | `BH.oM.Geometry.BoundaryRepresentation` |

In a special case where Revit requires an unbound curve (e.g. in case of floor outlines) closed BHoM curves are split in half to create a continuous loop consisting of two unbound Revit curves.

It is worth noting that pushing BHoM geometries directly to Revit is not allowed - they always need to be wrapped into some type of object (if are meant to be pushed as primitives, `ModelInstance` or `DraftingInstance` is recommended. Similarly, on pull, each geometrical Revit element will be wrapped into a non-primitive BHoM type.

### Conversion of Parameters and Identity Information
Revit element parameters can be pulled from and pushed to Revit together with an element. That is possible thanks to the fragment-based scheme explained in [Handling of Parameters](Handling-of-Parameters) section. Besides that, the information about identity of Revit elements correspondent to the BHoM objects is stored in `RevitIdentifiers` fragment as explained in [BHoM vs Revit identity](BHoM-vs-Revit-identity).

On top of the above, it is possible to create an entirely new parameter definition in Revit: either a project parameter or shared one. This is done by pushing the `BH.oM.Adapters.Revit.Parameters.ParameterDefinition` object.

### Material Take-offs
It is possible to pull a material take-off of any Revit element on `Pull`. It can be achieved by using [`RevitPullConfig` with `PullMaterialTakeOff` property set to `true`](https://github.com/BHoM/Revit_Toolkit/wiki/Pull-from-Revit-basics#action-config). Once that is done, `RevitMaterialTakeOff` fragment will be added to each pulled BHoM object, which can then be converted into an `ExplicitBulk` using `MaterialTakeoff` query.

### Warning and error messages
It is likely that the adapter will generate warnings on converts. This is related to the fact that each Revit object consists of a multitude of information that often cannot be translated to BHoM one to one. It is important to read warning messages as they usually explain what issue has been found.

Error messages, on the other hand, usually mean that a serious issue occurred on convert: either the object has not been converted due to an error in the method, or the conversion method simply does not exist. Same as with warnings, error messages should provide detailed information about the problem.