This page covers Structural and Geometrical conventions for the BHoM framework.

For Unit conventions, see [this page](/BHoM-Units-conventions).


# 1D-elements

## Coordinate system
The following local coordinate system is adopted for 1D-elements e.g. beams, columns etc:

<img src="/images/Coordinate axis bar.PNG" width=350>

* x-axis along the centre line of the element from start to end
* z-axis as the normal direction of the element  
* y-axis transverse to the normal  

**Linear elements**

For **non-vertical** members the local z is aligned with the global z and rotated with the orientation angle around the local x.

For **vertical** members the local y is aligned with the global y and rotated with the orientation angle around the local x.

A bar is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality.

**Curved planar elements**

For curved elements the local z is aligned with the normal of the plane that the curve fits in and rotated around the curve axis with the orientation angle.

## Section property nomenclature

Area - Area of the section property  
I<sub>y</sub> - Second moment of area, major axis  
I<sub>z</sub> - Second moment of area, minor axis  
W<sub>el,y</sub> - Elastic bending capacity, major axis  
W<sub>el,z</sub> - Elastic bending capacity, minor axis  
W<sub>pl,y</sub> - Plastic bending capacity, major axis  
W<sub>pl,z</sub> - Plastic bending capacity, minor axis  
R<sub>g,y</sub> - Radius of gyration, major axis  
R<sub>g,z</sub> - Radius of gyration, minor axis  
  
V<sub>z</sub> - Distance centre to top fibre  
V<sub>p,z</sub> - Distance centre to bottom fibre  
V<sub>y</sub> - Distance centre to rightmost fibre  
V<sub>p,y</sub> - Distance centre to leftmost fibre  
A<sub>s,z</sub> - Shear area, major axis  
A<sub>s,y</sub> - Shear area, minor axis  

## Signs of section forces

The directions for the section forces in a cut of a beam can be seen in the image below:

<img src="/images/BHoM Structual conv BeamForceConvArrows.png" width=550>

This is:
* Normal force positive along the local x-axis
* Shear forces positive along the local y and z-axes
* Bending moments positive around the local axis by using the right hand rule

This leads to the following:

### Axial force F<sub>x</sub>  
Positive (+) =  Tension  
Negative (-) =  Compression  
  
### Major axis bending moment M<sub>y</sub> and shear force F<sub>z</sub> 
As shown in the following diagram.

<img src="/images/BHoM Structual conv Moment and shear dir.PNG" width=500> 
  
### Minor axis bending moment M<sub>z</sub> and shear force F<sub>y</sub>  
Same sign convention as for major axis.  
  
### Torsional moment M<sub>x</sub>  
The torsional moment follows the [Right-hand rule](https://en.wikipedia.org/wiki/Right-hand_rule) convention.

<img src="/images/BHoM Structual conv Torsion.PNG" width=250> 

<!--- THIS HAS TO BE UPDATED 
### Test file

A test file to use on the adapters to check that the forces extracted matches the BHoM conventions can be [found here](NEED NEW LINK)
--->

## Bar offsets 
Bar offsets specify a local vector from the bars node to where the bar is calculated from, with a rigid link between the Node object and the analysis bars end point.

Hence:
* a BHoM bars nodes are where it attaches to other nodes,
* offsets are specified in the local coordinate system and is a translation from the node,
* local x = bar.Tangent();
* local z = bar.Normal();
* node + offset is where the bar node is analytically
* the space between is a rigid link