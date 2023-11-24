# Action config
Pull action config is represented by `RevitPullConfig` and allows to specify the following settings:

- `Discipline` - discipline, in which the user works (_Physical_ - default, _Structural_, _Building Environments_, _Architecture_, _Facade_) - this determines types of BHoM objects, to which the requested Revit elements are converted - more on that subject can be found in [Revit BHoM conversion](../Conversion from Revit)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be pulled (default is `false`)
- `IncludeNestedElements` - if true, Revit family instances will be pulled together with their subelements (default is `true`)
- `GeometryConfig` - settings defining the geometrical representation (the actual geometrical object representing the element in Revit) to be pulled (by default nothing) - more information available in [Pull of Geometry and Representation](../Pull of Geometry and Representation)
- `RepresentationConfig` - settings defining the mesh representation to be pulled (by default nothing) - more information available in [Pull of Geometry and Representation](../Pull of Geometry and Representation)
- `PullMaterialTakeOff` - if true, `RevitMaterialTakeOff` fragment will be added to the pulled BHoM object, which can then be converted into an `ExplicitBulk` using `MaterialTakeoff` query

If `RevitPullConfig` is left empty, default values will be used.