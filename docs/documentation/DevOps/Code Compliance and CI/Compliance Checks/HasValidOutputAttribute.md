## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasValidOutputAttribute.cs)

## Details

The `HasValidOutputAttribute` check ensures that, if there is a piece of Output documentation is present on a method, that it is of a correct type.

`MultiOutput` documentation should only be used on methods providing multiple outputs using the return type of `Output<t1, t2, ..., tn>`, while `Output` documentation should be present on methods returning a single type.

For example, the following two methods will fail this check because the documentation does not match the return types.

```
[Output("outputVariable", "My output documentation")]
public static Output<bool, string> MyOutputMethod()
{

}
```

```
[MultiOutput(0, "outputVariable", "My output documentation")]
public static bool MyOutputMethod()
{

}
```

These methods **fail** this check because the `MultiOutput` documentation is on a method returning a single type, while the `Output` documentation is on a method returning multiple results. For these methods to pass this check, they should look like this:

```
[MultiOutput(0, "outputVariable", "My output documentation")]
public static Output<bool, string> MyOutputMethod()
{

}
```

```
[Output("outputVariable", "My output documentation")]
public static bool MyOutputMethod()
{

}
```