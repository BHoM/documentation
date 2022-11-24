## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/ModifyReturnsSameType.cs)

## Details

The `ModifyReturnsSameType` check ensures that `Modify` methods return the same type as the first input. This ensures that the modify methods are giving users back the same object type they're putting in.

For example, the following method would fail because the return type is not the same as the first input.

`public static Opening AddOpenings(this Panel panel)`

Whereas this method will pass because the return type matches the input type.

`public static Panel AddOpenings(this Panel panel)`