## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/InputParameterStartsLower.cs)

## Details

The `InputParameterStartsLower` check ensures that method input variables (parameters) start with a lowercase letter.

This example would fail this check, because the variable name starts with an uppercase character.

`public static void HelloWorld(double Hello)`

While this example will pass because the variable name starts with a lowercase character.

`public static void HelloWorld(double hello)`