## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsValidEngineClassName.cs)

## Details

The `IsValidEngineClassName` check ensures that any engine class is one of either `Create`, `Compute`, `Convert`, `Modify`, `Query`. Any engine file which does not create one of these classes will fail this check.

Classes within the `Objects` folder of engines are not checked against this criteria.