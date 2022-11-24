# Implement an Adapter 

◀️ Previous read: _[The BHoM Toolkit](/Basics/The-BHoM-Toolkit)_

▶️ Next read: _[The CRUD methods](./The-CRUD-methods)_

___________________________________________________________________


> ## ⚠️ Note ⚠️
> Before reading this page, please check out:
> - [Getting started for developers](/Contributing/Getting-started-for-developers)
> - [Introduction to BHoM_Adapter](/BHoM_Adapter)
> - [Adapter Actions](/BHoM_Adapter/Adapter-Actions)
> - [The BHoM Toolkit](/Basics/The-BHoM-Toolkit)


___________________________________________________________________



## The Toolkit containing the adapter

See the page dedicated to the _[The BHoM Toolkit](/Basics/The-BHoM-Toolkit)_ to learn how to set up a Toolkit, which can then contain an Adapter.


## Main Adapter file and constructor
The main Adapter file sits in the root of the Adapter project and must have a name in the format `SoftwareNameAdapter.cs`.

The content of this file should be limited to the following items:
- The constructor of the Adapter. You should always have only one constructor for your Adapter.   
You may add input parameters to the constructor: these will appear in any UI when an user tries to create it.  
The constructor should define some or all of the Adapter properties:
   - the Adapter Settings;
   - the Adapter Dependency Types;
   - the Adapter Comparers;
   - the AdapterIdName;
   - any other protected/private property as needed.
- A few protected/private fields (methods or variables) that you might need share between all the Adapter files (given that the Adapter is a `partial` class, so you may share variables across different files). Please limit this to the essential.


## The Adapter Actions

### Overriding the Adapter Actions
If you want, you can override one or more of the Adapter Actions. This can be useful for quick development.
 
All Action methods are [defined as `virtual`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual), so [you can `override` them](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override). 

In order to reuse the existing logic embedded in the Adapter Actions, you should not override them. This requires the implementation of CRUD methods which will be called by the Actions. Continue reading to learn more.

## The Adapter Settings
The Adapter settings are general settings that can be used by the Adapter Actions and/or the CRUD methods. 

