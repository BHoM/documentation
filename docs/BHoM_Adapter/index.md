# Introduction to the BHoM_Adapter

In this page you will find a first overview about **what is the BHoM Adapter**.

!!! note

    ▶️ Part of a series of pages. Next read: [The Adapter Actions](Adapter-Actions).

    Before reading this page, have a look at the following pages:

    - [Structure of the BHoM framework](../Basics/BHoM-Toolkits.md)
    - [Getting started for developers](<../Guides and Tutorials/Coding with BHoM/index.md>)

    and make sure you have a general understanding of:

    - [The oM](/documentation/BHoM_oM/)
    - [The Engine](/documentation/BHoM_Engine/)

## What is a BHoM Adapter?
As shown in the [Structure of the BHoM framework](../Basics/BHoM-Toolkits.md), an adapter is the part of BHoM responsible to convert and send-receive data (import/export) with external software (e.g. Robot, Revit, etc.).

In brief:

* An Adapter connects the BHoM to an external software.
* Every Adapter offers different functionality, which we call _Adapter Actions_ (for example, `Push`, which means exporting from BHoM, and `Pull`, which means importing to BHoM).
* Different Adapters exist, one per each Software (e.g. Robot), or format (e.g. XML), to which BHoM can be converted. 

### Create an Adapter component or formula

Depending on the UI Software you are using, you can create an Adapter component (in Grasshopper, or _formula_ if you are in Excel) like this:

