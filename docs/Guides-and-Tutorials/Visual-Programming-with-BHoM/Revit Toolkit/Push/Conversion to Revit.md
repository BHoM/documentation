# Conversion to Revit
Revit Toolkit support conversion of many BHoM object types to Revit: they are listed in the table below together with their relevant Revit types. As a general rule, analytical objects (of types that belong to namespaces `BH.oM.Structure` or `BH.oM.Environment`) are not allowed to be pushed to Revit - their physical equivalents (objects of types from `BH.oM.Physical` namespace) should be used instead. So far, the only exception from that rule is `BH.oM.Environment.Elements.Space`.

| <div style="width:250px">BHoM Type</div> | <div style="width:250px">Revit Category</div> | <div style="width:250px">Revit Type</div> |
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

Conversion of BHoM object properties such as `Construction` or `FramingProperties` to Revit is currently not supported - Revit element type is applied based on name matching with defining property of a BHoM object (e.g. `Construction` of a wall or `Property` of a beam). Therefore, to create a Revit element of given family type, one needs to set BHoM object's property name to same value. Example of Push using this approach is available in [examples](../Push Examples#pushing-elements).

On top of the above list, there are three powerful generic types in Revit_Adapter that can wrap any Revit element. These are:

- `ModelInstance` - any Revit view independent element that has `Location` property
- `DraftingInstance` - any Revit view dependent element that has `Location` property
- `InstanceProperties` - any Revit `ElementType` or `GraphicsStyle `

The above types can be used on Push to create Revit elements that do not have a correspondent BHoM type, e.g. mechanical equipment, generic annotations or filled regions - examples of these can be found in [examples](../Push Examples#modelinstances-and-draftinginstances).

It is worth noting that pushing BHoM geometries directly to Revit is not allowed - they always need to be wrapped into some type of object (if are meant to be pushed as primitives, `ModelInstance` or `DraftingInstance` is recommended. Similarly, on pull, each geometrical Revit element will be wrapped into a non-primitive BHoM type.

A limited ability to create Revit types is provided by `BH.oM.Adapters.Revit.ClonedType` object - pushing it creates a clone of an existing Revit element type with a new name, which then can be updated freely.

The last two rows of the table, `Family` and `InstanceProperties`, correspond to an action of loading the families or chosen types to the model - this works only in combination with [FamilyLibrary](../Family Library).