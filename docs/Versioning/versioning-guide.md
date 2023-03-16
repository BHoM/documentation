# Versioning guide: implementing versioning for your changes

Versioning can be implemented in one or two ways, as explained in detail in the following sections:

1. By adding a `Versioning_XX.json` file to your project, where XX is the current version of BHoM.
2. By adding a `PreviousVersion` attribute to your changed method.

The choice of the appropriate one depends on the change you are doing. Let's go through the code changes that BHoM Versioning can address.


## Changes on methods

This section addresses how to do Versioning for code changes done to methods, which are probably the most common. There are two possibilites here, and the first is simpler and to be preferred.

### Via the `PreviousVersion` attribute

We recommend to simply add a `PreviousVersion` attribute on top of the method you are modifying. This attribute takes two arguments:
- The first argument of the attribute is the current version of BHoM, e.g. `6.1`. 
- The second argument is _the method's Versioning key_, [obtainable as explained in its dedicated section](#obtaining-a-versioning-key).

Some examples of its usage below.


#### Example: `PreviousVersion` attribute applied to a regular method that is being renamed

In this example, a method whose full name was `FilterFamilyTypesOfFamily`, located in the namespace `BH.Engine.Adapters.Revit` and hosted under the static class `Create`, is renamed to `FilterTypesOfFamily`.

!!! example "Versioning using the `PreviousVersion` attribute for a method being renamed"

    ```c#
    public static partial class Create
    {
        [PreviousVersion("3.2", "BH.Engine.Adapters.Revit.Create.FilterFamilyTypesOfFamily(BH.oM.Base.IBHoMObject)")]
        [Description("Creates an IRequest that filters Revit Family Types of input Family.")]
        [Input("bHoMObject", "BHoMObject that contains ElementId of a correspondent Revit element under Revit_elementId CustomData key - usually previously pulled from Revit.")]
        [Output("F", "IRequest to be used to filter Revit Family Types of a Family.")]
        public static FilterTypesOfFamily FilterTypesOfFamily(IBHoMObject bHoMObject)
        {
            //....
        }
    ```

#### Example: `PreviousVersion` attribute applied to a method whose inputs are being changed

In this example, a method inputs are being changed: an input (the second one) is being removed.  
The method in the example is a [constructor](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors), but the same example applies to any method. Constructors are rarely used in BHoM – we prefer `Create` Engine methods, which get exposed to UIs – but some types, in particular `BHoM_Adapter` implementations, make use of them.

!!! example "Versioning using the `PreviousVersion` attribute for a method whose inputs are being changed"

    ```c#
    public partial class XMLAdapter : BHoMAdapter
    {
        [PreviousVersion("3.2", "BH.Adapter.XML.XMLAdapter(BH.oM.Adapter.FileSettings, BH.oM.XML.Settings.XMLSettings)")]
        [Description("Specify XML file and properties for data transfer")]
        [Input("fileSettings", "Input the file settings to get the file name and directory the XML Adapter should use")]
        [Input("xmlSettings", "Input the additional XML Settings the adapter should use. Only used when pushing to an XML file. Default null")]
        [Output("adapter", "Adapter to XML")]
        public XMLAdapter(BH.oM.Adapter.FileSettings fileSettings = null)
        {
            //....
        }
    ```

### Via the versioning json file

This alternative is trickier and not required in most cases.

The way to do it is to provide a `Method` section in the `VersioningXX.json` file. 

