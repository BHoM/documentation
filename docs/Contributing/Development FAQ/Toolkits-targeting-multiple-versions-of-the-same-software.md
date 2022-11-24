It might happen that a Toolkit targeting a specific software will have to reference different assemblies for different versions of the software. 

For example, this happens for [ETABS_Toolkit](https://github.com/BHoM/ETABS_Toolkit). We will take it as an example in this page.

In ETABS, the various versions of the software have different API assemblies, and the assemblies have different names depending on the software version. For example: ETABS version 2016 has an API assembly named ETABS2016.dll; ETABS version 2017 has one named ETABSv17.dll.

For this reason, it's important to set the Build Configuration of the solution in a manner that allows the needed flexibility and maintains scalability.

For the sake of semplicity we will refer to this as **"versioning"** in this wiki page.

## Guidelines
### Limit the versioning to the VS Projects that need it

For example, ETABS_Toolkit needs to reference the software API (and therefore different versions of it) only in the project ETABS_Adapter.

This means that the other projects of the toolkit, namely ETABS_Engine and ETABS_oM, can avoid the problem altogether. No action should be taken on them.

### If only one VS Project needs versioning, make sure the others projects' _Build configuration_ target the _base_ build.
You can set this in Visual Studio _Build_ menu → _Configuration Manager_.

This means that Projects that do not need versioning – in the ETABS example the Engine and the oM – have to:
- For "Debug-type" builds: target the _base_ `Debug` configuration;
- For "Release-type" builds: terget the _base_ `Release` configuration.

The following screenshot shows an example for "Debug-type" build:
![image](https://user-images.githubusercontent.com/6352844/78662696-ca3cdc80-78c8-11ea-867b-685d6b3a93a9.png)

### Make sure builds are having clear separate assembly name
The assembly name can be set by modifying the Project's `.csproj` file.

> #### More info on how to modify the `.csproj`
> <details>
> This can be done by:  
>
> - In VS, right click the project in Solution Explorer → _Unload Project_ → right click again → edit `.csproj`. Edit,  save, then right-click again on the project and do _Reload Project_.  
>
> - OR by navigating to the project folder and editing the `.csproj` directly. 
> </detail>

The AssemblyName has to be defined so that it reflects the build version (e.g. 2017, 2018, etc.) and to be consistent with the naming conventions adopted for the specific Toolkit.

See the following example for the ETABS as an example:

```xml
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug17</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    ...
    <AssemblyName>ETABS17_Adapter</AssemblyName>
    ...
  </PropertyGroup>
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug18</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    ...
    <AssemblyName>ETABS18_Adapter</AssemblyName>
    ...
  </PropertyGroup>
```

### Test all builds are coming out correctly
Once you are done, please try to build using all configurations.

To ensure you are doing this correctly, go to the Toolkit's `Build` folder and delete all its contents every time you test a different Build.

### Make sure the a Build config is added to the BHoM installer
Contact the Toolkit's responsible - they will do it for you or assist you in doing that.