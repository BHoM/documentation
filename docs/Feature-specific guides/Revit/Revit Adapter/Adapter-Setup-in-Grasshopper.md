# Revit Adapter setup in Grasshopper

**Note:** Before reading this page, it is recommended to have a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section.

In Grasshopper, Revit Adapter with different values can be set up in literally few clicks. The adapter component can either be created based on _CreateAdapter_ component or with **Ctrl+Shift+B** menu. Once the Adapter component is placed on canvas, its `active` input needs to be set to `true` - that is the moment when the connection between Revit and the Adapter is being established. `IsValid` query allows to check if the adapter has been set up correctly on the BHoM side. 

In case of any issues, as a first line of bugfixing, it is recommended to deactivate and activate the adapter again (switch `active == false` and again, `active == true`).

![Adapter Setup in Grasshopper](https://user-images.githubusercontent.com/26874773/78887481-39990480-7a60-11ea-8a44-ea9109cab478.gif)

Once the adapter can be successfully activated, [settings](Revit-Adapter-basics#settings) can be further specified - the animation below shows how maximum timeout has been quickly changed to 60 minutes (default is 10, which may be not enough for massive adapter actions) using **Ctrl+Shift+B**. It is worth noting that required input type can be looked up by hovering the mouse over a certain input.

![Adapter Settings in Grasshopper](https://user-images.githubusercontent.com/26874773/78888165-67cb1400-7a61-11ea-9625-b5d82b534e6b.gif)