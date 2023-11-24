# Handling of Parameters

Efficient handling of Revit parameters is one of the key features of Revit_Toolkit. It is possible thanks to `RevitParameter` BHoM wrappers that are being generated per each parameter of an element (and its type) on Pull and unwrapped on Push. 

`RevitParameters` are stored in dedicated fragments that are attached to the BHoM object correspondent with the Revit element. For full control over what is pulled vs what is pushed, separate fragments for Pull (`RevitPulledParameters`) and Push (`RevitParametersToPush`) are used.

Diagram below shows the relationship between `RevitPulledParameters` and Push `RevitParametersToPush`:

![UpdateParameters](https://user-images.githubusercontent.com/26874773/85868605-cd11e400-b7ca-11ea-9880-32b20b6237a9.png)

## Getting and setting parameter values in one diagram
The diagram below shows how to get or set the parameter values depending on whether they are type or instance.

![Revit parameter value workflow](https://user-images.githubusercontent.com/26874773/151384428-d7a34049-64b3-4b7e-adf6-16637ad3135e.png)

## Parameter mapping
It may sometimes happen that different families have the same value stored under different parameter names. In such case, there is a need to map the values from more than one source into a single set. This can be done with the use of custom mapping settings that are part of [Revit adapter settings](../../../Visual Programming with BHoM/Revit Toolkit/Revit Adapter#settings).

`MappingSettings` object has a property named `ParameterMaps` that can contain parameter maps, each containing a set of `ParameterLinks` that define following relationships:
- relationship between the name of a Revit parameter and the name of a property of a BHoM object, to which its value will be assigned on Pull
- relationship between the name of a Revit parameter and the name under which the value will be stored in `RevitPulledParameters` on Pull
- the opposite to the first: relationship between the name of a property of a BHoM object, which value will be assigned to a given Revit parameter on Push
- the opposite to the second: relationship between the name under which the value is stored in `RevitParametersToPush` and the name of a Revit parameter to which it will be assigned on Push

If multiple Revit parameter names will be mapped into one name on the BHoM side:
- on Pull: first parameter found in the Revit element under one of the specified names will be copied over to the BHoM object
- on Push: the value originating from the BHoM object will be copied over to the first existing parameter found in the Revit element under one of the specified names

What is more, mapping can also be applied to type parameters, using `ElementTypeParameterLinks`.

Parameter maps are created per type, therefore a map specified for columns will not affect e.g. walls. The whole concept is mapped out in the diagram below.

![ParameterSettings](https://user-images.githubusercontent.com/26874773/82684268-95a39b00-9c52-11ea-928f-67563474b930.png)