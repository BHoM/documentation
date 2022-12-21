# Check Versioning

This check will confirm the changes proposed by the pull request do not negatively impact the results of versioning tests.

The check will clone all the repositories in the [BHoM_Installer](https://github.com/BHoM/BHoM_Installer) and compile all of them to get the relevant DLLs. Once the DLLs are generated, the versioning test will generate against the `master` branches of those repositories. Following that result, the DLLs will be regenerated against the branch of the pull request and generate a second result to compare with.

If the two results come back equal (i.e. there is no change to versioning presented by your pull request) then this will report back as a pass.

If the errors of your branch report less versioning errors than the `master` result, AND any errors in your branch report exist on the `master` result, this will be deemed to be an improvement and will report back as a pass.

If the errors of your branch are less than those of the `master` result, but the errors on your branch result do not exist on the `master` result, this will be deemed to be a failure as your pull request(s) are resulting in new versioning errors.

If the errors of your branch are more than the errors of the `master` result then this is also deemed to be a failure as your pull request(s) are increasing the number of versioning errors.

***

### Trigger commands:

**BHoMBot**
>`@BHoMBot check versioning`

***