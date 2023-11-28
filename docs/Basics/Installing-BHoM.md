# Installing BHoM

A BHoM installer is released quarterly and is subject to thorough testing.

## Installation steps
1. Download the BHoM installer from [bhom.xyz](https://bhom.xyz/).
2. Make sure **all instances of Rhino, Excel and Revit** are closed before running the BHoM installer.
3. Run the BHoM installer. The installer does not require administrative privileges. If asked for permission, just click OK and proceed.
4. Check if BHoM was correctly installed:

!!! example "Check if BHoM is correctly installed"

    === "Grasshopper"
     
        Open Grasshopper and verify that the BHoM tab is present.  
        ![image](https://github.com/BHoM/documentation/assets/6352844/cd826376-5319-4388-bbdf-a8fe0fcb85e2)
    
        Click in any empty spot, then press CTRL+Shift+B. This should open up the BHoM menu.  
        Try typing something there, like "Point". You should see a list of components.  
        ![image](https://github.com/BHoM/documentation/assets/6352844/22a3217b-ebaf-4a71-bdc0-c109db8ab4dd)

    === "Excel"

        Open Excel and verify if the BHoM tab is present:
        ![image](https://github.com/BHoM/documentation/assets/6352844/1dfeb5a2-0851-4540-9af7-5bfc215a1b90)

        Click on any cell, then press CTRL+Shift+B. This should open up the BHoM menu.  
        Try typing something there, like "Point". You should see a list of components.  
        ![image](https://github.com/BHoM/documentation/assets/6352844/e79fa6dc-19dd-4b81-abb4-26b6cdf20216)

## Installation troubleshooting / FAQ

### Can't install – _Error writing to file XXX: Verify you have access_

If you get an error such as:

![image](https://github.com/BHoM/documentation/assets/6352844/234a043c-8413-4cff-a385-f5d14c1ed4ee)

This can happen on Windows multi-user machines where a previous user had installed an old version of BHoM, and the current user that is trying to install it for himself does not have admin rights.

The solution is to delete the `C:\ProgramData\BHoM` folder.  
Unfortunately, if you don't have admin rights, the only way is to ask your Administrator to delete it.

Once the folder has been deleted, any user (also without admin rights) will be able to install BHoM correctly.

## Developers and contributors 🤖
Developers, general contributors, as well as those who need a special version of a toolkit, may need to compile the source code themselves.  
Please read [Getting started for developers](<../Guides-and-Tutorials/Coding-with-BHoM/index.md>) for more info.

!!! note "Alpha installer"

    We have a CI/CD pipeline that produces Daily alpha versions of the installer.
    
    At the moment, we don't currently publish Alpha installers due to some techincal issues.  
    Please get in touch with us, for example opening a GitHub discussion, if you'd like us to proritize them being published again.  
    You can also ask a member of the team to share an alpha installer, if required for some particular development exercise.
    
    The Alpha installer includes the most up-to-date changes present on each repository `develop` branch (or, in absence of that, the `main` branch). 
    Testing before merging to `develop` (or `main`) is always conducted, so a good level of stability can always be expected, although integration tests are limited on this stage. 
    Certain features may be subject to modifications or corrections until they become permanet features after the beta release.
