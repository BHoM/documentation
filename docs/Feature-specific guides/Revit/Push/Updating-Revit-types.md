# Revit Adapter: updating Revit types

In many scenarios, one may want to update the type of a Revit element previously pulled to BHoM. There are three ways to achieve that:
- setting the name of the defining property of a BHoM object (e.g. `Construction` of a wall or `Property` of a beam) to the name of the desired element type using `SetProperty` method - this is the standard way leveraging the name matching mechanism as explained in [Conversion to Revit section](Revit-BHoM-conversion#conversion-to-revit)
- setting the _Type_ parameter to the name of the desired new type using `SetRevitParameter`
- setting the _Type_ parameter to the object representing the desired new type using `SetRevitParameter` (the name will be extracted from the provided object)

Each of the above should yield same result, leading to updating the element type in Revit.

[![Update type in Grasshopper](https://user-images.githubusercontent.com/26874773/151376779-962c30ed-ea22-47c2-bb22-d615d74deeb5.png)](https://user-images.githubusercontent.com/26874773/151376779-962c30ed-ea22-47c2-bb22-d615d74deeb5.png)