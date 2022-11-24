## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasUniqueMultiOutputAttributes.cs)

## Details

The `HasUniqueMultiOutputAttributes` check ensures that a method returning a type of `Output<t, ..., tn>` has a matching number of `MultiOutput` attributes that have unique indexes.

For example, a method returning `Output<Panel, Opening>` would require 2 uniquely indexed `MultiOutput` attributes to document both the `Panel` and the `Opening`.

If the method looked like the below, while containing 2 `MultiOutput` attributes, would fail this check, because the index for both outputs cannot be `0`.

```
[MultiOutput(0, "panel")]
[MultiOutput(0, "opening")]
public static Output<Panel, Opening> MyTestMethod()
{
}
```

The method should instead look like this:

```
[MultiOutput(0, "panel")]
[MultiOutput(1, "opening")]
public static Output<Panel, Opening> MyTestMethod()
{
}
```

Where the index of the `MultiOutput` attributes is unique.