### INSTRUCTIONS

In Visual Studio, do File --> New Project and search for "BHoM". Select the template "BHoM Toolkit Template".

0. Take SoftwareName_Toolkit.zip from the `documentation` repo and copy it over to your Visual Studio `ProjectTemplates` folder, generally in: 
`C:\userName\Documents\Visual Studio 20xx\Templates\ProjectTemplates`

1. If Visual Studio displays the checkbox "_Place solution and project in the same directory_" (VS version 2019 onwards), select it. 

   (For all other VS versions, just make sure that the checkbox "Create directory for solution" is ticked). 

2. Specify your "SoftwareName" as the name of the solution. CamelCase, no spaces.

3. As parent root folder, specify the folder where you keep all other BHoM repos (generally, your GitHub folder `C:\Users\userName\GitHub\`). 

4. Select "Create" to create the new Toolkit solution.

This will result in a folder under your GitHub folder, such as `...\GitHub\SoftwareName`, with the template code inside, and the solution will open in Visual Studio.

Once the solution is created:

5. Close Visual Studio.

6. (Applies only you couldn't do step 1. "_Place solution and project in the same directory_")

   Go in the repo folder, which will be called "SoftwareName". It will contain only the solution file "SoftwareName.sln" and another folder "SoftwareName".
   
   Enter in this "SoftwareName" folder, take all the folders and files and move them one folder up, so they sit together with the .sln file. 
   
   Delete the resulting empty folder "SoftwareName".

7. Rename the solution name and the folder name: 
   
   7.1. Add "_Toolkit" to the solution name
   
   7.2. Add "_Toolkit" to the toolkit containing folder name.

8. Open the solution again.

   If you could do step 1. "_Place solution and project in the same directory_", everything will be working and you are good to go.

   Otherwise, if you couldn't do step 1, you will get "Project loading errors" due to the folder renaming of step 7. To correct:
   
     In Solution Explorer, right click each project and do "Remove".
     Then right-click on the Solution name and do "Add Existing Project". 
     Browse and select the `SoftwareName_Adapter`, `SoftwareName_Engine` and `SoftwareName_oM` projects in their new location.
   

