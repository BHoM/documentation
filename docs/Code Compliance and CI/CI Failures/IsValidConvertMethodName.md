## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsValidConvertMethodName.cs)

## Details

The `IsValidConvertMethodName` check ensures that `Convert` class methods are named correctly based on the guidance for BHoM development.

The guidance, at the time of writing, states that `Convert` methods should go `To` their external software, and `From` their external software, rather than `ToBHoM` or `FromBHoM`.

For example, this `Convert` method will fail:

`public static Span ToBHoM()`

While this one will pass:

`public static Span ToSoftware()`

### Naming conventions

Although not a strict requirement, it is advised that convert method names reflect the software that the convert is going `to` or `from`. This helps make it clear what the external object model is and helps inform users of what to expect when using the convert method.