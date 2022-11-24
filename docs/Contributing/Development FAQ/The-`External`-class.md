### Using external libraries in the BHoM UIs
---

The `External` class contains methods whose signature or return type contains schemas that are not sourced from either the `BH.oM` or the `System` namespace.

When creating an adapter is not possible, the BHoM gives the possibility to reflect specific assemblies that are not compliant.
The methods of the assembly can be found in the UIs via the `External` component.

There are three different levels at which an external assembly can be reflected in the BHoM, which differ in the level of compliance. From the least compliant, to the most compliant, they are explained below.

#### 1. Simple reflection
This mechanism reflects the methods of an assembly by keeping their native parameter types.
There is no common language (BHoM) that allows a complete communication with other parts of the ecosystem.
Although this is the fastest method to reflect an assembly, it does not guarantee that all the reflected methods will be usable, since no curation of the process is in place

To perform a simple reflection, you need to:
- Have the `Engine` project that corresponds to the assembly you want to reflect, e.g. `Numpy_Engine`. It follows the [usual Engine rules](//BHoM_Engine).
- Implement the `External` class, the same way you would implement a `Create` or `Query` class.
- Provide, in that class, two methods:
  - `public static List<MethodInfo> Methods()`
  - `public static List<ConstructorInfo> Constructors()`

They will be called by the Reflection_Engine, which will channel this methods into the External component of the UI.


#### 2. Reflection and common language
This stage assumes everything that exists in the previous one, and add the necessity to convert any type that is not a `System` type into a BHoM object. For instance, a `Numpy.NDarray` to a `BH.oM.MachineLearning.Tensor`. This guarantees that the object is compatible with the rest of the ecosystem and can them be used interchangeably in any other areas of the code.

To perform reflection with common language you need to:
- #### TODO


#### 3. API parsing and common language
This mechanism may or may not rely on the Reflection_Engine. It involves the automation of the parsing of the external api, which results into new BHoM code.

API parsing has to be tailored to the library you want to reflect.
It behaves as any other BHoM toolkit, since its methods lie in the usual BHoM classes `Compute`, `Convert`, `Create`, `Modify`, `Query`.