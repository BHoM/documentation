# Coding BHoM in a Grasshopper CSharp script component

BHoM can be referenced and used in a Grasshopper "C# Script" component. The only additional requirement as of the current version is to also reference `netstandard.dll` in the same Grasshopper component.

## Find the .NET Standard assembly dll file

Currently, a reference to the .NET Standard assembly is required to use BHoM from a C# script component in Grasshopper. 

You can generally find the .NET Standard assembly somewhere in your C: drive. Search for `netstandard.dll` in Explorer from your C: drive.
![Alt text](image-2.png)

Once found, get its location by right-clicking on it and doing "Open location", then copy the location in Explorer. Take note of it.

### If you can't find the .NET Standard assembly
If you can't find a `netstandard.dll` in your disk, you can download it from [here](https://www.nuget.org/packages/NETStandard.Library). Click on "download package". Open the downloaded `.npckg` file with a Zip archiver like 7zip. Go in the folder `build/netstandard2.0/ref/` and you will find `netstandard.dll`. Place the `netstandard.dll` somewhere in your C: drive where you will be able to find it. You could place it in the BHoM ProgramData directory, but be aware that if you reinstall or update BHoM it will get deleted.


## Reference the assemblies in the C# Script component

To start coding let's create a "C# Script" component in Grasshopper where we will reference the required DLLs.
1. Drop a "C# Script" component in the canvas.
2. Right click it, do "Manage Assemblies". A window will pop up.
3. Click "Add". A File Explorer window will pop up.
4. Add a reference to the `netstandard.dll` file, found as explained above. Select it and do "Open". You will see that it appears in the Referenced Assemblies section.
5. Click "Add" again. Navigate to the BHoM installation directory (`C:\ProgramData\BHoM\Assemblies`). There you will find all BHoM DLLs. As a minimum, we will want to include `BHoM.dll` and `BHoM_Engine.dll`. We can add as many as we need, but don't add them all together. You will come back to add more in case the script complains that some are missing.

![Referenced assemblies](referenced_assemblies01.png)

    

## Start scripting!

Let's make an example where we want to create a `BH.oM.Geometry.Point` object in the script. To do so, we need to add another 2 references, `Geometry_oM.dll` and `Dimensional_oM.dll`. Let's do that as explained above. We will end up having the following:

![Alt text](referenced_assemblies02.png)

Next, let's open the script and write:
```cs

BH.oM.Geometry.Point p = new BH.oM.Geometry.Point();
p.X = 3;
p.Y = 5;
p.Z = 1;

A = p;
```

You will have this:

![Alt text](examplescript.png)

Press OK, and voila, a BHoM point is created! You can also check its values with the `Explode` component:

![Alt text](examplescript_output.png)


### Script with more complex objects

Do the same for any other BHoM object you may want to create. Using more complex objects will require to add more references, like explained in the previous section. For example, if we want to create a structural node with this point, we can do:

```cs
BH.oM.Geometry.Point p = new BH.oM.Geometry.Point();
p.X = 3;
p.Y = 5;
p.Z = 1;

BH.oM.Structure.Elements.Node node = new BH.oM.Structure.Elements.Node();
node.Position = p;

A = p;
```

However, if you press OK, you will be met with an error like:

![Alt text](examplescript_error01.png)

This simply means that you need to add references to `Structure_oM.dll`. If we add that and try again, the error will still not go away, but will be different:

![Alt text](examplescript_error02.png)

This is because the `Structure_oM.dll` itself depends on `Analytical_oM.dll`.  
By adding this last dependency the error will go away.
