# Introduction to the BHoM_Adapter
▶️ Part of a series of pages. Next read:  _[The Adapter Actions](/BHoM_Adapter/Adapter-Actions)_

___________________________________________________________________

> ### Note
> Before reading this page, have a look at the following pages:
> - [Structure of the BHoM framework](/BHoM_Adapter/Structure-of-the-BHoM)
> - [Getting started for developers](/BHoM_Adapter/Getting-started-for-developers)
>
> and make sure you have a general understanding of:
> - [The oM](/BHoM_Adapter/BH.oM-%E2%80%90-Define-New-Objects)
> - [The Engine](/BHoM_Adapter/BH.Engine-%E2%80%90-Create-New-Algorithms)
> - [Using the BHoM](/BHoM_Adapter/Using-the-BHoM)
<br/>

In this page you will find a first overview about **what is the BHoM Adapter**.

___________________________________________________________________


## What is a BHoM Adapter?
As shown in the [Structure of the BHoM framework](/1.%20Basics/Structure-of-the-BHoM), an adapter is the piece of code responsible to actuate the connection (import/export) between different software packages.

The [BHoM_Adapter](https://github.com/BHoM/BHoM_Adapter) is one of the base repositories, with one main Project called `BHoM_Adapter`. That one is the **base** BHoM_Adapter (developers: it's an `abstract` class).

The base BHoM_Adapter includes a series of methods that are common to all software connections. Specific Adapter **implementations** are included in what we call the **Toolkits**.

We will see [how to create a Toolkit later](/BHoM_Adapter/The-BHoM-Toolkit); however consider that, in general, a Toolkit is simply a Visual Studio solution that can contain one or more of the following:
- A [BHoM_Adapter](/BHoM_Adapter/Introduction-to-the-BHoM_Adapter) project, that allows to implement the connection with an external software.
- A [BHoM_Engine](/BHoM_Adapter/BH.Engine-%E2%80%90-Create-New-Algorithms) project, that should contain the Engine methods specific to your Toolkit.
- A [BHoM_oM](/BHoM_Adapter/BH.oM-%E2%80%90-Define-New-Objects) project, that should contain any oM class (types) specific to your Toolkit.


To recap:
* an implementation of the base BHoM_Adapter connects the BHoM to an external software.
* Different Adapter implementations are found in the Toolkits (developers: the base BHoM_Adapter is an `abstract` class that is implemented in the Adapter of each Toolkit; a Toolkit's Adapter *extends* the base BHoM_Adapter).
* The base BHoM_Adapter repo contains a series of methods shared from all software connections. It provides an infrastructure for the Toolkits's adapters.


## Adapter actions 
 
First and foremost feature of the BHoM_Adapter are the **Adapter Actions**.

The Actions are your "portal" towards different external software. You will be able to export, import and much more with them.

The Adapter Actions, like all the rest of the BHoM, are always the same no matter what User Interface program you are using (Grasshopper, Excel, Dynamo...). In Grasshopper, there will be a component representing each action; in Dynamo, a node for each of them; in Excel, a _formula_ will let you use them.

To see them in their UI context, taking the example of Grasshopper, you can find these methods in the *Adapter* subcategory:

![image](https://user-images.githubusercontent.com/6352844/74931024-bac80980-53d6-11ea-95ea-418f2d2c3e44.png)

Let's have an overview of the actions.

### Adapter actions overview

The following is a brief overview, more than enough for any user.  
A more in-detail explanation, for developers and/or curious users, is left in the next page of this wiki.

The first thing to understand is that **the Adapter Actions do different things depending on the software they are targeting**.  
In fact, the first input to any Adapter Action is always an `Adapter`, which targets a specific external software or platform. The first input `Adapter` is common to all Actions.

The last input to any Adapter action is an `active` Boolean, that can be True or False. If you insert the value True, the Action will be activated and it will do its thing. False, and it will sit comfortably not doing anything.

#### Push and Pull

The most commonly used actions are the Push and the Pull. You can think of Push and Pull as Export and Import: they are your "portal" towards external software.  
Again, taking Grasshopper UI as an example, they look like this (but they always have the same inputs and outputs, even if you are using Excel or Dynamo): 
![image](https://user-images.githubusercontent.com/6352844/74932145-04195880-53d9-11ea-88a0-c91af87b9920.png)

##### Push
The Push takes the input `objects` and: 
   - if they don't exist in the external model yet, they are created brand new;
   - if they exist in the external model, they will be updated (edited);
   - under some particular circumstances and for specific software, if some objects in the external software are deemed to be "old", the Push will delete those. 

This method functionality varies widely depending on the software we are targeting. For example, it could do a thing as simple as simply writing a text representation of the input objects (like in the case of the File_Adapter) to taking care of object deletion and update (GSA_Adapter).

In the most complete case, the Push takes care of many different things when activated: ID assignment, avoiding object duplication, distinguishing which object needs updating versus to be exported brand new, etc.

##### Pull
The Pull simply grabs all the objects in the external model that satisfy the specified `request` (which simply is a _query_). 

If no request is specified, depending on the attached `adapter`, it might be that all the objects of the connected model will be input, or simply nothing will be pulled. You can read more about the requests in the [Adapter Actions - advanced parameters](#adapter-actions-advanced-parameters) section.

Now, let's see the remaining "more advanced" Adapter Actions.

#### Move, Remove and Execute

Again taking Grasshopper as our UI of choice, they look like this:
![image](https://user-images.githubusercontent.com/6352844/74932261-480c5d80-53d9-11ea-9487-d84ba7e59a37.png)

Let's see what they do:
* **Move**: This will copy objects over from a `source` connected software to another `target` software. It basically does a Pull and then a Push, without flooding the UI memory with the model you are transferring (which would happen if you were to manually Pull the objects, and then input them into a Push – between the two actions, they would have to be stored in the UI).
* **Remove**: This will delete all the objects that match a specific request (essentially, a query). You can read more about the requests in the [Adapter Actions - advanced parameters](#adapter-actions-advanced-parameters) section.
* **Execute**: This is used to ask the external software to execute a specific command such as _Run analysis_, for example. Different adapters have different compatible commands: try searching the CTRL+SHIFT+B menu for "[yourSoftwareName] Command" to see if there is any available one.

### Adapter Actions advanced parameters

You might have noticed that the Adapter Actions take some other particular input parameters that need to be explained: the Requests, the ActionConfig, and the Tags. 

Their understanding is not essential to grasp the overall mechanics; however you can find their explanation in the [Adapter Actions - Advanced parameters](/BHoM_Adapter/Adapter-Actions---advanced-parameters) section of the wiki.

### Wrap-up 

The Adapter Actions have been designed using particular criteria that are explained in the next Wiki pages. 

Most users might be satisfied with knowing that they have been developed like this so they can cover all possible use cases, while retaining ease of use. 

Try some of the Samples and you should be good to go! 🚀 

### If you are a developer 🤖 

When you want to contribute to the BHoM and create a new software connection, **you will not need to implement the Adapter Actions**, at least in most of the cases.  
If you need to, however, you can *override* them (more details on that in last page of this Wiki, where we explain how to implement an Adapter in a new BHoM Toolkit).

**So what is it that you need to implement?**

The answer is: the so called **`CRUD` Methods**. We will see them [in the next page](/BHoM_Adapter/Adapter-Actions).