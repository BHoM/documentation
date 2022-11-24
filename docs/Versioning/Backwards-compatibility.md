### Backwards compatibility

The two major subjects for backwards compatibility concerns methods/components and the objects/data itself.

#### Methods/Components

Only time these should have to break is when a parameter has been updated. This will in the long run be covered by the `Version_Engine`. See [object name or namespace changed](/Backwards-compatibility#object-name-or-namespace-changed).

For all other cases the developer is responsible for ensuring that they never update _public_ methods in a manner that can cause a script to break. Updates to methods will lead to scripts breaking if the interface of the method has been updated, which will be the case if at least one of the following is true:

1. Method name is changed
1. Method is moved to a different class
1. Method namespace is changed
1. Return type is changed
1. Input parameters are changed, in type, number or order

If none of the above holds true for the change being made, i.e. the change only concerns the body of the method, the change is free to do without any additional concern about versioning. (Obviously any fundamental change to the behavior of the method needs normal due care and documentation.)

If any of the above holds true the following process should be applied:

1. Implement the new method _without_ removing the old.

1. Put a [Deprecated](/Code-Attributes#deprecated) tag on the old method you want to update. In the tag link over to the new method.

1. The method with the `Deprecated` tag can be removed when at least 2 minor releases have passed. (For example a method deprecated in version 2.2 should not be removed before version 2.4 at the earliest.)

#### Object models and serialised data

If an object schema is updated it will potentially lead to breaking previously serialized data and for some cases methods. 

If the deserialisation from BSON or JSON fails, the `Serialiser_Engine` will fall back to deserialise any failing object to a `CustomObject`, containing all the data as keys in the CustomData.

To ensure that any old data is deserialised correctly to the updated object schema, methods in the `Versioning_Engine` will need to be implemented. Depending on the change made, different action needs to be taken as outlined below.

##### Object name or namespace changed

When a change has been made to the object name or namespace, a renaming method needs to be implemented in the `Version_Engine`, taking the previous full name as a string, including namespace (for example BH.oM.Structure.Element.Bar) and returning the new name as a string.

This will also be important when deserialising any method using the updated object as return type or input parameter.

##### Object definition changed

When the definition of an object has been changed, which could be:

- Adding a property
- Removing a property
- Change name or type of a property

the object will be deserialised to a `CustomObject`, as outline above.

To ensure that the object is being correctly deserialised covering the change being made, a convert method between versions needs to be implemented in the  `Version_Engine`, taking the `CustomObject` as an argument and returning a new `CustomObject` with properties updated to match the new object schema. The `Versioning_Engine` will then attempt to deserialize the updated schema to the correct object.

The method implemented should just cover update from one version to the next (for example 2.3 -> 2.4). This will make it possible to chain the updates when an object has gone through several changes over multiple versions.
