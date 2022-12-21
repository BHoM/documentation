# Branching Strategy

The primary branch which forms our codebases single source of truth is the `main` branch across all repositories. Depending on the category of the repository, there may be protections in place for the development of code and merging to `main` branches. As a repository progresses through its lifecycle from prototype to beta, the level of protections change as appropriate.

## Creating branches

No code should be committed directly to the `main` branch of any repository, all code should be produced on an independent branch and deployed to `main` via a Pull Request.

If you are using GitHub desktop, you should make sure you are on the correct default (`main` or `develop` depending on the repository state - see below) branch and refresh it to ensure you have the latest version on your machine.

Then create a new branch by clicking on the _Current branch_ button and select _New branch_.

Make sure to check [this page](/documentation/Contributing/Development%20FAQ/Coding-together-avoiding-conflicts/) for the guidelines on when to create a branch and when not to.

![img](https://raw.githubusercontent.com/BHoM/documentation/main/docs/_images/Issues_NewBranch1.png)

You should see that your repo history has now switched to a new branch.

![img](https://raw.githubusercontent.com/BHoM/documentation/main/docs/_images/Issues_NewBranch2.png)

From there you are ready to work on your code. Any commit that you will do, will be on that new branch.

### Branch naming convention

For all branches where code development is to take place, the following naming convention should be adopted.

_**RepoOrProjectName-#X-Description**_

where _**X**_ is the issue number you are solving. 

Both the Repo or Project name and the Issue number should refer to the _base issue being solved_.

For example, if you are working in IES Toolkit, aiming to resolve issue 99 (which fixes window placement), the branch name should be `IES_Toolkit-#99-FixingWindows`.

If you're working on a repository with multiple disciplines, such as BHoM_Engine, then you can name the branch after the specific engine you are working on. For example, if you are working in the Environment Engine, aiming to resolve issue 103 (which fixes window creation), the branch name should be `Environment_Engine-#103-FixWindowCreation`.

This branch naming convention is particularly important when producing development installers - BHoMBot will use the name of the branch to calculate where to place installer artefacts which are generated to aid in testing the Pull Request. If the branch is not named in this convention, BHoMBot will be unable to calculate this and you will lose out on CI benefits.

#### Branches in dependant repos - MUST be named identically

For instance if a change in the BHoM will lead to a change needed in some sub-repos, _**all of those sub-repos **MUST** get the same branch name**._ This is essential for our (CI) process to correctly check changes spanning across multiple repository Pull Requests.

## Prototypes

Prototype repositories use only a `main` branch for their code development. The `main` branch should be protected to the level that it requires a Pull Request to merge code, however, there is no requirement on Prototype Repositories for a Pull Request to receive a review. The Pull Request can be raised and merged instantly (depending on any required CI checks) without intervention from a reviewer. Reviews are still an option for Prototype repositories should people wish to discuss changes before a merge, but they are not a requirement.

There is no automatic deployments of Prototype repositories - the only way for code to be utilised is for it to be built from source or the DLLs shared between users.

When creating a new branch for the addition of code to a Prototype repository, branch from an up to date version of the `main` branch.

## Alpha State

Repositories deployed in an Alpha state use only a `main` branch for their code development. The `main` branch should be protected to the level that it requires a Pull Request with at least 1 approving review prior to the code being merged.

Once code is merged to the `main` branch, the code will be deployed via alpha installers and available for more general consumption via Installers. Therefore code which is deployed to `main` must meet certain CI criteria before being able to merge the Pull Request.

When creating a new branch for the addition of code to an Alpha repository, branch from an up to date version of the `main` branch.

## Beta State

Repositories deployed in a Beta state use both a `main` branch and a `develop` branch for their code development. The `develop` branch is set as the default branch.

The `main` branch continues to serve as the repository's single source of truth and is the branch which is deployed via beta installers at the end of each milestone.

The `develop` branch serves as a staging ground for development of features and larger pieces of work which is deployed via alpha installers.

The difference here for Beta repositories is that the `main` branch should only be updated each milestone with code from the `develop` branch which has been suitable tested and reviewed and deemed to be fit for purpose for general deployment in the Beta installers available on [BHoM.xyz](https://bhom.xyz) and other platforms. Utilising a different branch for general development (`develop`) from the Beta deployed branch (`main`) grants us a degree of control over what is deployed at the end of each milestone and beta.

For repositories which are undergoing large portions of work, perhaps large refactors or additional features, targeting new APIs, etc., it may not be suitable to deploy that work to a Beta where the work spans across multiple milestones of development. If this work was deployed to `main` for Alpha testing, it would then be automatically deployed to Beta at the end of the milestone when it may not be ready. Deploying to `develop` for Alpha testing then allows us to choose not to deploy that to `main` at the end of the milestone, allowing the Beta to contain only the deployable code that is up to the adequate standards without hindering development, or requiring Pull Requests to stay open for a lengthy time and take more resource to resolve when the time is right.

Additionally, separating the `main` Beta branch from the `develop` Alpha branch allows us to patch the Beta for critical bugs during a milestone of development, enabling the release of curated, up to standard code that resolves a specific bug without also deploying code which may be under ongoing development.

All Pull Requests for Beta repositories should aim to merge into the `develop` branch unless authorised by DevOps to merge into the `main` branch to perform a Beta Patch.

When creating a new branch for the addition of code to a Beta repository, you should branch from the branch where the code aims to end up. For example, if you are developing a new feature which will merge into the `develop` branch, then you must branch from an up to date version of the `develop` branch. However, if you are providing a bug fix for a Beta Patch, which aims to merge directly into the `main` branch, then you must branch from an up to date version of the `main` branch.

## Branch Protections

This table gives an overview of the protections required for each individual type of repository.

| Protection Setting | Prototype | Alpha | Beta (`develop`) | Beta (`main`) |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Require a Pull Request before Merging | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Require Approvals | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Minimum Number of Approvals | N/A | 1 | 1 | 1 |
| Dismiss stale pull request approvals when new commits are pushed | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Require review from Code Owners | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Restrict who can dismiss pull request reviews | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Allow specified actors to bypass required pull requests | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Require approval of the most recent push | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Require status checks to pass before merging | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Require branches to be up to date before merging | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Status Checks that are required | [See here](/documentation/DevOps/Code%20Compliance%20and%20CI/Continuous-integration/#use-of-ci-checks) | [See here](/documentation/DevOps/Code%20Compliance%20and%20CI/Continuous-integration/#use-of-ci-checks) | [See here](/documentation/DevOps/Code%20Compliance%20and%20CI/Continuous-integration/#use-of-ci-checks) | [See here](/documentation/DevOps/Code%20Compliance%20and%20CI/Continuous-integration/#use-of-ci-checks) |
| Require conversation resolution before merging | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Require signed commits | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Require linear history | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Require deployments to succeed before merging | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Lock branch | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Do not allow bypassing the above settings | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Restrict who can push to matching branches | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Restrict pushes that create matching branches | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| People, teams, or apps with push access | N/A | [Merge Team](/documentation/DevOps/Merge-Teams/) | [Merge Team](/documentation/DevOps/Merge-Teams/) | [DevOps Team](/documentation/DevOps/Merge-Teams/#the-devops-merge-team) |
| Allow force pushes | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Allow deletions | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |

## Branching diagrams

### `main` branch only

![image](https://user-images.githubusercontent.com/18049174/208904774-af84bb35-0d97-4db4-8407-48a44acbaa86.png)


### `main` branch with a `develop` branch

![image](https://user-images.githubusercontent.com/18049174/208923966-9a63ffea-d797-4481-84c9-fc9c7995987b.png)