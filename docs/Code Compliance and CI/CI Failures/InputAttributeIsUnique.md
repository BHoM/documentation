## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/InputAttributeIsUnique.cs)

## Details

The `InputAttributeIsUnique` check ensures that there are not duplicate `Input` or `InputFromProperty` attributes for the same parameter.

This ensures that our documentation is accurate and valid for what users might see.

For example, the following methods would fail this check because the input attribute is duplicated

```
[Input("hello", "My variable")]
[Input("hello", "Also my variable")]
public static void HelloWorld(double hello)
{
    
}
```

```
[Input("hello", "My variable")]
[InputFromProperty("hello")]
public static void HelloWorld(double hello, double goodbye)
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
[Input("hello", "My variable")]
[InputFromProperty("goodbye")]
public static void HelloWorld(double hello, double goodbye)
{
    
}
```