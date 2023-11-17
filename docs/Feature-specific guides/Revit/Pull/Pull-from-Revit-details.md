This chapter explains in detail the Pull action - it is recommended to read [Revit Adapter details](Revit-Adapter-Details) section first for the information about mechanics of the adapter itself.

As explained in [Pull from Revit basics](Pull-from-Revit-basics), there are two action-specific inputs that drive Pull:
- **Request** of type deriving from `IRequest` explained in more detail in a [dedicated section](Requests-and-filtering)
- **Action config** of type `RevitPullConfig`

They are specified as arguments of the `Pull` method of `RevitAdapter`. Depending on the thread on which the `Pull` method is executed, they will be either sent via Sockets as a data package (if `Pull` is executed outside of Revit thread) or passed directly to `RevitUIAdapter` (if everything is run on a single Revit thread).

Next, `RevitUIAdapter` triggers Pull action, which points directly to `Read` [CRUD method](https://github.com/BHoM/documentation/wiki/Adapter-Actions#the-crud-paradigm). `Read` executes following tasks:
1. Collects ElementIds of Revit elements that meet requirements set by the Request (done in `BH.Revit.Engine.Core.Query.ElementIds`).
2. Checks discipline enforced by:
    - Request - this happens e.g. when the filter is `FilterRequest` with `Type` property equal to `BH.oM.Structure.Elements.Bar` - pulling of elements of given type is possible only for structural discipline
    - `RevitPullConfig` - value carried by `Discipline` property
   
    If discipline is not enforced by any of the two above, `Discipline.Physical` is used as default. Conflict between disciplines is not allowed: if both Request and `RevitPullConfig` enforce a discipline (none of them is equal to `Discipline.Undefined`) and the disciplines enforced by each are not equal, the operation is cancelled with an error.
3. Retrieves the Revit elements under ElementIds from point 1. and [converts them to BHoM for discipline](Revit-BHoM-conversion#conversion-from-revit) determined in point 2. Conversion of all elements is being driven by `BH.Revit.Engine.Core.Convert.IFromRevit` dispatcher method combined with `BH.Revit.Engine.Core.Query.IBHoMType` and `BH.Revit.Engine.Core.Query.ConvertMethod` queries. To avoid converting any of the objects more than once, identifier of each object that has been converted in a given adapter action is being stored in `refObjects` dictionary together with the output of the convert.

The usual flow looks as in the picture below:

![FromRevitConvertFlow](https://user-images.githubusercontent.com/26874773/134532015-cec9accf-8a10-4c3c-995d-96a374ee7e42.png)

4. If `PullGeometryConfig` contains instruction to pull geometry, it is extracted from the elements and attached to the output BHoM objects as `RevitRepresentation` fragments.
5. If `PullRepresentationConfig` contains instruction to pull mesh representation, it is extracted from the elements and attached to the output BHoM objects as `RevitRepresentation` fragments.

Finally, the converted BHoM objects are returned to `RevitAdapter` (using a Sockets bypass if `RevitAdapter` and `RevitUIAdapter` do not run on the same thread).

The diagram below maps out the above workflow - it should be read as an action-specific variation of the _Adapter action_ stage of the [general Adapter flowchart](Revit-Adapter-Details).

[![Pull action flowchart](https://user-images.githubusercontent.com/26874773/85879220-3f3df500-b7da-11ea-964d-7f65297cae2a.png)](https://user-images.githubusercontent.com/26874773/85879220-3f3df500-b7da-11ea-964d-7f65297cae2a.png)
