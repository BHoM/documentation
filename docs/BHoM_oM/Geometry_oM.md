# Geometry_oM 

Geometry_oM is the core library, on which all engineering BHoM objects are based. It provides a common foundation that allows to store and represent spatial information about any type of object in any scale: building elements, their properties and others, both physical and abstract.

All objects can be found [here in the Geometry_oM](https://github.com/BHoM/BHoM/tree/master/Geometry_oM)

The code is divided into a few thematic domains, each stored in a separate folder:
-	Coordinate System
-	Curve
-	Interface
-	Math
-	Mesh
-	Misc
-	SettingOut
-	ShapeProfiles
-	Solid
-	Surface
-	Vector

All classes belong to one namespace (`BH.oM.Geometry`) with one exception of Coordinate Systems, which live under `BH.oM.Geometry.CoordinateSystem`. 
All methods referring to the geometry belong to `BH.Engine.Geometry` namespace.
 
## Interfaces
Two separate families of interfaces coexist in Geometry_oM. First of them organizes the classes within the namespace:

|Interface | Implementing classes |
|:-----------|:----------|
| `IGeometry` | All classes within the namespace |
| `ICurve` | Curve classes |
| `ISurface` | Surface classes |

The other extends the applicability of the geometry-related methods to all objects, which spatial characteristics are represented by a certain geometry type:

|Interface | Implementing classes |
|:-----------|:----------|
| `IElement0D` | All classes represented by `Point` |
| `IElement1D` | All classes represented by `ICurve` |
| `IElement2D` | All classes represented by a planar set of closed `ICurves` (e.g. building panels) |
| `IElement3D` | All classes represented by a closed volume (e.g. room spaces) - _not implemented yet_ |

## Tolerances
There is a range of constants representing default tolerances depending on the tolerance type and scale of the model:

| Scale | Value |
|:-----------|:----------|
| Micro | 1e-9 |
| Meso | 1e-6 |
| Macro | 1e-3 |
| Angle | 1e-6 |

## Conversion to proprietary software packages
While being pulled/pushed through the Adapters, the BHoM geometry is converted to relevant geometry format used by each software package.

[BHoM Rhinoceros conversion table](https://github.com/BHoM/Rhinoceros_Toolkit/wiki/BHoM---Rhinoceros-conversion-table)

## Known issues
At the current stage, Geometry_oM bears a few limitations:
- Nurbs are not supported (although there is a framework for them in place)
- 3-dimensional objects (curved surfaces, volumes etc.) are not supported with a few exceptions
- Boolean operations on regions contain a few bugs