- Add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- [Create a Versioning key as explained here](#obtaining-a-versioning-key). 
- Get a representational string of the method, [like this](https://user-images.githubusercontent.com/16853390/82109755-2964fb00-976b-11ea-838e-ad9b80ff2455.png). If you are changing a constructor method, just leave the `methodName` input empty.
- Add the following to the `Method` section of the `VersioningXX.json` file, as shown in the below example; make sure to place your changing method's Versioning key and representational string.


!!! example "Versioning using the `Versioning.json` file for a method whose inputs are being changed"

    ```json
      "Method": {
        "ToNew": {
          "BH.Adapter.XML.XMLAdapter(BH.oM.Adapter.FileSettings, BH.oM.XML.Settings.XMLSettings)": {
            "_t": "System.Reflection.MethodBase",
            "TypeName": "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.Adapter.XML.XMLAdapter, XML_Adapter, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null\" }",
            "MethodName": ".ctor",
            "Parameters": [
              "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.oM.Adapter.FileSettings\" }"
            ]
          }
        },
        "ToOld": {

        }
      }
    ```


## Changes on names of object types

Modifying the name of a type (i.e. of a class, an object's type) requires to:

- add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- add versioning information to the Versioning json file: provide the full name of the old type (namespace + type name) as key and the full name of the new type as value. 
 
In order to make the change backward compatible (i.e. to allow downgrading, i.e. to open a newer BHoM script from a machine running an older version of BHoM), you can fill the `ToOld` section with mirrored information. 

In the example below, we show how the Versioning json file looks like for two classes being renamed, respectively from `DocumentBuilder` to `GBXMLDocumentBuilder` and from `XMLSettings` to `GBXMLSettings`.

!!! example "Adding information to the `Versioning.json` file regarding two classes being renamed"

    ```json
    {
      ...
      "Type": {
        "ToNew": {
          "BH.oM.XML.Settings.XMLSettings": "BH.oM.External.XML.Settings.GBXMLSettings",
          "BH.oM.XML.Environment.DocumentBuilder": "BH.oM.External.XML.GBXML.GBXMLDocumentBuilder"
        },
        "ToOld": {
          "BH.oM.External.XML.Settings.GBXMLSettings": "BH.oM.XML.Settings.XMLSettings",
          "BH.oM.External.XML.GBXML.GBXMLDocumentBuilder": "BH.oM.XML.Environment.DocumentBuilder"
        }
      }
    }
    ```

## Changes in namespaces

This applies to the case where an entire namespace is renamed. This means all the elements inside that namespace will now belong to a new namespace. 

To record that change:
- Add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- provide the old namespace as key and the new namespace as value to the `Namespace.ToNew` section of the json file. 

In order to make the change backward compatible (i.e. to allow downgrading, i.e. to open a newer BHoM script from a machine running an older version of BHoM), you can fill the `ToOld` section with mirrored information.

!!! Example "Change in namespace"

    ```json
    {
      "Namespace": {
        "ToNew": {
          "BH.oM.XML":  "BH.oM.External.XML",
        },
        "ToOld": {
          "BH.oM.External.XML": "BH.oM.XML",
        }
      },
      ...
    }
    ```

## Changes in objects

### Changes in an object's property names

For the case where an object type was only modified by renaming some of its property, we have a simple solution, similar the one for namespaces and type names. 
It requires to:

- add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- add versioning information to the Versioning json file under the `Property.ToNew` entry. As a key, provide the full name of the type that contains the property you are renaming (namespace + type name) followed by the old property name. The value must be the new property name. 

In order to make the change backward compatible (i.e. to allow downgrading, i.e. to open a newer BHoM script from a machine running an older version of BHoM), you can fill the `ToOld` section with mirrored information. 

In the following example, two properties of the object `Bar` that lives in the namespace `BH.oM.Structure.Elements` are being renamed repectively from `StartNode` to `Start` and from `EndNode` to `End`.

!!! example "Changes in an object's property names"

    ```json
    "Property": {
        "ToNew": {
            "BH.oM.Structure.Elements.Bar.StartNode": "Start",
            "BH.oM.Structure.Elements.Bar.EndNode": "End"
        },
        "ToOld": {
            "BH.oM.Structure.Elements.Bar.Start": "StartNode",
            "BH.oM.Structure.Elements.Bar.End": "End",
        }
      }
    ```

### Structural changes to an object

What if you completely redesigned a type of object and changed the properties that define it?

This case cannot be solved by a simple replacement of a string and will most likely require some calculations to go from the old object to the new one. This means we need a method that takes the old object in and return the new. This fact presents two challenges: 

- The old object definition will not exist anymore, so we cannot use that as the input of the conversion method. Instead we will use a Dictionary containing the properties for both input and output of that conversion method. The other benefit is that the upgrader will not have to depend on BHoM dlls to be able to do the conversion.
- The conversion method needs to be compile and the upgrader needs to be able to access it. While there are ways to keep the conversion method decentralised, it is way simpler to have it in the versioning toolkit directly. This means this is the only case where you cannot just write the upgrade from your own repo. Luckily, this case is less frequent than the others.

So what do you need to do to cover the upgrade?
- First, locate the `Converter.cs` file int the project of the current upgrader.
- In that file, write a conversion method with the following signature: `public static Dictionary<string, object> UpgradeOldClassName(Dictionary<string, object> old)`. 
- In the `Converter` constructor, add that method to the `ToNewObject` Dictionary. the key is that object type full name (namespace + type name) and the value is the method.
- If you want to cover backward compatibility, you can also write a `DowngradeNewClassName` method and add it to the `ToOldObject` dictionary.

Here's an example.

!!! example "Structural changes to an object"

    ```c#
    public class Converter : Base.Converter
    {
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Converter() : base()
        {
            PreviousVersion = "";

            ToNewObject.Add("BH.oM.Versioning.OldVersion", UpgradeOldVersion); 
        }


        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/


        public static Dictionary<string, object> UpgradeOldVersion(Dictionary<string, object> old)
        {
            if (old == null)
                return null;

            double A = 0;
            if (old.ContainsKey("A")) 
                A = (double)old["A"];

            double B = 0;
            if (old.ContainsKey("B"))
                B = (double)old["B"];

            return new Dictionary<string, object>
            {
                { "_t",  "BH.oM.Versioning.NewVersion" },
                { "AplusB", A + B },
                { "AminusB", A - B }
            };
        }

        /***************************************************/
    }
    ```

A few things to notice:
- You are working from a Dictionary so make sure that the properties exist before using them
- You will also need to cast them since the dictionary values are all objects
- Make sure to provide the new object type in the dictionary by defining the "_t" property.


## Changes in a Dataset name or location

Updating the path to a Dataset works in a similar manner to changes to names of types. The path to a dataset is changed the path from C:\ProgramData\BHoM\Datasets leading up to the json file has been changed in any way. This could be for example be one or more of the following:

- The name of the json file has been changed
- The name of the folder or any super-folder of the json file has been changed
- An additional folder has been added to the path
- A folder has been removed from the path

When this has happened, you will need to:

- add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- add versioning information to the Versioning json file under the `Dataset` entries, as shown in the example below.

In the example below, the Versioning json file specifies the move of some structural material files to a parent folder called `Structure`.

!!! example "Changes in a Dataset name or location"

    ```json
    {
      "Dataset": {
        "ToNew": {
          "Materials\\MaterialsEurope\\Concrete": "Structure\\Materials\\MaterialsEurope\\Concrete",
          "Materials\\MaterialsEurope\\Rebar": "Structure\\Materials\\MaterialsEurope\\Rebar",
          "Materials\\MaterialsEurope\\Steel(Grade)": "Structure\\Materials\\MaterialsEurope\\Steel(Grade)",
          "Materials\\MaterialsEurope\\Steel": "Structure\\Materials\\MaterialsEurope\\Steel",
          "Materials\\MaterialsUSA\\Concrete": "Structure\\Materials\\MaterialsUSA\\Concrete",
          "Materials\\MaterialsUSA\\Steel": "Structure\\Materials\\MaterialsUSA\\Steel",
        },
        "ToOld": {
          "Structure\\Materials\\MaterialsEurope\\Concrete": "Materials\\MaterialsEurope\\Concrete",
          "Structure\\Materials\\MaterialsEurope\\Rebar": "Materials\\MaterialsEurope\\Rebar",
          "Structure\\Materials\\MaterialsEurope\\Steel(Grade)": "Materials\\MaterialsEurope\\Steel(Grade)",
          "Structure\\Materials\\MaterialsEurope\\Steel": "Materials\\MaterialsEurope\\Steel",
          "Structure\\Materials\\MaterialsUSA\\Concrete": "Materials\\MaterialsUSA\\Concrete",
          "Structure\\Materials\\MaterialsUSA\\Steel": "Materials\\MaterialsUSA\\Steel",
        }
      }
    }
    ```

When versioning Dataset the `ToNew` segment is required, and not optional. This is for the BHoM_UI to be able to update components linking to the Dataset.

The `ToOld`versioning of Dataset is optional, but should be done if the developer wants to ensure that the Dataset still is acessible from the same serach paths as before, for calls to the methods in the Library_Engine to still work. This could for example be to ensure the call `BH.Engine.Library.Libraries("Materials\\MaterialsEurope\\Concrete")` still returns the same Dataset as before the change was made. It is strongly recomended that calls like the above from  code is updated at the same time as the change to the dataset is made, but generally recomended that the `ToOld` versioning is done to ensure calls from any UI and that code calls to the methods outside the control of the developer making the change is still functions as before.

### Removed Dataset

When a dataset is removed without a replacement, a message should be provided, similar to how it is done for objects and methods. For datasets this is done via the MessageForDeleted section of the Dataset part of the upgrade. Example below showcasing a case where the European concrete and rebar materials have been removed:

!!! example "Removed Dataset"

    ```json
    {
      "Dataset": {
        "ToNew": {
        },
        "ToOld": {
        }
        "MessageForDeleted": {
          "Materials\\MaterialsEurope\\Concrete": "Clear message why this dataset has been removed. Point of contact (could be a github repository) where the user can ask questions about why this was removed.",
          "Materials\\MaterialsEurope\\Rebar": "Clear message why this dataset has been removed. Point of contact (could be a github repository) where the user can ask questions about why this was removed.",
        }
      }
    }
    ```


## Items that cannot be versioned: deletions or foundational changes

In some cases, an upgrade/downgrade of a method or object is simply not possible:

- The item was deleted without replacement
- A replacement exists but is so different from the original that an automatic conversion is impossible.

In such cases, it is important to inform the user and provide them with as much information as possible to facilitate the transition to the new version of the code. You will need to:

- add a `VersioningXX.json` file to the project, if it does not yet exists for the current version of BHoM, [as explained here](#adding-a-versioning_xxjson-file-to-the-project).
- add versioning information to the Versioning json file under the `MessageForDeleted` and/or `MessageForNoUpgrade` entries. As shown in the example below.


!!! example "Items that cannot be versioned"

    ```json
    {
      ...
      "MessageForDeleted": {
        "BH.oM.Adapters.DIALux.Furnishing": "This object was provided to build up DIALux models within a BHoM UI, but was deemed to be unnecessary with the suitable conversions between existing Environmental objects and DIALux provided by the DIALux Adapter. To avoid confusion, this object has been removed. If further assistance is needed, please raise an issue on https://github.com/BHoM/DIALux_Toolkit/issues",
        "BH.Engine.Grasshopper.Compute.IRenderMeshes(BH.oM.Geometry.IGeometry, Grasshopper.Kernel.GH_PreviewMeshArgs)": "The method was made internal to the Grasshopper Toolkit. If you still need to render objects, consider using one of the Render methods from BH.Engine.Representation instead",
        "BH.Engine.Adapters.Revit.Query.Location(BH.oM.Adapters.Revit.Elements.ModelInstance)": "This method was a duplicate of GetProperty method, please use the latter instead.",
        "BH.Engine.BuildingEnvironment.Convert.ToConstruction(BH.oM.Base.CustomObject)": "This method was providing a highly specific conversion between a specific custom data schema and Environment Materials that is no longer relevant to the workflows provided in Environments. It is advised to create materials manually using the Solid or Gas types as appropriate. For more assistance please raise an issue for discussion on https://github.com/BuroHappoldEngineering/BuildingEnvironments_Toolkit/issues",
      },
      "MessageForNoUpgrade": {
        "BH.oM.Structure.Loads.BarVaryingDistributedLoad": "The object has been redefined in such a way that automatic versioning is not possible. To reinstate the objects you could try exploding the CustomObject that will have been returned and make use of the BH.Enigne.Structure.Create.BarVaryingDistributedLoadDistanceBothEnds method from the Structures_Engine. If doing this, treat DistanceFromA as startToStartDistance and DistanceFromB as endToEndDistance. Also, treat ForceA and MomentA as ForceAtStart and MomentAtStart, and ForceB and MomentB as ForceAtEnd and MomentAtEnd. If you have any issues with the above, please feel free to raise an issue at https://github.com/BHoM/BHoM_Engine/issues.",
        "BH.Engine.Reflection.Modify.SetPropertyValue(System.Collections.Generic.List<BH.oM.Base.IBHoMObject>, System.Type, System.String, System.Object)": "Please use BH.Engine.Reflection.Modify.SetPropertyValue(object obj, string propName, object value) instead.",
        "BH.Engine.Base.Compute.Hash(BH.oM.Base.IObject, System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.Type>, System.Int32)": "This method's functionality has changed deeply with respect to an older version of BHoM. Please replace this component with BH.Engine.Base.Query.Hash(), then plug the inputs as needed.",
        "BH.Engine.Adapters.Revit.Create.ViewPlan": "This method is not available any more. To reinstate the object, please use BH.Engine.Adapters.Revit.Create(string, string) instead.",
        "BH.oM.LifeCycleAssessment.MEPScope": "This object has been updated to include new features to enhance calculations for LifeCycleAssesment workflows. Please update the object on the canvas using the default create component to update this component. For further assistance, please raise an issue on https://github.com/BHoM/LifeCycleAssessment_Toolkit/issues",
      }
    }
    ```

## Obtaining a Versioning Key

A versioning key is like a signature identifying a method or object. 
You can obtain it by using the `BH.Engine.Versioning.VersioningKey()` method, like explained below.

❗ **NOTE**⚠️ you need to get the versioning key of the object/method _before_ it was modified. If you have already done your code changes, you can simply commit your changes on your branch, then switch back to the `develop` branch and recompile.

### Versioning key for objects and Adapters

Just provide the input `declaringType`, which is the Full Name of the object that you are modifying (i.e. the name of the class preceded by its namespace).
![image](https://user-images.githubusercontent.com/6352844/225602151-6c27ee73-288c-440c-bfef-e94226f7a72c.png)


### Versioning key for methods
Provide both:
- the input `declaringType`, which is the Full Name of the Query/Compute/Create/Modify/Convert class (i.e. the name of the class, preceded by its namespace) which contains the method that you are modifying;
- the input `methodName`, which is the name of the method that you are modifying (in case you are renaming the method, this needs to be its name _before_ the rename).

Example: 
![image](https://user-images.githubusercontent.com/6352844/225602396-491f351c-2cf3-498e-bc9c-347e1667c71d.png)

## Adding a `Versioning_XX.json` file to the project

Adding a `Versioning_XX.json` file to the project is needed for certain versioning scenarios, but not all. In some cases (e.g. changes in a method) it may be sufficient to use the `PreviousVersion` attribute.

This is as simple as adding an empty json file to the project, named `Versioning_XX.json`, where the `XX` must be replaced with the current BHoM version. For example:

![image](https://user-images.githubusercontent.com/6352844/225606913-3f6a767d-5111-4fee-87c3-1d88e1727f8a.png)

The empty file should then be immediately populated with the following content (copy-paste it!):

```json
{
  "Namespace": {
    "ToNew": {
    },
    "ToOld": {
    }
  },
  "Type": {
    "ToNew": {

    },
    "ToOld": {
    }
  },
  "Property": {
    "ToNew": {
    },
    "ToOld": {
    }
  },
  "MessageForDeleted": {
  },
  "MessageForNoUpgrade": {
  }
}
```

Then you can fill it in as described by the relevant "changes" section.

### Why having a `Versioning_XX.json` file?
BHoM Versioning is implemented via a specific, stand-alone mechanism, hosted in the Versioning_Toolkit.

The information related to the changes to the current BHoM version are stored locally at the root of each project where the change occurred, so that everyone can independently change BHoM objects or methods without the need to modify the Versioning_Toolkit.


# Troubleshooting on Versioning

## The upgrade doesn't happen - How can I debug ?

The upgrader are independent exe files so you cannot reach them by attaching to your UI process as you would normally do when debugging the BHoM. They are also hidden processed so you don't have command windows popping up when opening old scripts. In case, you need to figure out what is going on in there, you can always have those upgrade processes visible by commenting two lines of code in the Versioning_Engine (situated on the code `BHoM_Engine` repo):

- In the Versioning-Engine project, find the `ToNewVersion` file
- In that file, find the `GetPipe` method 
- Toward the end of that method, comment out the following line:

```c#
process.StartInfo.UseShellExecute = false;
process.StartInfo.CreateNoWindow = true;
```
- recompile the solution and the BHoM_UI as usual

You should now have command windows popping up as soon as the upgrader are needed. You should also find the BHoMUpgrader processes in your task manager.

## Walkthroughs on Versioning
* [How to check your versioned changes are working](/documentation/How-to-check-your-versioned-changes-are-working-%3F)
* [Property name change](/documentation/Change-to-a-property-name)
* [Object name change and associated custom create method](/documentation/Object-name-change-and-associated-custom-create-method)

