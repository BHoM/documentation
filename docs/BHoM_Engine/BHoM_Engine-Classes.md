
* [Class titles and notation](#class-titles-and-notation)
	* [Create](#create)
	* [Modify](#modify)
	* [Query](#query)
	* [Compute](#compute)
	* [Convert](#convert)
	* [External](#external)
* [Exceptions](#exceptions)


## Class titles and notation
BHoM_Engine methods are always included into a `static` class. 

Different static classes define specific scopes for the methods they contain. There are 5 different static classes:
- Create - instantiate new objects
- Modify - modify existing objects
- Query - get properties from existing objects
- Compute - perform calculation given an existing object and/or some parameters
- Convert - transform an existing object into a different type
- External - reflects methods from external libraries 

### Create
- Returns a new object of the given class.
- Method is the name of the class being created.

`Bar bar = Create.Bar(line);`

Therefore the definition of the BHoMObject in the BHoM.dll should not contain any constructors (not even an empty default). 
With the exception of objects that implement `IImmutable`. See explanation of explicitly immutable BHoM Objects somewhere else. Later.

Object Initialiser syntax can be used with BHoM.dll only
e.g.

`Circle circ = new Circle { Centre = new Point { X = 10 } };`

`Grid grd = new Grid { Curves = new List<ICurve> { circ } };`

### Modify
- Returns a new version of the same object type as modified.
- Although immutability is enforced throughout - this namespace is for any method that _would be_ destructive for the object being operated on.
- Simply use the _Verb_ or _SetNoun_

`.Rotate` `.Translate` `.MergeVertices` `.SetPropertyValue` `.Explode` `.SplitAt` 

Modify is not actually the correct term/tense now as we are immutable! But immutability is intrinsic in the strategy for the whole BHoM now so in the interest of clarity at both code and UI level Modify as a term is being used. _Answers on a postcard for a better word!_ 

### Query
- Returns a derived property or objects or a simple boolean query (without modifying the information)
- Although immutability is enforced throughout - this namespace is for any method that _would_ ___NOT___ _be_ destructive for the object being operated on.
- Simply use the _Noun_, or _Verb_ or prefix with _Is_

`.Area` `.Mass` `.Distance` `.DotProduct`

`.Clone` Could be interpreted as noun or verb, so works.  

`.Intersect`

`.IsPlanar` `.IsEqual` `.IsValid` `.IsClosed`



In the case of explicitly immutable BHoM objects (see `IImmutable`), using this notation for derived properties will match notation of Readonly Properties also, which is neat.

### Compute
- For computationally more intensive methods, iterative processes and/or solvers etc.

`.EquilibriumPosition` 
`.TextFromSpeech` 
`.Integrate`

- Or for modifying methods that _would be_ destructive for the object being operated on but returns a different return type, or count of objects in a List.

`.Split`

There will potentially be grey areas between methods being classed as _Query_ or _Compute_, however in general it should be clear using the above guidelines and the distinction is important to ensure code is easily discoverable from both as an end user.

### Convert
- Returns a new type of object. 
- Method has the prefix of _To_ or _From_

`.ToJson()`
`.ToSVGString()`

All convert methods must therefore be in a Convert Namespace within an _Engine project, thus separating this simple functionally from the _Adaptor project, in any software toolkits also.

### External
- Contains a `Constructors` method, which returns a `List<ConstructorInfo>` that will be automatically reflected 
- Contains a `Methods` method, which returns a `List<MethodInfo>` that will be automatically reflected
- Can contain any other method within the constraints presented below.

For methods whose signature or return type includes one or more schemas that are not sourced from either the `BH.oM` or the `System` namespaces.

## Exceptions
Keep GetGeometry and SetGeometery as method names - these perhaps to be still treated slightly differently through new IGeometrical interface? Discuss. 

Also allow an additional _**Objects**_ Namespace where Engine code requires local class definitions for which there are good reasons to not promote to an _oM 

