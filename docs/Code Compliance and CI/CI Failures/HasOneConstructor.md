## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasOneConstructor.cs)

## Details

The `HasOneConstructor` check ensures that all BHoM objects that do have a constructor (and are allowed to do so by implementing the `IImmutable` interface) only contains one constructor with parameters.

Objects which implement a constructor are permitted to also implement a parameterless constructor, but only if this is necessary.

Objects which implement more than one constructor taking parameters will be flagged as failing this check.

#### More information

More information on the use of `IImmutable` interface within the BHoM can be found [here](/The-IImmutable-interface).