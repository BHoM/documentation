## TL;DR

You can record events in the Log by using 
- `BH.Engine.Reflection.Compute.RecordError(string message)`
- `BH.Engine.Reflection.Compute.RecordWarning(string message)`
- `BH.Engine.Reflection.Compute.RecordNote(string message)`

You can access all event logged since the UI was started by calling `BH.Engine.Reflection.Query.AllEvents()`

## Introduction

Things don't always run according to plan. Two typical situations can occur:
- The input value your method received are invalid or insufficient to generate the output. 
- The methods you call inside your method are failing

In either case, you are generally left with a few choices:
- throw an exception,
- return a null value,
- return a dummy value.

The first option stops the execution of the code completely while the other two allows things to continue but with the risk of the problem remaining unnoticed. A lot of times, none of those options are satisfactory. Let's take a simple example:

```c#
public List<object> MyMethod(List<BHoMObject> elements)
{
   List<object> results = new List<object>();
   foreach (BHoMObject element in elements)
      results.Add(DoSomething(element));
   return results;
} 
```

If `DoSomething()` throws an exception, this method will fail and pass on the exception. This might be the desired behaviour but we might also want to return all the successful results and just ignore the failing ones. In that case, we could write:

```c#
public List<object> MyMethod(List<BHoMObject> elements)
{
   List<object> results = new List<object>();
   foreach (BHoMObject element in elements)
   {
      try 
      {
         results.Add(DoSomething(element));
      }
      catch {}
   }
   return results;
} 
```

This does the job. But it also hide completely the fact that an error occurred for some of the elements so the results are incomplete.

This is why we have added a log system to the BHoM so all exceptional events can be recorded and passed to the UI.

## Recording Events

If we use the log, the code above would look like this:

```c#
using BH.Engine.Reflection;

public List<object> MyMethod(List<BHoMObject> elements)
{
   List<object> results = new List<object>();
   foreach (BHoMObject element in elements)
   {
      try 
      {
         results.Add(DoSomething(element));
      }
      catch 
      {
         Compute.RecordWarning("Element " + element.BHoM_Guid + " failed");
      }
   }
   return results;
} 
```

There are 3 levels of event you can record:
- Error: `RecordError()`
- Warning: `RecordWarning()`
- Note: `RecordNote()`

In Grasshopper, they will look like this:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/39418136-2796ab84-4c8b-11e8-9848-04628313bf95.png)

So the UI components will automatically expose all the events that occurred during their execution.

### So when should I use each type of event?

Besides fatal errors, `RecordError()` should be used in cases when we are not able to return any result for the provided input:
```c#
public static Point Centroid(this PolyCurve curve, double tolerance)
{
  if (!curve.IsClosed(tolerance))
  {
    Reflection.Compute.RecordError("Input curve is not closed. Cannot calculate centroid.");
    return null;
  }
  [...]
}
```
Note that errors most often go with returning `null` (or `.NaN` in case of doubles).


`RecordWarning()` is for all kind of situations when the result is possible to compute, but we cannot ensure if it is 100% correct. It is also suitable if provided object has been modified in not certainly desired way:
```c#
public static Vector Normal(this PolyCurve curve, double tolerance)
{
  if (curve.IsSelfIntersecting(tolerance))
    Reflection.Compute.RecordWarning("Input curve is self-intersecting. Resulting normal vector might be flipped.");

  [...]
}
```

At last `RecordNote()` is meant for the cases when everything run correctly but there is still some info that we would like to communicate to the end user:
```c#
public override List<object> Push([...])
{
  [...]
  if (pushConfig == null)
  {
    BH.Engine.Reflection.Compute.RecordNote("Revit Push Config has not been specified. Default Revit Push Config is used.");
    pushConfig = new RevitPushConfig();
  }
  [...]
}
```  
  
As one can see, there is no very strict convention on when to use each level of event. However, these examples should illustrate their intended purpose.

## Accessing All Events Since the Start

If you want to get the list of all the events that occurred since you started your script/program, you can use `BH.Engine.Reflection.Query.AllEvents()`. In Grasshopper, it will look something like this:

![img](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/39418803-f4c1a25a-4c8e-11e8-8380-bf77bafc4611.png)

As you can see, events are also BHoM object that you can explode as any other typical BHoM object.


## What About Exceptions?

Does that mean that we should stop using exception? No!

If your method ends up in a situation where it could not return any meaningful output, it should still throw an exception. Any method that catches an exception, on the other hand, should **ALWAYS** record something in the Log to make the user aware of what happened.


