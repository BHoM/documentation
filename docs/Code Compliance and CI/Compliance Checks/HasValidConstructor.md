## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasValidConstructor.cs)

## Details

The `HasValidConstructor` check ensures that any BHoM object which implements a constructor with parameters contains all of the parameters it requires to satisfy the Serialisation requirement.

Constructors should only exist on objects implementing the `IImmutable` interface. Objects with this interface should have properties which are `get` only (no `set` accessor). All of these `get` only properties should be parameters to the constructor, with the parameter name matching the property name following the usual lowercase conventions for parameter names.

Consider the following `IImmutable` object, which does not have a constructor.

```
public class MyObject : BHoMObject, IImmutable
{
    public virtual int MyInt { get; }
    public virtual string MyString { get; }
    public virtual Point MyPoint { get; set; }
}
```

This object will not correctly deserialise, as it will not be able to adequately set the properties `MyInt` and `MyString`. Therefore, a constructor must be provided with the parameter names matching, so the deserialisation can correctly align the deserialised data to the object property.

The property `MyPoint` does not have to be a parameter to the constructor, as it implements a `set` accessor. This is true for any property, including those inherited from the base `BHoMObject`.

As such, a valid constructor would look like this:

```
public MyObject(int myInt, string myString)
{
    //Constructor logic
}
```

#### Example of a valid object

The entire class, in its valid form, would look like this:

```
public class MyObject : BHoMObject, IImmutable
{
    public virtual int MyInt { get; }
    public virtual string MyString { get; }
    public virtual Point MyPoint { get; set; }

    public MyObject(int myInt, string myString)
    {
        //Constructor logic
    }
}
```

#### Example of an invalid object

If the constructor does not contain input parameters for all of the properties which implement only the `get` accessor, this will flag as a failure under this check. The following object is therefore incompliant, as only `MyInt` has a matching input parameter:

```
public class MyObject : BHoMObject, IImmutable
{
    public virtual int MyInt { get; }
    public virtual string MyString { get; }
    public virtual Point MyPoint { get; set; }

    public MyObject(int myInt)
    {
        //Constructor logic
    }
}
```

#### More information

More information on the use of `IImmutable` interface within the BHoM can be found [here](/The-IImmutable-interface).