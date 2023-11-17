**Note:** Before reading this page, it is recommended to have a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section.

### Basics
Having the adapter successfully set up, one can start interacting with Revit. In general, `Remove` action is very similar to [`Pull`](Pull-in-Grasshopper) (although instead of pulling it deletes elements). `Remove` component behaves like a standard Grasshopper component, so can be placed on canvas with a standard double left click action. Request, on the other hand, is a solely BHoM type, therefore it is easiest to invoke it with **Ctrl+Shift+B** menu, with an alternative of using `CreateObject` component (`CreateRequest` is currently on prototype stage and does not capture all Requests).

The example below shows a simple exercise of deleting all Revit sheets using category filter. There is a few details that might be worth noticing:
- `FilterByCategory` allows to switch off case sensitivity. This is a general use for most name matching components in Revit_Toolkit.
- Remove will not run as long as it is not activated (`active == true`).

![Remove in Grasshopper](https://user-images.githubusercontent.com/26874773/78932528-f4002a00-7aa7-11ea-85ca-5ba63f57a0e8.gif)

More examples is available in [Remove examples](Remove-examples) page.