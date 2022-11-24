# Versioning BHoM objects and methods

* [Why do we need versioning ?](#why-do-we-need-versioning-)
* [How does it work ?](#how-does-it-work-)
* [Decentralisation of the upgrade information](#decentralisation-of-the-upgrade-information)
* [Modifying namespaces](#modifying-namespaces)
* [Modifying methods](#modifying-methods)
* [Upgrading objects](#upgrading-objects)
* [Message for deleted items or items without upgrades](#message-for-deleted-items-or-items-without-upgrades)
* [The upgrade doesn't happen - How can I debug ?](#the-upgrade-doesnt-happen---how-can-i-debug-)
* [Technical details](#technical-details)
* [Example walk throughs](#example-walk-throughs)

## Why do we need versioning?

When a script created in one of our supported UI is saved, all the BHoM components save information about themselves so they can initialise properly when the script is re-opened. That information is simply kept in a string format (more precisely Json format) and contains details such as the component/method name, it's argument types, output types, ... 

If someone modifies a method definition in the code, it will become impossible to find that method based on outdated information and the initialisation of the component will fail. Unless, of course, we provide to the system a way to update that old json before using it to find the method.

The same logic applies for saved types (e.g. types of input/output of a component) and saved objects (e.g. objects stored in a database or file).

## How does it work ?

Alongside the dlls installed in `AppData\Roaming\BHoM\Assemblies`, you can find in the `bin` sub-folder a series of `BHoMUpgrader` exe programs. When a type/method/object fails to deserialise from its string representation (json), those upgrader are called to the rescue.

Every quarter, when we release a new beta installer, we also produce a new upgrader named `BHoMUpgrader` with the version number attached at the end (e.g. `BHoMUpgrader32` for version 3.2). That upgrader contains all the changes to the code that occurred during the quarter.

When deserialisation fails in the BHoM, the BHoM version used to serialise the object is retrieved from the json. The json is then upgraded to the following version repeatedly until it reaches the current version where it can finally be deserialised into a BHoM object.

![image](https://user-images.githubusercontent.com/16853390/120576933-23b18480-c456-11eb-9a1c-c1ebf8995257.png)

## Decentralisation of the upgrade information

We will go in details on how the upgrade information is stored inside an upgrader in the remaining sections. There is however one aspect worth mentioning already. Once a quarter is finished, an upgrader is never modified again and simply redistributed alongside the others. During that quarter however, the current upgrader is constantly updated to reflect the new changes. For everyone working on the BHoM to have to modify the exact same files inside the Versioning_Toolkit would be inconvenient and a frequent source of clashes. For that reason, the information related to the upgraded of the current quarter are stored locally at the root of each project where the change occurred. 

 ![image](https://user-images.githubusercontent.com/16853390/82024761-dcc5e500-96c2-11ea-86fc-53a6df0f14f5.png)

Notice that the file name ends with the version of the BHoM it applies to.

The content of an empty `Versioning_XX.json` file is as follow:

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

When the UI_PostBuild process that copies all the BHoM assemblies to the Roaming folder is ran (i.e. when BHoM_UI is compiled), the information from all the `Versioning_XX.json` files is collected and compiled in to a single json file copied to the roaming folder next to the BHoMUpgrader executable. It's content will look similar to the local json files with an extra section for the methods (more onto that later):

```json
{
  "Namespace": {
    "ToNew": {
      "BH.Engine.XML": "BH.Engine.External.XML",
      "BH.oM.XML": "BH.oM.External.XML"
    },
    "ToOld": {
      "BH.Engine.External.XML": "BH.Engine.XML",
      "BH.oM.External.XML": "BH.oM.XML"
    }
  },
  "Type": {
    "ToNew": {
      "BH.oM.Base.IBHoMFragment": "BH.oM.Base.IFragment",
      "BH.oM.Adapters.ETABS.EtabsConfig": "BH.oM.Adapters.ETABS.EtabsSettings", 
    },
    "ToOld": {
      "BH.oM.Base.IFragment": "BH.oM.Base.IBHoMFragment",
      "BH.oM.Adapters.ETABS.EtabsSettings":"BH.oM.Adapters.ETABS.EtabsConfig" 
    }
  },
  "Method": {
    "ToNew": {
        "BH.Adapter.XML.XMLAdapter(BH.oM.Adapter.FileSettings, BH.oM.XML.Settings.XMLSettings)": {
            "_t": "System.Reflection.MethodBase", 
            "TypeName": "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.Adapter.XML.XMLAdapter, XML_Adapter, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null\" }",
            "MethodName": ".ctor",
            "Parameters": [ "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.oM.Adapter.FileSettings\" }" ]
        },
        "BH.Engine.Geometry.Compute.ClipPolylines(BH.oM.Geometry.Polyline, BH.oM.Geometry.Polyline)": {
            "_t": "System.Reflection.MethodBase",
            "TypeName": "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.Engine.Geometry.Compute, Geometry_Engine, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null\" }",
            "MethodName": "BooleanIntersection",
            "Parameters": [ "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.oM.Geometry.Polyline\" }", "{ \"_t\" : \"System.Type\", \"Name\" : \"BH.oM.Geometry.Polyline\" }", "{ \"_t\" : \"System.Type\", \"Name\" : \"System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" }" ]
        }
    },
    "ToOld": {
      
    }
  },
  "Property": {
    "ToNew": {
        "BH.oM.Structure.Elements.Bar.StartNode": "BH.oM.Structure.Elements.Bar.Start",
        "BH.oM.Structure.Elements.Bar.EndNode": "BH.oM.Structure.Elements.Bar.End"
    },
    "ToOld": {
        "BH.oM.Structure.Elements.Bar.Start": "BH.oM.Structure.Elements.Bar.StartNode",
        "BH.oM.Structure.Elements.Bar.End": "BH.oM.Structure.Elements.Bar.End",
    }
  },
  "MessageForDeleted": {
  },
  "MessageForNoUpgrade": {
  }
}
```

Let's now go into details on how to record a change on the code for the various possible aspects that can be modified.

## Modifying namespaces

This applies to the case where an entire namespace is renamed. This means all the elements inside that namespace will now belong to a new namespace. 

To record that change, simply provide the old namespace as key and teh new namespace as value to the `Namspace.ToNew` section of the json file. If you want the change to be backward compatible, you can also fill the `ToOld` section with the mirrored information.

Example:

```
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

## Modifying names of types

Modifying the name of a type works very much the same way. Provide the full name of the old type (namespace + type name) as key and the full name of the new type as value. If you want the change to be backward compatible, you can also fill the `ToOld` section with the mirrored information.

Example:

```
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

## Modifying methods

Technically, we could the exact same thing for methods as we have done for types and namespaces. The content to provide is a bit more complex though. See for example

```
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

_**IF**_ you want to go that route, you can simply provide a `Method` section in the `VersioningXX.json` file and it will be picked up with the rest during the `UI_PostBuild` process. To create the key, you can use the `VersionKey` component _**before doing the change on your method**_:

![image](https://user-images.githubusercontent.com/16853390/82109653-52d15700-976a-11ea-9da5-cb60df287dcb.png)

If you update a constructor, just leave the `methodName` input empty.

The representation of the new method is simply the json string.

![image](https://user-images.githubusercontent.com/16853390/82109755-2964fb00-976b-11ea-838e-ad9b80ff2455.png)

But that's messy and admittedly difficult to read of you need to come back to it and check what is in the upgraded methods section.

_**SO**_, instead we recommend you use a `PreviousVersion` attribute on the method you have modified. For example, here's what it looks like for a constructor and a regular method:

```c#
public partial class XMLAdapter : BHoMAdapter
{
    [Description("Specify XML file and properties for data transfer")]
    [Input("fileSettings", "Input the file settings to get the file name and directory the XML Adapter should use")]
    [Input("xmlSettings", "Input the additional XML Settings the adapter should use. Only used when pushing to an XML file. Default null")]
    [Output("adapter", "Adapter to XML")]
    [PreviousVersion("3.2", "BH.Adapter.XML.XMLAdapter(BH.oM.Adapter.FileSettings, BH.oM.XML.Settings.XMLSettings)")]
    public XMLAdapter(BH.oM.Adapter.FileSettings fileSettings = null)
    {
        //....
    }
```

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

Notice that you still have to create the key using the `VersionKey` component but at least you don't have to deal with raw json.


## Upgrading objects

So far, we have focused on upgrading items that are used to save and restore components in the UI. But what about actual objects stored in a database or a file ? Well, if only their namespace or type name was modified, the solutions above will be enough. But what if you completely redesigned that type of object and changed the Properties that define it ?

This case cannot be solved by a simple replacement of a string and will most likely require some calculations to go from the old object to the new one. This means we need a method that takes the old object in and return the new. Two things about that: 
- The old object definition will not exist anymore so we cannot use that as the input of the conversion method. Instead we will use a Dictionary containing the properties for both input and output of that conversion method. The other benefit is that the upgrader will not have to depend on BHoM dlls to be able to do the conversion.
- The conversion method needs to be compile and the upgrader needs to be able to access it. While there are ways to keep the conversion method decentralised, it is way simpler to have it in the versioning toolkit directly. This means this is the only case where you cannot just write the upgrade from your own repo. Luckily, this case is less frequent than the others.

So what do you need to do to cover the upgrade then ?
- First, locate the `Converter.cs` file int the project of the current upgrader.
- In that file, write a conversion method with the following signature: `public static Dictionary<string, object> UpgradeOldClassName(Dictionary<string, object> old)`. 
- In the `Converter` constructor, add that method to the `ToNewObject` Dictionary. the key is that object type full name (namespace + type name) and the value is the method.
- If you want to cover backward compatibility, you can also write a `DowngradeNewClassName` method and add it to the `ToOldObject` dictionary.

Here's an example:

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

## Modifying property names

For the case where an object type was only modified by renaming some of its property, we have a simpler solution. One very similar to what was done for namespaces and type names actually. 

As a key, provide the full name of the containing type (namespace + type name) followed by the old property name. As a value as key, do the same but with the new property name. If you want the change to be backward compatible, you can also fill the `ToOld` section with the mirrored information.

Example:

```
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

## Message for deleted items or items without upgrades

In rare cases, an upgrade is simply not possible:
- The item was deleted without replacement
- A replacement exists but is so different from the original that an automatic conversion is impossible.

In both cases, it is important to inform the user and provide them with as much information as possible to facilitate the transition to the new version of the code. Here are a few example of how this can be achieved:

```
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

## Modifying a Dataset name or location

Updating the path to a Dataset works in a similar manner to changes to names of types. The path to a dataset is changed the path from C:\ProgramData\BHoM\Datasets leading up to the json file has been changed in any way. This could be for example be one or more of the following:

- The name of the json file has been changed
- The name of the folder or any super-folder of the json file has been changed
- An additional folder has been added to the path
- A folder has been removed from the path

When this has happened, the `Dataset` part of the versioning file should be modified. An example is shown below for versioning required for moving all structural materials to a super-folder called `Structure`

```
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

The `ToOld`versioning of Dataset is optional, but shouold be done if the developer wants to ensure that the Dataset still is acessible from the same serach paths as before, for calls to the methods in the Library_Engine to still work. This could for example be to ensure the call `BH.Engine.Library.Libraries("Materials\\MaterialsEurope\\Concrete")` still returns the same Dataset as before the change was made. It is strongly recomended that calls like the above from  code is updated at the same time as the change to the dataset is made, but generally recomended that the `ToOld` versioning is done to ensure calls from any UI and that code calls to the methods outside the control of the developer making the change is still functions as before.

### Removed Dataset

When a dataset is removed without a replacement, a message should be provided, similar to how it is done for objects and methods. For datasets this is done via the MessageForDeleted section of the Dataset part of the upgrade. Example below showcasing a case where the European concrete and rebar materials have been removed:

```
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

## Technical details

If you want to know about how the upgrader does its job, this section is for you. Otherwise, feel free to skip it.

The diagram below show the chains of calls between the 3 main upgrade methods:
- UpgradeMethod
- UpgradeType
- UPgradeObject

Note that `UpgradeType` is actually covering both the namespace replacement and the type name replacement. The reason behind it is that they come down to the same string replacement principles both at the beginning of an item full name (since types include their namespace in their full name too).

Also note that those three are the 3 places where an older upgrader can be called if needed.

![image](https://user-images.githubusercontent.com/16853390/82113415-7905ef80-9788-11ea-8d77-53c153286a2f.png)
## Example walk throughs
* [How to check your versioned changes are working](/How-to-check-your-versioned-changes-are-working-%3F)
* [Property name change](/Change-to-a-property-name)
* [Object name change and associated custom create method](/Object-name-change-and-associated-custom-create-method)