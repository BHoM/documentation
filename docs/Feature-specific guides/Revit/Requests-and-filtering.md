Requests are used to filter the elements in Revit document that are meant to be processed (e.g. pulled or removed). Currently there is over 20 requests available in Revit_Toolkit that could be divided into three categories presented below. Practical implementation of the requests is discussed in [Pull examples](Pull-examples).

### Filtering all Revit elements by properties
First category that could be distinguished, are Requests that force parsing all elements in the model looking for certain feature, e.g. workset or parameter value. Name of such requests start with a prefix _FilterBy_.

| Request | Description |
|----------------|--------------|
| `FilterByBHoMType` | Filters Revit elements based on their correspondent BHoM Type. Wrapper for `BH.oM.Data.Requests.FilterRequest`. |
| `FilterBySelection` | Filters elements selected in Revit. Wrapper for `BH.oM.Data.Requests.SelectionRequest`. |
| `FilterByActiveWorkset` | Filters all elements in active Revit workset. |
| `FilterByCategory` | Filters all elements of a Revit category. |
| `FilterByDBTypeName` | Filters all elements of given Autodesk.Revit.DB type. Information about types can be found in the Revit API documentation. |
| `FilterByElementIds` | Filters elements by their ElementIds. |
| `FilterByFamilyType` | Filters all elements of given Revit family type. |
| `FilterByFamilyAndTypeName` | Filters all elements of given Revit family and type, with option to loose the search by leaving one of the input names blank. |
| `FilterByParameterBool` | Filters elements based on given Boolean parameter value criterion. |
| `FilterByParameterElementId` | Filters elements based on given ElementId parameter value criterion." |
| `FilterByParameterExistence` | Filters elements the have (or do not have) a parameter with given name. |
| `FilterByParameterInteger` | Filters elements based on given integer parameter value criterion. |
| `FilterByParameterNumber` | Filters elements based on given floating point number parameter value criterion. |
| `FilterByParameterText` | Filters elements based on given text parameter value criterion. |
| `FilterByScopeBox` | Filters elements located at least partially inside a given Revit Scope Box. |
| `FilterBySelectionSet` | Filters elements contained in a given Revit Selection Set. |
| `FilterByUniqueIds` | Filters elements by their UniqueIds. |
| `FilterByUsage` | Filters used/unused elements in a Revit document. |
| `FilterByViewSpecific` | Filters elements specific to (owned by) a given view in Revit. |
| `FilterByVisibleInView` | Filters all elements visible in a given Revit view. |
| `FilterByWorkset` | Filters all elements in a given Revit workset. |

### Filtering Revit elements of given feature
Another specific group of Requests are the ones parsing only elements that have a given feature, e.g. are families or model elements. Names of such requests start with a prefix _Filter[FeatureName]_.
| Request | Description |
|----------------|--------------|
| `FilterActiveView` | Filters the active view in Revit. |
| `FilterFamilyByName` | Filters Revit families by name. If the family name is left blank, all families will be filtered. |
| `FilterFamilyTypeByName` | Filters Revit family types by names of theirs and their parent family, with option to loose the search by leaving one or both of the input names blank. |
| `FilterMemberElements` | Filters elements being members of selection sets, assemblies, systems etc. |
| `FilterModelElements` | Filters elements that have geometrical representation in the Revit model. |
| `FilterTypesOfFamily` | Filters Revit family types that belong to a given Revit family. |
| `FilterViewByName` | Filters Revit views by name. If the view name is left blank, all families will be filtered. |
| `FilterViewsByTemplate` | Filters all Revit views that implement a given view template. |
| `FilterViewsByType` | Filters all views of given type. |
| `FilterViewTemplateByName` | Filters Revit view templates by name. If the template name is left blank, all view templates will be filtered. |

### Special Requests
Last group of Requests are the special ones that do not fall into neither of the above categories.
| Request | Description |
|----------------|--------------|
| `EnergyAnalysisModelRequest` | Filters all elements that are contained in Revit's energy analysis model. |
| `FilterEverything` | Filters all elements in the model. This means a lot of data - please use carefully! |
| `LogicalOrRequest` | Logical structure that allows joining multiple requests using [OR statement](https://en.wikipedia.org/wiki/OR_gate). |
| `LogicalAndRequest` | Logical structure that allows joining multiple requests using [AND statement](https://en.wikipedia.org/wiki/AND_gate). |
| `LogicalNotRequest` | Logical structure that inverts the query specified by the input request, i.e. any object that fits this request will be excluded from a pull. |

### Programmatic filtering
On code level, each Revit-applicable type that inherits from `IRequest` is coupled with a `BH.Revit.Engine.Core.ElementIds` method that extracts the ElementIds of Revit elements that match the requirements it imposes. These methods can be used without prior creation of `IRequest`.