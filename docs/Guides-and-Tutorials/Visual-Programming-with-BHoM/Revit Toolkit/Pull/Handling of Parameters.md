# Handling of parameters on Pull
On Pull, the parameters of a Revit element get wrapped into `RevitParameter` objects, which are collected in `RevitPulledParameters` fragment attached to the BHoM object representing the element. Such parameters can be queried in two ways:

- all in one go using `GetRevitParameters` method
- value of a particular one using `GetRevitParameterValue` method

## Parameter mapping
It may sometimes happen that different families have the same value stored under different parameter names. In such case, there is a need to map the values from more than one source into a single set. This can be done with the use of custom mapping settings that are part of [Revit adapter settings](../../Revit Adapter#settings).

**Note:** The concept of parameter mapping is easy to use, but complex to explain. Therefore, it is recommended to first look at the examples [here](../Pull Examples#inspecting-parameters) and [here](../../Push/Push Examples#pushing-elements-with-parameters) in order to understand the practicalities of it. More details can be found [here](../../../../Coding-with-BHoM/Revit Toolkit/Handling of Parameters).