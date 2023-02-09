# Object comparison through identifiers

Object comparison can be done in several ways, depending on the purpose.

Do you want to compare objects...

- to see who is different from who?
- to see if some object changed from an initial set to a second version of the same set?
- to find unique instances (find duplicates)?

Each of these is a very different scenario. We've tried to uniform the required techniques and simplify the approach for the users.

For any scenario, the comparison can be achieved by comparing an **identifier** associated to the object.

## Types of object identifiers

There are essentially two types of identifiers: **PersistentId** and **InstanceId**.

### PersistentId
This is called "Persistent" because it is assigned to the object when the object is first created, and it never changes for the life of the object. The object can be modified many times, but the persistentId remains the same. This is called **_permanence_ property**.

![PersistentId](https://user-images.githubusercontent.com/6352844/99396629-e29ebc00-28d9-11eb-97a1-1b6ad3a4c49b.png)

The persistentId is generally implemented using a **GUID** (see the [guid definition](https://en.wikipedia.org/wiki/Universally_unique_identifier)). If the persistentId is represented by a GUID, we get the additional feature that it allows to uniquely identify an object: **_uniqueness_ property**.  

![permanenceVSuniqueness](https://user-images.githubusercontent.com/6352844/99396395-981d3f80-28d9-11eb-86a6-c847d98b6374.png)

#### PersistentId in BHoM

In BHoM, the peristentID is a GUID that is generated automatically every time you create a BHoMObject, and it is stored in the property "`BHoM_Guid`" of any BHoMObject. This gives the BHoM_Guid the uniqueness property. Additionally, if you modify the object using any `Modify` method, the BHoM Framework has mechanisms that guarantee that the BHoM_Guid will be ported to the modified object. Therefore, BHoM_Guid also respects the _permanence_ property.

#### PersistentId in Third-Party software.

However, in general, the PersistentId can be represented by other data types, for example an integer. This is what some third-party software do. In this case, the PersistentId only has the _permanence_ property.

For example, Revit has a PersistentId for every object, and it uses a GUID for it. However, other software may use other types, like strings or integers, or they may not have it at all.

In general, we must be cautious when using PersistentId that is not implemented as a GUID, because we lose the "uniqueness" property.

When exporting/importing an object to/from a third party software that has a PersistentId, the BHoM_Adapter is responsible to storing the PersistentId onto the BHoM object converted to/from the software. Third party software PersistentId are stored separately from the `BHoM_Guid`: they are stored in a _PersistentId fragment_.



### StateId

The instanceId is an Id that unequivocally identifies an object at a specific point in time: **_State_ property**.

Every time the object is modified, the InstanceId changes.

![InstanceId](https://user-images.githubusercontent.com/6352844/99397632-3958c580-28db-11eb-8801-c809e0f97605.png)

For example, the InstanceId may be represented again with a GUID, that is however re-generated every time the object is modified. This would respect the _state_ property.

However, the InstanceId can be more effectively represented by a **Hash Code**, or **hash** for short.

The hash is essentially a long string of numbers and letters that codifies the status of the object. There are many ways of calculating the hash. but in the version we implement in BHoM, along with all its properties, and the values of its properties. If two objects are identical except for the value of a single property, their hash is going to be completely different.

If the StateId is implemented through an hash like described above, the StateId gets an additional feature: it is unique to a specific configuration of a specific object. In other words, it guarantees that it is going to be the same for all occurrences of an object in the same state; if an object is different from another, their hashes are going to be different. This is called **_global equivalence_ property**.

#### StateId in BHoM

BHoM implements the stateId through a hash function as described above. The stateId can be stored in the Fragments of the BHoMObjects under a HashFragment.

#### StateId in third-party software

Third-party software more commonly use integers, or strings, to represent the stateId. In this case,

### Recap: PersistentId and StateId characteristics


| PersistentId characteristic | Mandatory?                             | Example implementation  |
|-----------------------------|------------------------------------------|----------------------------------|
| Persistency                 | Yes (must always be true)                | <ul><li>Any type (`integer`, `string`, etc.) as long as the software handling the object guarantees ID persistency upon modification. </li><li>`GUID` guarantees it for free without work required from the software. </li></ul> |
| Global Uniqueness           | No (additional feature, true only for GUID type ID) | `GUID`. No two GUIDs are the same, ever.                 |

| StateId characteristic    | Mandatory?                               | Example of type implementing it  |
|-----------------------------|------------------------------------------|----------------------------------|
| State                       | Yes (must always be true)                | <ul><li>Any type (`integer`, `string`, etc.) as long as the software handling the object guarantees to change the Id every time it is modified. </li><li>A Hash Code guarantees this for free without additional responsibility from the software.  </li></ul> |
| Global equivalence          | No (additional feature, true only for Hash type ID) | Hash Code computed from all property values of the object.  |


# Type of comparisons

Let's see a few example cases that you might need.

## I want to compare two objects and see what properties are different between them.

For example, you have a Bar, `bar1` that you want to compare to another Bar, `bar2`, to see if their cross-section is the same or not.

In this case, you use [DifferentProperties(bar1, bar2)](https://github.com/BHoM/BHoM_Engine/blob/ce7659fca7e3389b31e09e91566b2d8ff10c7606/Diffing_Engine/Query/DifferentProperties.cs#L40-L118):

![image](https://user-images.githubusercontent.com/6352844/99528019-931dc600-2995-11eb-92e6-f5d5865880cb.png)

In this image, you can see DifferentProperties in action. Following DifferentProperties, in your script, you want to use the `ListModifiedProperties` component in order to nicely explode the output.

> **Note for developers**: `ListModifiedProperties` is needed because `DifferentProperties` returns a complex Dictionary that is useful from the code perspective. See code descriptions.



## I have a set of objects, and I want to find out what objects are "unique".






## I want to compare two sets of objects to understand how they differ.

Generally, when you compare two sets of objects, are interested in knowing one or more of the following:
- What objects have been added in the second set, that were not in the first set (**_Added_ objects**)?
- What objects that were in the first set are not present in the second set (**_Deleted_ objects**)?
- What objects that were in the first set are still in the second set, but have been modified (**_Modified_ objects**)?
- Of the _modified_ objects, what properties have changed (**_Modified properties per object_**)?

The answer to those four questions can be computed by performing what we call `Diffing()`. The result of the diffing is an object that we call `Diff`:

https://github.com/BHoM/BHoM/blob/4d3259c32759ab31069f99f195e74e53d198e9bd/Diffing_oM/Diff.cs#L35-L51

Let's see how we should compute the diffing to obtain a Diff.

### I want to compare two third-party software models (e.g. two Revit models)

For example, you have a model Revit, or Robot, or any other software, that you want to compare to a second model. 
The models represent the same project (for example, a residential building). The first model may represent an initial version (**_Revision 1_**), and the second model is a revised version (**_Revision 2_**).

The `Diffing()` that BHoM offers works between BHoMObjects. Therefore, the first step is to import the models into BHoM via the specific BHoM_Adapter for your software. This will convert the objects to BHoMObjects.  
You will therefore obtain two sets of objects, one for the Revision 1 and one for Revision 2.

All this information can be obtained by passing the two sets of objects into the `Diffing()` method.

However, this requires that the objects have a PersistentId assigned by the third party software (for more info on PersistentId, see [TODO: ADD LINK TO WIKI PAGE]). The persistentId is needed so we can tell what objects have been modified, added or removed. Revit supports the PersistentId.

### I want to compare two sets of BHoMObjects 