You can define them as you want; just consider that the settings are supposed to stay the same across any instance of the same adapter, i.e. the Adapter Settings are global `static` settings valid for all instances of your Toolkit Adapter. In other words, these settings are independent of what Action your Toolkit is doing (unlike the [ActionConfig](/BHoM_Adapter/Adapter-Actions---advanced-parameters#actionconfig)). If you want to create settings that affect a specific action, implement an ActionConfig instead.

The base [BHoM_Adapter code](https://github.com/BHoM/BHoM_Adapter) gives you extensive explanation/descriptions/comments about the Adapter Settings. 

## Implement the CRUD methods

The CRUD folder should contain all the needed CRUD methods. 

You can see the [CRUD methods implementation details in their dedicated page](/BHoM_Adapter/The-CRUD-methods).

Here we will cover a convention that we use in the code organisation: the CRUD "interface methods".

In the template, you can see how for all CRUD method there is an interface method called `ICreate`, `IRead`, etc.

These interface methods are the ones called by the adapter. You can then create as many CRUD methods as you want, even one per each object type that you need to create. The interface method is the one that will be called as appropriate by the Adapter Actions. From there, you can dispatch to the other CRUD methods **of the same type** that you might have created.

For example, [in GSA_Toolkit you can find something similar to this](https://github.com/BHoM/GSA_Toolkit/blob/c5bcd1af40a51a9e1e850202523e5f00621edd1b/GSA_Adapter/CRUD/Create.cs#L42-L61):
```cs
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
           return CreateObject((obj as dynamic));
        }
```

The the statement `CreateObject((obj as dynamic))` does what is called **dynamic dispatching**. It calls automatically other Create methods (called `CreateObject` - all [overloading](https://www.geeksforgeeks.org/c-sharp-method-overloading/) each other) that take different object types as input.



## Additional methods and properties
The mapping from the Adapter Actions to the CRUD methods does need some help from the developer of the Toolkit. 

This is generally done through additional methods and properties that need to be implemented or populated by the developer.

* Pushing of dependant objects
* Merging objects deemed to be the same
* Merging incoming objects with objects already existing in the model
* Applying an software specific 'id' to the objects being pushed


### Dependency types

This is an important concept:

> **BHoM does not define a relationship chain between most Object Types.**

This is because our Object Model aims to be as abstract and context-free as possible, so it can be applied to all possible cases.

If we were to define a relationship between all types, things would be more complicated than they already are. A typical scenario is the following.
Some FE analysis software define Loads (e.g. weight) as independent properties, that can be Created first and then applied to some objects (for example, to a beam).
Others require you to first define the object owning the Load (e.g. a beam), and then define the Load to be applied to it (the weight).

We can't have a generalised relationship between the beams and the loads, because not all external software packages agree on that. We should pick one. So instead, we pick none.

> #### Note: optional feature
> You can also avoid creating a relationship chain at all - if you are fine with exporting a flat collection of objects.   You can activate/deactivate this Adapter feature by configure the Setting: `m_AdapterSettings.HandleDependencies` to true or false. If you enable this, you must implement `DependencyTypes` as explained below.


### Dependency types in practice
We solve this situation by defining the `DependencyTypes` property:
```cs
Dictionary<Type, List<Type>> DependencyTypes { get; }
```
This is a property of the single Adapter – that is, it can be different for different software connections.

The Toolkit developer should populate this accordingly to the inter-relationships that the BHoMObject hold in the perspective of the external software.

The Dictionary key is the Type for which you want to define the Dependencies; the value is a List of Types that are the dependencies.

An example [from GSA_Toolkit](https://github.com/BHoM/GSA_Toolkit/blob/c5bcd1af40a51a9e1e850202523e5f00621edd1b/GSA_Adapter/GSAAdapter.cs#L59-L68):
```cs
DependencyTypes = new Dictionary<Type, List<Type>>
{
    {typeof(BH.oM.Structure.Loads.Load<Node>), new List<Type> { typeof(Node) } },
    ...
}
```


### Comparers
The comparison between objects is needed in many scenarios, most notably [in the Push, when you need to tell an old object from a new one](/BHoM_Adapter/Adapter-Actions#push).

In the same way that the BHoM Object model cannot define all possible relationships between the object types, it is also not possible to collect all possible ways of comparing the object with each other. Some software might want to compare two objects in a way, some in another.

> #### Note: optional feature
> You can also avoid creating a default comparers - if you are fine for the BHoM to use the default C# [IEqualityComparer](https://msdn.microsoft.com/en-us/library/ms132151(v=vs.110).aspx).  

### Adapter Comparers in practice

By default, if no specific Comparer is defined in the Toolkit, the Adapter uses the [IEqualityComparers](https://msdn.microsoft.com/en-us/library/ms132151(v=vs.110).aspx) to compare the objects. 

There are also some specific comparers for a few object types, most notably:
* [Node comparer - by proximity](https://github.com/BHoM/BHoM_Engine/blob/master/Structure_Engine/Objects/EqualityComparers/NodeDistanceComparer.cs)
* [BHoMObject name comparer](https://github.com/BHoM/BHoM_Engine/blob/master/BHoM_Engine/Objects/EqualityComparers/BHoMObjectNameComparer.cs)

However you may choose to specify different comparers for your Toolkit. You must specify them in the Adapter Constructor.

An example [from GSA_Toolkit](https://github.com/BHoM/GSA_Toolkit/blob/c5bcd1af40a51a9e1e850202523e5f00621edd1b/GSA_Adapter/GSAAdapter.cs#L50-L57):
```cs
            AdapterComparers = new Dictionary<Type, object>
            {
                {typeof(Bar), new BH.Engine.Structure.BarEndNodesDistanceComparer(3) },
                ...
            };
```

