# 1 - End of milestone

The contents of this page detail the actions to be undertaken at the end of a given Milestone. These procedures may be updated at any point.

## Related documents

The following documents are considered part of this procedure, and contain more in-depth details about specific aspects. It is recommended these are read in conjunction with this document.

 - [Beta testing procedure](Beta-testing-procedure)
 - [Producing a beta installer guide](Producing-a-beta-installer)
 - [Preparing a new Milestone](Preparing-a-new-Milestone)

# 2 - Scope

The scope of this document is restricted to the end of a development Milestone as decided by DevOps.

Interpretation of this procedure rests with the DevOps Lead or their nominated individual.

# 3 - Events

### 3.1 - Final Sprint Begins

The final sprint is placed under `feature-freeze` whereby any code which matches the definition of a `feature` is blocked from being merged into the beta code. Clarifications on what constitutes a `feature` can be sought from the DevOps Team.

During the final sprint, all development should be done against the daily test artefacts, and all members of the development teams should be installing the daily artefacts to evaluate the effectiveness of code developed during that milestone. This is to help avoid situations of bugs being found only in the final beta that exist within the alphas and test artefacts, but may not be visible when building code from source.

Development teams are responsible for ensuring their developers undertake this practice, and core users within their teams should also begin moving from the previous beta to new alphas and test artefacts in this sprint to aid the testing process. Discipline leads may be asked to confirm certain progress reports of testing during this phase.

### 3.2 - Beta Test Procedure takes effect

The Beta Test Procedure is outlined in [this document](Beta-testing-procedure) and will be followed in accordance with the above statement regarding developing against the Beta installers. The DevOps team will oversee this operation during the lifecycle of the final sprint.

### 3.3 - `develop` into `main`

All repositories which are set to be included in the Beta must have Pull Requests raised to merge the code which has been developed during the milestone from their respective `develop` branches into their `main` branches for deployment.

New branches must be made from the `develop` branch and a Pull Request raised for each repository as appropriate. Each Pull Request will require a review and test prior to merging into `main` and deploying in the Beta. This Pull Request should be raised by someone within the DevOps team. Once the Pull Requests are raised, the BHoMBot command `@BHoMBot check beta-status` should be triggered for each Pull Request. This will provide an initial report on the impact of each individual Pull Request to aid merging decision making.

The branch name must be suitable and unique for the milestone as this will form the Beta Test Branch for BHoMBot installer payloads when generating test installers during the final sprint.

Each Pull Request must be reviewed and signed off by the relevant testers as determined by each Discipline Code Lead prior to it being merged to `main`. Where a Pull Request is dependant on upstream changes (e.g. a Toolkit depending on a BHoM_Engine change), the upstream changes must be prioritised for testing and review, even if the Toolkit Pull Request does not then get merged.

### 3.4 - Pull Request lock down

Pull Request lock down will be put into effect once the Pull Requests for merging `develop` into `main` have been raised. No Pull Request may be merged into a repository that is included in the Beta without approval from DevOps.

### 3.5 - Final merging of `develop` into `main`

The deadline for the final merging of any Pull Request aiming to deploy code to the beta will be announced by DevOps at the start of the final sprint, but will not be later than 9am on the day of the artefact being produced.

Once this deadline has passed, any Pull Requests not yet merged for deployment will be closed and their changes will not be deployed in the Beta. They may be deployed in future Betas if subsequent milestones merge `develop` into `main`. The code will not be lost, as it will continue to reside on the `develop` branch and will continue through into the next milestone.

If a Toolkit requires alignment updates to compile and deploy, a separate Pull Request will be raised by DevOps which performs this alignment with no further changes incorporated.

### 3.6 - Tagging

Each repository included in the beta must be tagged at the commit latest to `main` for the version being produced.

An important note to make, is the `TargetCommit` must be set to `main` to target the `main` branch - otherwise it will default to target the default branch (which is `develop` for beta repositories). This will cause issues if not set and other work is committed to `develop` before the tags are completed.

The installer repository should also be tagged to correspond to the version of the installer at the time the beta was produced.

### 3.7 - Change Log Creation

The Change Log is prepared by a member of the DevOps team using the authorised script. The Change Log should encompass every pull request merged during the milestone to the `main` branch for deployment, from every repository included within the installer.

The following checks must be done as part of the Change Log Creation:
 - That all repositories included in the installer are present and correctly pulling PR information
 - That the grouping categories are correctly set
 - Toolkits are correctly included change logs as appropriate

### 3.8 - Prepare release notes script

The Release Notes script puts a release tag onto the `main` branches of repositories included within the installer. The release notes are prepared by a member of the DevOps team using the authorised script. The release notes should follow the standard for BHoM releases.

The following checks must be done as part of the Release Notes preparation:
 - The release notes title is accurate
 - The release notes themselves are accurate
 - The release notes script can successfully produce a release note on a CI Test repository

