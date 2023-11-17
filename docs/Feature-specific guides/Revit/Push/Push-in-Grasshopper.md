# Revit Push in Grasshopper

!!! note
    Before reading this page, it is recommended to have a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section.

## Basics
Having the adapter successfully set up, one can start interacting with Revit. Similar to [`Pull`](Pull-in-Grasshopper), `Push` behaves like a standard Grasshopper component, so can be placed on canvas with a standard double left click action. The objects to be pushed need to be BHoM objects and should generally be one of the types supported by [BHoM conversion to Revit](Revit-BHoM-conversion#conversion-to-revit).

The example below shows a simple exercise of pushing a few sheets to Revit. Please note that `Push` will not run as long as it is not activated (`active == true`).

![Push in Grasshopper](https://user-images.githubusercontent.com/26874773/102643892-3f52f800-4160-11eb-8a11-257e40e8271c.gif)

More examples is available in [Push examples](Push-examples) page.