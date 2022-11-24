## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/MethodNameStartsUpper.cs)

## Details

The `MethodNameStartsUpper` check ensures that method declarations start with an uppercase character.

For example, the following method declaration would fail this check because the method name begins with a lowercase character.

`public static void helloWorld()`

While this one will pass because it starts with an uppercase character.

`public static void HelloWorld()`