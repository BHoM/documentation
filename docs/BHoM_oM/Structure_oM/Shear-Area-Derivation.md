## Shear Area Derivation
It is here outlined how BHoM calculates shear area for a section  
Shear Area formula used for calculation:  
<img src="https://user-images.githubusercontent.com/53530468/73440510-4b1bad00-4349-11ea-9385-92bebff64fde.png" width=700>  
And A(x) is defined as all the points less than x within the region A. 

Moment of inertia is know and hence the denominator will be the focus.  
<img src="https://user-images.githubusercontent.com/53530468/73440873-fd537480-4349-11ea-8293-e2ac97b38605.png" width=350>

Sy for an area can be calculated for a region by its bounding curves with Greens Therom:  
<img src="https://user-images.githubusercontent.com/53530468/73440925-14926200-434a-11ea-94d6-d69182c7cb17.png" width=350>  
which for line segments is:  
<img src="https://user-images.githubusercontent.com/53530468/73441036-44416a00-434a-11ea-8dd1-10571d2d8905.png" width=350>

And while calculating this for the entire region as line segments is easy, we want to have the regions size as a variable of x.  
So we make some assumptions about the region we are evaluating.
* Its upper edge is always on the X-axis
* No overhangs  

i.e. its thickness at any x is defined by its lower edge,   
achieved by using `WetBlanketIntegration()`   
Example:  
<img src="https://user-images.githubusercontent.com/53530468/73441531-0c86f200-434b-11ea-8b04-3501f0421e6c.png" width=250>

We will then calculate the solution for each line segment from left to right.   
This is important as Sy is dependent on everything to the left of it.

We then split the solution for Sy into three parts:
* S<sub>0</sub>, The partial solution for every previous line, i.e. sum until current
* The current line segment with variable _t_
* A closing line segment with variable _t_, connects the end of the current line segment to the X-axis  

Closing along the X-axis is not needed as the horizontal solution is always zero.  
Visual representation of the area it works on:  
<img src="https://user-images.githubusercontent.com/53530468/73441841-91720b80-434b-11ea-91c4-558dd6854a96.gif" width=350>

We will now want to define all variables in relation to _t_  
<img src="https://user-images.githubusercontent.com/53530468/73442180-37be1100-434c-11ea-8c1c-cace222f34b4.png" width=500>

And then plug everything into the integral  
<img src="https://user-images.githubusercontent.com/53530468/73444284-31ca2f00-4350-11ea-97dc-31a3dbc135f0.png" width=900>  

### To summarise the practical proccess
1. The region will be converted to the right format by `WetBlanketInterpetation()` 
2. The integral is evaluated for the first line segment and added to the results sum
3. The S<sub>0</sub> value for the first line segment is calculated and added to the S_0 sum
4. step 2 and 3 repeats for every line except the last
5. The squared Moment of inertia is then divided by the result
