As seen in the [Diffing](/Diffing:-tracking-changes-in-your-BHoM-objects) and the [Hash](/Hash:-an-object's-identity) wiki pages, the real power of object comparison is given by the options that you have when performing it. For this reason, we expose options to customise these operations via the `ComparisonConfig` object. 

Here is an example of the ComparisonConfig object seen from Grasshopper:

![2021-12-09 16_07_51-Grasshopper - ComparisonConfig versioning check_](https://user-images.githubusercontent.com/6352844/145563306-e3415a33-3e42-41fb-8054-614dfd61eab1.png)


There are also "Toolkit-specific" `ComparisonConfig` objects that extend the available options when dealing with certain objects, for example Revit's [`RevitComparisonConfig`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_oM/Config/RevitComparisonConfig.cs) gives further options when dealing with Revit objects. More details on it in its dedicated page.

> ### Note for developers
> The "default" [`comparisonConfig` object](https://github.com/BHoM/BHoM/blob/main/BHoM/ComparisonConfig.cs) inherits from the [`BaseComparisonConfig` abstract class](https://github.com/BHoM/BHoM/blob/main/BHoM/BaseComparisonConfig.cs), which defines all the "basic" options. This abstract class can be extended by the "Toolkit-specific" `comparisonConfig`s, so you can include additional options to deal with certain objects in your Toolkit, of which [`RevitComparisonConfig`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_oM/Config/RevitComparisonConfig.cs) is an example.  
> If you implement your own Toolkit-specific `comparisonConfig` object, you will need to implement the functions that deal with it too, which are a  toolkit-specific `Diffing()` method ([example in Revit](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs)), a toolkit-specific `HashString()` method ([example in Revit](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Query/HashString.cs)), and any  number of `ComparisonInclusion()` methods that you might need ([example in Revit](https://github.com/BHoM/Revit_Toolkit/blob/a71d99fa93ab5fbad0c01ac14885e090c186ab91/Revit_Engine/Query/ComparisonInclusion.cs#L39-L44)). More details can be found in the [diffing guide for developers](/Diffing-and-Hashing%3A-guide-for-developers).


# Description of the `ComparisonConfig` options

Let's see the `ComparisonConfig` options in detail.  

Many of the following examples use the [`Bar` class](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) as a reference object.


* [PropertyExceptions](#propertyexceptions)
* [PropertiesToConsider](#propertiestoconsider)
* [CustomDataKeysExceptions](#customdatakeysexceptions)
* [CustomDataKeysToConsider](#customdatakeystoconsider)
* [TypeExceptions](#typeexceptions)
* [NamespaceExceptions](#namespaceexceptions)
* [MaxNesting](#maxnesting)
* [MaxPropertyDifferences](#maxpropertydifferences)
* [NumericTolerance](#numerictolerance)
* [PropertyNumericTolerance](#propertynumerictolerance)
* [SignificantFigures](#significantfigures)
* [PropertySignificantFigures](#propertysignificantfigures)


## PropertyExceptions

You can specify one or more names of properties that you want to _ignore_ (not consider, take as exceptions) when comparing objects. 
This allows to ignore properties and also sub-properties (i.e., properties of properties) of any object.
This also supports `*` wildcard within property names, so you can match multiple properties.  
You can specify either the simple name of the property (e.g. `StartNode`), or the FullName of the property (e.g. `BH.oM.Structure.Elements.Bar.StartNode`) if you want to be more precise and avoid confusion in case you have properties/sub-properties with the same name.

To clarify the above, here are examples using the [`Bar` class](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) as a reference: 

### Property name VS Property Full Name - examples
- Specifying the property name `StartNode` would ignore the [`StartNode` property](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L46). It follows that any sub-property of `StartNode` will also be ignored.
- Specifying the property **Full Name** `BH.oM.Structure.Element.Bar.StartNode` would achieve the same result, but it is **_safer_** than using only the simple name `StartNode` (and may as well save computation time, [like in the case of PropertiesToConsider when Hashing](/Configuring-objects-comparison%3A-%60ComparisonConfig%60/#note-hash-performance-when-using-propertiestoconsider)).
 
To explain why using the property Full Name is safer, consider the example where you are Diffing a mix of objects which include both [`Bar`s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) and also [`GraphLink`s](https://github.com/BHoM/BHoM/blob/main/Data_oM/Collections/GraphLink.cs), both of which own a `StartNode` property. If you input `StartNode` in the `PropertyExceptions`, you must be aware that both properties `BH.oM.Structure.Elements.Bar.StartNode` and `BH.oM.Data.Collections.GraphLink.StartNode` will be treated as exceptions, hence ignored. Specifying the property full name is safer.


### Sub-properties examples
- Specifying `StartNode.Position`, would ignore any change in the [`Position` property of the start Node](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Node.cs#L40), but [all the other properties of `StartNode`](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Node.cs#L42-L46) would still be considered.
- Specifying `StartNode.Position.X`, would ignore any change in the [`X` property of the start Node's Position property](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Geometry_oM/Vector/Point.cs#L37), but [all the other properties of `StartNode.Position`](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Geometry_oM/Vector/Point.cs#L39-L43) would still be considered.
- Again, you can specify the Full Name even for sub-properties, like `BH.oM.Structure.Elements.Bar.StartNode.Position.X`, and as seen above, this is safer.


### Wildcard examples

You can specify `*` wildcards within property names, so you can match multiple properties with a single text.
  
- Specifying `BH.oM.Structure.Elements.Bar.*.Position.Y` would match:
  - `BH.oM.Structure.Elements.Bar.StartNode.Position.Y`
  - `BH.oM.Structure.Elements.Bar.EndNode.Position.Y`

  so if this is specified in the `PropertyExceptions`, those 2 properties will be ignored.

- Specifying `BH.oM.Structure.Elements.Bar.*.Y` would match:
  - `BH.oM.Structure.Elements.Bar.StartNode.Position.Y`
  - `BH.oM.Structure.Elements.Bar.EndNode.Position.Y`
  - `BH.oM.Structure.Elements.Bar.StartNode.Orientation.Y`
  - `BH.oM.Structure.Elements.Bar.EndNode.Orientation.Y`  

  so if this is specified in the `PropertyExceptions`, those 4 properties will be ignored.

- Again, you can specify only the name instead of the Full Name to obtain the same result, i.e. `*.Position.Y` would achieve the same result as `BH.oM.Structure.Elements.Bar.*.Position.Y` when the input objects are only [`Bar`s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71), but you incur in the same risks illustrated above if your input objects are of different types (see [property name VS property Full Name](/Configuring-objects-comparison%3A-%60ComparisonConfig%60/#property-name-vs-property-full-name---examples)).

- You can add as many `*` wildcards as you wish, which is especially handy when you have input objects of different types. Specifying `BH.oM.Structure.*.Start*.*Y` with both [`Bar`s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) and [`BarRelease`s](https://github.com/BHoM/BHoM/blob/main/Structure_oM/Constraints/BarRelease.cs) input objects would match all of the following properties:
  - `BH.oM.Structure.Elements.Bar.StartNode.Position.Y`
  - `BH.oM.Structure.Elements.Bar.StartNode.Orientation.Y`
  - `BH.oM.Structure.Elements.Bar.StartNode.Offset.Start.Y`
  - `BH.oM.Structure.Constraints.BarRelease.StartRelease.TranslationalStiffnessY`
  - `BH.oM.Structure.Constraints.BarRelease.StartRelease.RotationalStiffnessY`
  - `BH.oM.Structure.Constraints.BarRelease.StartRelease.TranslationY`
  - `BH.oM.Structure.Constraints.BarRelease.StartRelease.RotationY`

  so if this is specified in the `PropertyExceptions`, and both [`Bar`s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) and [`BarRelease`s](https://github.com/BHoM/BHoM/blob/main/Structure_oM/Constraints/BarRelease.cs) are in the input objects, all those 7 properties will be ignored.  
If instead you only had `Bar`s in the input objects, the `BH.oM.Structure.*.Start*.*Y` would only match the first 3 properties in the list above.

## PropertiesToConsider

The `PropertiesToConsider` input allows you to add property names that should be considered in the comparison.  

If you add a property name in this field, only the value held in that property will be considered. 

If the property name that you specified is not found on the object, then no properties will be considered. Therefore, make sure you input property names that exist on the object.

Like for the `PropertyExceptions` option, you can specify the property names as just the Name (e.g. `StartNode`), as a Full Name (e.g. `BH.oM.Structure.Elements.Bar.StartNode`) and/or using wildcards (e.g. `BH.oM.Structure.Elements.*.StartNode`) to get different matching results. See the [section on `PropertyExceptions`](#propertyexceptions) for more details on Full Names and using wildcards.

> ### Note: Hash performance when using `PropertiesToConsider`
>
> Using `PropertiesToConsider` can be a resource-intensive operation **when calculating an object's Hash** (Diffing instead is only slightly affected). To speed up the Hash computation:
> - use only property Full Names as an input to `PropertiesToConsider`;
> - do not use Wildcards in `PropertiesToConsider`;
> - limit the amount of property names in `PropertiesToConsider`.
> 
> Technical explanation in the details below.
> 
> <details>
> 
> The Hash of an object is calculated by recursively navigating all properties of the object and taking their value. If you specify some `PropertiesToConsider`, the property value is only considered if its name matches a property name in there. Then, the recursion continues, and if the current property has some sub-property, the algorithm checks the sub-property, and so on. When checking a certain property, the algorithm doesn't know the names of all its sub-properties until it gets there. 
> 
> If the property names include Wildcards or are not specified as Full Names, there can be situations where some nested sub-property needs to be considered, but then its parent's siblings must be ignored. When computing the `Hash()`, we are traversing the property tree of the object, but we do not know all the properties during the traversal. For example, say that your input object is a `Bar`, and you want to consider exclusively properties that match `*.Name`. The situation is:
> 
> ![image](https://user-images.githubusercontent.com/6352844/141302351-fb36b4a7-69f9-45da-af92-f56be3926298.png)
> 
> One way of solving this could be to "consider" all the properties of the object while doing the Hash, and, at the end, cull away those that do not match any `PropertiesToConsider`. This basically is like saying that we build our knowledge of the object while computing its Hash. However, this can be wasteful for two reasons:
> - speed: many other operations may be done to the object values being considered when computing the Hash (e.g. numerical approximations);
> - space: we would need to store in RAM many values that we may never use.
> 
> For this reason, we instead build the knowledge of the property tree before computing the hash; in other words, we traverse the entire object once and look at the property names, and get the "consequent" PropertiesToConsider, i.e. all the properties of the object that match your wildcard or partial property name, _translated to their Full Name form_. By using Full Names, it the becomes easy for the Hash algorithm to consider or not a property: just check if the property full name matches any of the `PropertiesToConsider`.
> 
> The cost of this can be cut by specifying Full Names instead of just the name (i.e. `BH.oM.Structure.Elements.Bar.StartNode` instead of `StartNode`) and avoiding wildcards `*` when using `PropertiesToConsider`.
> 
> </details>


## CustomDataKeysExceptions

This works similarly to [`PropertyExceptions`](#PropertyExceptions), but is used only for BHoMObjects [CustomData dictionary](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/BHoM/BHoMObject.cs#L42) keys. 

Setting a key name in `CustomDataKeysExceptions` means that if that key is found on in the CustomData dictionary of an object, it will not be considered.

This option does not support wildcard, unlike `PropertyExceptions`.

## CustomDataKeysToConsider

Setting a key name in `CustomDataKeysToConsider` means that only that dictionary key will be considered amongst any BHoMObject's CustomData. If no matching CustomData key is found on the object, no CustomData entry will be considered.

This option does not support wildcard.

## TypeExceptions

You can input any Type here. Any object or property of corresponding types will not be considered.

## NamespaceExceptions

You can input the name of any namespace here. An example of a namespace is `BH.oM.Structure.Elements`.

Any object or property that belong to the corresponding namespace will not be considered.

This option does not support wildcard.

## MaxNesting

This option limits the depth of property discovery when computing Diffing or an object's Hash.

Properties whose **Nesting Level** is equal to or larger than `MaxNesting` will not be considered.

> ### Property Nesting Level definition
> The nesting level of a property defines how deep we are in the object property tree.  
> For example:
> - a [`Bar`'s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) `StartNode` property is at Nesting Level 1 (it is also called a  "top-level" property of the object)
> - a [`Bar`'s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) `StartNode.Position` property is at Nesting Level 2, because `Position` is a sub-property of `StartNode`.

Top-level properties are at level 1. Setting `MaxNesting` to 1 will make the Hash or Diffing consider only top-level properties. Setting `MaxNesting` to 0 will disregard any object property (only the class name will end up in the Hash, and Diffing will not find any differences).

This option is better used as a safety measure to avoid excessive computation time when diffing or computing the hash for objects that may occasionally have one or more deeply nested properties of which we do not care about.

## MaxPropertyDifferences

When Diffing, this indicates the maximum number of Property Differences that will be collected and returned. This setting does not affect the Hash calculation (in fact, this option should be moved in [DiffingConfig](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Diffing_oM/DiffingConfig.cs#L34-L55) instead). 

You can not control what properties are returned and what remain excluded due to this numeric limit. Hence, this option is better used as a safety measure to avoid excessive computation time when:
- we care about finding different objects, but do not care about what properties did change between them, although a better and faster option for this would be to use [`DiffingConfig.EnablePropertyDiffing`](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Diffing_oM/DiffingConfig.cs#L43-L46) set to `false`;
- we are okay with finding only the first n differences between objects, whatever those may be.

## NumericTolerance

This option sets the Numeric tolerance applied when considering any _numerical property_ of objects.
For example, a [`Bar`'s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) `StartNode.Position.X` property is a numerical property.

When a numerical property is encountered, the function [`BH.Engine.Base.RoundWithTolerance()`](https://github.com/BHoM/BHoM_Engine/blob/main/BHoM_Engine/Query/RoundWithTolerance.cs) is applied to its value, which becomes approximated with the given `NumericTolerance`.

Therefore, when Hashing, the property's approximate value will be recorded in the Hash. When Diffing, the property approximate value will be used for the comparison.

If both `NumericTolerance` and `SignificantFigures` are provided in the ComparisonConfig, both approximations are executed, and the largest approximation among all (the least precise number) is registered.


> ### `RoundWithTolerance()` details
> 
> The function [`BH.Engine.Base.RoundWithTolerance()`](https://github.com/BHoM/BHoM_Engine/blob/main/BHoM_Engine/Query/RoundWithTolerance.cs) will approximate the input value with the given tolerance, which is done by rounding (to floor) to the nearest tolerance multiplier.
> 
> Some examples of `RoundWithTolerance()` are:
> 
> | Input number | Input Tolerance | Result (approximated number) |
> |--------------|-----------------|------------------------------|
> | 12           | 20              | 0                            |
> | 121          | 2               | 120                          |
> | 1.2345       | 1.1             | 1.1                          |
> | 0.014        | 0.01            | 0.01                         |
> | 0.014        | 0.02            | 0                            |


## PropertyNumericTolerance

This option applies a given Numeric Tolerance to a specific property, therefore considering its value approximated using the given tolerance.

In order to use it, you have to create and input in `PropertyNumericTolerance` one or more [`NamedNumericTolerance` objects](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/BHoM/NamedNumericTolerance.cs#L27-L40), where you set:
- the `Name` of the property you want to target; this supports `*` wildcard usage;
- the `Tolerance` that you want to apply to the given property.

The approximation will work exactly as per the [`NumericTolerance`](#NumericTolerance) option, only it will target exclusively the properties with the name specified via the [`NamedNumericTolerance` objects](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/BHoM/NamedNumericTolerance.cs#L27-L40).

If a match is found, this takes precedence over the `NumericTolerance` option.  
If conflicting values/multiple matches are found among the `ComparisonConfig`'s numerical precision options, the largest approximation among all (least precise number) is registered.

The `Name` field supports wildcard usage. Some examples:
- `BH.oM.Geometry.Vector`: applies the corresponding tolerance to all numerical properties of Vectors, i.e. X, Y, Z
- `BH.oM.Structure.Elements.*.Position`: applies the corresponding tolerance to all numerical properties of properties named `Position` under any Structural Element, e.g. `Bar.Position.X`, `Bar.Position.Y`, `Bar.Position.Z` and at the same time also `Node.Position.X`, `Node.Position.Y,` `Node.Position.Z`.

## SignificantFigures

This option sets the Significant Figures considered for any _numerical property_ of objects.
For example, a [`Bar`'s](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/Structure_oM/Elements/Bar.cs#L39-L71) `StartNode.Position.X` property is a numerical property.

When a numerical property is encountered, the function [`BH.Engine.Base.RoundToSignificantFigures()`](https://github.com/BHoM/BHoM_Engine/blob/main/BHoM_Engine/Query/RoundToSignificantFigures.cs) is applied to its value, which becomes approximated with the given `SignificantFigures`.

Therefore, when Hashing, the property's approximate value will be recorded in the Hash. When Diffing, the property approximate value will be used for the comparison.

If both `SignificantFigures` and `NumericTolerance` are provided in the ComparisonConfig, both approximations are executed, and the largest approximation among all (the least precise number) is registered.

> ### `RoundToSignificantFigures()` details
>
> The function [`BH.Engine.Base.RoundToSignificantFigures()`](https://github.com/BHoM/BHoM_Engine/blob/main/BHoM_Engine/Query/RoundWithTolerance.cs) will approximate the input value with the given Significant Figures. Some examples:
>
> | Input number | Input Significant Figures | Result (approximated number) |
> |--------------|-----------------|------------------------------|
> | 1050.67 | 1 | 1000 |
> | 1050.67 | 2 | 1100 |
> | 1050.67 | 3 | 1050 |
> | 1050.67 | 4 | 1051 |
> | 1050.67 | 5 | 1050.7 |
> | 123456.123 | 7 | 123456.1 |
> | 123456.123 | 1 | 100000 |
> | 0.0000000000000000000123456789 | 5 | 1.2346E-20 |
> | 0.0000000000000000000123456789 | 99 | 1.23456789E-20 |

## PropertySignificantFigures

This option applies the approximation with given Significant Figures to a specific property.

In order to use it, you have to create and input in `PropertyNumericTolerance` one or more [`NamedSignificantFigures` objects](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/BHoM/NamedSignificantFigures.cs#L27-L40), where you set:
- the `Name` of the property you want to target; this supports `*` wildcard usage;
- the `SignificantFigures ` that you want to consider when evaluating the given property.

The approximation will work exactly as per the [`SignificantFigures`](#SignificantFigures) option, only it will target exclusively the properties with the name specified via the [`NamedSignificantFigures` objects](https://github.com/BHoM/BHoM/blob/afb17a5a206da0747f671bca286c368d37f498b2/BHoM/NamedSignificantFigures.cs#L27-L40).

If a match is found, this takes precedence over the `SignificantFigures` option.  
If conflicting values/multiple matches are found among the `ComparisonConfig`'s numerical precision options, the largest approximation among all (least precise number) is registered.

The `Name` field supports wildcard usage. Some examples:
- `BH.oM.Geometry.Vector`: applies the corresponding tolerance to all numerical properties of Vectors, i.e. X, Y, Z
- `BH.oM.Structure.Elements.*.Position`: applies the corresponding tolerance to all numerical properties of properties named `Position` under any Structural Element, e.g. `Bar.Position.X`, `Bar.Position.Y`, `Bar.Position.Z` and at the same time also `Node.Position.X`, `Node.Position.Y,` `Node.Position.Z`.