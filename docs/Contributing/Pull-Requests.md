## Introduction

Pull Requests are the primary mechanism of resolving issues and deploying new code to users. They provide us an opportunity to review and reflect on the proposed changes and ensure they meet the criteria of the issue and the broader agenda without introducing any major concerns with bugs or broken functionality.

Pull Requests should be seen as a collaborative process during the review stage. Raising a pull request is not a guarantee that proposed changes will be deployed to the `main` branch, but changes can only be deployed via a pull request mechanism.

## Raising a Pull Request

A pull request can be raised at any stage of the development cycle, either as draft, `WIP` (Work In Progress) or as ready for review depending on the state of the proposed changes. A pull request can be reviewed at any time by anybody, but it is good practice to request a review from key individuals working in that area (for example, a DevOps reviewer when making changes to the core, or a geometry reviewer if making changes to the Geometry oM/Engine).

A raised pull request should have the following features within it - these are provided as headings in the pull request template to complete when raising the pull request:

 - Clear identification of any dependant pull requests that this work is relying on to operate - for example, if your work in a toolkit depends on a change in BHoM_Engine, then in the toolkit pull request there should be a clear link to the BHoM_Engine at the top of your toolkit pull request
 - Linked issues that are being resolved by this pull request - where there are multiple pull requests in a series, at least one of them needs to be referencing an issue that clearly outlines what needs to change in the code. The pull request should aim to solve just the issue outlined. One pull request can resolve several issues at once if needed
 - Test scripts - either reference to data-driven unit-tests (which BHoMBot will then run) or links to test scripts built in a BHoM suitable UI, or reference to the issue which may contain test scripts when the issue was raised.
 - Change log - see [our change log guidance](Releases/Changelog)
 - Additional comments - anything extra you feel will help the reviewers in reviewing your pull request

## Categorising a Pull Request

All pull requests should set a label defining the `type` of pull request, this is to categorise pull requests when producing the change log.

## Pull Request activity

A pull request is a mark of coding resource that was used to try to solve a given issue (or issues). As such, it should be viewed that a pull request is aiming to deploy that code to the `main` branch (pending review) unless it is a speculative piece of work looking at possible options for a given idea. However, due to the pace of change within the BHoM ecosystem, a pull request can be difficult to deploy if it is left for too long. By rule of thumb, a pull request should aim to be deployed within one sprint of time (raised, reviewed, amended per review, and deployed), to avoid hanging work that isn't deployable.

To keep our review requirements focused on the latest workload, each milestone will have a Pull Request closure day if deemed necessary by DevOps.

Pull requests which have not had any activity in 3 months are deemed to have gone stale. Pull requests which have not had any activity in 6 months will be closed to avoid drawing review resource if no activity has happened. Activity can be defined as committing code to the pull request, commenting on the pull request (even if just with an update stating the work is still desired but there's a lack of resource to close it out currently) or any activity which shows up on the pull request within the time period examined.