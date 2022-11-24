# Technical philosophy of the BHoM 

The Buildings and Habitats object Model [BHoM] has been designed as a hybrid model for code architecture - integrating a number of concepts from across existing languages/platforms. 
_Think of your favourite aspects of GH, C# and MongoDB combined._

Specifically the BHoM has a data structure and data manipulation strategy which is directly compatible with both visual flow-based programming and text-based imperative code. <br/>
<br/>	
The aim being to enable seamless transition from design and code experimentation to prototyping to development and deployment
 with increased participation and co-creation, and 
 greater rigour, review, robustness and transparency in our scripts, our code and the tools we use. 
 
For the ***AEC industry*** this means a platform for combining the efforts of the _professional programmer_ through to the enthusiastic _computational designer/engineer/architect_ all in ***one coding ecosystem***.
<br/>
<br/>
	
## The basic architecture

The Buildings and Habitats object Model is organised as four distinct categories of code: _object Model, Engine, Adapter_ and _User Interface._

<br/>

***1. The object model [oM] is nothing more than structured data - a collection of schemas.***
> The _oM_ is defined as naturally type strong C# classes, but comprising of only simple public Get Set Properties, with all methods excluded from the class definition including even the requirement for default constructors.<sup>1</sup>  
Ultimately, they are very close to C type structures with the added benefit of inheritance and polymorphism that a C# class provides.

<br/>
<br/>	
		
***2. The Engine is nothing more than data manipulators - a structured collection of components/methods.***
> All functionality is provided to the base types through extension methods in the _Engine_ and organised as static methods within public static partial classes. Immutability is enforced on inputs of each method to enable translation to flow based programming environment.

<br/>
<br/>	
	
***3. A common protocol for adaptors enables a single interface irrespective of the external software dealing with.***
> IO and CRUD concepts are combined to enable convenient Push-Pull visual programming UI with CRUD functions interfacing with the external application. <br/>Crucially the abstract BHoM_Adapter enables centralized handling of complex data merging so that creators of new adapters can focus on what makes their adapter different, reusing what is common and has already been solved

<br/>
<br/>	
	
***4. The UI exposes code directly. Same terminology. Complete transparency.***
>Through reflection, all objects, engine methods, adapters - any functionality implemented - is accessible immediately through the UI. 
This means the same code can be explored through the two contrasting development mediums - either Visual _Studio_ or Visual _Programming_ - but with direct parity.

<br/>
<br/>	
	

## The approach to coding
	
The above code structure therefore enables at its core ***ease of extensibility*** ...

<br/>

***A. Open, flexible data schemas***	
>The base object class provides a CustomData Dictionary allowing dynamic assignment of any data type to any object. To the extent that a CustomObject is defined as an Empty Object.
Default definitions for common objects can be curated and collectively agreed upon, however all are inherently flexible and extendible.

<br/>
<br/>	
	
***B. Ease of extensibility of functionality too***
>By structuring the code almost exclusively as extension methods in the Engine this enables new functionality to be added to existing objects without the requirement for derived types or indeed modification or recompilation of the base object.
This naturally opens the door wide to distributed development and customisation of new functionality on top of any existing base objects.

<br/>
<br/>	
	
and finally, as highlighted, the above architecture and code design principles place ***mass participation and co-creation*** as central.

<br/>

***C. Transparency in code***
>The source code architecture, principles and terminologies are all open, exposed and reflected as a common language across the visual and text based environments as described. 
This is paramount for a seamless transition from a visual UI to code _and vice versa_ with huge benefits to the developer in debugging and the designer in prototyping and well as a teaching aid to the lower level concepts behind the UI.

<br/>	
<br/>
		
***D. Human readable data*** 
> All objects natively serialisable based on JSON being compatible with MongoDB and standard data format for the web.

<br/>
<br/>	
	

## A shift from data encapsulation

Despite being one of the pillars of OOP, data encapsulation has been systematically eliminated in favor of a solution more transparent and more closely related to visual programming. This translates into a few interesting side-effects:

***A. Node <--> Code correspondence***

> Since objects have no private members and functionality is represented as a collection of individual static methods, the conversion between code and visual programming nodes becomes a straight-forward exercise.

<br/>	
<br/>

***B. Shallow hierarchies***

> Most objects inherit directly from the BHoMObject class and polymorphism is expressed mainly through interfaces. This is made possible without duplication of code thanks to the lack of encapsulation and an engine  designed around extension methods.

<br/>	
<br/>

***C. Orthogonal properties***

> With all object properties public, it is paramount for those to be independent from each other. This also means the objects are crafted with the minimal required information needed to construct them. All derived properties are exposed as methods in the engine.


<br/>
<br/>	
	

## Further Reading

* [BH.oM: Organise your Design Data](/BHoM_oM)
* [BH.Engine: Create New Algorithms](/BHoM_Engine)
* [BH.UI: Expose your Code to UIs](/BHoM_UI/)
* [BH.Adapter: Linking to Commercial Software](/BHoM_Adapter) 

	
<br/>
<br/>	
<br/>
<br/>	

---
	
<sup>1</sup> By exception IImmutable objects are allowed where calculation of derived properties in the engine requires lazy computation. <br/>
`Section Profile` is a good example

In addition some explicit casting and operator overrides etc. are also included in the BHoM definitions of some limited base objects.<br/>
`Node` is a good example





