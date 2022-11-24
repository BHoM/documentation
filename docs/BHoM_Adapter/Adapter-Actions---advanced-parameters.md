# Adapter Actions: advanced parameters 

> ### Note
> This page can be seen as an Appendix to the pages [Introduction to BHoM_Adapter](/BHoM_Adapter) and [Adapter Actions](/BHoM_Adapter/Adapter-Actions).

The Adapter Actions have some particular input parameters that have not been covered in the [introduction to the BHoM_Adapter](/BHoM_Adapter). These are:

- the **ActionConfig** (used by all Actions: Push, Pull, Move, Remove, Execute);
- the **Requests** (used by the Pull)
- the **Data Tags**  (if implemented for the specific Adapter, they are used by: Push, Pull, Move, Remove)

### ActionConfig

The ActionConfig is an object type used to specify any kind of Configuration that might be used by the Adapter Actions. 

This means that it can contain configurations that are specific to certain Actions (e.g. only to the Push, only to the Pull), and that a certain Push might be activated with a different Push ActionConfig than another one. This makes the ActionConfig different from the [Adapter Settings](/BHoM_Adapter/Implement-an-Adapter#the-adapter-settings) (which are `static` global settings).

The base ActionConfig provides some configurations that are available to all Toolkits (you can find more info about those in the code itself).

You can inherit from the base ActionConfig to specify your own in your Toolkit. For example, if you are in the SpeckleToolkit, you will be able to find:
- SpecklePushConfig: inherits from ActionConfig
- SpecklePullConfig: inherits from ActionConfig

this allows some data to be specified when Pushing/Pulling. 

ActionConfig is an input to _all Adapter methods_, so you can reference configurations in any method you might want to override.


</br></br>


### Requests

Requests are an input to the Pull adapter Action. 

They were formerly called Queries and are exactly that: Queries. You can specify a Request to do a variety of things that always involve Pulling data in from an external application or platform. For example:
- you can Request the results of an FE analysis from a connected FEM software,
- specify a GetRequest when using the HTTP_Toolkit to download some data from an online RESTFul Endpoint
- query a connected Database, for example when using Mongo_Toolkit.

Requests can be defined in Toolkits to be working specifically with it.

You can find some requests that are compatible with all Toolkits in the base BHoM object model.
An example of those is the FilterRequest.

The FilterRequest is a common type of request that basically requests objects by some specified type. See [`FilterRequest`](https://github.com/BHoM/BHoM/blob/51113dbafd41c1afa11916ce98348641bae884ab/Data_oM/Requests/FilterRequest.cs#L28-L41).

In general, however, Requests can range from simple filters to define the object you want to be sent, to elaborated ones where you are asking the external tool to run a series of complex data manipulation and calculation before sending you the result. 

> **Additional note: batch requests**
>
> For the case of complex queries that need to be executed batched together without returning intermediate results, you can use a `BatchRequest`. 

> **Additional note: Mongo requests**
> 
> For those that use Mongo already, you might have noticed how much faster and convenient it is to let the database do the work for you instead doing that in Grasshopper. It also speeds up the data transfer in cases where the result is small in bytes but involves a lot of data to be calculated.

</br></br>

### Data Tags

When objects are pushed, it is important to have a way to know which objects needs to be `Update`d, the new ones to be `Create`d, and the old ones to be `Delete`d. 

If the number of objects changes between pushes, you cannot rely on unique identifiers to match the objects one-to-one. The problem is especially clear when you are pushing less objects than the last push.  

Attaching a unique **tag** to all the objects being pushed as a group is a lightweight and flexible way to find those objects later. 

> For those using D3.js, this is similar to attaching a class to html elements. For those using Mongo or Flux, this is similar to the concept of key. 

#### Tags in practice

At the moment, each external software will likely require a different solution to attach the tags to the objects. 

If the software doesn't provide any solution to store the tag attached to the objects (e.g., like Groups), we could make use of another appropriate field to store the tag, for example the _Name_ field that is quite commonly found.

In case you need to use the Name field of the external object model, the format we are using for that is (example for an object with three tags):
```
Name __Tags__:tag1_/_tag2_/_tag3
```

For an in depth explanation on how tags are used and what you should be implementing for them to work, read the Push section of our [Adapter Actions](./Adapter-Actions) page; in particular, look at the [practical example](./Adapter-Actions#a-practical-example).  

