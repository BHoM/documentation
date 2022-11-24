# Coding together avoiding conflicts

Since multiple people may be working on the codebase at the same time please remain aware of other branches on the same repository and keep an eye out for potential conflicts between them, this is especially true of open Pull Requests. If there are changes on parallel branches, and especially ones you know will cause conflicts, there is no substitute to reaching out to the author(s) of those changes and discussing the intent and goals behind yours and theirs and aligning the best way to resolve them. You may find that one of you may be making a change that will actually make the other's goals easier to achieve or even unnecessary and save some work. Someone pausing development may be the best resolution in some cases, in others continuing and dealing with the conflicts later may be, and in others there could be refactoring work that could be done now to save this effort being necessary.

Be sure to regularly fetch and check that your branch integrates cleanly with master, if it does not please rectify these conflicts on your branch.

Core Contributors are expected to resolve conflicts on their PRs in order to have their PR accepted and merged. Maintainers should expect to assist external contributors with this process or otherwise handle them at merge time. Also see GitHub's [about merge conflicts page](https://help.github.com/en/articles/about-merge-conflicts)


## Never Work on the Same Files

The challenge is therefore to make sure that we never have two people modifying the same files in two separate branches. While it is easy to be aware which code file you are modifying, it is very important to understand that there are a few files maintained by Visual Studio that can also be the source of clashes:

- **Solution file**: This file is modified every time a project is added for example. This means we can never have two people creating a new project in two different branches. If you know you will have to do that, you have to block the entire repository for the duration of your sprint. To block a repo, make sure your issue and card on the SCRUM board follow the [naming convention of a repo-level issue](Resolving-issues#branch-naming-conventions). 
- **Project file**: This file is modified every time you add a file to the project. This happens a lot since you create a file every time you create a new section of code. It will also be modified if you move a file. Because of this, two people are never allowed to work on the same project at the same time. To block the project, make sure your issue and card on the SCRUM board follow the [naming convention of a project-level issue](Resolving-issues#branch-naming-conventions).


## FAQ

### I have to make changes across multiple projects at the same time, what do I do?

If it is only two projects, you can simply name your issue and branch with the two project names instead of just one. If this is more than that, you will have to block the entire repository. In that situation, it is frequent that unplanned changes will have to be made in other projects anyway so it is safer to block the whole repository.

### I am not sure if my code will be limited to a single project. There might be ripple effects. What do I do?

In doubt, it is safer to block the whole repository. It is very annoying for everyone else though so only do it if it is clear the side effect of your changes cannot be dealt with in a separate issue/PR. Also make sure you keep your sprint as short as possible so you limit the time you are blocking everyone. One thing to consider is to work only locally until you know for sure the effect your code has so you can create the branch accordingly.

### My issue is super urgent but someone else is already blocking the project/repository.

You can always work locally. Just don't create a branch yet and solve the problem on your machine. Contact the other person blocking you to coordinate. As soon as his/her PR is merged, you can pull the latest changes on your machine and create your pull request.

### I am creating a branch that will never be merged. Is there a solution for that?

Yes, you can use this naming convention instead: **NeverMerge-IssueX-Description**. As you can see, we have replaced the project or repository name with **NeverMerge**. This is a very rare case though since 99.9% of the code should be meant to be merged.