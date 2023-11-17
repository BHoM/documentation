This chapter explains in detail the Remove action - it is recommended to read [Revit Adapter details](Revit-Adapter-Details) section first for the information about mechanics of the adapter itself.

As explained in [Remove from Revit basics](Remove-from-Revit-basics), there are two action-specific inputs that drive Remove:
- **Request** of type deriving from `IRequest` explained in more detail in a [dedicated section](Requests-and-filtering)
- **Action config** of type `RevitRemoveConfig`

They are specified as arguments of the `Revit` method of `RevitAdapter`. Depending on the thread on which the `Remove` method is executed, they will be either sent via Sockets as a data package (if `Remove` is executed outside of Revit thread) or passed directly to `RevitUIAdapter` (if everything is run on a single Revit thread).

Next, `RevitUIAdapter` triggers Remove action, which points directly to `Delete` [CRUD method](https://github.com/BHoM/documentation/wiki/Adapter-Actions#the-crud-paradigm). `Delete` executes following tasks:
1. Collects ElementIds of Revit elements that meet requirements set by the Request (done in `BH.Revit.Engine.Core.Query.ElementIds`).
2. Deletes the Revit elements under ElementIds from point 1.

Finally, the number of deleted elements is returned to `RevitAdapter` (using a Sockets bypass if `RevitAdapter` and `RevitUIAdapter` do not run on the same thread).

The diagram below maps out the above workflow - it should be read as an action-specific variation of the _Adapter action_ stage of the [general Adapter flowchart](Revit-Adapter-Details).

[![Remove action flowchart](https://user-images.githubusercontent.com/26874773/78884892-f2107980-7a5b-11ea-9b06-94fedee48f19.png)](https://user-images.githubusercontent.com/26874773/78884892-f2107980-7a5b-11ea-9b06-94fedee48f19.png)