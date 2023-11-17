# Revit Push

Pushing from BHoM to Revit can be simply explained as creation of Revit elements based on BHoM objects. In order to perform that action, the adapter needs to be [set up correctly](https://github.com/BHoM/Revit_Toolkit/wiki/Revit-Adapter-basics) first. Once this is done, the user needs to specify the first 2 of these 3 inputs:

1. **Objects**: the objects you want to push to Revit from BHoM.
2. **Push type**: decides whether the existing Revit elements should be replaced by the new ones, or just updated, or never replaced, etc.
3. **Action config** (optional) settings of this particular Action.

Besides that, a tag can be added to all newly created elements. Once the adapter and inputs are ready, the Push action needs to be activated - in visual programming environment this is done by setting its `active` property to `true`.

## Push inputs explanation

### Objects
Any BHoM objects can be attempted to be pushed, but only the ones that have a BHoM -> Revit conversion method implemented will be created in Revit document – a full list of such types can be found in [Revit BHoM conversion](Revit-BHoM-conversion) section. If a given Revit type is not matched with any BHoM type, one can try to use [`ModelInstance` or `DraftingInstance`](Revit-BHoM-conversion#modelinstance-draftinginstance-and-instanceproperties) as a powerful workaround. 

**Important!** Conversion of BHoM object properties to Revit family types is currently not supported - Revit element type is applied based on name matching with BHoM property. Therefore, to create a Revit element of given family type, one needs to set BHoM object's property name to same value. Example of Push using this approach is available [here](Push-examples#pushing-elements).

### Push type
Push type specifies the way in which Revit elements should be created and updated. The `RevitUIAdapter` triggers the Push action, which, depending on `PushType`, executes to a combination of `Delete`, `Create` and `Update` [CRUD methods](../../../BHoM_Adapter/The-CRUD-methods.md), as explained below. 

- If `PushType` includes deleting Revit elements, `Push` method collects ElementIds of Revit elements that are [linked to relevant BHoM objects](BHoM-vs-Revit-identity) and deletes them by calling Delete CRUD method.
- If `PushType` includes creating Revit elements, `Push` method [creates new Revit elements based on BHoM objects](Revit-BHoM-conversion#conversion-to-revit) by calling Create CRUD method. Conversion is driven by `BH.Revit.Engine.Core.Convert.IToRevit` dispatcher method. To avoid converting any of the objects more than once, identifier of each object that has been converted in a given adapter action is being stored in `refObjects` dictionary together with the output of the convert.
- If `PushType` includes updating Revit elements, `Push` method collects ElementIds of Revit elements that are [linked to relevant BHoM objects](BHoM-vs-Revit-identity) and updates them by calling Update CRUD method. Two methods are required to explicitly update a Revit element of given type:
    - type-specific `BH.Revit.Engine.Core.Modify.Update` that handles properties and parameters
    - type-specific `BH.Revit.Engine.Core.Modify.SetLocation` that handles geometry of the element
    
    The above are being dispatched by `BH.Revit.Engine.Core.Modify.IUpdate` and `BH.Revit.Engine.Core.Modify.ISetLocation` respectively. If type-specific `Update` method does not exist, only the parameter values will be copied over to the Revit element, as explained [here](https://github.com/BHoM/Revit_Toolkit/wiki/Handling-of-Parameters).

Finally, the successfully pushed BHoM objects are returned to `RevitAdapter` (using a Sockets bypass if `RevitAdapter` and `RevitUIAdapter` do not run on the same thread).


### Action config: RevitPushConfig
Push action config is represented by `RevitPushConfig` and allows to specify the following settings:

- `SuppressFailureMessages` - if true, Revit warnings are suppressed in order not to interrupt the element creation procedure (default is `false`)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be processed (default is `false`)
- `SetLocationOnUpdate` - if true, only parameters of the updated Revit element will be processed, without overwriting its location based on the BHoM object (for more see [Pushing Revit elements with parameters section](Handling-of-Parameters#pushing-revit-elements-with-parameters)).

If `RevitPushConfig` is left empty, default values will be used.

## Revit Push flow-chart explanation (for coders)

The diagram below maps out the above workflow - it should be read as an action-specific variation of the _Adapter action_ stage of the [general Adapter flowchart](Revit-Adapter-Details).

[![Push action flowchart](https://user-images.githubusercontent.com/26874773/78884885-f046b600-7a5b-11ea-9f5e-6d582dcfb889.png)](https://user-images.githubusercontent.com/26874773/78884885-f046b600-7a5b-11ea-9f5e-6d582dcfb889.png)
