# 1 - Beta Testing

The contents of this page detail the actions to be undertaken, with approximate timings, at the end of a Milestone to test the Beta installers in the lead up to the release of that Milestones beta. These procedures may be updated at any point. This document forms part of the [End of Milestone Procedure](End-of-Milestone-procedure).

# 2 - Purpose

The purpose of this test procedure is to ensure that all aspects of the Beta installers are checked in the lead up to the production of the Beta installer. The outcome of this procedure is to give confidence to those using the Beta that the toolkits and operations will work as designed.

# 3 - Scope

The scope of testing is restricted to elements of the installer most likely to impact use of the installers. It is not designed to sign off as a complete bug-free installer, however, the state of the Beta should not be worse than that of its previous version. This ensures that each Beta trends towards a more positive setting with each release.

# 4 - Running tests

Each discipline lead is responsible for ensuring suitable, adequate, and reasonable tests are conducted on each of the toolkits within their group. These tests should be run as often as possible during a milestone, but are strictly monitored during the final sprint of a milestone.

During the final sprint, a discipline lead must ensure they, or a suitable member of their team, carries out an adequate test of each toolkit using a given Beta installer. Building from source is not permitted for these tests, as the purpose is to ensure the final Beta installer is fit for purpose.

It is advised that testing utilises the formal test procedures where applicable to make the process of testing and verifying the code base easier, as test procedures should capture the core functionality. Where a test procedure does not exist, it is the responsibility of the discipline lead to ensure suitable testing is carried out.

## 4.1 - Test Reports

Each day during the final sprint, the DevOps Lead or their appointed deputy is responsible for collating the test reports. Test reports should confirm what toolkits have been tested, whether any toolkits have been exempted (see below), and any issues that have been found. It is the responsibility of each Discipline Lead to provide accurate information upon request on the state of their testing.

## 4.2 - Fixing issues

It is the responsibility of each Discipline Lead to triage issues found as a result of testing. Any bug which did not exist in the previous Beta should be prioritised, following standard best practice for issue management generally. Bugs which existed in the previous Beta should not be prioritised during this period (though may be triaged and resolved if there are no other issues).

As a rule of thumb, the following hierarchy should apply when triaging issues for resolution during the final sprint (in order from most important to least).

 - Issues which impact the delivery of the Beta installer should be prioritised.
 - Issues which impact the Core Framework or UIs and User Experience (UX)
 - Issues which impact multiple toolkits but are not classified as Core Framework (e.g, an issue which impacts all Structural Adapters)
 - Issues which were not present in the previous Beta
 - Issues which were present in the previous Beta

Guidance and support on issue triaging can be obtained from the Governance and DevOps teams.

Discipline leads are responsible for ensuring they have adequate resource to resolve issues found, including reviewing the Pull Requests, and subsequent re-tests.

If an issue is resolved with the approval of DevOps, and merged to the repository's `develop` branch, DevOps will reproduce the Pull Request which merges `develop` into `main` to include this additional fix.

## 4.3 - Exceptions

It may be appropriate for a toolkit to not receive testing every day during the final sprint, providing the following criteria can be met.

1. The Discipline Lead, along with any relevant Toolkit Lead or key stakeholder, is satisfied that the code base contained within that Toolkit is isolated to changes made in the core
2. The core for that toolkit on which it depends has not changed since the last test
3. There have been no Pull Requests merged on that toolkit since the last test

The Discipline Lead of the toolkits concerned may consult with other relevant stakeholders, including other Discipline Leads, however, the final responsibility for testing, or skipping, a toolkit resides with the Discipline Lead. It is recommended that should any of the criteria above not be met, that the toolkit undergo a subsequent retest.

# 5 - Merging `develop` into `main`

Once suitable testing has been conducted on the Pull Request which is aimed to be deployed in the Beta, the testers must comment with suitable approving reviews. The Discipline Code Lead must then inform DevOps that the Pull Request is ready to be merged, and DevOps will then merge the Pull Request for deployment if it is deemed appropriate to do so. Instances where it may not be appropriate to merge a Pull Request include if the Pull Request is depending on code in a higher repository (for example BHoM_Engine) that has not yet been merged. In these cases the Pull Request may have to wait, and may risk not being included if the higher repository Pull Request is not subsequently deployed.

# 6 - Final Beta test

After the creation of the Beta artefact, the Beta must be signed off by each Discipline Lead. The Beta must be tested against all available Test Procedures for code residing within the installer. Additional tests are allowed, but cannot be used as substitutions to the test procedures. Where a test procedure does not exist, the Discipline Lead is responsible for ensuring adequate and suitable testing is performed for that area of code.