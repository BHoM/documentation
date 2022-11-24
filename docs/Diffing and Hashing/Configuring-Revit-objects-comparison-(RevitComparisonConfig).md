As we've seen in the [Diffing](/Diffing:-tracking-changes-in-your-BHoM-objects) and [Hash](/Hash:-an-object's-identity) pages, we can customise how objects are compared to each other (either using Diffing or by comparing their Hashes) through the [`ComparisonConfig` object](/Configuring-objects-comparison-(ComparisonConfig)).

In addition to the basic `ComparisonConfig` that we can use with any object, we also have a Revit-specific [`RevitComparisonConfig` object](https://github.com/BHoM/Revit_Toolkit/blob/ffe1406c8abac574ac5bfcbf25609da1e5db049a/Revit_oM/Config/RevitComparisonConfig.cs#L32-L59) that expands the available options.

Below is an example of how the `RevitComparisonConfig` looks in Grasshopper. Note that most of them are already covered by the [`ComparisonConfig` object](/Configuring-objects-comparison-(ComparisonConfig)) base wiki, while the Revit-specific options are only the first 4 (explained below).

![image](https://user-images.githubusercontent.com/6352844/145990764-8e8ae057-e81c-4489-b644-2e2e6e583a52.png)




> ### Note for developers: _Toolkit-specific_ `ComparisonConfig` objects
> The "default" [`comparisonConfig` object](https://github.com/BHoM/BHoM/blob/main/BHoM/ComparisonConfig.cs) inherits from the [`BaseComparisonConfig` abstract class](https://github.com/BHoM/BHoM/blob/main/BHoM/BaseComparisonConfig.cs), which defines all the "basic" options. This abstract class can be extended by the "Toolkit-specific" `comparisonConfig`s, so you can include additional options to deal with certain objects in your Toolkit, of which [`RevitComparisonConfig`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_oM/Config/RevitComparisonConfig.cs) is an example.  
> 
> **In general, if you implement your own Toolkit-specific `comparisonConfig` object, you will need to implement the functions that deal with it, i.e. a _toolkit-specific `Diffing()`_ method and a _toolkit-specific `HashString()`_ method.**
> 
> The `RevitComparisonConfig` is in fact used by the [`RevitDiffing()` method](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs), and, when hashing, by [Revit's `HashString()` method](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Query/HashString.cs). These two methods can be invoked manually, to deal with Revit Objects, or are automatically invoked by the IDiffing() method when the input objects are Revit objects.


## `ParametersExceptions`

Allows to specify Revit Parameter names that should not be considered while Diffing or computing an object's Hash.

This supports `*` wildcard matching.

## `ParametersToConsider`

The `ParametersToConsider` input allows you to add parameter names that should be considered while Diffing or computing an object's Hash.

If you add a parameter name in this field, only the value held in that parameter will be considered.

If the parameter name that you specified is not found on the object, then no parameter will be considered for that object.

This input supports `*` wildcard matching.

## `ParameterNumericTolerance`

This works similarly to the [`PropertyNumericTolerance` option](/Configuring-objects-comparison:-%60ComparisonConfig%60#propertynumerictolerance), but it applies to Revit Parameters only. See that wiki section for more details on how to use it.

## `ParameterSignificantFigures`

This works similarly to the [`PropertySignificantFigures` option](/Configuring-objects-comparison:-%60ComparisonConfig%60#propertysignificantfigures), but it applies to Revit Parameters only. See that wiki section for more details on how to use it.
  
<br/><br/>
______________
  
For a description of all remaining options, see /Configuring-objects-comparison:-%60ComparisonConfig%60.