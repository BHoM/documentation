Null Handling is the practice of protecting against `null` inputs to methods within the engines and adapters.

`Null` inputs can throw errors that are unhelpful to the user, typically a `object is not set to an instance of an object` exception, which does not provide the user with much information on how to resolve this problem within their chosen UI.

As such, it is good practice to ensure all of the inputs to a method are valid before trying to run operations on them. Take the following method as an example.

```
public static string GetName(BH.oM.Environment.Elements.Panel panel)
{
    string name = "";
    name += panel.Name + " ";
    name += panel.Construction.Name;
    return name;
}
```

If `panel` is `null`, then the line `name += panel.Name + " ";` will throw a `NullReferenceException` as you cannot get the `Name` property of an object with no data associated to it (`null`). This may then confuse the user. Therefore, we should check whether the `panel` is `null` and tell the user before using it.

```
public static string GetName(BH.oM.Environment.Elements.Panel panel)
{
    if(panel == null)
    {
        BH.Engine.Reflection.Compute.RecordError("Panel cannot be null when querying the name. The panel should have data associated to it and be a valid instantiation of the object."); //Suitable error message that helps the user understand what's going on
        return ""; //A suitable return - you could `return null;` here instead if needed
    }

    string name = "";
    name += panel.Name + " ";
    name += panel.Construction.Name;
    return name;
}
```

The return from a `null` check should be appropriate for the return object type. For complex objects (e.g. a BHoM object return type, such as a `Panel` or `Bar`), returning `null` should be appropriate, as empty objects (such as `return new Panel();`) will likely cause more problems down the line if the object is not `null`, but has no data. For primitive types (e.g. `string`, `int`) then returning a suitable default is appropriate, such as an empty string (`""`). For numbers (`int`, `double`, etc.), returning a number should be carefully considered. `0` may be a valid response to the method that the downstream workflow will rely on, so consider returning negative numbers (e.g. `-1`) instead, or numbers outside the realm of reality for the equation (such as `1e10` or `-1e10` for large and small numbers respectively). The same is for `bool` return types, consider what `true` or `false` may imply further down the line and return the appropriate response. For collections, empty collections are appropriate.

The final decision for what the return should be will reside with the relevant toolkit lead, who should take into consideration the expected use cases and user stories.

The error message should also convey to the user which bit of the data is `null` and what they need to fix it. Consider the above example, the `panel` may not be `null` but the `Construction` property might be. Therefore `panel.Construction.Name` will also throw a `NullReferenceException`.

### IsNull

For complex objects, with multiple properties to check, you may wish to implement an `IsNull` check query method, which takes the object and checks all of the nested data to check if any of it is `null` and returns a `true` or `false` and an error message if anything was `null`. An example of this can be seen in [the Structure_Engine `IsNull` method](https://github.com/BHoM/BHoM_Engine/blob/master/Structure_Engine/Query/IsNull.cs) which checks objects and their complex properties. This is useful for areas where the entire object must have valid data, but may not be appropriate for other instances. It is toolkit lead and developer discretion as to which way null checks should be handled in a given method.

### Cheat Sheet

The following cheat sheet can be used as a guideline for what should be the default return type if a `null` check has failed for different types. This is not the definitive list, and many occasions may do something different with suitable justification. But if in doubt, the following can be used and would be accepted in 99 cases out of 100.

| Return type | Return value | 
| ------------- | ------------- |
| `int`, `decimal` | `-1` or `0` - whichever is the most appropriate downstream |
| `double` | `double.NaN` or `-1` or `0` - whichever is the most appropriate downstream |
| `float` | `float.Nan` or `-1` or `0` - whichever is the most appropriate downstream |
| `string` | `""` or `null` - whichever is the most appropriate downstream |
| `bool` | `false` or `true` - whichever is the most appropriate downstream (will depend on what the method is doing, e.g. a query for `HasConstruction` could return `false` appropriately because a `null` object cannot have a construction) |
| `List` or other `IEnumerable` | Empty list (`new List<object>();`) or `null` |
| Complex object (e.g. a `BHoMObject` such as `Panel` or `Bar` | `null` |
