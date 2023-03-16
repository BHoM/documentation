# Technical background on Versioning

If you want to know about how the upgrader does its job, this section is for you. Otherwise, feel free to skip it.

## How does BHoM Versioning work?

Alongside the dlls installed in `AppData\Roaming\BHoM\Assemblies`, you can find in the `bin` sub-folder a series of `BHoMUpgrader` exe programs. When a type/method/object fails to deserialise from its string representation (json), those upgrader are called to the rescue.

Every quarter, when we release a new beta installer, we also produce a new upgrader named `BHoMUpgrader` with the version number attached at the end (e.g. `BHoMUpgrader32` for version 3.2). That upgrader contains all the changes to the code that occurred during the quarter.

When deserialisation fails in the BHoM, the BHoM version used to serialise the object is retrieved from the json. The json is then upgraded to the following version repeatedly until it reaches the current version where it can finally be deserialised into a BHoM object.

![image](https://user-images.githubusercontent.com/16853390/120576933-23b18480-c456-11eb-9a1c-c1ebf8995257.png)

### Decentralisation of the upgrade information

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

## How does the upgrader work?

The diagram below show the chains of calls between the 3 main upgrade methods:
- UpgradeMethod
- UpgradeType
- UPgradeObject

Note that `UpgradeType` is actually covering both the namespace replacement and the type name replacement. The reason behind it is that they come down to the same string replacement principles both at the beginning of an item full name (since types include their namespace in their full name too).

Also note that those three are the 3 places where an older upgrader can be called if needed.

![image](https://user-images.githubusercontent.com/16853390/82113415-7905ef80-9788-11ea-8d77-53c153286a2f.png)
