# Revit Push

Pushing from BHoM to Revit can be simply explained as creation of Revit elements based on BHoM objects. In order to perform that action, the adapter needs to be [set up correctly](../Revit Adapter) first. Once this is done, the user needs to specify the first 2 of these 3 inputs:

1. [**Objects**](Conversion to Revit): the objects you want to push to Revit from BHoM.
2. [**Push type**](Push Types): decides whether the existing Revit elements should be replaced by the new ones, or just updated, or never replaced, etc.
3. [**Action config**](Action Config) (optional) settings of this particular Action.

Besides that, a tag can be added to all newly created elements. Once the adapter and inputs are ready, the Push action needs to be activated - in visual programming environment this is done by setting its `active` property to `true`.