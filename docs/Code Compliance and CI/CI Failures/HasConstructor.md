## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasConstructor.cs)

## Details

The `HasConstructor` check ensures that all BHoM objects do not have a constructor unless they are implementing the `IImmutable` interface on the object.

Constructors are only valid on `IImmutable` objects that contain `get` only properties, and are necessary for BHoM serialisation to function correctly.

The following scenarios will result in this check failing:

 - An object which contains a constructor, and does not implement the `IImmutable` interface
 - An object which implements the `IImmutable` interface, but does not contain a constructor

#### More information

More information on the use of `IImmutable` interface within the BHoM can be found [here](/The-IImmutable-interface).