## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/ModifyReturnsDifferentType.cs)

## Details

The `ModifyReturnsDifferentType` check ensures that `Modify` methods return either `void` or a different type to the first input. Methods returning `void` will be returning the first input parameter, modified by the method, to the user in a visual programming environment. Further information is available [here](https://github.com/BHoM/admin/issues/11) and [here](https://github.com/BHoM/BHoM/discussions/1031#discussioncomment-106258).

For example, the following method would fail because the return type is the same as the first input.

`public static Panel AddOpenings(this Panel panel)`

Whereas this method will pass because the return type is different from the input type.

`public static Opening AddOpenings(this Panel panel)`

And this method will pass because its return type is `void` and will return the first input object to the user in a visual programming environment.

`public static void AddOpenings(this Panel panel)`