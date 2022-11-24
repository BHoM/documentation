This page gives a more in-depth technical explanation about some diffing methods, and also serves as a guide for developers to build functionality on top of existing diffing code.  
See the [Diffing](/Diffing:-tracking-changes-in-your-BHoM-objects) and the [Hash](/Hash:-an-object's-identity) wiki pages for a more quick-start guide.

### Contents

* [Developing Toolkit-specific diffing methods](#developing-toolkit-specific-diffing-methods)
* [IDiffing() method: internal workings](#idiffing-method-internal-workings)
  * [Invoking of the Toolkit-specific diffing methods](#invoking-of-the-toolkit-specific-diffing-methods)
  * [What happens for objects that do not have a Toolkit-specific diffing method](#what-happens-for-objects-that-do-not-have-a-toolkit-specific-diffing-method)
* [Other Diffing methods inner workings](#other-diffing-methods-inner-workings)
  * [ObjectDifferences() method inner workings](#objectdifferences-method-inner-workings)
  * [Mapping our ComparisonConfig to Kellerman library](#mapping-our-comparisonconfig-to-kellerman-library)
* [Customising the Diffing output: ComparisonInclusion() extension method](#customising-the-diffing-output-comparisoninclusion-extension-method)
* [Customising the Hash: HashString() extension method](#customising-the-hash-hashstring-extension-method)
* [Toolkit-specific ComparisonConfig options](#toolkit-specific-comparisonconfig-options)
* [Testing and profiling](/Diffing-and-Hashing%3A-guide-for-developers/#testing-and-profiling)

# Developing _Toolkit-specific diffing methods_

The [`IDiffing()` method](/Diffing:-tracking-changes-in-your-BHoM-objects#idiffing-method) is designed to be a "universal" entry point for users wanting to diff their objects; for this reason, it has an automated mechanism to call any _Toolkit-specific diffing method_ that can is compatible with the input objects. This work similarly to the [_Extension Method discovery pattern_](https://github.com/BHoM/BHoM_Engine/blob/b7b03a0785fc21a7dea21680925a4f94c760ef77/Reflection_Engine/Compute/TryRunExtensionMethod.cs) that is often leveraged in many BHoM methods.

A _Toolkit-specific Diffing method_ is defined as a method:
- that is `public`;
- whose name ends with `Diffing`;
- that has the following inputs:
  - a first `IEnumerable<object>` for the past objects;
  - a second `IEnumerable<object>` for the following objects; 
  - any number of optional parameters;
  - a final `DiffingConfig` parameter (that should default to `null`, and be auto initialised if null within the implementation).

Any method that respect these criteria is discovered and stored during the assembly loading [through this method](https://github.com/BHoM/BHoM_Engine/blob/main/Diffing_Engine/Query/AdaptersDiffingMethods.cs). It gets [invoked by the `IDiffing()` as explained here](/Diffing:-guide-for-developers#invoking-of-the-toolkit-specific-diffing-methods).

# `IDiffing()` method: internal workings

The IDiffing method does a series of automated steps to ensure that the most appropriate diffing method gets invoked for the input objects.

## Invoking of the Toolkit-specific diffing methods

The IDiffing first looks for any [Toolkit-specific diffing method](/Diffing%3A-guide-for-developers/_edit#developing-toolkit-specific-diffing-methods) that is compatible with the input objects ([relevant code here](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/IDiffing.cs#L89-L120)). This is done by checking if there is a `IPersistentAdapterId` stored on the objects; if there is, the namespace to which that `IPersistentAdapterId` object belongs is taken as the source namespace to get a compatible Toolkit-specific diffing method. For example, if the input objects own a [`RevitIdentifier` fragment](https://github.com/BHoM/Revit_Toolkit/blob/a71d99fa93ab5fbad0c01ac14885e090c186ab91/Revit_oM/Parameters/RevitIdentifiers.cs#L29) (which implements `IPersistentAdapterId`), then the namespace `BH.oM.Adapters.Revit.Parameters` is taken. This namespace, which is an `.oM` one, is ["modified" to an `.Engine` one](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/IDiffing.cs#L105), so the related Toolkit Engine is searched for a diffing method. 

[If a _Toolkit-specific diffing method_ match is found, that is then invoked](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Compute/IDiffing.cs#L111-L120). For example, this is how [`RevitDiffing()`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs) gets called by the IDiffing.  
Note that only the first matching method gets invoked. This is because we only allow to have 1 Toolkit-specific diffing method. If you have method overloading over your Toolkit-specific Diffing method (for example, because you want to provide the users with multiple choices when they choose to invoke directly your Toolkit-specific diffing method), you must ensure that all overloads are equally valid and can any can be picked by the IDiffing with the same results (like it happens for [`RevitDiffing()`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs): all methods end up calling a single, `private` Diffing method, and additional inputs are optional, so they all behave the same if called by the IDiffing).

## What happens for objects that do not have a Toolkit-specific diffing method

If the previous step does not find any `Toolkit-specific diffing method` compatible with the input objects, then a variety of steps are taken to try possible diffing methods. In a nutshell, a series of checks are done on the input objects to see what diffing method is most suitable. This is better described in the following diagram. For more details on each individual diffing method, see /Diffing%3A-tracking-changes-in-your-BHoM-objects/#other-diffing-methods.

![IDiffing1](https://user-images.githubusercontent.com/6352844/146181923-e6a5004d-3e39-48e3-a034-2495caf18fb5.png)


# Other Diffing methods inner workings

In addition to the main Diffing method `IDiffing()`, there are several other methods that can be used to perform Diffing. These are a bit more advanced and should be used only for specific cases. All diffing methods can be found in the [Compute folder of Diffing_Engine](https://github.com/BHoM/BHoM_Engine/tree/main/Diffing_Engine/Compute).

Most diffing methods are simply relying on an ID that is associated to the input objects, or a similar way to determine which object should be compared to which. Once a match is found, the two matched objects (one from the `pastObjects` set and one from the `followingObjects` set) are sent to the `ObjectDifferences()` method, as illustrated by the following diagram.  

This diagram also illustrates that only the `DiffWithHash()` method does not rely on the `ObjectDifferences()` method. The `DiffWithHash()` is a rather simple and limited method, in that it cannot identify Modified objects but only new/old ones, and it is described [here](/Diffing:-tracking-changes-in-your-BHoM-objects#other-diffing-methods).

![Diffing methods-simplified](https://user-images.githubusercontent.com/6352844/146228227-b826c68b-6b4f-4be5-b41f-3b09b7e9653b.png)

## `ObjectDifferences()` method inner workings

As shown above, the method that does most of the work in diffing is the [`BH.Engine.Diffing.Query.ObjectDifferences()` method](https://github.com/BHoM/BHoM_Engine/blob/main/Diffing_Engine/Query/ObjectDifferences.cs). 

This is the method that has the task of finding all the differences between two input objects. This method currently leverages an open-source, free library called [`CompareNETObjects` by Kellerman software](https://github.com/GregFinzer/Compare-Net-Objects). It maps our [`ComparisonConfig` options](/Configuring-objects-comparison%3A-%60ComparisonConfig%60) to the [equivalent class](https://github.com/GregFinzer/Compare-Net-Objects/blob/master/Compare-NET-Objects/ComparisonConfig.cs) in the `CompareNETObjects` library, and then executes the comparison using it.

### Mapping our `ComparisonConfig` to Kellerman library

Because not all of the options available in the [ComparisonConfig](/Configuring-objects-comparison%3A-%60ComparisonConfig%60) are mappable to Kellerman's, `ObjectDifferences()` has to adopt a workaround. For example, our [numerical approximation options](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/BHoM/BaseComparisonConfig.cs#L70-L88) are not directly compatible.  
The general compatibility strategy is:
- if an option is mappable/convertible, map/convert it from our `ComparisonConfig` to Kellerman's `CompareLogic` object. [This is true for most of them](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Query/ObjectDifferences.cs#L72-L78).
- if an option is not compatible with Kellerman (like our [numerical approximation options](https://github.com/BHoM/BHoM/blob/5ec4a0ec34f95382f64530779aafda34252dbbfa/BHoM/BaseComparisonConfig.cs#L70-L88)), set Kellerman `CompareLogic` so it finds all possible differences with regards to that option (like we do for [numerical differences](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Query/ObjectDifferences.cs#L80-L84)), then **iterate the differences found** and cull out those that are non relevant ([example for the numerical differences](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Query/ObjectDifferences.cs#L189-L191)).

The loop to iterate over the differences found by Kellerman is also useful to further customise the output, as shown by the [following section](/Diffing-and-Hashing%3A-guide-for-developers/#customising-the-diffing-output-comparisoninclusion-extension-method).

# Customising the Diffing output: `ComparisonInclusion()` extension method

In order to customise our diffing output, we want to customise how the `ObjectDifferences()` method determines the differences between objects.
This is done through a specific `ComparisonInclusion()` extension method that is [invoked when we loop through the differences](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/Diffing_Engine/Query/ObjectDifferences.cs#L118-L136) found by the Kellerman library. This is essentially an application of the [_Extension Method discovery pattern_](https://github.com/BHoM/BHoM_Engine/blob/b7b03a0785fc21a7dea21680925a4f94c760ef77/Reflection_Engine/Compute/TryRunExtensionMethod.cs) that is often leveraged in many BHoM methods.

You can implement a `ObjectDifferences()` method in your Toolkit to customise how the difference between two specific objects is to be considered by the diffing. This method must have the following inputs, in this order:
- a fist object input (which will be the object coming from the `pastObjs` set);
- a second object input, of the same type as the first object (which will be the object coming from the `followingObjs` set);
- a `string` input, which will contain the Full Name of the property difference found by the `ObjectDifferences()` method;
- a `BaseComparisonConfig` input, which will be passed in by the `ObjectDifferences()` method.

The method must return a `ComparisonInclusion` object, which will contain information on whether the difference should be included or not, and how to display it.

Here is an example of [`ComparisonInclusion()` for RevitParameters](https://github.com/BHoM/Revit_Toolkit/blob/a71d99fa93ab5fbad0c01ac14885e090c186ab91/Revit_Engine/Query/ComparisonInclusion.cs#L39-L44):
```cs
public static ComparisonInclusion ComparisonInclusion(this RevitParameter parameter1, RevitParameter parameter2, string propertyFullName, BaseComparisonConfig comparisonConfig)
{
    // Initialise the result.   
    ComparisonInclusion result = new ComparisonInclusion();
    
    // Differences in any property of RevitParameters will be displayed like this.
    result.DisplayName = parameter1.Name + " (RevitParameter)"; 

    // Check if we have a RevitComparisonConfig input.
    RevitComparisonConfig rcc = comparisonConfig as RevitComparisonConfig;

    // Other logic
    ...
}
```

Note that this method supports Toolkit-specific `ComparisonConfig` objects, like e.g. `RevitComparisonConfig`. See [the section below](/Diffing-and-Hashing:-guide-for-developers#toolkit-specific-comparisonconfig-options) for more details.

# Customising the Hash: `HashString()` extension method

If you want a specific object to be Hashed in a particular way, you can implement a `HashString()` extension method for that object in your Toolkit. The `HashString()` method will get invoked [when computing the Hash()](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/BHoM_Engine/Query/Hash.cs#L217-L221). This is essentially an application of the [_Extension Method discovery pattern_](https://github.com/BHoM/BHoM_Engine/blob/b7b03a0785fc21a7dea21680925a4f94c760ef77/Reflection_Engine/Compute/TryRunExtensionMethod.cs) that is often leveraged in many BHoM methods.

This method must have the following inputs, in this order:
- An object input, which will be the object for which we are calculating the Hash.
- A `string` input, which will indicated the FullName of the property being analysed by the Hash() method (for example when the input object is a property of another object; this can be useful in certain cases, and if not useful can simply be ignored).
- A `BaseComparisonConfig` input, which can be used to  will be passed in by the `Hash()` method.

Here is an example of [`HashString()` for RevitParameters](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Query/HashString.cs):

```cs
public static string HashString(this RevitParameter revitParameter, string propertyFullName = null, BaseComparisonConfig comparisonConfig = null)
{
    // Null check.
    if (revitParameter == null) return null;

    string hashString = revitParameter.Name + revitParameter.Value;

    // Check if we have a RevitComparisonConfig input.
    RevitComparisonConfig rcc = comparisonConfig as RevitComparisonConfig;

    // Other logic
    ...
}
```

Note that this method supports Toolkit-specific `ComparisonConfig` objects, like e.g. `RevitComparisonConfig`. See [the section below](/Diffing-and-Hashing:-guide-for-developers#toolkit-specific-comparisonconfig-options) for more details.

# Toolkit-specific `ComparisonConfig` options

There are cases where you may need more options to further customise the Hash or Diffing process, to refine how they work with your Toolkit's objects.

The "default" [`comparisonConfig` object](https://github.com/BHoM/BHoM/blob/main/BHoM/ComparisonConfig.cs) gives all the default options, and it inherits from the [`BaseComparisonConfig` abstract class](https://github.com/BHoM/BHoM/blob/main/BHoM/BaseComparisonConfig.cs). This abstract class can be extended by the "Toolkit-specific" `comparisonConfig`s, so you can include additional options to deal with certain objects in your Toolkit.  
See an example with Revit's [`RevitComparisonConfig`](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_oM/Config/RevitComparisonConfig.cs).

If you implement your own Toolkit-specific `ComparisonConfig` object, you will need to implement the functions that deal with it too, which should include at least one of:
- A toolkit-specific `Diffing()` method ([example in Revit](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Compute/RevitDiffing.cs)), which your users can call independently, or that may be automatically called by the IDiffing method, [as shown here](/Diffing-and-Hashing%3A-guide-for-developers/#developing-toolkit-specific-diffing-methods).
- A toolkit-specific `HashString()` method ([example in Revit](https://github.com/BHoM/Revit_Toolkit/blob/main/Revit_Engine/Query/HashString.cs)), which will get [invoked when computing the Hash()](https://github.com/BHoM/BHoM_Engine/blob/82c1276ecb10d3d773a6a8e28643787f742e6a43/BHoM_Engine/Query/Hash.cs#L217-L221). 
- Any number of `ComparisonInclusion()` methods that you might need to customise the diffing output per each object ([example in Revit for RevitParameters](https://github.com/BHoM/Revit_Toolkit/blob/a71d99fa93ab5fbad0c01ac14885e090c186ab91/Revit_Engine/Query/ComparisonInclusion.cs#L39-L44)), as explained [here](/Diffing-and-Hashing:-guide-for-developers#customising-the-diffing-output-comparisoninclusion-extension-method). 


# Testing and profiling

We have a [DiffingTests repo](https://github.com/BHoM/DiffingTests_Prototypes) which contains Unit Tests and profiling functions. These are required given the amount of options and use cases that both offer.

