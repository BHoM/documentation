## Introduction

Open issues are reviewed weekly and the most critical ones are assigned to
specific people as part of their weekly tasks. That task of resolving an issue
is called a sprint. If you need more information on how those issues are being
created, check [this
page](Submitting-an-Issue).

A person in charge of that issue will then create a new branch, write the code
necessary to solve that issue (with potentially multiple commits on that
branch) and then submit a **pull request** to merge that branch back to the
main development branch. This pull request will be reviewed by other developers
and the code on that branch will potentially be edited to match everyone's
satisfaction. The pull request will then be approved and the branch will be
merged with the main one. For more detailed explanations on the process, check
[this short guide](https://guides.github.com/introduction/flow/)

If you haven't already make sure you read [Using the SCRUM
Board](Using-the-SCRUM-Board) - it's easy!


## Overview of important steps to successful coding in the BHoM 
### A. Preparatory work
**Preparatory work is mandatory**. Before doing anything _review the activity_ in relevant repos and speak to team
   working in similar areas of the code. You can not start working on any part
   of the code before you have checked that there are no Pull Requests open for the _Project_ or for the
      entire repo you want to modify. See [naming
      convention](Resolving-an-Issue#branch-naming-conventions)

**If the above steps are not fulfilled**, _coordinate_ with the person
   working on that branch. Either work on the same branch if possible,
   expanding the pull request to cover more issues (make sure you link all
   issues in the conversation of the pull request), or [work
   locally](Working-Together-‐-Avoiding-Conflicts#my-issue-is-super-urgent-but-someone-else-is-already-blocking-the-projectrepository)
   on your machine until the other branch is merged.
   1. If you choose to work on the same pull request, make sure any
      conversation being done is done publicly on Github to ease to process of
      the reviewers.
   2. If ___Urgent___ and you cannot coordinate
      [work locally, but do not branch yet](Best-practices/Coding-together-avoiding-conflicts.md#my-issue-is-super-urgent-but-someone-else-is-already-blocking-the-projectrepository)


### B. Solving the issue
1. Select an __Issue__ or raise one.

1. Create a __Branch__ for the specific __Issue__ - using the correct [naming
   convention](#branch-naming-conventions)
   and considering [to branch or not to
   branch?](Working-Together-‐-Avoiding-Conflicts)

1. As soon as you pushed your first commit, open a _Draft Pull Request_, and [add the card to the _Project SCRUM Board_](Best-practices/Using-the-SCRUM-Board.md#creating-a-card). This action will communicate to others that the repo is now _locked_ and [avoids conflicts](Best-practices/Coding-together-avoiding-conflicts.md). 

1. Push each individual __Commit__ - keeping commits as specific and frequent
   as possible. Always review what files you are committing. And make sure your
   sprint is not drifting from the original issue.

1. When your code is ready to be reviewed, [change the stage of the pull request](https://help.github.com/en/articles/changing-the-stage-of-a-pull-request) by marking the pull request as `ready for review`. Also remember to:
   1. use the [fixes
      keyword](https://help.github.com/articles/closing-issues-using-keywords/)
      to reference your issue
   1. assign your reviewers, 
   1. include links to any __test files__ that have been used to assist with
      swift review process,
   1. it is also useful to add any comments and context that can be helpful in
      the review process

1. Work with your reviewer to close out

1. On successful _Merge and Rebase_ high five the person next to you! :tada: 



## Branch naming conventions

See [the DevOps branching strategy](https://bhom.xyz/documentation/Development/Best%20practices/Branching-Strategy/#branch-naming-convention).


## Breaking changes

See [our versioning strategy](https://bhom.xyz/documentation/Development/Versioning/versioning-guide/) for more information on avoiding breaking changes.
