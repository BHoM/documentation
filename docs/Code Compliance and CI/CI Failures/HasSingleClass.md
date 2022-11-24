## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasSingleClass.cs)

## Details

The `HasSingleClass` check ensures there is only one class declaration per `cs` file. This is designed to make the code easy to find and understand by people coming into BHoM for the first time.

For example, a class which looks like the below, would be invalid and fail this check. There should only be one `class` declaration per file.

```
namesapce BH.Engine.Test
{
    public static partial class Query
    {
    }

    public static partial class Compute
    {
    }
}
```