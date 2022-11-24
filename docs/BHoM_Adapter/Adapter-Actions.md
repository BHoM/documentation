# Adapter actions 

After covering the basics in [Introduction to BHoM_Adapter](/BHoM_Adapter/Introduction-to-the-BHoM_Adapter), this page explains the Adapter Actions more in detail, including their underlying mechanism.

After reading this you should be all set to develop your own [BHoM Toolkit](/Basics/The-BHoM-Toolkit) 🚀 


___________________________________________________________________

<br/>

> ### ⚠️ Note ⚠️
> Before reading this page, make sure you have read the [Introduction to BHoM_Adapter](/BHoM_Adapter/Introduction-to-the-BHoM_Adapter).
<br/>

◀️ Previous read: _[introduction to BHoM_Adapter](/BHoM_Adapter/Introduction-to-the-BHoM_Adapter)_

▶️ Next read: _[The BHoM Toolkit](/Basics/The-BHoM-Toolkit)_ and, optionally, _[The CRUD methods](/BHoM_Adapter/The-CRUD-methods)._

<br/>
___________________________________________________________________


## How the Adapter Actions work
[As we saw before](/BHoM_Adapter/Introduction-to-the-BHoM_Adapter), the Adapter Actions are backed by what we call *CRUD* methods. Let's see what that means.

### The CRUD paradigm
A very common **paradigm** that describes **all the possible action types** is [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete). This paradigm says that, regardless of the connection being made, the connector actions can be always categorised as:
* **C**reate = add new entries
* **R**ead = retrieve, search, or view existing entries
* **U**pdate = edit existing entries
* **D**elete = deactivate, or remove existing entries

Some initial considerations:

- Read and Delete are quite self-explanatory; regardless of the context, they are usually quite straightforward to implement.  

- Create and Update, on the other hand, can sometimes overlap, depending on the interface we have at our disposal (generally, the external software API can be limiting in that regard).

- Exposing directly these methods would make the User Experience quite complicated. Imagine having to split the various objects composing your model into the objects that need to be `Create`d, the ones that needs to be `Update`d, and so on. Not nice. 

We need something simpler from an UI perspective, while retaining the advantages of CRUD - namely, their limited scope makes them simple to implement.

The answer is **the Adapter Actions: they take care of calling the `CRUD` methods in the most appropriate way** for both the user and the developer.

### An example: the Push Action
Let's consider for example the case where we are _pushing_ BHoM objects from Grasshopper to an external software.  
The first time those objects are `Push`ed, we expect them to be `Create`d in the external software.  
The following times, we expect the existing objects to be `Update`d with the parameters specified in the new ones. 

> ### In detail: Why the "Actions-CRUD" paradigm?
> This paradigm allows us to _extend_ the capabilities of the CRUD methods alone, while keeping the User Experience as simple as possible; it does so mainly through the **Push**. The Push, in fact, can take care for the user of doing `Create` or `Update` or `Delete` when most appropriate – based on the objects that have been `Read` from the external model.
>
> The rest of the Adapter Actions mostly have a 1:1 correspondence with the backing CRUD methods; for example, Pull calls `Read`, but its scope can be expanded to do something in addition to only Reading. This way, `Read` is "action-agnostic", and can be used from other Adapter Actions (most notably, the Push). You write `Read` once, and you can use it in two different actions!

> ### Side note: Why using five different Actions (Push, Pull, Move, Remove, Execute)...
> **... and not something simpler, like "Export" and "Import"?**  
> **... or just exposing the CRUD methods?**  
> The reason is that the methods available to the user need to cover all possible use cases, while being simple to use.
> We could have limited the Adapter Actions to only Push and Pull – that does in fact correspond to Export and Import, and are the most commonly used – but that would have left out some of the functionality that you can obtain with the CRUD methods (for example, the Deletion).
>
> On the other hand, exposing directly the CRUD methods would not satisfy the criteria of simplicity of use for the User.
> Imagine having to Read an external model, then having manually to divide the objects in the ones to be `Update`d, the ones to be `Delete`d, then separately calling `Create` for the new ones you just added... Not really simple! The Push takes care of that instead.

> ### Side note: Other advantages of the "Actions-CRUD" paradigm
> We've explained how this paradigm allows us to cover all possible use cases while being simple from an User perspective. In addition, it allows us to:
> 1) ensure consistency across the many, different implementations of the BHoM_Adapter in different Toolkits and contexts, therefore:
> 2) ensuring consistency from the User perspective (all UIs have the same Adapter Actions, backed by different CRUD methods)
> 3) maximise [code scalability](https://stackoverflow.com/a/9420039/3873799)
> 4) Ease of development – learn once, implement everywhere

## CRUD methods: details and implementation

