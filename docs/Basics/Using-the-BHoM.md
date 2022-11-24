## Overview

For this introduction, we will be using Grasshopper as a model but be aware that the same general principles will apply to other UIs (Dynamo, Excel, ...) too. 

The UI layer has been designed so that it will automatically pick everything implemented in the BHoM, the Engines and the Adapters without the need to change anything on the code of the UI. This means that, instead of having one component for every single piece of functionality, it will group them under common components. This way, the number of component there doesn't have to change when more functionality is added to the rest of the code. Here's what it looks like in Grasshopper:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_Menu.png)

As you can see, this mirror [the structure of the BHoM](Structure-of-the-BHoM) with a section for **oM**, for **Engine**, and for **Adapter**. So, the **oM** section is for creating object, the **Engine** section is for manipulating them or running some form of calculation, and the **Adapter** section is for exchanging data with external softwares.

## Key Concept

In order to explain how most of those components work, let's start with the **Create BHoM Object** that can be found in the **oM** section:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_CreateComponent.gif)

As you can see, you first drop a dummy component on the canvas that has no input nor output. You then select in its menu what you want it to be to turn it into its final form.

The principle is exactly the same for the **Compute**, **Convert**, **Modify**, and **Query** components in the **Engine** section as well as for the **Create Adapter** and **Create Query** components in the **Adapter** section. Here's the example for the **Create** and **Create Adapter** components:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_QueryComponent.png)

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_AdapterComponent.png)

## Search Menus

Notice that there are a couple more ways to create the final component you need: 

* Use the search menu from the component:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_ComponentSearchMenu.gif)

* Use the Ctrl+Shift+B shortcut and then do a search from that menu

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_CtrlBSearchMenu.gif)

If you want to search for something that include a series of words, just separate them by a space like done above.

## Create Custom Objects

We have seen how to Create BHoM objects using the **Create BHoMObject** component. There will be situations where you need a type of object that is not part of the BHoM (yet?). For this, we have the **CustomObject** component:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_CustomObjComponent.gif)

This component allows you to define your own objects with a custom set of properties. You will notice that the Component start with two inputs: Name and Tags. This is because a **CustomObject** is also a **BHoMObject** and every **BHoMObject** has a property for Name and a property for Tags. IF you don't want to use those two, just remove them.

Usually, that component is automatically figuring out the type of each property based on the data plugged in its inputs. There might be times when it got it wrong. For that reason, you can always specify manually the type of each input from its context menu. This is especially useful when the input is a list. In that case, just tick the box for **List** to tell Grasshopper you want that list as a single input instead of one value in the list per object.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_TypeHint.png)

## Alternative Ways to Create Known Types of Objects

The CreateObject component provides a series of recommended ways to create known objects. Those correspond to the methods defined in the Create section of the BHoM_Engine. There might be rare cases where you cannot find a constructor that suits your needs. In that situation, you can use the CreateCustom component to define your own way to build a known object, just select the type of object you want to create from the contextual menu and select your own inputs. Inputs that are not properties of the object will be stored in CustomData.

![](https://user-images.githubusercontent.com/16853390/50468221-95618a80-09e1-11e9-8c31-f6dec30f93b8.gif)

## Other Types of Objects

Sometimes, you will find a component requiring an input that is not a BHoM object and not something you can create in Grasshopper either. The **Enum**, **Type** and **Dictionary** components are exactly there to cover those situations. One case you will probably encounter soon is when using the **FilterQuery** component from the **Adapter** section. 

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_TypeComponent.gif)

The **Dictionary** and **Enum** work from the same principle: you select their final form from their menu. 

The **Enum** component has a slightly different form though:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_EnumAndData.gif)

The **Data** component shown above is allowing you to select data from one of our static databases. Its output type will therefore vary based on the data you select. Those will generally be a **BHoM object** though.

## Engine components

The 4 components on the left correspond to the 4 categories of methods you can find in the **Engine**: **Compute**, **Convert**, **Modify**, and **Query** (**Create** being in the **oM** section). 

The 3 components in the middle are for extracting or updating properties of BHoM objects. The one you will probably use most of the time is the **Explode** component:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_ExplodeComponent.gif)

The last two components are for converting any BHoM object to and from [JSON](https://en.wikipedia.org/wiki/JSON). This stand for **J**ava**S**cript **O**bject **N**otation. This is the langage we use when we represent BHoM objects as string. Unless you see straight away how those components can be of used to you, you can safely ignore them.

## Adapter components

We have already mentioned the **Create Adapter** and the **Create Query** components from the right part of the **Adapter** section. The 6 components on the left part correspond to the 6 operations provided by the interface of every BHoM adapter: **Push**, **Pull**, **UpdateProperty**, **Delete**, **Excecute** and **Move**. Most likely than not, you will generally use the **Push** and **Pull** components so we'll show how those two work here. 

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/GH_PushPullComponents.gif)

Here we have the Socket adapter to send data across and get it back. Obviously, you would use sockets to send data between two different UIs or computers instead of just within Grasshopper but this example is just to show how the **Push** and **Pull** components are working.

## Things to Remember

While we have shown quite a few things here, the main thing to remember is that most of the components in our UIs require you to select something from their menu before they switch to their final state. You can do that by either navigation the menu tree or using the search box. Those menu trees are organised exactly the same way has the code you will find on GitHub. You can also use **Ctrl+Shift+B** to create the final component directly. 

On top of that concept, remember the **CustomObject** and **Explode** components. They are a very convenient way to pack and unpack groups of data.

From there, the best way to learn how to use those tools is to play with them in your UI of choice or to browse the documentation provided on the Wiki of each repository.

