# Revit Remove

Removing elements from Revit to BHoM works very similar to [pulling], with the difference that the Revit elements get removed instead of extracted and converted to BHoM. In order to perform Remove action, the adapter needs to be [set up correctly](../Revit Adapter) first. Once this is done, the user needs to specify two basic Remove inputs:

- [**Request**](../Pull/Requests and Filtering) (which Revit elements are meant to be removed?) 
- [**Action config**](Action Config) (settings of this particular action - optional, if not specified, default values are used)

Once the adapter and inputs are ready, the Remove action needs to be activated: in visual scripting environments, this is done by setting its `active` property to `true`.