# Revit push: advanced usage details

This chapter explains in detail the Push action - it is recommended to read [Revit Adapter details](Revit-Adapter-Details) section first for the information about mechanics of the adapter itself.

As explained in [Push to Revit basics](Push-to-Revit-basics), there are three action-specific inputs that drive Push:
- **Objects**, an `IEnumerable<IBHoMObject>` to be pushed to Revit
- **Push type** of type `BH.oM.Adapter.PushType` explained in more detail in a [dedicated section](Push-types)
- **Action config** of type `RevitPushConfig`

They are specified as arguments of the `Push` method of `RevitAdapter`. Depending on the thread on which the `Push` method is executed, they will be either sent via Sockets as a data package (if `Push` is executed outside of Revit thread) or passed directly to `RevitUIAdapter` (if everything is run on a single Revit thread).

Next, `RevitUIAdapter` triggers Push action, which, depending on `PushType`, points to a combination of `Delete`, `Create` and `Update` [CRUD methods](https://github.com/BHoM/documentation/wiki/Adapter-Actions#the-crud-paradigm), as explained below. 

- If `PushType` includes deleting Revit elements, `Push` method collects ElementIds of Revit elements that are [linked to relevant BHoM objects](BHoM-vs-Revit-identity) and deletes them by calling Delete CRUD method.
- If `PushType` includes creating Revit elements, `Push` method [creates new Revit elements based on BHoM objects](Revit-BHoM-conversion#conversion-to-revit) by calling Create CRUD method. Conversion is driven by `BH.Revit.Engine.Core.Convert.IToRevit` dispatcher method. To avoid converting any of the objects more than once, identifier of each object that has been converted in a given adapter action is being stored in `refObjects` dictionary together with the output of the convert.
- If `PushType` includes updating Revit elements, `Push` method collects ElementIds of Revit elements that are [linked to relevant BHoM objects](BHoM-vs-Revit-identity) and updates them by calling Update CRUD method. Two methods are required to explicitly update a Revit element of given type:
    - type-specific `BH.Revit.Engine.Core.Modify.Update` that handles properties and parameters
    - type-specific `BH.Revit.Engine.Core.Modify.SetLocation` that handles geometry of the element
    
    The above are being dispatched by `BH.Revit.Engine.Core.Modify.IUpdate` and `BH.Revit.Engine.Core.Modify.ISetLocation` respectively. If type-specific `Update` method does not exist, only the parameter values will be copied over to the Revit element, as explained [here](https://github.com/BHoM/Revit_Toolkit/wiki/Handling-of-Parameters).

Finally, the successfully pushed BHoM objects are returned to `RevitAdapter` (using a Sockets bypass if `RevitAdapter` and `RevitUIAdapter` do not run on the same thread).

The diagram below maps out the above workflow - it should be read as an action-specific variation of the _Adapter action_ stage of the [general Adapter flowchart](Revit-Adapter-Details).

[![Push action flowchart](https://user-images.githubusercontent.com/26874773/78884885-f046b600-7a5b-11ea-9f5e-6d582dcfb889.png)](https://user-images.githubusercontent.com/26874773/78884885-f046b600-7a5b-11ea-9f5e-6d582dcfb889.png)