The following points outlines the use of the dimensional interfaces as well as extension methods required to be implemented by them for them to function correctly in the Spatial_Engine methods.

Please note that for classes that implement any of the following analytical interfaces, an default implementation already exists in the [Analytical_Engine](https://github.com/BHoM/BHoM_Engine/tree/master/Analytical_Engine) and for those classes an implementation is only needed if any extra action needs to be taken for that particular case. The analytical interfaces with default support are:

| Analytical Interface | Dimensional interface implemented |
|:-----------|:----------|
| `INode` | `IElement0D` |
| `ILink<TNode>` | `IElement1D` |
| `IEdge` | `IElement1D` |
| `IOpening<TEdge>` | `IElement2D` |
| `IPanel<TEdge, TOpening>` | `IElement2D` |

Please note that the default implementations do _not_ cover the mass interface `IElementM`.

1. If the [BHoM](https://github.com/BHoM/BHoM) class implements an `IElement` interface corresponding with its geometrical representation:

    |Interface | Implementing classes |
    |:-----------|:----------|
    | `IElement0D` | Classes which can be represented by `Point` (e.g. nodes) |
    | `IElement1D` | Classes which can be represented by `ICurve` (e.g. bars) |
    | `IElement2D` | Classes which can be represented by a planar set of <br> closed `ICurves` (e.g. planar building panels) |
    | `IElementM`  | Classes which is containing matter in the form of a material and a volume |

2. It needs to have the following methods implemented in it's oM-specific Engine:

    |Interface | Required methods | Optional methods | When |
    |:-----------|:----------|:----------|:----------|
    | `IElement0D` | <ul><li>`Geometry()`</li> <li>`SetGeometry(Point point)`</li><li>`HasMergeablePropertiesWith(IElement0D)`</li></ul> | <br> |
    | `IElement1D` | <ul><li>`Geometry()`</li> <li>`SetGeometry(ICurve curve)`</li><li>`HasMergeablePropertiesWith(IElement1D)`</li></ul> | <ul><li>`Elements0D()`</li> <li>`SetElements0D(`<br>`List<IElement0D> newElements0D)`</li> <li>`NewElement0D(Point point)`</li></ul> | `IElement1D` which endpoints are defined by `IElement0D` |
    | `IElement2D` | <ul><li>`OutlineElements1D()`</li> <li>`SetOutlineElements1D(`<br>`List<IElement1D> outlineElements1D)`</li> <li>`NewElement1D(ICurve curve)`</li> <li>`HasMergeablePropertiesWith(IElement2D)`</li>  </ul> |<ul><li>`InternalElements2D()`</li>  <li>`NewInternalElement2D()`</li> <li>`SetInternalElements2D(`<br>`List<IElement2D> internalElements2D)`</li></ul> | If the `IElement2D` has internal elements |
    | |
    | `IElementM` | <ul><li>`MaterialComposition()`</li> <li>`SolidVolume()`</li></ul> | | |

3. `Spatial_Engine` contains a default `Transform` method for all `IElementXD`s. This implementation only covers the transformation of the base geometry, and does not handle any additional parameters, such as local orientations of the element. For an object that contains this additional layer of information, a object specific `Transform` method must be implemented.
<br/><br/>