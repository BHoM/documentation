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
      [work locally, but do not branch yet](Working-Together-‐-Avoiding-Conflicts#my-issue-is-super-urgent-but-someone-else-is-already-blocking-the-projectrepository)


### B. Solving the issue
1. Select an __Issue__ or raise one.

1. Create a __Branch__ for the specific __Issue__ - using the correct [naming
   convention](#branch-naming-conventions)
   and considering [to branch or not to
   branch?](Working-Together-‐-Avoiding-Conflicts)

1. As soon as you pushed your first commit, open a _Draft Pull Request_, and [add the card to the _Project SCRUM Board_](/Using-the-SCRUM-Board#creating-a-card). This action will communicate to others that the repo is now _locked_ and [avoids conflicts](Working-Together-‐-Avoiding-Conflicts). 

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

Branch from `main`. 

If in GitHub desktop, you should make sure you are on the main branch and refresh it to ensure you have the latest version on your machine.

Then create a new branch by clicking on the _Current branch_ button and select _New branch_. 

Name that branch: 

### _**RepoOrProjectName-#X-Description**_ 
where _**X**_ is the issue number you are solving. 

Both the Repo or Project name and the Issue number should refer to the _base issue being solved_.

#### In particular note: Branches in dependant repos - MUST be named identically.

For instance if a change in the BHoM will lead to a change needed in some sub-repos, _**all of those sub-repos **MUST** get the same branch name**._ This is essential for our Continous Integration (CI) process to correctly check changes spanning across multiple repo PRs.


You should use the Repo name if the files modified will span across multiple projects in that base issue Repo. If isolated to a single Project, using just the Project Name is helpful for others.

Make sure to check [this
page](Working-Together-‐-Avoiding-Conflicts)
for the guidelines on when to create a branch and when not to.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Issues_NewBranch1.png)

You should see that your repo history has now switched to a new branch.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Issues_NewBranch2.png)

From there you are ready to work on your code. Any commit that you will do,
  will be on that new branch.


## Breaking changes

A breaking change is one that will make your code incompatible with existing
uses of it. That could be a dependent project within the BHoM or a user's use
of it from one of the UIs. Any change to a Method's signature (name, parameter
types and return type) will be a breaking change, as is anything that changes
the method's contract, that is: the things that a method expects of its inputs,
even without changing their type, especially if the range of valid inputs is
being made narrower; what it returns, especially if the constraints placed on
its outputs are made looser; and any changes in side-effects. Custom data
entires on `BHoMObject`s may be considered part of a contract so changes to how
they are used should be considered breaking in most cases. Changes to a
Method's implementation that do not modify the expectations a user has on its
inputs or outputs are not breaking. Adding new methods is not breaking.

Breaking changes should be avoided, mitigated or postponed in order to align a
number of breaking changes into a new major release. Methods should be
deprecated instead of being removed and also instead of having their signatures
modified, this includes renaming. In the case of a need to rename a Method or
make a trivial change to its input or output types then you should create a new
method with the change, move the implementation into the new method, deprecate
the old one and have it forward to the new, e.g.


```cs
[DeprecatedAttribute(...)]
public static Point Misspelled(Vector a)
{
  return CorrectlySpelled(a);
}

public static Point CorrectlySpelled(Vector a)
{
  // do the thing
}

[DeprecatedAttribute(...)]
public static Line Foo(Vector a, Vector b)
{
  return Foo(a.ToPoint(), b.ToPoint());
}

public static Line Foo(Point a, Point b)
{
  // do something
}
```