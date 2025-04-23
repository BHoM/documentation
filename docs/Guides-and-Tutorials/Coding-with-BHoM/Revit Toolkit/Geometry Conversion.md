# Geometry conversion
The table below presents geometry conversion methods offered by Revit_Toolkit.

| <div style="width:250px">Revit type </div>| <div style="width:50px">Supported conversion direction | <div style="width:250px">BHoM type</div> |
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

