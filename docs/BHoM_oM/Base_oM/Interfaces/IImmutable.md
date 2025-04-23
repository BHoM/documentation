The IImmutable interface makes an object unmodifiable after it was instantiated. In order to modify an IImmutable object, a new object with the desired properties needs to be instantiated, where all the properties that are required to stay the same should be copied from the old object. 

IImmutable should be implemented:

a) if objects instantiated from a class should not be modifiable, by design, in some or all of its properties;  
b) if objects contain properties that are **non-orthogonal**.

Whilst reason (a) is self-explanatory, (b) is due to a specific problem that non-orthogonal properties expose.

As a reminder, a class with ortogonal properties is a class whose properties all contain information that cannot be derived from other properties. Orthogonality is a software design principle for writing components in a way that changing one component doesn’t affect other components. For example, an orthogonal "Column" class may define a Start Point and an End Point as separate properties, but then it cannot define a third property called “Line” which goes between a start point and an end point, as it would be redundant: modifying the start or end point would require to modify the Line property too. For this reason, class with non-orthogonal properties should implement the `IImmutable` interface, because the consistency of its properties can be guaranteed only when the class is instantiated.


### How to implement it
To implement the `IImmutable` interface, you need to make two actions:

1. Inherit from it: i.e. `public class YourObject : IImmutable`
1. The properties you want to be immutable must be `public`, `get` only, and contain a default value. i.e. `public string Title { get; } = ""`
1. All the properties that are not immutable, can follow the usual BHoM conventions, `public`, `get` and `set`, and have a default value
1. It must implement only **one** constructor, whose parameters are types of all the immutable properties of the object.

For an example, you can check the `BH.oM.Structure.SectionProperties.SteelSection` from the `Structure_oM`:
[Steel Section example](https://github.com/BHoM/BHoM/blob/main/Structure_oM/SectionProperties/SteelSection.cs)

