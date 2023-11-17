**Note:** Before reading this page, it is recommended to have a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section.

**Important:** on the first run it may happen that pull will fail with connection error - simply refreshing `active` to `true` should help in that case.

Having the adapter successfully set up, one can start interacting with Revit. `Pull` behaves like a standard Grasshopper component, so can be placed on canvas with a standard double left click action. Request, on the other hand, is a solely BHoM type, therefore it is easiest to invoke it with **Ctrl+Shift+B** menu, with an alternative of using either `CreateRequest` or `CreateObject` component.

The example below shows a simple exercise of pulling all Revit elements that can be converted into BHoM `IFramingElements` (which capture both columns and framing). There is a few details that might be worth noticing:
- `FilterByBHoMType` expects a type and not an instance. In Revit language, the user is expected to provide a element type and not the element itself. Therefore, `CreateType` component is being used.
- `Explode` is a general use component that allows to quickly see all properties of any BHoM object. It is very useful and can be applied almost anywhere.
- Pull will not run as long as it is not activated (`active == true`).
- The pull component is turning orange indicating that it threw a [warning](Revit-BHoM-conversion#warning-and-error-messages). That is often acceptable, although should never be left unnoticed.

![Pull in Grasshopper](https://user-images.githubusercontent.com/26874773/78929093-1000cd00-7aa2-11ea-85c9-fc864cfa9832.gif)

More examples is available in [Pull examples](Pull-examples) page.