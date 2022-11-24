## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsVirtualProperty.cs)

## Details

The `IsVirtualProperty` check ensures that object properties are using the `virtual` modifier.

The follow object property would fail this check because the virtual modifier does not exist.

`public double MyDouble { get; set; } = 0.1;`

This property would pass this check because the virtual modifier has been set.

`public virtual MyDouble { get; set;} = 0.1;`

All BHoM object properties should be virtual to allow for easy extension.

This check is only operating on oM based objects. Objects within an `Objects` folder of an Engine (`Engine/Objects`) or Adapters are exempt from this check.