The paragraphs that follow down below are dedicated to explaining _the relationship between the CRUD methods and the Adapter Actions_. 

For first time developers, this is not essential – **you just need to assume that _the CRUD methods are called by the Adapter Actions when appropriate_**.  
You may now want to jump to [our guide to build a **BHoM Toolkit**](/BHoM_Adapter/The-BHoM-Toolkit).

> You will read more about the CRUD methods and how you should implement them in [their dedicated page](/BHoM_Adapter/The-CRUD-methods) that you should read after the BHoM_Toolkit page.

Otherwise, keep reading.

# Advanced topic (optional) - Adapter actions: complete description

We can now fully understand the Adapter Actions, complete of their relationships with their backing CRUD methods.

## Push

The Push action is defined as follows:
```c#
 public virtual List<object> Push(IEnumerable<object> objects, string tag = "", PushType pushType = PushType.AdapterDefault, ActionConfig actionConfig = null)
```

This method exports the objects using different combinations of the CRUD methods as appropriate, depending on the `PushType` input. 

![image](https://user-images.githubusercontent.com/6352844/74738489-ec15cd80-524e-11ea-86a7-a3f68f35ec68.png)

Let's see again how we described the Push mechanism in the previous page:
> The Push takes the input `objects` and: 
>   - if they don't exist in the external model yet, they are created brand new;
>   - if they exist in the external model, they will be updated (edited);
>   - under some particular circumstances and for specific software, if some objects in the external software are deemed to be "old", the Push will delete those. 

The determination of the object status (_new, old_ or _edited_) is done through a "Venn Diagram" mechanism:
![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/VennDiagram.png)

The [Venn Diagram](https://github.com/BHoM/BHoM_Engine/blob/master/Data_Engine/Create/VennDiagram.cs) is a BHoM object class that can be created with any `Comparer` that you might have for the objects. It compares the objects with the given rule (the `Comparer`) and returns the objects belonging to one of two groups, and the intersection (objects belonging to both groups).

During the Push, the two sets of objects being compared are the objects _currently being pushed_, or **`objectsToPush`**, and the ones that have been _read from the external model_, or **`existingObjects`**.

This is the reason why **the first `CRUD` method that the Push will attempt to invoke is `Read`**. The Push is an _export_, but you need to check what objects _exist_ in the external model first if you want do decide _what_ and _how_ to export.

> ### Additional note: custom Comparers
> Once the `existingObjects` are at hand, it's easy to compare them with the `objectsToPush` through the Venn Diagram. Even if no specific comparer for the object has been written, the base C# IEqualityComparer will suffice to tell the two apart. If you want to have some specific way of comparing two objects (for example, if you think that two overlapping columns should be deemed the same no matter what their `Name` property is), then you should define specific comparer for that type. You can see how to do that in the next page dedicated to the BHoM_Toolkit.

### A practical example

Now, let's think that we are pushing two columns: column `A_new` and column `B_new`; **and** that the external model has already two columns somewhere, column `B_old` and column `C_old`. `B_new` and `B_old` are located in the same position in the model space, they have all the same properties except the Name property.

We activate the Push.

First, the external model is read. The existingObjects list now includes the two existing columns `B_old` and `C_old`.

Then a VennDiagram is invoked to compare the existingObjects with the objectsToPush (which are the two pushed columns `A_new` and `B_new`).

#### 1) The object being pushed is new. 
There is no existing object in the external model that corresponds to one of the columns being pushed. Easy peasy: Push will call `Create` this column for this category of objects. `A_new` is `Create`d.

#### 2) The object being pushed is deemed the same of one in the external model.
What does "deemed the same" means?

It means that the `Comparer` has evaluated them to be the same. This does not exclude that there might be some property of the objects that the Comparer is deliberately skipping to compare. 

For example, we might have a Comparer that says:
> _two overlapping columns should be deemed the same no matter what their `Name` property is._

If so, columns `B_new` and `B_old` are deemed the same.

But then, we need to update the Name property of the column in the external model, with the most up-to-date Name from the object being pushed.

Hence, we call `Update` for this category of objects.  
`B_new` is passed to the `Update` method.

#### 3) Remaining existing objects that are not among the objects being pushed.
What to do with this category of objects? What to do with `C_old`? 

An easy answer would be "let's `Delete` 'em!", probably. However, if we simply did that, then we would force the user to always input, in the objectsToPush, also all the objects that _do not need to be Deleted_. 

Which is what we ask the user to do anyway, but to a lesser scale. 
Our approach is **not to do anything** to these objects, **unless tags have been used**.

We assume that if the User wants the `Delete` method to be called for this category of objects, then the existing objects must have been pushed with a tag attached. If the tag of the objects being Pushed is the same of the existing objects, we deem those objects to be effectively old, calling `Delete` for them.

Let's imagine that our column `C_old` was originally pushed with the attached tag "basementColumns".
If I'm currently pushing columns with the same tag "basementColumns", it means that I'm pushing the whole set of columns that should exist in the basement. Therefore, `C_old` is `Delete`d.

#### _Overlapping_ objects with multiple tags

Let's say that I push a set of columns with the tag "basementColumns". Everything that those bars need to be fully defined – what we call the Dependant Objects, e.g. the bar end nodes (points), the bar section property, the bar material, etc. – will be pushed together with it, and **with the same tag attached**. 

Let's then say I then push another set of bars corresponding to an adjacent part of the building with the tag "groundFloorColumns". 

It could be that a column with the tag "basementColumns" has an endpoint that _overlaps_ with the endpoint of another column tagged "groundFloorColumns". That endpoint is going to have two tags: `basementColumns groundFloorColumns`.

The overlapping elements will end up with two tags on them: "basementColumns" and "groundFloorColumns". 

Later, I do another push of columns tagged with the tag `groundFloorColumns`.
Some objects come up as existing only in the external model and not among those being pushed.  
Since a tag is being used and checks out, I should be deleting all these objects.  
However, the overlapping endpoint should not be deleted; simply, `groundFloorColumns` should be removed from its tags.

We then call the `IUpdateTags` method for these objects (no call to `Delete`). 
That is a method that should be implemented in the Toolkit and whose only scope is to update the tags. Its implementation is left to the developer, but some examples can be seen in some of the existing adapters (GSA_Adapter).

#### A full diagram for 1), 2) and 3)

This diagram summarises what we've been saying so far for the Push.

![image](https://user-images.githubusercontent.com/6352844/75054097-55eddb80-54ca-11ea-8158-56f0fe924991.png)



#### Complete flow diagram of the Push (advanced)

Since an image is worth a thousand words, we provide a complete flow diagram of the Push below. If you click on the image you can download it.

This is really an advanced read that you might need only if you want to get into the nitty-gritty of the Push mechanism.

<a href="https://github.com/BHoM/BHoM_Adapter/files/4218880/191003-Adapter.workflows-PROPOSED_mergedALT2andALT1.1.-cleaned.pdf">
<img src="https://user-images.githubusercontent.com/6352844/74760173-ea113600-5271-11ea-90c6-7e4f8302b79e.png">
</a>

## Pull

The Pull action is defined as follows:
```c#
public virtual IEnumerable<object> Pull(IRequest request, PullType pullType = PullType.AdapterDefault, ActionConfig actionConfig = null)
```

This Action has a more 1:1 correspondence with the backing CRUD method: it is essentially a simple call to _Read_ that grabs all the objects corresponding to the specified `IRequest` (which is, essentially, simply a query).  
There is some additional logic related to technicalities, for instance how we deal with different IRequests and different object types (IBHoMObject vs IObjects vs IResults, etc).

![image](https://user-images.githubusercontent.com/6352844/74739504-def9de00-5250-11ea-807f-d38df3a8e4f1.png)


You can find more info on Requests in their related section of the [Adapter Actions - Advanced parameters](/BHoM_Adapter/Adapter-Actions---advanced-parameters) wiki page.

Note that the method returns a list of `object`, because the pulled objects must not necessarily be limited to BHoM objects (you can import any other class/type, also from different Object Models).


## Move

Move performs a Pull and then a Push. 

![image](https://user-images.githubusercontent.com/6352844/74739349-8de9ea00-5250-11ea-9812-32768f59a10a.png)


It's greatly helpful in converting a model from a software to another without having to load all the data in the UI (i.e., doing separately a Pull and then a Push), which would prove too computationally heavy for larger models.

![image](https://user-images.githubusercontent.com/6352844/74739474-cd183b00-5250-11ea-8954-e41200bf300c.png)



## Remove

The Remove action is defined as follows:
```c#
int Remove(IRequest request, ActionConfig config = null);
```

This method simply calls Delete. 

![image](https://user-images.githubusercontent.com/6352844/74739638-2a13f100-5251-11ea-89cb-1e9efd804efb.png)

You might find some Toolkits that, prior to calling Delete, add some logic to the Action, for example to deal with a particular input Request. 

The method returns the number of elements that have been removed from the external model.



## Execute

The Execute is defined as follows:

```c#
public virtual Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
```

The _Execute_ method provides a way to ask your software to do things that are not covered by the other methods. A few possible cases are asking the tool to run some calculations, print a report, save,... A dictionary of parameters is also provided if needed. In the case of print for example, it might be the folder where the file needs to be saved and the name given to the file. 

The method returns _true_ if the command was executed successfully.



# Next steps: Create Your Own Adapter

Read on our [guide to build a **BHoM Toolkit**](/BHoM_Adapter/The-BHoM-Toolkit).

