## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasValidPreviousVersionAttribute.cs)

## Details

The `HasValidPreviousVersionAttribute` check ensures that, if there is a piece of versioning documentation present explaining what the previous version of a method or constructor was, the `FromVersion` is correct.

The `FromVersion` for a `PreviousVersion` attribute should be set to the current milestone of development, with `PreviousVersion` attributes being removed at the end of the milestone in preparation for the next.

If a `PreviousVersion` attribute has not been tidied up, it will be flagged by this check and should be removed in the Pull Request which captures it.

If a `PreviousVersion` attribute has been added in that Pull Request, the `FromVersion` should match the current development milestone cycle.