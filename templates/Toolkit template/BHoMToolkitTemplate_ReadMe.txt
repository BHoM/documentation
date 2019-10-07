### INSTRUCTIONS

In Visual Studio, do File --> New Project and search for "BHoM". Select the template "BHoM Toolkit Template".

1. If Visual Studio shows the checkbox "Place solution and project in the same directory" (VS 2019 onwards),
select it. (For all other VS versions, just make sure that "Create directory for solution" is ticked). 

2. Specify your "SoftwareName" as the name of the solution. CamelCase, no spaces.

3. As parent root folder, specify the folder where you keep all other BHoM repos (generally, your GitHub folder "C:\Users\userName\GitHub\"). 

4. Select "Create" to create the new Toolkit solution.

This will result in a folder under your GitHub folder, such as `...\GitHub\SoftwareName`, with the template code inside, and the solution will open in Visual Studio.

Once the solution is created:

5. Close Visual Studio.

6. (Applies only if you couldn't do step 1. "Place solution and project in the same directory") 
   Go in the repo folder, which will be called "SoftwareName". It will contain only the solution file "SoftwareName.sln" and another folder "SoftwareName".
   Enter in this "SoftwareName" folder, take all the folders and files and move them one folder up, so they sit together with the .sln file. 
   Delete the resulting empty folder "SoftwareName".

7. Rename the solution name and the folder name: 
   7.1. Add "_Toolkit" to the solution name
   7.2. Add "_Toolkit" to the toolkit containing folder name.

