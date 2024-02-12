# Setting up a new Repo

This page provides instructions on how to set up a repository within BHoM to meet our guidelines/standards and assist our automated processes to work with the new repository. This is for brand new repositories, which by default will start life as __Prototype__ status. Once repositories progress to become __Beta__ repositories, the requirements for the repository will shift slightly, including additional requirements to the [branching strategy](https://bhom.xyz/documentation/Contributing/Best-practices/Branching-Strategy/). If further assistance is required, please reach out to the [DevOps team](https://github.com/orgs/BHoM/teams/devops).

1. Name the Repo _SoftwareNameOrFocus_ _Toolkit. It will likely end in Toolkit - see explaination [here](../Basics/BHoM-Toolkits.md). It may end in _Tool if the designation of the repository is for a zero-code tool rather than an interoperability toolkit. DevOps can assist in making the distinction if required.
1. Make sure the __Public__ option is selected.
1. Under Settings -> Options. Ensure only the merge option is enabled and the default commit message is set to be the Pull Request title.

![image](https://github.com/BHoM/documentation/assets/18049174/17347b30-9ef9-4446-b8bf-02edf0c63eaa)

2. Add a Team under Collaborators and teams

1. Under Branches. Set the __main__ Branch as ___protected___ with the following settings (click edit on the right-hand side of the listed main branch)

![image](https://user-images.githubusercontent.com/16853390/50325923-859a0000-0522-11e9-95ba-486c8e55dfe6.png)

1. If you don't have a team for that repo yet, you can create it [here](https://github.com/orgs/BHoM/teams). Make sure the team has the same name as the repo and that you have added the repo into its list of repositories with the the **"Write"** access level. Now you should be able to link it in the branch setup page above.

## Initial Content

TODO: provide details about:
- Readme file
- License file
- gitignore file
- VS template