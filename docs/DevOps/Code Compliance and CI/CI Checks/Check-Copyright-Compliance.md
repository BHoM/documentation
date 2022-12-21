# Check Copyright Compliance

This check will confirm the `cs` files changed within a pull request are compliant to [the guidelines](Code-Compliance) for having valid copyright on their code files. This check will run only the compliance checks that have the Compliance Type of `copyright` in the table on the linked page.

If the check is unsuccessful, you can trigger BHoMBot to make certain fixes for you. This can be accessed by viewing the details of the check and clicking the `Fix` button to trigger the process on the pull request.

If you believe the check has failed erroneously, you can request dispensation from the CI/CD team. This can be accessed by viewing the details of the check and clicking the `Request Dispensation` button to trigger the process on the pull request. The CI/CD team will review the failures and weigh up the options on progressing the pull request. Dispensation may not always be granted, but this will be a discussion between the pull request collaborators and the CI/CD team.

***

### Trigger commands:

**BHoMBot**
>`@BHoMBot check copyright-compliance`

***