!!! example "Adapter component"

    === "Grasshopper"
        
        1. Select the Adapter component:  
        ![image](https://user-images.githubusercontent.com/6352844/222768393-31aa120f-aaec-40c6-bd46-daed07515f75.png)
        2. Right click on centre of the component, then select an an Adapter from the menu (or use the text box to search):  
        ![image](https://user-images.githubusercontent.com/6352844/222768903-25ded54d-28cb-4cbf-ac8e-6950993b6e26.png)
        3. A component gets created. See the inputs and follow the instructions of your chosen adapter to use it.  
        ![image](https://user-images.githubusercontent.com/6352844/222773471-76c27898-92a6-49a4-9f86-b041b980d29c.png)


    === "Excel"

        1. Select an adapter from the menu:  
        ![image](https://user-images.githubusercontent.com/6352844/222769136-552b54a8-11a5-4f9b-89ee-9ca3986b225d.png)
        2. A formula gets created in the active cell. See the inputs and follow the instructions of your chosen adapter to use it.  
        ![image](https://user-images.githubusercontent.com/6352844/222773308-eae348cc-3475-47c2-ad3b-eb61efc19941.png)


## Adapter actions 
 
The **Adapter Actions** are the way to communicate with an external software via an Adapter. 

Adapter Actions are BHoM components that you connect to a specific Adapter (e.g. Robot Adapter). Like any other BHoM component, are always look the same no matter what User Interface program you are using (Grasshopper, Excel, ...). In Grasshopper, there will be a component representing each action; in Excel, a _formula_ will let you use them. You can find the Adapter Actions in the *Adapter* subcategory:

!!! example "Adapter Actions"

    === "Grasshopper"

        1. Select an Actions from the "Adapter" category, e.g. `Push`:
        ![image](https://user-images.githubusercontent.com/6352844/222767152-703c2379-80ec-46c9-bb33-a70ea7b6d693.png)
        
        2. The selected action is instantiated as a component to which an adapter can be connected. You will need to specify also the objects and possibly other inputs; keep reading.
        ![image](https://user-images.githubusercontent.com/6352844/222779905-c48a5c63-ddb3-48d0-848b-f92c7c2137b1.png)

    === "Excel"

        3. Select an Actions from the "Adapter" category, e.g. `Push`:
        ![image](https://user-images.githubusercontent.com/6352844/222767005-bfe0cf04-d1a2-4316-bb52-0a5f3fb70b6b.png)

        4. The selected action is instantiated as a formula to which an adapter can be connected. You will need to specify also the objects and possibly other inputs; keep reading.
        ![image](https://user-images.githubusercontent.com/6352844/222779644-87182236-57b4-40f4-bcb8-381d11a96a0f.png)



### Example usage: use Robot Adapter to `Push` (export) a BHoM model to Robot

Before looking at the Adapter Actions in more detail, see the following illustrative example of a Push to Robot.  

!!! note

    Although the Adapter actions always look the same, remember that each adapter may behave differently. Some adapters expect that you will use the Push with specific BHoM objects. For example, you can not push Architectural Rooms objects (`BH.oM.Architecture.Room`) to a Structural Adapter like RobotAdapter.

!!! example "Illustrative example of Push"

    === "Grasshopper"

        Example file download: [Example push GH.zip](https://github.com/BHoM/documentation/files/10884344/Example.push.GH.zip)

        ![image](https://user-images.githubusercontent.com/6352844/222777731-1e13a971-fef6-43ad-a2a3-fbb34840ae95.png)

    === "Excel"

        Example file download: [Example push Excel.zip](https://github.com/BHoM/documentation/files/10884338/Example.push.Excel.zip)

        ![image](https://user-images.githubusercontent.com/6352844/222777599-26428bcd-43ee-4d51-b36c-a4294f4ebd04.png)

## Adapter actions overview

The following is a brief overview, more than enough for any user.  
A more in-detail explanation, for developers and/or curious users, is left in the next page of this wiki.

The first thing to understand is that **the Adapter Actions do different things depending on the software they are targeting**.  
In fact, the first input to any Adapter Action is always an `Adapter`, which targets a specific external software or platform. The first input `Adapter` is common to all Actions.

The last input to any Adapter action is an `active` Boolean, that can be True or False. If you insert the value True, the Action will be activated and it will do its thing. False, and it will sit comfortably not doing anything.

### Push and Pull

The most commonly used actions are the Push and the Pull. You can think of Push and Pull as Export and Import: they are your "portal" towards external software.  
Again, taking Grasshopper UI as an example, they look like this (but they always have the same inputs and outputs, even if you are using Excel): 
![image](https://user-images.githubusercontent.com/6352844/74932145-04195880-53d9-11ea-88a0-c91af87b9920.png)

#### Push
The Push takes the input `objects` and: 
   - if they don't exist in the external model yet, they are created brand new;
   - if they exist in the external model, they will be updated (edited);
   - under some particular circumstances and for specific software, if some objects in the external software are deemed to be "old", the Push will delete those. 

This method functionality varies widely depending on the software we are targeting. For example, it could do a thing as simple as simply writing a text representation of the input objects (like in the case of the File_Adapter) to taking care of object deletion and update (GSA_Adapter).

In the most complete case, the Push takes care of many different things when activated: ID assignment, avoiding object duplication, distinguishing which object needs updating versus to be exported brand new, etc.

#### Pull
The Pull simply grabs all the objects in the external model that satisfy the specified `request` (which simply is a _query_). 

If no request is specified, depending on the attached `adapter`, it might be that all the objects of the connected model will be input, or simply nothing will be pulled. You can read more about the requests in the [Adapter Actions - advanced parameters](#adapter-actions-advanced-parameters) section.

Now, let's see the remaining "more advanced" Adapter Actions.

### Move, Remove and Execute

Slightly more advanced Actions. Again taking Grasshopper as our UI of choice, they look like this:
![image](https://user-images.githubusercontent.com/6352844/74932261-480c5d80-53d9-11ea-9487-d84ba7e59a37.png)

Let's see what they do:

* **Move**: This will copy objects over from a `source` connected software to another `target` software. It basically does a Pull and then a Push, without flooding the UI memory with the model you are transferring (which would happen if you were to manually Pull the objects, and then input them into a Push – between the two actions, they would have to be stored in the UI).

* **Remove**: This will delete all the objects that match a specific request (essentially, a query). You can read more about the requests in the [Adapter Actions - advanced parameters](#adapter-actions-advanced-parameters) section.

* **Execute**: This is used to ask the external software to execute a specific command such as _Run analysis_, for example. Different adapters have different compatible commands: try searching the CTRL+SHIFT+B menu for "[yourSoftwareName] Command" to see if there is any available one.

## Adapter Actions advanced parameters

You might have noticed that the Adapter Actions take some other particular input parameters that need to be explained: the Requests, the ActionConfig, and the Tags. 

Their understanding is not essential to grasp the overall mechanics; however you can find their explanation in the [Adapter Actions - Advanced parameters](Adapter-Actions---advanced-parameters.md) section of the wiki.

## Wrap-up 

The Adapter Actions have been designed using particular criteria that are explained in the next Wiki pages. 

Most users might be satisfied with knowing that they have been developed like this so they can cover all possible use cases, while retaining ease of use. 

Try some of the Samples and you should be good to go! 🚀 

### If you are a developer 🤖 

The [BHoM_Adapter](https://github.com/BHoM/BHoM_Adapter) is one of the base repositories, with one main Project called `BHoM_Adapter`.  
That one is the **base** BHoM_Adapter. The base BHoM_Adapter includes a series of methods that are common to all software connections. Specific Adapter **implementations** are included in what we call the **Toolkits**. The base BHoM_Adapter is an `abstract` class that is implemented in each Toolkit's Adapter implementation. A Toolkit's Adapter *extends* the base BHoM_Adapter.

We will see [how to create a Toolkit later](../Basics/BHoM-Toolkits.md); however consider that, in general, a Toolkit is simply a Visual Studio solution that can contain one or more of the following:
- A [BHoM_Adapter](index.md) project, that allows to implement the connection with an external software.
- A [BHoM_Engine](../BHoM_Engine/index.md) project, that should contain the Engine methods specific to your Toolkit.
- A [BHoM_oM](../BHoM_oM/index.md) project, that should contain any oM class (types) specific to your Toolkit.

When you want to contribute to the BHoM and create a new software connection, **you will not need to implement the Adapter Actions**, at least in most of the cases.  
If you need to, however, you can *override* them (more details on that in last page of this Wiki, where we explain how to implement an Adapter in a new BHoM Toolkit).

**So what is it that you need to implement?**

The answer is: the so called **`CRUD` Methods**. We will see them [in the next page](Adapter-Actions.md).