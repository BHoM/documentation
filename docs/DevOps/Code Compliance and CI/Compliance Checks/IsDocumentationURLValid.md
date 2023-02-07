## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsDocumentationURLValid.cs)

## Details

The `IsDocumentationURLValid` check ensures that, if there is a documentation URL attribute on the code, that the URL provided can link to a valid web resource.

If the check cannot load the URL (returning anything other than a 200 HTTP status code), this will return a fail. If the server is unavailable then this will return a fail and the check may need rerunning if external server availability affects the check.

This check does not check the validity of the resource, only that the link provided can be used to access a valid web resource.