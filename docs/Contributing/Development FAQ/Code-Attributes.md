## General

The BHoM framework makes use of [attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/) to annotate and explain classes, methods and properties. Attributes used is a combination custom attributes created in the BHoM and the one provided by the core C# libraries.

The information provided in the attributes will be used by the UI and help control what is exposed as well as give the end user a better understanding of what your method is supposed to do.

To make use of the custom attributes you will need to make sure that your project has a reference to the `Base_oM`. You will also need to to make sure that the following usings exists in the .cs file you want to use the attributes in:

```
using BH.oM.Base.Attributes;
using System.ComponentModel;
```

The attributes are described below.

### Description

Only consists of a single string and can be used on a class, method or a property. Used to give a general explanation of what the class/ method or property is doing. You can only add one description to each entity. Example:

```
        [Description("Calculates the counterclockwise angle between two vectors in a plane")]
        public static double Angle(this Vector v1, Vector v2, Plane p)
        {
            //....code
        }
```



#### Description authoring guidelines ✏️ 


We should be aiming for _all_ properties, objects and methods to have a description. With only the very simplest of self explanatory properties to not require a description by exception - and indeed only where the below guidelines can not be reasonably satisfied. 

So what makes a good description?

1. A description must impart additional useful information beyond the property name, object and namespace. 
2. Further to a definition, the description is an opportunity to include usage guidance, tips or additional context.
3. The description is a place you can include synonyms etc. to help clarify for others in different regions/domains, being inclusive as possible.
4. Also don't forget the addition of a [Quantity Attribute](https://github.com/BHoM/BHoM/tree/master/Quantities_oM/Attributes) can be used now, appropriate for Doubles and Vectors.

### DisplayText

Only consists of a single string and can be used on enums. Used to provide a human-friendly text version of the enum in the UI. Example:

```
    public enum Market
    {
        Undefined,
        [DisplayText("Europe ex UK & Ireland")]
        Europe_ex_UKAndIreland,
        India,
        [DisplayText("Middle East")]
        MiddleEast,
        [DisplayText("Other UK & Ireland")]
        Other_UKAndIreland,
        ...
    }
```


### Input
Used on methods to describe the input parameters. Consists of two strings, name and description. The name need to correspond to the name of the parameter used in the method and the description is used the explain the methods purpose. Multiple input tags can be used for the same method. Examples:

```
        [Input("obj", "Object to be converted")]
        public static string ToJson(this object obj)
        {
            //....code
        }
```

```
        [Input("externalBoundary", "The outer boundary curve of the surface. Needs to be closed and planar")]
        [Input("internalBoundaries", "Optional internal boundary curves descibing any openings inside the external. All internal edges need to be closed and co-planar with the external edge")]
        public static PlanarSurface PlanarSurface(ICurve externalBoundary, List<ICurve> internalBoundaries = null)
        {
            //....code
        }
```

### Output
Used on methods to describe the resulting return object. Consists of two strings, name and description. The name will be used by the UIs to name the result of the method and the description will help explain the returned object. You can only add one output to each method. Example:

```
        [Output("List", "Filtered list containing only objects assignable from the provided type")]
        public static List<object> FilterByType(this IEnumerable<object> list, Type type)
        {
            //....code
        }
```

### NotImplemented
Used on methods that are not yet implemented. Method with this tag will not be exposed in the UIs. Example:

```
        [NotImplemented]
        public static double Length(this NurbsCurve curve)
        {
            throw new NotImplementedException();
        }
```

### PreviousVersion
The previous version attribute helps with code versioning of methods when a method has been changed in terms of name, namespace or input parameters. Example of how to use it see [Method versioning](/Versioning---How-to-modify-code-without-breaking-user-scripts#modifying-methods)

### Replaced
Used on a method that is being replaced by another method and is to be deleted in coming versions while no automatic versioning is possible. **_This attribute should only be used when [Versioning](/Versioning---How-to-modify-code-without-breaking-user-scripts) is impossible!_** This attribute will hide the method from the method tree in the UIs as long as the `FromVersion` property is lower or equal to the assembly file version and thereby make it impossible to create any new instances of the method. Any existing scripts will still work and reference the method. To read more about method deprecation strategy [please see here](/Backwards-compatibility).

The deprecated attribute has four properties:

- `string` Description - Description as to why the method is being replaced.
- `Version` FromVersion - Which version was this method replaced. Here you generally only have to specify the first two digits, for example `2.3`.
- `Type` ReplaceingType - Where can you find any replacing method (if it exists)
- `string` ReplacingMethod - What is the name of the replacing method (if it exists)

Example:

```
        [Replaced(new Version(2,3), "Replaced with CurveIntersections.", null, "CurveIntersections")]
        public static List<Point> CurvePlanarIntersections(this Arc curve1, Circle curve2, double tolerance = Tolerance.Distance)
        {
            //....code
        }
```

### ToBeRemoved
Attribute only to tag a class or method that is to be removed. **_This attribute should only be used when [Versioning](/Versioning---How-to-modify-code-without-breaking-user-scripts) is impossible!_** This attribute will hide the method from the method tree in the UIs as long as the `FromVersion` property is lower or equal to the assembly file version and thereby make it impossible to create any new instances of the method.

