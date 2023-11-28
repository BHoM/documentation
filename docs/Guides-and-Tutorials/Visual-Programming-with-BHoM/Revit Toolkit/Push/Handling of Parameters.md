# Handling of parameters on Push

## Setting Parameters on Push
Out of the box, default parameter values will be assigned when creating a Revit element based on a BHoM object. This can be overwritten by setting the parameters to push with `SetRevitParameter` method. Similarly, when an existing element is updated on Push, only the parameters explicitly instructed to be overwritten (`SetRevitParameter` method) will change.

By default, when a Revit element gets updated, first its parameters are overwritten and then the location is updated. This means that if the user sets values to location-related parameters, the change may not take place due to being superseded by location update. To avoid that, it is possible to prevent the element's location from being updated by switching `SetLocationOnUpdate` property of [`RevitPushConfig`](../Action Config) to `false`.

Basic examples are available [here](../Push Examples#pushing-elements-with-parameters).

## Pushing new Parameter definitions
It is possible to create new Revit parameters (project or shared ones) by pushing a `BH.oM.Adapters.Revit.Parameters.ParameterDefinition` object.

## Parameter mapping
It may sometimes happen that different families have the same value stored under different parameter names. In such case, there is a need to map the values from more than one source into a single set. This can be done with the use of custom mapping settings that are part of [Revit adapter settings](../../Revit Adapter#settings).

**Note:** The concept of parameter mapping is easy to use, but complex to explain. Therefore, it is recommended to first look at the examples [here](../../Pull/Pull Examples#mapping-parameters-on-pull) and [here](../Push Examples#mapping-parameters-on-push) in order to understand the practicalities of it. More details can be found [here](../../../Coding-with-BHoM/Revit Toolkit/Handling of Parameters.md).