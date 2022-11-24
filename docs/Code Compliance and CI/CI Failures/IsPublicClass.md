## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsPublicClass.cs)

## Details

The `IsPublicClass` check ensures that classes declared within files have the `public` modifier, rather than `private` or `internal`, etc.

The following class declaration would fail because it does not give the `public` modifier.

```
namespace BH.Engine.Test
{
    static partial class Query
    {
    }
}
```

Files contained within an Engines `Objects` folder are exempt from this check (e.g. files with the file path `Your_Toolkit/Toolkit_Engine/Objects/Foo.cs` will be exempt).