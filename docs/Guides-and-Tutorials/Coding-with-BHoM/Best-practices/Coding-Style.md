# BHoM's coding style and conventions

## General C# conventions

Our coding style generally follows the [Microsoft guidelines on C#](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/).

However, to attain a higher level of clarity and transparency, BHoM code also adheres to additional customised rules and style guidelines.

## Additional conventions

BHoM code also adheres to customised rules and style guidelines. These are in place for several reasons, mainly:

- to make easier to read and contribute to the codebase;
- to ensure the functionality can be correctly exposed to the UIs;
- to organise functionality and classes in a tidy, easy-to-find manner.


### Access modifiers

Access modifiers specify the accessibility level of type and type members. They denote whether a type or member can be used by other code in the same assembly, and in other assemblies.

- In line with BHoM's focus on clarity and transparency, we generally use the `public` access modifier, which allows a type or member to be accessed by any other code in the same assembly or other assembly that reference it.
- When absolutely necessary, we use the `private` access modifier to limit the access of a type or member to only code in the same class.
- Although C# provides many [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers), we limit our use to the two mentioned above.


### Filenames, objects and methods

- A `.cs` file can contain only 1 (one) `class`, and there is no concept as a `Helper` or `Utils` class.
- For **oM objects** the name of the `.cs` file is the Name (excluding the namespace) of the Object (class), e.g. the `Line` class is in the `Line.cs` file.
- For **engine methods**, a file can only contain methods whose name start or end with the name of their file file, e.g. `Flip(Line line)` and `Flip(Arc arc)` are in the same file `Flip.cs`, and `FilterPanels` and `FilterOpenings` can both reside inside a `Filter.cs` file.


### Folders and namespaces

Namespaces and the folder structure that contains the `.cs` files have a close relationship. To define the correct folder structure helps keeping the relationship with the namespaces. This, in turn enables additional functionalities, such as deriving the [web address]() of the source code of a method.

For a `Class`, an `Attribute`, an `Enum`, and an `Interface`, the folder structure respects the following rules:

- If a file is in a sub folder, the namespace of the entity must follow: if `Bar` is in a sub folder `Elements`, its namespace must suffix the `Elements` word `BH.oM.Structure.Elements`.

- An `Enum` must be in a separate folder `Enums`. Although, the namespace remains unchanged, and does not follow - i.e. `Enums` is appended as suffix. For example `BarFEAType` is in the sub folder `Elements`, and it is an `enum`. Its namespace respects A., so it contains the `Elements` word, but does not contain the `Enum` word: BH.oM.Structure.Elements. At the same time, since it is an `Enum` it is in an `Enums` folder.

- The same rule as B. applies to:
  - `Attribute` => `Attributes`
  - `Interface` => `Interfaces`


### Enum ordering

The order an Enum is written is the order in which it is displayed in the UI dropdown options. This order is therefore important to the UX of using the Enum within a workflow. The order should therefore follow one of the following conventions. There may be occasions when an Enum order does not follow the conventions below. These occasions should be clearly documented with the reasons why a different convention has been followed.

#### Alphabetical

The order of the Enum should be alphabetical (following British-English spelling conventions) in ascending order (i.e. A-z).

**Caveat for `Undefined`**

If your Enum option has an `Undefined` option to denote a default unset option, then this should go as the first option at the top of the Enum.

For an example of an Enum following this convention, see the [Environment Panel Type Enum](https://github.com/BHoM/BHoM/blob/master/Environment_oM/Elements/Enums/PanelType.cs).

#### Logical

The order of the Enum can be in a logical order instead where this makes more sense than alphabetical. An example of such an Enum might be one that records the size of an object. In this case, the options might be:

```
ExtraSmall
Small
Normal
Large
ExtraLarge
```

This order for the Enum makes logical sense and provides a good UX where users will have context from the name of the Enum that the order might be different to alphabetical (e.g. the name might be `UnitSize`).

### Yoda condition
 
For conditional statements, the variable expression should be placed in front of the constant expression. When this order is reversed, it is referred to as a "[Yoda condition](https://en.wikipedia.org/wiki/Yoda_conditions)". For readability, we avoid using Yoda conditions in our code base. An example of both is given below.

```c#

string str = "hello world" 

if (str == "BHoM") { /* … */} //most common convention - preferred for BHoM development

else if ("BHoM" == str) {/* … */} //Yoda style, as the constant "BHoM" precedes the string variable

```
