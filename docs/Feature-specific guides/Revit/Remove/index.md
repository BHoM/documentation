# Revit Remove

Removing elements from Revit to BHoM works very similar to [pulling], with the difference that the Revit elements get removed instead of extracted and converted to BHoM. In order to perform Remove action, the adapter needs to be [set up correctly](https://github.com/BHoM/Revit_Toolkit/wiki/Revit-Adapter-basics) first. Once this is done, the user needs to specify two basic Remove inputs:

- **Request** (which Revit elements are meant to be removed?) 
- **Action config** (settings of this particular action - optional, if not specified, default values are used)

Once the adapter and inputs are ready, the Remove action needs to be activated: in visual scripting environments, this is done by setting its `active` property to `true`.

### Request
Requests are listed and explained in [requests and filtering](Requests-and-filtering) section.

### Action config
Remove action config is represented by `RevitRemoveConfig` and allows to specify the following settings:

- `SuppressFailureMessages` - if true, Revit warnings are suppressed in order not to interrupt the removal procedure (default is `false`)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be removed (default is `false`)
- `RemovePinned` - if true, pinned Revit elements will be removed (default is `false`)

If `RevitRemoveConfig` is left empty, default values will be used.

### Details
Code mechanics of the Remove adapter action is explained in [Remove from Revit details](Remove-from-Revit-details) section.