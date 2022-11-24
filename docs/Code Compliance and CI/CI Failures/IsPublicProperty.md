## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsPublicProperty.cs)

## Details

The `IsPublicProperty` check ensures that object properties are public using the public modifier.

The follow object property would fail this check because the modifier is set to private.

`private double MyDouble { get; set; } = 0.1;`

All BHoM object properties should be publicly accessible.

This check is only operating on oM based objects. Objects within an `Objects` folder of an Engine (`Engine/Objects`) or Adapters are exempt from this check.