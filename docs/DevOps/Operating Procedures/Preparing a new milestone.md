# 1 - Preparing a new milestone

The contents of this page detail the actions to be undertaken at the beginning of a given Milestone. These procedures may be updated at any point.

# 2 - Related documents

The following documents are considered related to this procedure. It is recommended these are read in conjunction with this document for a full understanding of the procedures being followed.

 - [End of Milestone procedure](End-of-Milestone-procedure)

# 3 - Purpose

The purpose of this procedure is to outline the steps which are to be taken during the transition period from one milestone to the next. Due to the nature of development, the current development calendar does not provide for hard breaks between development cycles. The release of one beta, and end of that milestone, does not have breathing space to the next milestone. This is afforded by the slick operation in which milestones are turned around, benefited by the experience and skill of the team involved, and the automation of many of the processes involved, requiring only oversight.

# 4 - Halting this procedure

If at any time an event occurs which draws the capability of the new milestone being advanced into doubt, the Governance lead or the CI/CD lead may bring a halt to proceedings. Halting this procedure should be done prior to any irreversible changes being made to the code base as part of this procedure. Should a halting of this procedure be initiated, the Governance and CI/CD teams should meet to discuss the situation and prepare a continuation plan that allows the cause of the halt to be handled. As appropriate, other discipline leads should be updated and included in that process, particularly where a halting of the procedure may cause a delay to development.

# 5 - Tasks

The following tasks should be completed as part of the preparation of a new milestone. Full details of each task are given further below. All of the tasks below are the responsibility of the CI/CD lead to ensure completion, however, many tasks will be delegated to suitable individuals.

 - The milestone that has just closed should have all relevant planning milestones closed on all repositories
 - Appropriate planning milestones are set up across all repositories for the new milestone
 - The installer versions are upticked to reflect the new milestone
 - Upticking current milestone version for Test Toolkit
 - The `AssemblyFileVersion` should be updated across all repositories
 - The [Versioning_Toolkit](https://github.com/BHoM/Versioning_Toolkit) needs to have a new upgrader added and prepared for the next milestone to aid the next milestones development
 - The `PreviousVersionAttribute`s should be removed across all repositories, along with all `Versioning_xy.json` files
 - Upticking of copyright versions on BHoM repositories only

## 5.1 - Closure of milestones

The planning milestones on repositories included within the installer for the milestone just completed should be closed, including both RC and Release milestones.

## 5.2 - Opening of milestones

Unless previously done, the milestones for RC and Release, with appropriate deadline dates, should be opened and added to all repositories included within the installer.

## 5.3 - Upticking installers

The [installer](https://github.com/BHoM/BHoM_Installer) should be upticked within their code base to ensure the latest set of alphas reflect the new milestone.

## 5.4 - Upticking Test Toolkit

[Test_Toolkit](https://github.com/BHoM/Test_Toolkit) also has a reference to the current milestone in development to aid with some compliance checks, and should be updated in the following locations:
 - CodeComplianceTest_Engine/Query/CurrentVersion.cs

## 5.5 - Assembly File Version updates

The script to allow BHoMBot to update the Assembly File Versions should be executed. Pull Requests should be merged within 2 days of being raised, as Assembly File Versions have to be accurate to allow versioning to work appropriately. There should be no reason for delay to this task, and the CI/CD lead should work with Discipline leads to ensure timely merging of those Pull Requests.

## 5.6 - New Versioning Upgrader

The [Versioning_Toolkit](https://github.com/BHoM/Versioning_Toolkit) needs to have a new upgrader added with the previous upgrader locked for future developments.

## 5.7 - Removal of `PreviousVersion` attributes

To keep the code base tidy, the script allowing BHoMBot to remove `PreviousVersion` attributes on code should be executed. Pull Requests should be merged within 5 days of being raised.

## 5.8 -  Upticking of copyright

Once per year, in the first sprint of January, all code within the BHoM organisation needs copyrights to be updated to reflect the new year. The script to allow BHoMBot to do this should be executed, and Pull Requests merged within 5 days. BHoMBot copyright compliance checks will be provided to aid checking that the copyright is valid, with Discipline leads then responsible for merging the Pull Requests around other Pull Requests, but no later than 5 days after being raised.

The following areas need to be upticked:

 - All `.cs` files within the BHoM organisation across all repositories which are not archived
 - The primary [copyright header](https://github.com/BHoM/BHoM/blob/develop/COPYRIGHT_HEADER.txt) on the BHoM/BHoM repository
 - The copyright footers on bhom.xyz in the index file [here](https://github.com/BHoM/bhom.github.io/blob/main/index.html#L326) and [here](https://github.com/BHoM/bhom.github.io/blob/main/index.html#L357)
 - The copyright footers on bhom.xyz/documentation in [the yml file](https://github.com/BHoM/documentation/blob/main/mkdocs.yml#L2)