# Setting up a new Repo

It is recommended that you use the [template repository](https://github.com/BHoM/template-repository) for initial set up of your new repository. It will include an appropriate `gitignore` file, a suitable Visual Studio file, and a `ReadMe` file which can be easily updated for your repository. It will also include some sample code for an oM, Engine, and Adapter to get you started.

This page provides instructions on how to set up a repository within BHoM to meet our guidelines/standards and assist our automated processes to work with the new repository. This is for brand new repositories, which by default will start life as __Prototype__ status. Once repositories progress to become __Beta__ repositories, the requirements for the repository will shift slightly, including additional requirements to the [branching strategy](https://bhom.xyz/documentation/Contributing/Best-practices/Branching-Strategy/). If further assistance is required, please reach out to the [DevOps team](https://github.com/orgs/BHoM/teams/devops).

1. Select the repository template - ![image](https://github.com/BHoM/documentation/assets/18049174/bdba3548-0d83-43d2-9c4d-06a51fb7e165)
1. Name the Repo _SoftwareNameOrFocus_ _Toolkit. It will likely end in Toolkit - see explaination [here](../Basics/BHoM-Toolkits.md). It may end in _Tool if the designation of the repository is for a zero-code tool rather than an interoperability toolkit. DevOps can assist in making the distinction if required.
1. Make sure the __Public__ option is selected.
1. Under Settings -> Options. Ensure only the merge option is enabled and the default commit message is set to be the Pull Request title - ![image](https://github.com/BHoM/documentation/assets/18049174/17347b30-9ef9-4446-b8bf-02edf0c63eaa)
1. Add a Team under Collaborators and teams
1. Under Branches. Set the __main__ Branch as ___protected___ with the following settings (click edit on the right-hand side of the listed main branch)

![image](https://github.com/BHoM/documentation/assets/18049174/85b0d3c7-b055-4399-8b78-2d9783049fc7)
![image](https://github.com/BHoM/documentation/assets/18049174/23c57880-2b27-4339-b8de-7d40ea67a24d)
![image](https://github.com/BHoM/documentation/assets/18049174/a34701bd-c732-4f24-8009-749e435fd9bd)
![image](https://github.com/BHoM/documentation/assets/18049174/225108d0-4c79-43f3-9ce6-2514917d0e76)
![image](https://github.com/BHoM/documentation/assets/18049174/c9bb55a6-4d00-403c-a99e-24a2e12da746)

If you don't have a team for that repo yet, you can create it [here](https://github.com/orgs/BHoM/teams). Make sure the team has the same name as the repo and that you have added the repo into its list of repositories with the the **"Write"** access level. Now you should be able to link it in the branch setup page above.