Diffing is the process of determining what changed between two sets of objects. 

Typically, the two sets of objects are two versions of the same thing (of a pulled Revit model, of a Structural Model that we want to Push to an Adapter, etc), in which case Diffing can effectively be used as a Version Control tool.

🤖 **Developers**: check out also the [Diffing and Hash: Guide for developers](/Diffing-and-Hashing:-guide-for-developers).

![image](https://user-images.githubusercontent.com/6352844/146008221-15ebcb4b-8b0c-410d-8dcb-ddf576664931.png)


The [Diffing_Engine](https://github.com/BHoM/BHoM_Engine/tree/main/Diffing_Engine) gives many ways to perform diffing on sets of objects. Let's see them.


# IDiffing method

The most versatile method for diffing is the [`BH.Engine.Diffing.Compute.Diffing()` method](https://github.com/BHoM/BHoM_Engine/blob/main/Diffing_Engine/Compute/IDiffing.cs), also called `IDiffing`. Ideally, you should always use this Diffing method, although other alternatives exist for specific cases (see [Other diffing methods](/Diffing%3A-tracking-changes-in-your-BHoM-objects/#other-diffing-methods) below). A detailed technical explanation of the IDiffing can be found in the guide for developers.

This method can be found in any UI by simply looking for `diffing`:
![image](https://user-images.githubusercontent.com/6352844/146007504-68efd77b-2cf7-4448-95a8-cd43a0a0bab8.png)
![image](https://user-images.githubusercontent.com/6352844/146008541-427c9f36-e55f-453e-b84d-fd381ecd0b9a.png)


The method takes three inputs:
- `pastObject`: objects belonging to a past version, a version that precedes the `followingObjects`'s version.
- `followingObjects`: objects belonging to a following version, a version that was created after the `pastObject`'s version.
- `diffingConfig`: configurations for the diffing, where you can set your `ComparisonConfig` object, see below.

The IDiffing, like all diffing methods, relies on an **identifier** assigned to each object, which can be used to match objects, so it knows which to compare to which even across multiple versions of the objects. The identifer is generally a unique number assigned to each object, and this number is assumed to remain always the same even if the object is modified. The identifier looked for is of type `IPersistentAdapterId`, searched in the object's Fragments; this is typically stored on objects when they are Pulled from an Adapter. This means that the IDiffing works best with objects pulled from a BHoM Adapter that stores the object Id on the object (most of them do).

In case no Identifier can be found on the objects, the IDiffing attempts other diffing methods on the objects; this is explained in more detail in the diffing guide for developers.

The output of every diffing method is always a **`diff` object**, which we will describe in a section below.

## `DiffingConfig` (and `ComparisonConfig`)

The `DiffingConfig` object can be attached to any Diffing method and allows you to specify options for the Diffing comparison. 

![New Project (12)](https://user-images.githubusercontent.com/6352844/146351680-1617c046-9507-47d6-a202-7bd213c43ffa.png)
The Diffing config has the following inputs:

- **`ComparisonConfig`** allows you to specify all the object comparison options; **see [its dedicated page](/Configuring-objects-comparison:-%60ComparisonConfig%60)**.
- `EnablePropertyDiffing`: optional, defaults to `true`. If disabled, Diffing does not checks all the property-level differences, running much faster but potentially ignoring important changes.
- `IncludedUnchangedObjects`: optional, defaults to `true`. When diffing large sets of objects, you may want to not include the objects that did not change in the diffing output, to save RAM.
- `AllowDuplicateIds`: optional, defaults to `false`. The diffing generally uses identifiers to track "who is who" and decide which objects to compare; in such operations, duplicates should never be allowed, but there could be edge cases where it is useful to keep them.

## The Diffing output: the `Diff` object

The output of any Diffing method is an object of type [`Diff`](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/Diffing_oM/Diff.cs#L34-L57). The `diff` output can be _`Explode`d_ to reveal all the available outputs: 

![image](https://user-images.githubusercontent.com/6352844/146033707-f4b7c1a1-063e-4c0e-8bcd-c415afd732e6.png)


- `AddedObjects`: objects present in the second set that are not present in the first set.
- `RemovedObjects`: objects not present in the second set that were present in the first set.
- `ModifiedObjects `: objects that are recognised as present both in the first set and the second set, but that have some property that is different. The rules that were used to recognise modification are in the `DiffingConfig.ComparisonConfig`.
- `UnchangedObjects`: objects that are recognised as the same in the first and second set.
- `ModifiedObjectsDifferences`: all the differences found between the two input sets of objects.
- `DiffingConfig`: the specific instance of `DiffingConfig` that was used to calculate this `Diff`. Useful in scenarios where a `Diff` is stored and later inspected.

The `ModifiedObjectDifferences` output contains a List of  [`ObjectDifferences` objects](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/Diffing_oM/ObjectDifferences.cs#L34-L45), one for each modified object, that contains information about the modified objects. These can be further _`Explode`d_:

![image](https://user-images.githubusercontent.com/6352844/146036787-2ecddb03-86bf-4a63-aad8-1b72c99a7e69.png)


- `PastObject`: the object in the `pastObjs` set that was identified as modified (i.e., a different version of the same object was found in the `followingObjs` set).
- `FollowingObject`: the object in the `followingObjs` set that was identified as modified (i.e., a different version of the same object was found in the `pastObjs` set).
- `Differences`: all the differences found between the two versions of the modified object. This is a List of [`PropertyDifference` objects](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/Diffing_oM/PropertyDifference.cs#L34-L48), one for each difference found on the modified object.

Finally, exploding the `Differences` object, we find:

![image](https://user-images.githubusercontent.com/6352844/146034910-62c8bded-4024-4fc7-a2bc-0b960fd307b6.png)

- `DisplayName`: name given to the difference found. This is generally the PropertyName (name of the property that changed), but it can also indicate other things. For example, if a `ComparisonInclusion()` extension method is defined for some of the input objects ([like it happens for Revit's `RevitParameter`s](https://github.com/BHoM/Revit_Toolkit/blob/a71d99fa93ab5fbad0c01ac14885e090c186ab91/Revit_Engine/Query/ComparisonInclusion.cs#L39-L77)), then the `DisplayName` may also contain some specific naming useful to identify the difference (in the case of `RevitParameter`, this is the name of the RevitParameter that changed in the modified object).  
An example of a DisplayName could be `StartNode.Position.X` (given a modified object of type `BH.oM.Structure.Elements.Bar`).
- `PastValue`: the modified value in the `PastObject`.
- `FollowingValue`: the modified value in the `FollowingObject`.
- `FullName`: this is the modified property **Full Name**. An object difference can always be linked to a precise object property that is different; this is given in the Full Name form, which includes the namespace. An example of this could be `BH.oM.Structure.Elements.Bar.StartNode.Position.X`. Note that this FullName can be significantly different from `DisplayName` (as happens for `RevitParameter`s, where the Full Name will be something like e.g. `BH.oM.Adapters.Revit.Parameters[3].RevitParameter.Value`).

# Other Diffing methods

In addition to the main Diffing method `IDiffing()`, there are several other methods that can be used to perform Diffing. These are a bit more advanced and should be used only for specific cases. The additional diffing methods can be found in the [Compute folder of Diffing_Engine](https://github.com/BHoM/BHoM_Engine/tree/main/Diffing_Engine/Compute). 

Other than these, _Toolkit-specific_ diffing methods exist to deal with the subtleties of comparing Objects defined in a Toolkit. Users do not generally need to know about these, as [Toolkit-specific diffing methods will be automatically called for you if needed by the generic IDiffing method](/Diffing-and-Hashing%3A-guide-for-developers#invoking-of-the-toolkit-specific-diffing-methods). Just for reference, a Toolkit-specific Diffing method is [`RevitDiffing()`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs).



## `DiffWithFragmentId()` and `DiffWithCustomDataKeyId()`

These two methods are "ID-based" diffing methods. They simply retrieve an Identifier associated to the input objects, and use it to match objects from the `pastObjs` set to objects in the `followingObjs` set, deciding who should be compared to who.

- The [`DiffWithFragmentId()`](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/DiffWithFragmentId.cs#L52) retrieves object identifiers from the objects' Fragments. You can specify which Fragment you want to get the ID from, and which property of the fragment is the ID. 
- The [`DiffWithCustomDataKeyId()`](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/DiffWithCustomDataKeyId.cs#L53) retrieves object identifiers from the objects' CustomData dictionary. You can specify which dictionary Key you want to get the ID from.

Both method then call the `DiffWithCustomIds()` to perform the comparison with the extracted Ids, see below.

## `DiffWithCustomIds()`

The [`DiffWithCustomIds()` method](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/DiffWithCustomIds.cs#L52) allows you to provide:
- Two input objects sets that you want to compare, `pastObjs` and `followingObjs`;
- Two input identifiers sets, `pastObjsIds` and `followingObjsIds`, with the Ids associated to the `pastObjs` and `followingObjs`.

You can specify some `null` Ids in the `pastObjsIds` and `followingObjsIds`; however these two lists must have the same number of elements as `pastObjs` and `followingObjs`, respectively.

The IDs are then used to match the objects from the `pastObjs` set to objects in the `followingObjs` set, to decide who should be compared to who:
- If an object in the `pastObjs` does not have a corresponding object in the `followingObjs` set, it means that it has been deleted in the following version, so it is identified as "Removed" (old).
- If an object in the `followingObjs` does not have a corresponding object in the `pastObjs` set, it means that it has been deleted in the past version, so it is identified as "Added" (new).
- If an object in the `pastObjs` matches by ID an object in the `followingObjs`, then it is identified as "Modified" (it changed between the two versions). This means that the two objects will be compared and all their differences will be found. This is done by invoking the `ObjectDifferences()` method, that is [explained in detail here](/Diffing-and-Hashing:-guide-for-developers#objectdifferences-method-inner-workings).


## DiffOneByOne()

The [`DiffOneByOne()`](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/DiffOneByOne.cs#L52) method simply takes two input lists, `pastObjs` and `followingObjects`, and these have the objects in the same identical order. It then simply compares each object one-by-one. If matched objects are equal, they are "Unchanged", otherwise, they are "Modified" and their property difference is returned. 

For this reason, this method is not able to discover "Added" (new) or "Removed" (old) objects.

## DiffWithHash()

The [`DiffWithHash()`](https://github.com/BHoM/BHoM_Engine/blob/main/Diffing_Engine/Compute/DiffWithHash.cs) method simply does a Venn Diagram of the input objects' [Hashes](/Hash:-an-object's-identity):

![image](https://user-images.githubusercontent.com/6352844/146240551-33b43deb-6ac2-4c48-aef6-07bd172c25d2.png)

The Venn Diagram is computed by means of a [`HashComparer`](https://github.com/BHoM/BHoM_Engine/blob/6cf19b04a34803fcdc904bdfaaab3245f5869514/BHoM_Engine/Objects/EqualityComparers/HashComparer.cs#L39), which simply means that the [Hash](/Hash:-an-object's-identity) of all input objects gets computed.  

If objects with the same hash are found they are identified as "Unchanged"; otherwise, objects are either "Added" (new) or "Removed" (old) depending if their hash exists exclusively in following or past set. For this reason, this method is **not able to discover "Modified" objects**.

The Hash is leveraged by this method so you are able to customise how the diffing behaves by specifying a [`ComparisonConfig` options](/Configuring-objects-comparison:-%60ComparisonConfig%60) in the `DiffingConfig`.



## DiffRevisions

This method was designed for the [AECDeltas workflow](https://github.com/aecdeltas/aec-deltas-spec) and is currently not widely used. 

It essentially expects the input objects to be wrapped into a [`Revision` object](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/Diffing_oM/Revision.cs#L34-L62), which is useful to attach additional Versioning properties to them. 
The Revisions can then be provided as an input to `DiffRevisions()`, and the logic works very similarly to the other diffing methods seen above.
