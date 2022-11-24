This page describes the Units conventions for the BHoM.

For geometrical/structural conventions, refer to [this page](/BHoM-Structural-Conventions).

# General philosophy
The BHoM framework adheres as much as possible to the conventions of the [SI system](https://en.wikipedia.org/wiki/International_System_of_Units).

Any Engine method must operate in SI to avoid complexity of Unit Conversions inside calculations.
Conversion to and from SI is the responsibility of the Converts inside the Adapters. 

The [Localisation_Toolkit](https://github.com/BHoM/Localisation_Toolkit) provides support for conversion between SI and other units systems.

BHoM object properties can be decorated with a Quantity to define (in SI) the dimensionality of primitive properties. See [Quantities_oM](https://github.com/BHoM/BHoM/tree/master/Quantities_oM/Attributes)

When some units (derived or not) are not explicitly covered by this Wiki page, it is generally safe to assume that measures expressed in SI units will not be converted by the BHoM.

- Mass: kilograms [kg]
- Length: meters [m]
- Force: Newtons [N]
- Moments: [N*m]
- Stress/Pressure: [N/m²]
- Spring constraints: [N/m]
- Rotational constraints: [N*m/rad]
- Temperature: [K]

For conventions on forces and constraints directions, see [this page](/BHoM-Structural-Conventions).