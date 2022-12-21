# Check Ready To Merge

This check will confirm the pull request is ready to merge based on the following conditions.

 - Any requested changes have been addressed (changed to an approving review) or dismissed
 - The pull request does not have a `status:do-not-merge` label
 - The pull request has suitable labels for the change log
 - The pull request has at least one approving review
 - The pull request has passed `check-core` and `check-installer` from BHoMBot

This check is done for all pull requests that are linked in a series. If any of the pull requests are not ready, then the check will report that none of them are ready. This is to protect against merging pull requests in a series that may be dependent on each other accidently, where one pull request is ready to merge but another is not. This protects the installer builds (where `check-installer` reports a pass to all pull requests because the changes are ok, but if one of the pull requests then isn't merged it will fail to build the installer later) as well.

***

### Trigger commands:

**BHoMBot**
>`@BHoMBot check ready-to-merge`

***