## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/InputAttributesAreInOrder.cs)

## Details

The `InputAttributesAreInOrder` check ensures that any `Input` or `InputFromProperty` attributes are in the same order as the input parameters for the given method.

This ensures that our documentation is easy to follow for developets.

For example, the following methods would fail this check because the input attribute not in the same order as the method input parameters.

```
[Input("hello", "My variable")]
[Input("goodbye", "Also my variable")]
public static void HelloWorld(int goodbye, double hello)
{
    
}
```

```
[Input("goodbye", "My variable")]
[InputFromProperty("hello")]
public static void HelloWorld(double hello, double goodbye)
{
    
}
```

The correct implementation should instead look like this:

```
[Input("goodbye", "My variable")]
[Input("hello", "Also my variable")]
public static void HelloWorld(int goodbye, double hello)
{
    
}
```

```
[InputFromProperty("hello")]
[Input("goodbye", "My variable")]
public static void HelloWorld(double hello, double goodbye)
{
    
}
```