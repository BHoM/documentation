## Design Results
Design results represents the outputs from design checks carried out by bespoke engine methods. They are explicit in their properties and relate to specific design codes and actions. 

This is intentional and preferred to more generic implementations such as having a generic `Parameters` property of type `Dictionary<string,double>` where the properties can fluccuate between implementations.

To provide consistency across different design result objects a base `DesignResult` is provided that inherits from existing classes in the `Structure` and `Analytical` namespaces.

### Base Class
The base class for all structural design results is stored in `BH.oM.Structure.Design` as an `DesignResult` which inherits from the [`IStructuralResultClass`](https://github.com/BHoM/BHoM/blob/develop/Structure_oM/Results/IStructuralResult.cs) and [`IResultItem`](https://github.com/BHoM/BHoM/blob/cded0de0047171577144479fe8165684648f1ac3/Analytical_oM/Results/IResultItem.cs). 

### Creating your own design result class
The first decision to make is what namespace our class will sit in.

#### Namespaces
The namespace is used to designate the design code, for example `BH.oM.Structure.Design.Eurocode`, `BH.oM.Structure.Design.AISC` or `BH.oM.Structure.Design.SHC`.

This keeps the object and engine method names clean. 

These can be extended to materials too (e.g. `BH.oM.Structure.Design.Eurocode.Timber` and `BH.oM.Structure.Design.Eurocode.Steel`).

!!! tip

	We do not need to include the subsection and part of the code in the namespace - that is covered in the designation `Enum`.

Next, we need to decide on an object name.

#### Class name
Name the class after the structural action being checked such as `Tension, `Bending` or `Torsion` using the language in the design code. 

#### Designations
This is an `Enum` that is included on the specific object to designate the specific version or annex of that code.

!!! example "What a steel design designation might look like"
    ```c#
	namespace BH.oM.Structure.Design.AISC
		{
			public enum SteelDesignation
			{
				[Description("Specification for structural steel buildings")]
				[DisplayText("AISC 360-16 : 2016")]
				AISC_360_16_2016 = 0,

				[Description("Specification for structural steel buildings")]
				[DisplayText("AISC 360-22 : 2022")]
				AISC_360_22_2022 = 1    
			}
		}
    ```

#### Example Class
Bringing together those decisions, we can create a class for tension design in accordance with EN 1993-1-1:2005 + A1:2014

!!! example "What a tension design class in Eurocode may look like"
    ```c#
	namespace BH.oM.Structure.Design.Eurocode
	{

		[Description("An object that contains the outputs from a tension check.")]
		public class Tension : DesignResult, IImmutable
		{
			/***************************************************/
			/**** Properties                                ****/
			/***************************************************/
			[Description("Id of the structure. Unused for many results.")]
			public virtual IComparable ObjectId { get; }

			[Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
			public virtual IComparable ResultCase { get; }

			[Description("Positive index, starting at one. Only set for cases with modal outputs such as dynamic cases.")]
			public virtual int ModeNumber { get; }

			[Description("Time step for time history results.")]
			public virtual double TimeStep { get; }

			[Description("The utilisation of the design check.")]
			public override double Utilisation { get; }

			[Description("The partial safety factor for the resistance of cross-sections.")]
			public virtual double GammaM0 { get; }

			[Force]
			[Description("The design axial force derived from the characteristic load multiplied by the relevant partial safety factors.")]
			public virtual double DesignAxial { get; }

			[Force]
			[Description("The design ultimate resistance of the net cross section subject to tension.")]
			public virtual double ResistanceAxial { get; }
		}
		
		/***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Tension(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double utilisation, double gammaM0,
            double designAxial, double resistanceAxial)
            : base(objectId, resultCase, modeNumber, timeStep)
        {
            Utilisation = utilisation;
            GammaM0 = gammaM0;
            DesignAxial = designAxial;
            ResistanceAxial = resistanceAxial;
        }
	}
    ```
	
1. Note that properties such as `Area` are not stored on the `TensionDesign` object as that is queryable from the `Bar.SectionProperty.Area` to avoid bloating objects and duplicating data. 
2. Only properties that are dervied from the design code should be stored on the `DesignResult` object.  
3. [Quantity Attributes](https://github.com/BHoM/BHoM/tree/develop/Quantities_oM/Attributes) are used to specify the units (adhering to the BHoM SI). 
4. The utilisation property has the `abstract` modifier on the `DesignResult` class. Therefore, it is required to have an `override` modifier in the implemented class - see the above `Tension` class. This ensures the `DescriptionAttribute` for the `Utilisation` property is tailored to the specific design result.
5. The constructor uses the `base` keyword to declare the properties from the `abstract` `DesignResult` class so they do not need to be set in the constructor.

Similar classes can be derived for `CompressionDesign`, `BucklingDesign` and `ShearAndTorsionDesign`.

!!! tip
	
	The `IImmutable` is not strictly required on the class definition as it's implicit from `DesignResult` but it's clearer to state explicitly. You can read from about [`IImmutable` here.](https://bhom.xyz/documentation/BHoM_oM/Base_oM/Interfaces/IImmutable/)

#### Identifying results
Specific results can be identified using a combination of `ObjectId`, `ResultCase`, `TimeStep`, `ModeNumber`. 

For example, when a user wants to retrieve a specific result from a database. 

!!! tip
	
	If you are writing multiple iterations of design results to a database you will need to include an iteration property on your design result object.



