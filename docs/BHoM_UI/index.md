# BH.UI: Expose your code to User Interfaces

For an user perspective on the UIs, you might be looking for _[Using the BHoM](/Basics/Using-the-BHoM)_.

## Supported UIs

The UI layer has been designed so that it will automatically pick everything implemented in the BHoM, the Engines and the Adapters without the need to change anything on the code of the UI.

Here's what the menu looks like in Grasshopper. The number of component there doesn't have to change when more functionality is added to the rest of the code:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_Menu.png)

When dropped on the cavas, most of those components will have no input and no output. They will be converted to their final form once you have selected what they need to be in their menu:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_ComponentSearchMenu.gif)

You can get more information on how to use one of the BHoM UI [on this page](/Basics/Using-the-BHoM).


## Automatic rendering of a `BHoMObject`
`BHoMObject`s are rich objects, which may or may not contain a geometry representation.
If a geometry representation can be extracted, either from one of its properties, or as a result of their manipulation, it can be used to automatically render the object in the GUIs. The only action to enable that, is to create a `Query.Geometry` method, whose only parameter is the object you want to display, and place it in the `Engine` namespace that corresponds to the `oM` of the object. The method has to return an `IGeometry` or one of its assignable types.

For example, let's assume I want to automatically display a `BH.oM.Structure.Elements.Bar`. I'd do as follows:
1. Go into the correspondent Engine - i.e. `BH.Engine.Structure`
1. Go into the `Query` folder - i.e. `BH.Engine.Structure.Query`
1. If it does not exist yet, create a `Geometry.cs` file
1. Add an extension method name `Geometry`, whose only parameter is the object you want to display:
```c#
public static Line Geometry(this BH.oM.Structure.Elements.Bar bar)
{
  // Extract your geometry
  return calculatedGeoemtry
}
```

## Creating a new UI

Most of the functionality required by every UI has already been ported to the BHoM_UI repository or to the Engine (when used in more than the UIs). This makes the creation of a new UI a lot less cumbersome but this is still by no mean a small task. I would recommend to reach out to those that have already worked on UI (check the contributors of those repos) before you start writing a new UI from scratch.