## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsValidIImmutableObject.cs)

## Details

The `IsValidIImmutableObject` check ensures that `IImmutable` objects contain at least one property which has only a `get` accessor (no `set` accessor).

If an object has no properties which are `get` only, then the `IImmutable` interface should not be used.

#### More information

More information on the use of `IImmutable` interface within the BHoM can be found [here](/The-IImmutable-interface).