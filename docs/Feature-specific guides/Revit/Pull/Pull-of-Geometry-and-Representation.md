By default, Revit elements are pulled and converted to the BHoM objects as explained in [Revit BHoM conversion](Revit-BHoM-conversion). However, on top of that, it is possible to extract additional information about the actual geometry of an element in Revit, as well as its representation including colours. Instruction about that extra information to pull is passed to the adapter via `GeometryConfig` and `RepresentationConfig` properties of [`RevitPullConfig`](Pull-from-Revit-basics#action-config).

`PullGeometryConfig` object allows to set following geometry-related instructions:
- `PullEdges` - if true, edges of elements will be pulled and stored in `RevitRepresentation` fragment, queryable using `RevitEdges` method
- `PullSurfaces` - if true, surfaces of elements will be pulled and stored in `RevitRepresentation` fragment, queryable using `RevitSurfaces` method
- `PullMeshes` - if true, meshed surfaces of elements will be pulled and stored in `RevitRepresentation` fragment, queryable using `RevitMeshes` method
- `MeshDetailLevel` - detail level of mesh to be pulled, correspondent to level of detail in Revit
- `IncludeNonVisible` - invisible element parts will be pulled and passed to `RevitRepresentation` fragment if true

`PullRepresentationConfig` specifies render mesh settings:
- `PullRenderMesh` - if true, mesh representation of elements will be pulled and stored in `RevitRepresentation` fragment, queryable using `RenderMeshes` method
- `DetailLevel` - detail level of representation, correspondent to level of detail in Revit
- `IncludeNonVisible` - invisible element parts will be pulled and passed to `RevitRepresentation` fragment if true

