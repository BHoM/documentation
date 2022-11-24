◀️ Previous read: _[The BHoM Toolkit](/Basics/The-BHoM-Toolkit)_ and _[Adapter Actions](./Adapter-Actions)_

___________________________________________________________________

<br/>

> ### Note
> This page can be seen as an Appendix to the pages [Adapter Actions](./Adapter-Actions) and [The BHoM Toolkit](/Basics/The-BHoM-Toolkit).


As we have seen, the CRUD methods are the support methods for the Adapter Actions. They are the methods that have to be implemented in the specific Toolkits and that differentiate one Toolkit from another.

Their scope has to be well defined, as explained below.

Note that **the Base Adapter is constellated with comments ([example](https://github.com/BHoM/BHoM_Adapter/blob/b5b35b8177901a4f1b1399ab86f7a21f7ffc9668/BHoM_Adapter/CRUD/IRead.cs#L35-L46)) that can greatly help you out**.

Also **the [BHoM_Toolkit Visual Studio template](/The-BHoM-Toolkit) contains lots of comments** that can help you.


# Create
Create must take care only of Creating, or exporting, the objects.
Anything else is out of its scope. 

For example, a logic that takes care of checking whether some object already exists in the External model – and, based on that, decides whether to export or not – cannot sit in the Create method, but has rather to be included in the Push. 
This very case (checking existing object) is [already covered by the Push logic](./Adapter-Actions/).

The main point is: keep the Create simple. It will be called when appropriate by the Push.

## The Create method in practice
The Create method scope should in general be limited to this:
- calling some conversion from BHoM to the object model of the specific software and a 
- Use the external software API to export the objects.

If no API calls are necessary to convert the objects, the best practice is to do this conversion in a `ToSoftwareName` file that extends the public static class `Convert`. See the [GSA_Toolkit](https://github.com/BHoM/GSA_Toolkit) for an example of this.

If API calls are required for the conversion, it's best to include the conversion process directly in the Create method. See [Robot_Toolkit](https://github.com/BHoM/Robot_Toolkit) for an example of this.

In the [Toolkit template](/Basics/The-BHoM-Toolkit), you will find some methods to get you started for creating `BH.oM.Structure.Element.Bar` objects.


### AssignNextFreeId

This is a method for returning a free index that can be used in the creation process. 

Important method to implement to get pushing of dependant properties working correctly. Some more info given in the [Toolkit template](/Basics/The-BHoM-Toolkit/). 



# Read
The read method is responsible for reading the external model and returning all objects that respect some rule (or, simply, all of them).

There are many available overloads for the Read. You should assume that any of them can be [called "when appropriate" by the Push and Pull adapter actions](/Adapter-Actions/).

## The Read method in practice
The Read method scope should in general be specular to the Create:
- Use the external software API to import the objects.
- Call some conversion from the object model of the specific software to the BHoM object model.

Like for the Create, if no API calls are necessary to convert the objects, the best practice is to do this conversion in a `FromSoftwareName` file that extends the public static class `Convert`. See the [GSA_Toolkit](https://github.com/BHoM/GSA_Toolkit) for an example of this.

Otherwise, if API calls are required for the conversion, it's best to include the conversion process directly in the Read method. See [Robot_Toolkit](https://github.com/BHoM/Robot_Toolkit) for an example of this.

# Update
The Update has to take care of copying properties from from a new version of an object (typically, the one currently being Pushed) to an old version of an object (typically, the one that has been Read from the external model). 

The update will be [called when appropriate by the Push](/Adapter-Actions/).

## The Update method in practice

If you have implemented your custom [object Comparers and Dependency objects](/The-BHoM-Toolkit#additional-methods-and-properties), then the CRUD method `Update` will be called for any objects deemed to already exist in the model. 

Unlike the Create, Delete and Read, this method already exposes a simple implementation in the base Adapter, which may be enough for your purposes: it calls Delete and then Create.

This is not exactly what `Update` should be – it should really be an "edit" without deletion, actually – but this base implementation can be useful in the first stages of a Toolkit development.

This base implementation can always be overridden at the Toolkit level for a more appropriate one instead.

# Delete
The Update has to take care of deleting an object from an external model.
The Delete is called by these Adapter Actions: the Remove and the Push. See the [Adapter Actions page for more info](./Adapter-Actions/).

### The Delete method in practice

#### Deletion of objects with tag
By default, an object with multiple tags on it will not be deleted; it only will get that tag removed from itself.

This guaranties that elements created by other people/teams will not be damaged by your delete.
