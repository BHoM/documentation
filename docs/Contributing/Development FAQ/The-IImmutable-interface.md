TODO: Specify when to use it

### How to implement it
To implement the `IImmutable` interface, you need to make two actions:
1. Inherit from it: i.e. `public class YourObject : IImmutable`
1. The properties you want to be immutable must be `public`, `get` only, and contain a default value. i.e. `public string Title { get; } = ""`
1. All the properties that are not immutable, can follow the usual BHoM conventions, `public`, `get` and `set`, and have a default value
1. It must implement only **one** constructor, whose parameters are types of all the immutable properties of the object.

For an example, you can check the `BH.oM.Structure.SectionProperties.SteelSection` from the `Structure_oM`:
https://github.com/BHoM/BHoM/blob/master/Structure_oM/SectionProperties/SteelSection.cs

