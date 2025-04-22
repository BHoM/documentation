## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/InputAttributeHasMatchingParameter.cs)

## Details

The `InputAttributeHasMatchingParameter` check ensures that a given `Input` or `InputFromProperty` attribute has a matching input parameter on a method.

This ensures that our documentation is accurate and valid for what users might see.

For example, the following methods would fail this check because the input attribute does not match a given input parameter.

```
[Input("hello", "My variable")]
public static void HelloWorld(double goodbye)
{
    
}
```

```
[InputFromProperty("hello")]
public static void HelloWorld(double goodbye)
{
    
}
```

The correct implementation should instead look like this:

```
[Input("hello", "My variable")]
public static void HelloWorld(double hello)
{
    
}
```

```
[InputFromProperty("hello")]
public static void HelloWorld(double hello)
{
    
}
```