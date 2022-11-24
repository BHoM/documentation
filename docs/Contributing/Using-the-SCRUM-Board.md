## Introduction

To keep things organised and avoid stepping on each other's toes, we are relying on the [_GitHub Project SCRUM Board_](https://github.com/orgs/BHoM/projects/3). The _Project SCRUM Board_ is the way we communicate, the tool we use to have a bigger picture of what is happening, and the way you will keep records of your work into the BHoM.
Since the the _Project SCRUM Board_ is fully automatised, it is read-only and represents a view on what is happening across all the BHoM repositories.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/ScrumBoard.png).

Each card that you see there corresponds to an [issue raised in one of the repos](Submitting-an-Issue). From the moment it is created to the time when that issue has been completely resolved, the corresponding cards, i.e. the issue card and the associated pull-request card, will go through the different columns of this board. 

## Creating a Card
The best way to create a card is to [create an issue in the corresponding repository](Submitting-an-Issue) and add it to "SCRUM Development Board Planning" project. The card will automatically appear in the most appropriate column.

Although this is not recommended, if you want to create the card from the project board itself, see the GitHub's help page [Adding issues and pull requests to a project board](https://help.github.com/en/articles/adding-issues-and-pull-requests-to-a-project-board). Be mindful that when you convert the card to issue, it should follow the guidelines described in [Submitting an Issue](Submitting-an-Issue)

## SCRUM Board Columns

### Priority this Sprint 

This column contains only issue cards. Once an issue has been assigned to a person as part of his/her tasks for the week, the card can be added to the "SCRUM Development Board Planning" project. This action will place the card - an issue card - into the "Priority this Sprint" column automatically. If the card/issue was not assigned to anyone at that time, it will then be assigned to that person. You can see who has been assigned the issue by looking at the avatar at the bottom right of the card.

### In Progress 

This column contains only pull request cards. A card is in this column when a person [starts working on the corresponding issue](Resolving-an-Issue). New pull requests that are added to the "SCRUM Development Board Planning" project will automatically appear here. Normally, only one card per person should be in that column at a time.
<!-- The difference between Draft prs and usual prs is discussed in Resolving and Issue --->

Cards in that column are also _**locking**_ the repository or the project it targets. This means that nobody is allowed to start editing code in that repository while a card is in the _In Progress_ or _Review in Progress_ column. This also means that you can only add a card in that column if there is not already a card locking the same repository. Coordinate with the card's owner [if this is the case](Working-Together-%E2%80%90-Avoiding-Clashes).

### Review in Progress

This column contains only pull request cards. Once the pull request has been reviewed, and a reviewer requested a change, the `automation` will move the card from the _In Progress_ column into this one.

### Reviewer approved

This column contains only pull request cards. Once the changes in the pull request have been accepted by the minimum number of reviewers required, it will be moved into this column. When a pull request is in this column, it is ready to be merged, unless a label `do-not-merge` is on it.

### Completed

Once the pull request has been [merged into the master branch](Resolving-an-Issue#review-process) and the issue closed, the card is moved the the **Completed** column where it will be discussed in the next planning call. Notice that, once an issue is closed, the logo at the top left of the card has turn red. The **Completed** column is the only one that should have cards in that state.