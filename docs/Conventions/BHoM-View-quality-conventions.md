# View quality conventions
This page describes the view quality conventions that are used within the BHoM. 
The description is intended to be a non-technical guide and provide universal access to understanding the methods of calculation of different view quality metrics. Links to the relevant methods are provided for those who wish to view the C# implementation.

Jump to the section of interest:
* [Measure Cvalues](#measure-cvalues)
  * [Find focal points](#find-focal-points)
* [Measure Avalues](#measure-avalues)
  * [Measure Occlusion](#measure-occlusion)
* [Measure Evalues](#measure-evalues)
* [Background Information](#background-information)
# Measure Cvalues
[Method in Humans_Engine](https://github.com/BHoM/BHoM_Engine/blob/master/Humans_Engine/Query/CvalueAnalysis.cs)
![cvalue calculation](https://user-images.githubusercontent.com/6618854/111189354-e69fc980-85ad-11eb-8a18-4a2bb901d7d9.png)
## Find focal points
[Method in Humans_Engine](https://github.com/BHoM/BHoM_Engine/blob/1210c894accd9b6e9539ca8a7fd3b91302b33356/Humans_Engine/Query/CvalueAnalysis.cs#L102)
![focalpoint](https://user-images.githubusercontent.com/6618854/111189362-e8698d00-85ad-11eb-8d5a-d691733b146f.png)
# Measure Avalues
[Method in Humans_Engine](https://github.com/BHoM/BHoM_Engine/blob/master/Humans_Engine/Query/AvalueAnalysis.cs)

Avalue is the percentage of the spectator's view cone filled with the playing area.
![overview](https://user-images.githubusercontent.com/6618854/117262086-cb806600-ae48-11eb-9ad5-dcf2107fb587.jpg)

![p1v2](https://user-images.githubusercontent.com/6618854/117304577-cede1680-ae75-11eb-92e0-95964d45ad1c.png)
## Measure Occlusion

Occlusion is the percentage of the spectator's view occluded by the heads of spectators in front.
![occlusion](https://user-images.githubusercontent.com/6618854/117308559-92141e80-ae79-11eb-9050-0836dd5a5a0c.jpg)
![occlusion](https://user-images.githubusercontent.com/6618854/114209869-07fa9800-9957-11eb-9e6b-f16d7b5c73f8.jpg)

# Measure Evalues
[Method in Humans_Engine](https://github.com/BHoM/BHoM_Engine/blob/master/Humans_Engine/Query/EvalueAnalysis.cs)

Description coming soon...

# Background Information
## References

Hudson and Westlake. [Simulating human visual experience in stadiums.](https://github.com/BHoM/BHoM_Engine/files/6309099/simulatinghumanexperience.pdf) Proceedings of the Symposium on Simulation for Architecture & Urban Design. Society for Computer Simulation International, (2015).