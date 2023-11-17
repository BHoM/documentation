In some cases, on Pull, the elements of one Revit API type and belonging to one Revit category are meant to be converted into a few different BHoM types. An example of this may be `FamilyInstance` belonging to _Mechanical Equipment_ category - this potentially could be converted to multiple BHoM types, such as `Exhaust`, `Fan` etc. This would not be possible out of the box, but can be achieved using family maps in `MappingSettings`.

The picture below shows an example of `MappingSettings` structured in a way that will map elements from families _BHE_GenericModels_OpeningRectangular_Wall_ and _BHE_GenericModels_OpeningRectangular_Floor_ to `BH.oM.Architecture.BuildersWork.Opening`, plus it will map the _BHE_Height_ parameter to `Height` property of the output BHoM object as well as _BHE_Width_ to `Width`.

Mapping has been also covered in the [Pull examples](https://github.com/BHoM/Revit_Toolkit/wiki/Pull-examples#mapping-parameters-on-pull).

![mapping](https://user-images.githubusercontent.com/26874773/134541156-0c7c87aa-a0af-4294-8799-9245387c72c4.png)
