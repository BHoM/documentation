# Action config
Push action config is represented by `RevitPushConfig` and allows to specify the following settings:

- `SuppressFailureMessages` - if true, Revit warnings are suppressed in order not to interrupt the element creation procedure (default is `false`)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be processed (default is `false`)
- `SetLocationOnUpdate` - if true, only parameters of the updated Revit element will be processed, without overwriting its location based on the BHoM object (for more see [Pushing Revit elements with parameters section](../Handling of Parameters)).

If `RevitPushConfig` is left empty, default values will be used.