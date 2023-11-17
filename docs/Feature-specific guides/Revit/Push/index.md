# Revit Push

Pushing from BHoM to Revit can be simply explained as creation of Revit elements based on BHoM objects. In order to perform that action, the adapter needs to be [set up correctly](https://github.com/BHoM/Revit_Toolkit/wiki/Revit-Adapter-basics) first. Once this is done, the user needs to specify two basic Push inputs:
- **Objects** (which BHoM objects are meant to be pushed?)
- **Push type** (should the existing Revit elements be replaced by the new ones, updated etc.)
- **Action config** (settings of this particular action - optional, if not specified, default values are used)

Besides that, a tag can be added to all newly created elements. Once the adapter and inputs are ready, the Push action needs to be activated - in visual programming environment this is done by setting its `active` property to `true`.

### Objects
Any BHoM objects can be attempted to be pushed, but only the ones that have a BHoM -> Revit conversion method implemented will be created in Revit document - a full list of such types can be found in [Revit BHoM conversion](Revit-BHoM-conversion) section. If a given Revit type is not matched with any BHoM type, one can try to use [`ModelInstance` or `DraftingInstance`](Revit-BHoM-conversion#modelinstance-draftinginstance-and-instanceproperties) as a powerful workaround. 

**Important!** Conversion of BHoM object properties to Revit family types is currently not supported - Revit element type is applied based on name matching with BHoM property. Therefore, to create a Revit element of given family type, one needs to set BHoM object's property name to same value. Example of Push using this approach is available [here](Push-examples#pushing-elements).

### Push type
Push type specifies the way in which Revit elements should be created and updated - more info on that is available in [Push types](Push-types) section.

### Action config
Push action config is represented by `RevitPushConfig` and allows to specify the following settings:
- `SuppressFailureMessages` - if true, Revit warnings are suppressed in order not to interrupt the element creation procedure (default is `false`)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be processed (default is `false`)
- `SetLocationOnUpdate` - if true, only parameters of the updated Revit element will be processed, without overwriting its location based on the BHoM object (for more see [Pushing Revit elements with parameters section](Handling-of-Parameters#pushing-revit-elements-with-parameters)).

If `RevitPushConfig` is left empty, default values will be used.

### Details
Code mechanics of the Push adapter action is explained in [Push to Revit details](Push-to-Revit-details) section.