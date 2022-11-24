## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsStaticClass.cs)

## Details

The `IsStaticClass` check ensures class declarations contain the `static` modifier.

The following class declaration would fail because it does not give the `static` modifier.

```
namespace BH.Engine.Test
{
    public partial class Query
    {
    }
}
```

Files contained within an Engines `Objects` folder are exempt from this check (e.g. files with the file path `Your_Toolkit/Toolkit_Engine/Objects/Foo.cs` will be exempt).