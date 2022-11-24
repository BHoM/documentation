## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/PropertyAccessorsHaveNoBody.cs)

## Details

The `PropertyAccessorsHaveNoBody` check ensures that object property accessors do not have method bodies included with them.

For example, the following object definition will fail this check, because the `get` accessor has a body.

`public double MyDouble { get { return 0.1; }; set; }`

Whereas this property will fail because the `set` accessor has a body.

`public double MyDouble { get; set { _val = value; }; }`

This property will pass as a compliant property.

`public double MyDouble { get; set; } = 0.0`

This check is only operating on oM based objects. Objects within an `Objects` folder of an Engine (`Engine/Objects`) or Adapters are exempt from this check.