# How to use Git

## Introduction

This documentation will be focused on the use of Git Bash.

The first step is to create a space on your computer where you want all your local files to be stored. Now you want to create different repositories (repos) in this folder. Do this by opening up git bash and using `git clone (web address)`. [A good list of repos for getting started can be found here.](https://bhom.xyz/documentation/Contributing/Getting-started-for-developers/)

## Pushing code changes to GitHub

Before getting started it is recommended to [read through this](https://docs.github.com/en/get-started/quickstart/github-flow) first.

Start off by creating a new branch with an [appropriate name.](https://bhom.xyz/documentation/Development/Best%20practices/Branching-Strategy/)

You create a new branch with 'git checkout -b (name of the branch)'. Make sure that you are on develop when creating a new branch to prevent branches created from other branches. 
It is now time for you to do the changes you wish to do. When you are satisfied with everything it is time make a commit. You should always rebuild the code to make sure that it compiles, and if needed test out the code before pushing it to GitHub. 

Start by running 'git status' which will show you, in red, all of the files that has been changed. If everything looks alright use 'git add .' which adds all of the files to the commit. If you wish to only add selected files you can use 'git add (name of the file)' for the files you wish to include. 

Once the files are added it can be a good idea to double-check using 'git status' again, and the included files should now be showed in green instead of red.
Then it is time to use commit these changes with 'git commit -m ("message")'. Keep in mind that this message will be shown on GitHub along the commit so a somewhat brief explanation of what is included in the commit can be a good idea.

Finally it is time to actually push the commit to GitHub with 'git push origin (branch name)'. It is now possible to create a [pull request on GitHub.](https://bhom.xyz/documentation/Contributing/Pull-Requests/)	
If you were to need to make any more changes before the PR is merged just make sure you are on your branch for that feature, (no need to create a new branch) and do the necessary changes and then  start the push process again, starting with **git status** and 'git add .'. 
  

## Avoiding conflicts

In order to avoid conflicts when creating pull requests make sure that the repository you are working on is up to date. 
Make sure you are on the develop branch by using 'git checkout develop'
Start off by using **git fetch origin** which gets updates from other repositories and then 'git pull origin (branch name)' to then update your code from others.

