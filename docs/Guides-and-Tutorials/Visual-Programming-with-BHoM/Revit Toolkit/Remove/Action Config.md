# Action config
Remove action config is represented by `RevitRemoveConfig` and allows to specify the following settings:

- `SuppressFailureMessages` - if true, Revit warnings are suppressed in order not to interrupt the removal procedure (default is `false`)
- `IncludeClosedWorksets` - if true, Revit elements from closed worksets will be removed (default is `false`)
- `RemovePinned` - if true, pinned Revit elements will be removed (default is `false`)

If `RevitRemoveConfig` is left empty, default values will be used.