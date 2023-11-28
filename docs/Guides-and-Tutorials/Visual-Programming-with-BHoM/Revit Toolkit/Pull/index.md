# Revit Pull

Pulling elements from Revit to BHoM means extracting them from the Revit model combined with [converting them to BHoM](Conversion from Revit). In order to perform that action, the adapter needs to be [set up correctly](../Revit Adapter) first. Once this is done, the user needs to specify two basic Pull inputs:

- [**Request**](Requests and Filtering) (which Revit elements are meant to be pulled?) 
- [**Action config**](Action Config) (settings of this particular action - optional, if not specified, default values are used)

Once the adapter and inputs are ready, the Pull action needs to be activated - in visual programming environment this is done by setting its `active` property to `true`.