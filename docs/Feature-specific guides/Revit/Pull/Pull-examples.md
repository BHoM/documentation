# Revit Pull examples

- It is worth having a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section and the rest of Revit_Toolkit Wiki before reading this page.
- Most of the scripts are presented in [Grasshopper](Pull-in-Grasshopper). All source files are available in [samples](https://github.com/BHoM/samples/tree/master/Revit_Toolkit).

### Pulling selection
One of the more practical ways to specify elements for pull is simply selecting them in Revit and using `FilterBySelection`.

[![Pull selection in Grasshopper](https://user-images.githubusercontent.com/26874773/78938992-9376ea00-7ab3-11ea-9826-df4177714257.png)](https://user-images.githubusercontent.com/26874773/78938992-9376ea00-7ab3-11ea-9826-df4177714257.png)


### Inspecting parameters
As explained in [Handling of parameters](Handling-of-Parameters) section, each BHoM object representing a pulled Revit element has a fragment containing information about all parameters of the latter. These can be queried either as a batch or only value of a chosen one can be extracted. The example below shows both options excercised on a pulled wall.

[![Inspect parameters](https://user-images.githubusercontent.com/26874773/86139774-6b19ed00-baf0-11ea-9b96-76e01ce746b3.png)](https://user-images.githubusercontent.com/26874773/86139774-6b19ed00-baf0-11ea-9b96-76e01ce746b3.png)

### Advanced filters
It is possible to combine multiple filters with each other to create very specified queries. The example below shows how to pull all elements that can be converted to either structural bars or structural panels, which also have a parameter _Enable Analytical Model_ (checkbox type) equal to `true`.

[![Complex request 1 in Grasshopper](https://user-images.githubusercontent.com/26874773/87020691-7ea21380-c1d4-11ea-8df3-8e3048f76861.png)](https://user-images.githubusercontent.com/26874773/87020691-7ea21380-c1d4-11ea-8df3-8e3048f76861.png)

------

Sometimes pull needs to be done in more than one step. Below it is shown how to first pull the active view and then use it to pull all detail items that belong to it. As can be seen, FilterByViewSpecific takes BHoMObject as an argument - it _knows_ that this object represents a given Revit view thanks to relationship explained in [BHoM vs Revit identity](BHoM-vs-Revit-identity) section.

[![Complex request 2 in Grasshopper](https://user-images.githubusercontent.com/26874773/78998013-05007800-7b48-11ea-8b2d-2c8c10888f7b.png)](https://user-images.githubusercontent.com/26874773/78998013-05007800-7b48-11ea-8b2d-2c8c10888f7b.png)

------

Another example of two step pull is pulling family type: first the family itself is pulled, then it is queried for all its types. Worth noting is the fact that error in Grasshopper component is caused by the empty input - once the pull is executed successfully, it will turn standard gray.

[![Complex request 3 in Grasshopper](https://user-images.githubusercontent.com/26874773/78998338-b30c2200-7b48-11ea-82ee-53342b907cc9.png)](https://user-images.githubusercontent.com/26874773/78998338-b30c2200-7b48-11ea-82ee-53342b907cc9.png)

It is important to distinguish pulling types (above) from pulling elements of a given type. Example below shows the latter (pulling actual HEA 300 beams, instead of HEA 300 family type).

[![Complex request 4 in Grasshopper](https://user-images.githubusercontent.com/26874773/78999097-3c702400-7b4a-11ea-87bf-085ae304d812.png)](https://user-images.githubusercontent.com/26874773/78999097-3c702400-7b4a-11ea-87bf-085ae304d812.png)

------

The next example shows how to pull plan views, which name starts with _Structural_ prefix. Such view can be then manipulated (with [Push](Push-examples#update)) or used for further queries.

[![Complex request 5 in Grasshopper](https://user-images.githubusercontent.com/26874773/78999239-848f4680-7b4a-11ea-8d37-f5838155e17d.png)](https://user-images.githubusercontent.com/26874773/78999239-848f4680-7b4a-11ea-8d37-f5838155e17d.png)

------

For those familiar with [Revit API](https://www.revitapidocs.com), it is possible to filter the elements by their API type. It is worth noticing that this method works only for types that inherit from `Autodesk.Revit.DB.Element`.

[![Complex request 6 in Grasshopper](https://user-images.githubusercontent.com/26874773/78999350-b7393f00-7b4a-11ea-91b4-dedca037ee85.png)](https://user-images.githubusercontent.com/26874773/78999350-b7393f00-7b4a-11ea-91b4-dedca037ee85.png)

### Disciplines
As mentioned in [Conversion from Revit](Revit-BHoM-conversion#conversion-from-revit) section, depending on the discipline set in Action config, Revit elements can be converted to different BHoM objects. A vivid example of that is shown in the script below. Revit walls are being converted to:
- `BH.oM.Physical.Elements.Wall` for Physical discipline
- `BH.oM.Structure.Elements.Panel` for Structural discipline
- `BH.oM.Environment.Elements.Panel` for Environmental discipline

[![Pull disciplines in Grasshopper](https://user-images.githubusercontent.com/26874773/78989255-6a963980-7b33-11ea-92fd-699b7f336d25.png)](https://user-images.githubusercontent.com/26874773/78989255-6a963980-7b33-11ea-92fd-699b7f336d25.png)


### Pulling energy analysis model
Energy analysis is a specific discipline that requires information about meta information (e.g. topology or building location) that is often not needed for other disciplines. Therefore `EnergyAnalysisModelRequest` in order to ease the process of pulling comprehensive data from Revit energy analysis model.

[![Pull energy analysis model in Grasshopper](https://user-images.githubusercontent.com/26874773/78938834-3e3ad880-7ab3-11ea-8ced-591efa11efae.png)](https://user-images.githubusercontent.com/26874773/78938834-3e3ad880-7ab3-11ea-8ced-591efa11efae.png)

### Pulling edges
A _hidden_ feature of action config: pulling any elements together with their geometry as shown in Revit! In case below, of framing elements. As explained in [Pull of Geometry and Representation](Pull-of-Geometry-and-Representation) section, the edges are stored in BHoM object's `CustomData` under _Revit_edges_ key - easiest way to retrieve it is to use `GetProperty` component (only in Grasshopper), alternatively the object and its `CustomData` can be decomposed with `Explode`.

[![Pull edges in Grasshopper](https://user-images.githubusercontent.com/26874773/78990081-c661c200-7b35-11ea-905f-53d0933e852d.png)](https://user-images.githubusercontent.com/26874773/78990081-c661c200-7b35-11ea-905f-53d0933e852d.png)


### Pulling representations
Is it also possible to pull the mesh representation of a Revit element - this can be achieved by setting `RepresentationConfig` of the `RevitPullConfig` as explained in [Pull-of-Geometry-and-Representation](Pull-of-Geometry-and-Representation) section.

[![Pull representation](https://user-images.githubusercontent.com/26874773/85882268-40255580-b7df-11ea-86e7-573d998da59f.png)](https://user-images.githubusercontent.com/26874773/85882268-40255580-b7df-11ea-86e7-573d998da59f.png)

### Mapping parameters on Pull
As explained in [Parameter mapping](Handling-of-Parameters#parameter-mapping) section, values stored in parameters of a Revit element or its type under different names can be mapped into a single parameter wrapper in BHoM. The script below pulls all columns from the model and copies over from their type parameter values named _b_ or _Height_ to a single BHoM parameter named _ProfileHeight_. What is more, it overwrites BHoM objects' names with _Column Location Mark_ parameter values.

**Note:** The script is meant to be run with the Revit sample named _rst_basic_sample_project.rvt_ available in Revit samples folder.
[![Mapping parameters on Pull](https://user-images.githubusercontent.com/26874773/86023199-a56d8680-ba2b-11ea-883f-4341aed6cc55.png)](https://user-images.githubusercontent.com/26874773/86023199-a56d8680-ba2b-11ea-883f-4341aed6cc55.png)
