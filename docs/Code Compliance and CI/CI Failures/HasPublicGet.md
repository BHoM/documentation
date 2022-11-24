## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasPublicGet.cs)

## Details

The `HasPublicGet` check ensures that object properties have public `get` accessors. A property of a BHoM object which does not have a public `get` accessor will fail this check.

For example, the following object definition will fail this check, because the `get` accessor does not exist.

`public double MyDouble { set; }`

This property will pass as a compliant property.

`public double MyDouble { get; set; } = 0.0`

This check is only operating on oM based objects. Objects within an `Objects` folder of an Engine (`Engine/Objects`) or Adapters are exempt from this check.