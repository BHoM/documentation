# Beta Patching

The contents of this page detail the actions to be undertaken in the event of a desire to provide a patch to a beta release. These procedures may be updated at any point.

# 1 - Related documents

The following documents are not considered part of this procedure, but contain additional information which may be beneficial. It is recommended these are read in conjunction with this document.

 - [Beta testing procedure](https://bhom.xyz/documentation/DevOps/Operating%20Procedures/Beta%20testing%20procedure/)
 - [Producing a beta installer guide](https://bhom.xyz/documentation/DevOps/Operating%20Procedures/Producing%20a%20beta%20installer/)

# 2 - Activation of this procedure

Activation of this procedure is done by DevOps at any time that a repository included in the beta installer receives a bug fix to its `main` branch outside of the final sprint of a milestone, or where one or more repositories may have not been included in the initial release where more testing may have been required.

If the development cycle is currently in the final sprint of a milestone, then a beta patch cannot be produced as a new beta is being created, and the bug fix should be dispatched for that beta instead.

# 3 - Procedure for patching - missing repositories

Where a repository has not made the initial beta due to issues with testing and the pull request from `develop` into `main` has been closed, this pull request will be reopened and undergo the standard testing and review procedure. Once the Pull Request is merged, DevOps will then carry out the following functions.

# 4 - Procedure for patching - bug fixes

A new branch from `main` for the repository to be patched should be made, with code written to resolve the bug and reviewed via a Pull Request in the usual manner without circumventing the standard code review procedures. The Pull Request must be tested thoroughly, ideally against any existing test procedure for that repository where available. Where a test procedure is not available, it is the Discipline Code Lead who is responsible for signing off on the Pull Request. Once the Pull Request is merged, DevOps will then carry out the following functions.

## 4.1 - Patching `develop`

The same branch (if not deleted) can be used to patch `develop` as well and ensure the bug fix is in both branches so alphas aren't affected either. Thie pull request can be handled in the usual fashion as it will be going into `develop` as part of that milestone and not need any special support. However, it is important that the bug fix is put into `develop` to prevent the patch being needed again at the end of the milestone when `develop` is merged into `main`.

# 5 - Preparing the patch

The following actions must be undertaken to prepare the beta patch.

## 5.1 - Change log update

DevOps responsible for generating an updated change log for the patched beta to include the change being fixed.

## 5.2 - Create the tag on the repository

DevOps is responsible for tagging the repository with the appropriate patch number.

Should the patch number be required, the patch number should always be 1 greater than the most recent patch number. For example, if a beta patch has previously been generated on a different repository (thus making the current beta version Vx.y.b.1) then the beta patch for this repository will become Vx.y.b.2 even if this repository does not have a Vx.y.b.1 patch itself.

An important note to make, is the `TargetCommit` must be set to `main` to target the `main` branch - otherwise it will default to target the default branch (which is `develop` for beta repositories). This will cause issues if not set and other work is committed to `develop` before the tags are completed.

## 5.3 - Produce the beta installers

Full details of producing a beta installer can be found in the [Producing a Beta Installer guide](https://bhom.xyz/documentation/DevOps/Operating%20Procedures/Producing%20a%20beta%20installer/).

## 5.4 - Testing the beta installer

DevOps is responsible for deciding the scope of testing the patched beta artefact. Where there is any doubt as to the potential scope of changes produced by the patch, a full beta test should be conducted, as per the guidelines in [this procedure](https://bhom.xyz/documentation/DevOps/Operating%20Procedures/End%20of%20milestone%20procedure/).

Where the scope of testing can be clearly defined, the Discipline Lead of the affected repository is responsible for reporting back on successful use of the beta patch artefact, using all available test procedures. This work may be delegated down as appropriate to other developers and users, but the Discipline Code Lead takes final responsibility for reporting back.

The testing of the beta patch artefact should be a matter of priority, and the DevOps lead and Discipline Code Lead should remain in regular contact to ensure the results are reported back ASAP. Ideally this should be completed by the end of the next business day at the latest.

## 5.5 - Releasing the beta installer

This is to be done in line with the release of a standard beta, the procedure for which can be found [here](https://bhom.xyz/documentation/DevOps/Operating%20Procedures/End%20of%20milestone%20procedure/).

# 6 - External website

The BHoM.xyz website should be updated as appropriate, including new API updates were applicable.