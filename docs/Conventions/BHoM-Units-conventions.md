# BHoM Unit conventions

This page describes the Units conventions for the BHoM.

For geometrical/structural conventions, refer to [this page](/documentation/BHoM-Structural-Conventions).

## General philosophy: use SI!
The BHoM framework adheres as much as possible to the conventions of the [SI system](https://en.wikipedia.org/wiki/International_System_of_Units).

Any Engine method must operate in SI to avoid complexity of Unit Conversions inside calculations.
Conversion to and from SI is the responsibility of the Converts inside the Adapters. 

When some units (derived or not) are not explicitly covered by this Wiki page, it is generally safe to assume that measures expressed in SI units will not be converted by the BHoM.

- Mass: kilograms [kg]
- Length: meters [m]
- Force: Newtons [N]
- Moments: [N*m]
- Stress/Pressure: [N/m²]
- Spring constraints: [N/m]
- Rotational constraints: [N*m/rad]
- Temperature: [K]

For conventions on forces and constraints directions, see [this page](/documentation/BHoM-Structural-Conventions).

## Localisation toolkit

The [Localisation_Toolkit](https://github.com/BHoM/Localisation_Toolkit) provides support for conversion between SI and other units systems.

## Quantity attributes

BHoM object properties can be decorated with a _Quantity Attribute_ to define (in SI) what unity the property should be considered in. 
This is to be applied only to properties that are of a primitive numerical type, e.g. `int`, `double`, etc. 

See [Quantities_oM](https://github.com/BHoM/BHoM/tree/master/Quantities_oM/Attributes) for the available attributes.
