## Hash definition

A Hash, sometimes called also _hash code_, is the "unique signature" or "identity" of an object.

The hash is generally a string (a text) containing alphanumeric characters. It is composed by applying a _Hash algorithm_ to an object, which parses the input object, all its properties, and the values assigned to those properties. The returned hash is a "combination of all the variables" present in the object. It follows that its most important feature is that **the hash remains the same as long as the object remains the same** (under certain criteria, which can be customised).

The Hash for objects can be used in many different kinds of _comparisons_, or for any case where a unique identification of an object is needed. Examples include:
- you can compute hash for objects to quickly and safely _compare objects with each other_, so you can determine _unique objects_ (i.e., what objects are duplicates or not)
- you can _compare an object's hash at different points in time_. You can store the hash of an object in a certain moment; then, some time later, you can check if the object changed (i.e., even a slight variation of one of its properties) by checking if its hash changed.


## BHoM's `Hash()` method

BHoM exposes a `Hash()` method to calculate the Hash for any BHoM object (any object implementing the `IObject` interface).


This method is defined in the base BHoM_Engine: [`BH.Engine.Base.Query.Hash()`](https://github.com/BHoM/BHoM_Engine/blob/6cf19b04a34803fcdc904bdfaaab3245f5869514/BHoM_Engine/Query/Hash.cs#L47-L52). Here is an example of how the method can be used in Grasshopper:

![image](https://user-images.githubusercontent.com/6352844/145988611-bd7df512-48d8-4aa5-99a1-830f51991a40.png)

The method returns a `string`, a textual Hash code that uniquely represents the input object.

This method's most parameters are:
- the `IObject` you want to get the Hash for;
- `comparisonConfig` configurations on how the Hash is calculated (see the dedicated section);
- `hashFromFragment`: if instead of computing the Hash of the object, you want to retrieve a Hash that was previously stored in the object's Fragments.  
  In order to set the HashFragment on a BHoMObject's Fragment, you can use the [`SetHashFrament()` method](https://github.com/BHoM/BHoM_Engine/blob/main/BHoM_Engine/Modify/SetHashFragment.cs): ![image](https://user-images.githubusercontent.com/6352844/145989383-600d33fe-fefa-4e13-b8e8-22c3d2c54d2a.png)




## Hash `ComparisonConfig`: options to compute the Hash

The real potential of the Hash algorithm is given by its customisation options, which we call [_ComparisonConfig_](/Configuring-objects-comparison%3A-%60ComparisonConfig%60) (comparison configurations).

For example, you may want to configure the Hash algorithm so it only considers numerical properties that changed within a certain tolerance. This way, you can determine if an object changed by looking at changes in the Hash, and you will be alerted only if the change was a numerical change greater than the given tolerance.

For this reasons, we expose many configurations in a `ComparisonConfig` object:

![image](https://user-images.githubusercontent.com/6352844/146352031-edcebdcc-b6db-49d1-8a1b-903c1c2ae6ce.png)

See the [Wiki page dedicated to `ComparisonConfig`](/Configuring-objects-comparison%3A-%60ComparisonConfig%60) for details on it.

Note that some ComparisonConfig options may slow down the computation of the Hash, which becomes particularly noticeable when hashing large sets of objects. An option that may have particular negative impact when computing the Hash is `PropertiesToConsider`, as explained [here](/Configuring-objects-comparison:-%60ComparisonConfig%60#note-hash-performance-when-using-propertiestoconsider).

<br></br>

> ## Note for developers: customising an object's Hash
>
> If you want a specific object to be Hashed in a particular way, you can implement a specific `HashString()` method for that object in your Toolkit.
> 
> Here is an example [for Revit's `RevitParameter` object](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Query/HashString.cs). The `HashString()` method will get invoked [hen computing the Hash(). 
>
> More info in the [Diffing and Hash: guide for developers](/Diffing-and-Hashing:-guide-for-developers#customising-the-hash-hashstring-extension-method) wiki page.