Authorisation for the execution of the script during this preparation and testing phase resides with the DevOps team.

### 3.9 - Dispatch release notes

A manual release is to be made of the BHoM_Documentation repository. These releases are to contain their correct titles, but their bodies may be left blank while the change log is produced.

The release notes body in the release notes script is to be double checked to ensure the link to documentation release notes is accurate for the given repository status.

The release notes script is then to be used to tag the releases across all repositories included within the installer.

Once the appropriate change logs are prepared, these should be edited into the release notes on the documentation repositories.

Authorisation for final execution of the script resides with the Governance team.

### 3.10  - Produce beta installer

Full details of producing a beta installer can be found in the [Producing a Beta Installer guide](Producing-a-beta-installer).

### 3.11 - Release beta installer for testing

The beta installer should be released to the key individuals responsible for toolkits across the organisations for testing. Testing should ensure their toolkits show up correctly, and work as intended for the given release. This testing is a final review, with testing of functionality ideally done during the final sprint using daily alphas.

The discipline team leads are responsible for reporting back to the DevOps team their approval of the installer. The installer may be tested overnight to allow a broad testing regime globally. The method of approval will be determined at the time of release, but is likely to include public confirmation via Teams or other appropriate channels. Discipline leads are responsible for ensuring the code which sits within their remit is approved appropriately. They will be called upon to assist in any bug fixes which may be found with the beta installer to ensure timely resolutions.

The release should be made public on appropriate collaboration channels.

### 3.12 - Accepting or Rejecting the Beta

Following the final testing and reporting back to the DevOps Team, a final judgement will be made as to whether the beta should be released to the public. If the testing is inadequate, or there are significant issues that may be caused by the release of the beta, then the beta may be rejected. Any person may petition for a beta to be rejected if they feel it would be prudent to do so, however, the final decision to accept or reject the beta resides with the DevOps Team.

If the beta is to be released, then the milestone will be closed out in accordance with the remainder of this procedure.

If the beta is not to be released, then one of the following scenarios may be undertaken.

 - The beta testing period is extended
 - The beta is abandoned

If the beta testing period is to be extended, this should be announced on appropriate communications channels, detailing the reasons for extending the testing period and the new timelines to be followed. The timelines to be followed will be determined by the DevOps Team as an appropriate judgement call based on the situation. If an extended testing period is required, the time taken to complete the testing protocols will count as part of the milestone in which the beta was due to be delivered. The subsequent milestone will be shortened appropriately to accommodate this, in chunks no shorter than whole sprints. For example, if week 1 of the new milestone is given to the previous milestone to extend beta testing, week 2 of the new milestone will be converted into a downtime week, and the new milestone will begin in week 3. In this example, the new milestone will then be 10 weeks long and will reduce by 1 feature sprint. If the subsequent milestone does not need to be affected by a testing extension then the new milestone will start as planned in week 1 and not be reduced.

If the beta is to be abandoned, the milestone will be closed out in accordance with the remainder of this procedure, with the exception of communications regarding the release of the artefact. Appropriate communications will be made explaining the situation and outlining when a new beta will be planned to be made available at the end of the next milestone.

Abandoning the beta should not be a decision taken lightly, and all efforts should be made to ensure a beta delivery for a milestone. A late delivery is preferred over no delivery.

It is not appropriate to deliver a partial beta, owing to the interconnected workings of many toolkits which sit in different disciplines, and the versioning constraints which would require large work to be undertaken to temporarily remove items from the beta at that stage.

Until a beta is released, or the milestone is closed out in the event of abandoning a beta, the pull request freeze remains in effect, unless otherwise decided by the DevOps Team.

### 3.13 - Close milestone

The milestone should be closed and the GitHub milestones updated to reflect the new development periods.

### 3.14 - Prepare next milestone

Following the close out of the milestone, the next milestone should be set up ready to begin as soon as is appropriate. Typically, this might be after a weekend, but should be set up in such a way that the next milestone could begin the next day after release.

Full details of actions needed to be undertaken to set up the next milestone can be found in the [Preparing a new Milestone Procedure](Preparing-a-new-Milestone)

# 4 - Communications of the end of the milestone

### 4.1 - Release beta installer publicly

Once the installer has been reviewed, and the discipline leads have reported back to the DevOps team their acceptance of the installer, the installer should be release for general consumption. This should be done in the following ways.

#### 4.2 - Update of external website

The BHoM.xyz website should be updated by a member of the DevOps team to incorporate the new public installer for the end of the milestone. The website should be updated to highlight this is a new installer, and references changed as appropriate.

# 5 - Lift PR lock down

The lock down of Pull Request merging can now be lifted, with Pull Requests able to be merged as appropriate as part of the code creation for the next set of alphas and subsequent beta. The lifting of Pull Request lock down must be clearly announced on Teams and other appropriate communication channels.