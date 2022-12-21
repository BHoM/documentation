## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/PreviousInputNamesAttributeHasMatchingParameter.cs)

## Details

The `PreviousInputNamesAttributeHasMatchingParameter` check ensures that a given `PreviousInputNames` attribute has a matching input parameter on a method.

This ensures that our documentation is accurate and valid for what users might see.

For example, the following method would fail this check because the input attribute does not match a given input parameter.

```
[PreviousInputNames("hello", "notHello")]
public static void HelloWorld(double goodbye)
{
    
}
```

The correct implementation should instead look like this:

```
[PreviousInputNames("hello", "notHello")]
public static void HelloWorld(double hello)
{
    
}
```