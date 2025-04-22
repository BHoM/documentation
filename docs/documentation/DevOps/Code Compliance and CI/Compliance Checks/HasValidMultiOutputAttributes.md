## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasValidMultiOutputAttributes.cs)

## Details

The `HasValidMultiOutputAttributes` check ensures that a method returning a type of `Output<t, ..., tn>` has a matching number of `MultiOutput` attributes documenting the returned objects.

For example, a method returning `Output<Panel, Opening>` would require 2 `MultiOutput` attributes to document both the `Panel` and the `Opening`.