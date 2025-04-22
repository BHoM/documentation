## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/MethodNameContainsFileName.cs)

## Details

The `MethodNameContainsFileName` check ensures that method names within Engine files (with the exception of `Create` methods) at least partially match the file name.

For example, a method `BHoMTypeList()` can exist inside a file `TypeList.cs`, because the method name contains the file name. However, `BHoMTypeCollection()` would not be valid as `TypeList.cs` is not contained within the method name.