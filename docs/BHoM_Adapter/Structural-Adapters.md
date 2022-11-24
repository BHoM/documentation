# Structural Engineering adapters

This page gives examples and outlines the general common behaviour of the adapters communicating with structural engineering software. 

To get an general introduction to how the adapters are working, and how to implement a new one please see the set of wiki pages starting from [Introduction to the BHoM Adapter](/BHoM_Adapter/).

## Specific Structural Engineering adapters

For information regarding software specific adapter features, known issues and object relation tables, please see their toolkit wikis:

- [Robot_Toolkit wiki](https://github.com/BHoM/Robot_Toolkit/wiki)
- [GSA_Toolkit wiki](https://github.com/BHoM/GSA_Toolkit/wiki)
- [Etabs_Toolkit wiki](https://github.com/BHoM/ETABS_Toolkit/wiki)
- [Lusas_Toolkit wiki](https://github.com/BHoM/Lusas_Toolkit/wiki)

## Pushing and pulling elements

Please see [the samples](https://github.com/BHoM/samples/tree/master/Structural_Adapters/Elements) for examples of how to push elements to a software using the adapters.

## Pushing and pulling loads
The objects assigned to the loads need to have been in the software. The reason for this is that the objects need to have been tagged with a CustomData representing their identifier in the software. To achieve this you can

1. First push all the elements, then in a separate step pull them out again and sort out which elements that are applicable to be loaded. (Recomended workflow)
1. Use the objects output of the PushComponent. That adapter will have made sure that all objects coming out from the adapter will have been assigned with the correct tags.

Please see [the samples](https://github.com/BHoM/samples/tree/master/Structural_Adapters/Loads) for examples of how to push elements to a software using the adapters.

## Pulling results

_Examples to be inserted_