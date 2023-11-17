### Notes
- It is worth having a look at [Using the BHoM](https://github.com/BHoM/documentation/wiki/Using-the-BHoM) section and the rest of Revit_Toolkit Wiki before reading this page.
- Most of the scripts are presented in both [Grasshopper](Push-in-Grasshopper). All source files are available in [samples](https://github.com/BHoM/samples/tree/master/Revit_Toolkit).

### Pushing elements
As mentioned in [Push to Revit basics](Push-to-Revit-basics#objects) section, Revit element types are name matched BHoM object properties. Therefore, the only property that is relevant for `Construction` of BHoM walls and floors as well as `Property` of BHoM framing elements is their name - all others will be simply ignored on Push.

The scripts below show how to push a primitive building to Revit. To make that happen, **family types with names used in the script need to be loaded to the model**. [`PushType`](Push-types) is set to `CreateOnly`, which means that the attempt to update the existing elements will not be made.

[![Push elements in Grasshopper](https://user-images.githubusercontent.com/26874773/79354045-2a242a80-7f3c-11ea-92b2-5ed66eb374e0.png)](https://user-images.githubusercontent.com/26874773/79354045-2a242a80-7f3c-11ea-92b2-5ed66eb374e0.png)


### Pushing elements with parameters
In order to create a Revit element with predefined values of parameters or to update it, the user first needs to set parameter value using `SetRevitParameter` or `SetRevitParameters` method. First allows to set only one parameter at a time, while the second can take lists of parameter names and values. The example below shows how to push a grid of columns with predefined parameters, either by setting the parameters one by one or in batch.

[![Push elements with parameters](https://user-images.githubusercontent.com/26874773/86146125-167a7000-baf8-11ea-90f7-dffa6051483e.png)](https://user-images.githubusercontent.com/26874773/86146125-167a7000-baf8-11ea-90f7-dffa6051483e.png)

### Pushing framing elements
When pushing framing elements to Revit, they get created exactly in the physical location of the BHoM object regardless the values of parameters, i.e. if the pushed beam is meant to be adjusted to its top face, its final location in space will be exactly same as in BHoM, with vertical adjustment parameter set to _Top_ (its driving curve will move up with regard to the driving curve of the framing in BHoM).

To match the driving curves of a BHoM framing with the adjusted Revit element, one first needs to push the element with the parameters unset, and then update only the parameters using `RevitPushConfig.SetLocationOnUpdate == false`. Both scenarios are shown in the script below.

[![Push framing elements](https://user-images.githubusercontent.com/26874773/86032460-b0c6af00-ba37-11ea-8292-e24c51cd5c23.png)](https://user-images.githubusercontent.com/26874773/86032460-b0c6af00-ba37-11ea-8292-e24c51cd5c23.png)


### ModelInstances and DraftingInstances
`ModelInstances` can be used to push objects of types that are not natively supported by BHoM. A sample below shows how to apply this technique to mechanical ducts.

[![Push model instances in Grasshopper](https://user-images.githubusercontent.com/26874773/79354892-496f8780-7f3d-11ea-92c3-5b0d22929cbc.png)](https://user-images.githubusercontent.com/26874773/79354892-496f8780-7f3d-11ea-92c3-5b0d22929cbc.png)


Similar approach can be used to drafting instances: the next script generates a line load representation of family _Linear Loads_ and type _Load Label 2mm_ in view named _Load Plan Level 0_.

[![Push detail items in Grasshopper](https://user-images.githubusercontent.com/26874773/79354939-58eed080-7f3d-11ea-96cd-39c8e2302427.png)](https://user-images.githubusercontent.com/26874773/79354939-58eed080-7f3d-11ea-96cd-39c8e2302427.png)

If only the name is specified on definition of a model instance or drafting instance, it will be converted into a primitive (model line, detail line, filled region etc.):

[![Push detail lines in Grasshopper](https://user-images.githubusercontent.com/26874773/79354934-57250d00-7f3d-11ea-94fa-e336c56fba98.png)](https://user-images.githubusercontent.com/26874773/79354934-57250d00-7f3d-11ea-94fa-e336c56fba98.png)


### Update
**Note:** Update is currently in prototype stage and might not always work as expected.

Once the element is pulled from Revit, one can e.g. change one of its parameters (by using `SetProperty`) and push back to Revit, as shown in the example below. To update the elements instead of creating new, [`PushType`](Push-types) needs to be set either to `UpdateOnly` or `DeleteThenCreate`.

Worth noting is the fact that error in Grasshopper component is caused by the empty input - once the pull is executed successfully, it will turn standard gray. Similarily, the warning on Push does not always need to mean that the push had not succeeded - it might happen that e.g. the update of location had not worked, but it was not meant to happen actually.

[![Update parameter in Grasshopper](https://user-images.githubusercontent.com/26874773/79356143-dff07880-7f3e-11ea-89ff-cf13e289a170.png)](https://user-images.githubusercontent.com/26874773/79356143-dff07880-7f3e-11ea-89ff-cf13e289a170.png)

Not only elements can be manipulated. Update can be successfully applied to families or types as well, for example to batch rename or changing any other settings. It is worth noting that if the name parameter is left blank on family pull, all families in the model are being pulled in one go.

[![Update family names in Grasshopper](https://user-images.githubusercontent.com/26874773/79356146-e1ba3c00-7f3e-11ea-87b4-e89b738073f0.png)](https://user-images.githubusercontent.com/26874773/79356146-e1ba3c00-7f3e-11ea-87b4-e89b738073f0.png)

### Type update
Revit element type can be updated in 2 ways, either by setting _Type_ parameter to the desired type (or its name) or by setting the defining property of a BHoM object to the name of the desired type. All options are shown in the screenshot below.

[![Type update](https://user-images.githubusercontent.com/26874773/134544689-cd725e88-6798-476c-a27d-37cd5c7761ec.png)](https://user-images.githubusercontent.com/26874773/134544689-cd725e88-6798-476c-a27d-37cd5c7761ec.png)

### Mapping parameters on Push
As explained in [Parameter mapping](Handling-of-Parameters#parameter-mapping) section, values stored in BHoM object's properties and Revit parameter wrappers attached to it can be mapped into parameters of a Revit element or its type under different names. The script below pushes a wall and copies over the name of the BHoM object to the wall's Mark parameter, plus it copies over a single value attached to the BHoM object to two parameters of the wall and its type.

[![Mapping parameters on Push](https://user-images.githubusercontent.com/26874773/86028224-ee283e00-ba31-11ea-9575-f96e67c82ec4.png)](https://user-images.githubusercontent.com/26874773/86028224-ee283e00-ba31-11ea-9575-f96e67c82ec4.png)
