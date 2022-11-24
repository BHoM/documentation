## Introduction

Issues are used to keep track of all the requests for bug fixing, new features,... They can be created inside each repository and optionally assigned to a specific person. 

A good short guide on issues is available [here](https://guides.github.com/features/issues/)

## Create a New Issue

* On github, go the the repository that needs modifications and select the _**Issues**_ tab. 

* Click on the green _**New Issue**_ button on the top right corner.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Issues_Step1.PNG)

* Fill in the title. The name should be __Description__ or __ProjectName - Description__ depending on whether the issue needs changes in the entire repo or in a specific Visual studio project. If you don't know which one it is, just use the repository name. 

* and fill in the description. This is using [markdown](https://guides.github.com/features/mastering-markdown/) so you can format your message like you would a wiki page. You can also attached files simply by dropping them in the message area.

* Please be specific as you can with both the title description and the body text to give others as much information and context around your proposed issue.

* If you are not already a BHoM Collaborator or part of the Organisation, then you are good to go. Press _**Submit New Issue**_. A collaborator already with write access will pick up the issue and Label/Assign.

## Collaborator Issue flagging and assignment

* As a collaborator or maintainer with write access - it is important to assign labels, as well as assignees if at all possible, for issues as you create them - as well as new issues created by others outside of the organisation to assist with triaging 

* If you already know who is going to handle that issue, you can assign it to that person by using _**Assignees**_ on the right side of the screen. Otherwise, just leave it blank.

* Make sure you select a _**Label**_ to specify the type of issue you have (more about this on the next section).

* If you request is linked to a very specific deadline, you can also pick a _**Milestone**_ from the list.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Issues_CreateNew.png)


## Choose a Label

The two main categories of labels are **feature** and **bug**. **Features** are for requesting functionality that doesn't exist yet. If there is similar functionality already but not matching 100% what you need (e.g. missing inputs or outputs you would need), this is also a feature request. **Bug** is for when that functionality exists but provides an incorrect result or crashes.

For both of those categories, we have 3 levels of importance:
- **Critical**: It is simply impossible to continue without either that feature or fixing that bug. No workaround exists using alternative methods or a quick self-made script. 
- **Regular**: This is slowing down progress. There is a workaround but it is not exactly ideal. 
- **Minor**: You noticed a missing feature or a bug but it doesn't stop/slow you in your current work.

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/Issues_Labels.PNG) 

Outside of those two main groups, 4 more labels are provided:
- **Compliance**: This is for people working directly within the code. You found some code that doesn't follow th rules we have in place for how the code should be structured and would like this to be fixed.
- **Question**: When you don't have anything specific you need to be changed but would like some clarification on a specific point or would like to start a debate.
- **Test_script**: You have created some new functionality and would like it to have its own set of automatic testing scripts to make sure it is regularly checked. Notice that you have to raise the issue where the test scripts will be written, NOT where the code to be tested is.
- **Documentation**: You find the documentation about a specific part of the code lacking. As for the test_script label, you need to raise the issue in the repository where the documentation is going to be created.