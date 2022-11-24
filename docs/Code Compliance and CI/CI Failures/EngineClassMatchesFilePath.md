## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/EngineClassMatchesFilePath.cs)

## Details

The `EngineClassMatchesFilePath` check looks at whether the the class of the engine method matches based on its file path.

For example, `Compute` class files should sit within the file path `Your_Toolkit/Toolkit_Engine/Compute` and not within `Your_Toolkit/Toolkit_Engine/Query`. This check ensures the class name is correct based on the file name.

Files contained within an Engines `Objects` folder are exempt from this check (e.g. files with the file path `Your_Toolkit/Toolkit_Engine/Objects/Foo.cs` will be exempt).