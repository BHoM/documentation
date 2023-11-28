# Matching Revit elements with BHoM objects
Exchange of information between Revit and BHoM often requires linking the objects from both sides with each other, e.g. when querying the model for changes or updating it. The mutual relationship is being created and maintained as follows:

- On **Pull**, the identifiers of pulled Revit element are stored in `RevitIdentifiers` fragment attached to the resultant BHoM object.
- On **Push**, Revit element is being considered correspondent to a BHoM object when the latter contains a `RevitIdentifiers` fragment with value of `ElementId` property equal to the ElementId of the former.

### RevitIdentifiers
As mentioned in the previous section, the information about identity of a Revit element correspondent to a BHoM object is stored in `RevitIdentifiers` fragment of the latter. That fragment contains a few important pieces of information:

- `PersistentId` - global, software-agnostic identifier used by BHoM, in Revit correspondent to element's UniqueId
- `ElementId` - ElementId of the Revit element correspondent to the BHoM object
- `CategoryName` - Category of the Revit element correspondent to the BHoM object
- `FamilyName` - Family of the Revit element correspondent to the BHoM object
- `FamilyTypeName` - Family type of the Revit element correspondent to the BHoM object
- `FamilyTypeId` - ElementId of family type of the Revit element correspondent to the BHoM object
- `Workset` - Workset of the Revit element correspondent to the BHoM object
- `HostId` - ElementId of the Revit element hosting the Revit element correspondent to the BHoM object
- `OwnerViewId` - ElementId of view that owns the Revit element correspondent to the BHoM object
- `ParentElementId` - ElementId of the parent element of the Revit element correspondent to the BHoM object
- `LinkPath` - path to the link document that owns the Revit element correspondent to the BHoM object

The identifiers of a BHoM object can be retrieved with `GetRevitIdentifiers` method.