# Namespaces 

For those coding in C#, you will see that the namespaces are matching the 4 main C# project categories: oM, Engine, Adapter and UI. 

All code that exists within BHoM should start with a `BH` namespace.

Then, namespace suffixes are added to the base `BH` namespace via dots, depending on the code. Schemas (types, i.e. classes, interfaces and similar) should always fall into an `oM` namespace. Methods should go into an `Engine` namespace, Adapters into an `Adapter` namespace and User Interfaces into an `UI` namespace. 

Therefore, anything in BHoM should fall into one of the following namespaces:

1. BH.oM

2. BH.Engine

3. BH.Adapter

4. BH.UI

# Scope-specific namespaces

In general, anything in BHoM will target either a specific discipine, or group of concepts, or a software. For example, geometrical concepts like Point, Line and so on all have something in common: they are Geometrical concepts. Similarly, a Column and a Room can be defined as Architectural concepts. Therefore, namespaces typically should define which kind of scope they target. Example namespaces you can find are:
- `BH.oM.Geometry` - geometrical schemas
- `BH.Engine.Structure` - methods applicable to Structural concepts
- `BH.UI.Grasshopper` - functionality related to a BHoM User interface targeting the Grasshopper software.