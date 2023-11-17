# Revit Remove examples

- It is worth having a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section and the rest of Revit_Toolkit Wiki before reading this page.
- All source files are available in [samples](https://github.com/BHoM/samples/tree/master/Revit_Toolkit).

### Removing pinned elements and closed worksets
By default, `Remove` will not delete pinned elements as well as the ones on closed worksets. To enable processing the mentioned groups, the user needs to set the action config (typically created with **Ctrl+Shift+B** menu in Grasshopper and/or the `CreateObject` component). The script below shows how to delete all generic annotations from the model, incl. pinned ones and ones on closed worksets. 

[![Remove pinned in Grasshopper](https://user-images.githubusercontent.com/26874773/78938858-498e0400-7ab3-11ea-9c42-3f5ad0bd60ec.png)](https://user-images.githubusercontent.com/26874773/78938858-498e0400-7ab3-11ea-9c42-3f5ad0bd60ec.png)
