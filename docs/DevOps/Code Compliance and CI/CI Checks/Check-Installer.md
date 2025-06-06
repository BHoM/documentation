# Check Installer

The Check-Installer pipeline answers the question of:
 > If this pull request is merged to `develop` or `main`, could we build a deployable installer from it?

This checks all of the repositories included within the [BHoM_Installer](https://github.com/BHoM/BHoM_Installer) against the branch of the pull request of the toolkit being checked, and ensures all repositories included within the installer are built successfully. Any problems are then identified early and able to be handled appropriately.

If any part of the installer fails to build successfully then a failed check will be returned to the pull request.

For BHoMBot, if you have dependant pull requests linked as part of a series, running the check on one pull request will trigger a check result (success or failure depending on the outcome) to all pull requests in the series, as they will have all been tested when requested.

***

### Trigger commands:

**BHoMBot**
> `@BHoMBot check installer`

***

### Arguments

`-quick` - if this flag is provided, then only the code changed by the pull request and its immediate dependencies (upstream) will be compiled. If not provided, the default of compiling all the code in the installer will be used instead.

***
