## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/PreviousInputNamesAttributeIsUnique.cs)

## Details

The `PreviousInputNamesAttributeIsUnique` check ensures that there are not duplicate `PreviousInputNames` attributes for the same parameter.

This ensures that our documentation is accurate and valid for what users might see.

For example, the following method would fail this check because the input attribute is duplicated

```
[PreviousInputNamesAttributeIsUnique("hello", "notHello")]
[PreviousInputNamesAttributeIsUnique("hello", "alsoNotHello")]
public static void HelloWorld(double hello)
{
    
}
```

The correct implementation should instead look like this:

```
[PreviousInputNamesAttributeIsUnique("hello", "notHello, alsoNotHello")]
public static void HelloWorld(double hello)
{
    
}
```