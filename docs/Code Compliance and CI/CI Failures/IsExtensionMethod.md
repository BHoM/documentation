## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsExtensionMethod.cs)

## Details

The `IsExtensionMethod` check makes sure that an engine method within a **query, modify, or convert** class is classed as an extension method to the first object type. Extension methods are made by using the `this` keyword prior to the declaration of the first input parameter. If a method does not take any inputs to operate, then it is exempt from this check.

For example, the following method declaration will fail this check, because it is missing the `this` keyword before the first object:

```
public static bool MethodIsValid(Panel myPanel, Opening myOpening)
{
    return false;
}
```

Whereas this method will pass the check, because the first parameter contains the `this` keyword to make the method an extension method.

```
public static bool MethodIsValid(this Panel myPanel, Opening myOpening)
{
    return false;
}
```

Methods within the Compute and Create classes are exempt from this check.

Files contained within an Engines `Objects` folder are exempt from this check (e.g. files with the file path `Your_Toolkit/Toolkit_Engine/Objects/Foo.cs` will be exempt).