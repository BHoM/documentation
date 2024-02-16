# Logging and exceptions

## BHoM Logging

BHoM implements an Events Log (the Log) which can store information about processes executing within the BHoM environment. All parts of the code base are encouraged to make use of this Log rather than implementing additional logging systems, and we encourage [discussions](https://github.com/orgs/BHoM/discussions) on improving our logging system as we grow.

The Log is housed within the [BHoM_Engine](https://github.com/BHoM/BHoM_Engine/blob/develop/BHoM_Engine/Query/DebugLog.cs) project, so is available to all tools and toolkits building on the BHoM framework.

The [`Event`](https://github.com/BHoM/BHoM/blob/develop/BHoM/Debugging/Event.cs) object contains enough properties to enable debugging and reporting issues or information to users via the [Log](https://github.com/BHoM/BHoM/blob/develop/BHoM/Debugging/Log.cs). An event can be one of [these types](https://github.com/BHoM/BHoM/blob/develop/BHoM/Debugging/EventType.cs).

You can record events in the Log by using any of the following options:

- `BH.Engine.Base.Compute.RecordError(string message)` 
- `BH.Engine.Base.Compute.RecordWarning(string message)` 
- `BH.Engine.Base.Compute.RecordNote(string message)` 

This will log either an Error, a Warning, or a Note as appropriate with the message of your choosing.

### Logging Exceptions

If you want to also handle `Exception` information within your Event, you can call one of these methods:

 - `BH.Engine.Base.Compute.RecordError(Exception exception, string message = "")` 
 - `BH.Engine.Base.Compute.RecordWarning(Exception exception, string message = "")` 
 - `BH.Engine.Base.Compute.RecordNote(Exception exception, string message = "")`

This will record the event with the type of your choosing and include information from the C# exception passed with it. You can provide an optional message to assist users as well.

## Accessing events

### Accessing All Events Since the Start

You can access all events logged since the BHoM was started by calling `BH.Engine.Base.Query.AllEvents()`.

If you want to get the list of all the events that occurred since you started your script/program, you can use `BH.Engine.Reflection.Query.AllEvents()`. In Grasshopper, it will look something like this:

![img](https://raw.githubusercontent.com/BHoM/documentation/main/Images/39418803-f4c1a25a-4c8e-11e8-8380-bf77bafc4611.png)

As you can see, events are also BHoM object that you can explode as any other typical BHoM object.

### Accessing All Current Events

You can control the Current Events to capture events that occur during the run of your code. To do this, start by clearing the current event log to ensure you have nothing from another process by calling `BH.Engine.Base.Compute.ClearCurrentEvents()`. Then, when you're ready to obtain the current events, you can use `BH.Engine.Base.Query.CurrentEvents()` to get all the events logged since the current events were last cleared.

### Accessing All Events Since A Certtain Time

You can access all events logged since a certain time by calling `BH.Engine.Base.Compute.EventsSince(DateTime utcTime)`. This will return all events logged where the `UtcTime` of the event is on or after the provided `utcTime` passed into the method.

### Accessing All Events With Periodic Bookmarks

Finally, you can access events based on a moving bookmark, which acts similar to `EventsSince()` but provides the current time as the next bookmark. When you call `BH.Engine.Base.Compute.EventsSinceBookmark()`, it will provide all the events which have occurred since the last time you called the method. On startup, the bookmark timestamp will be the time of initialisation of the code. When you call the method, the bookmark is then updated to be the time you inspected the events log, so the second time you call `EventsSinceBoomark()`, you will only get the events which have occured on or after the first time you checked.

For example, if the system starts up at 10:30:00am then this is the initial time of the bookmark. If you inspect the `EventsSinceBookmark()` at 10:32:00am, you will get all the events which have occurred after 10:30:00, and the bookmark is updated to be 10:32:00am. If you inspect `EventsSinceBookmark()` again at 10:34:00, you will get all the events which occurred after 10:32:00, and the bookmark is updated to 10:34:00.

## Dealing with errors

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

If we use the log, the code above could look like this:

```c#
using BH.Engine.Base;

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

![img](https://raw.githubusercontent.com/BHoM/documentation/main/Images/39418136-2796ab84-4c8b-11e8-9848-04628313bf95.png)

So the UI components will automatically expose all the events that occurred during their execution.

### So when should I use each type of event?

Besides fatal errors, `RecordError()` should be used in cases when we are not able to return any result for the provided input:

```c#
public static Point Centroid(this PolyCurve curve, double tolerance)
{
  if (!curve.IsClosed(tolerance))
  {
    Base.Compute.RecordError("Input curve is not closed. Cannot calculate centroid.");
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
    Base.Compute.RecordWarning("Input curve is self-intersecting. Resulting normal vector might be flipped.");

  [...]
}
```

And last `RecordNote()` is meant for the cases when everything run correctly but there is still some info that we would like to communicate to the end user:

```c#
public override List<object> Push([...])
{
  [...]
  if (pushConfig == null)
  {
    BH.Engine.Base.Compute.RecordNote("Revit Push Config has not been specified. Default Revit Push Config is used.");
    pushConfig = new RevitPushConfig();
  }
  [...]
}
```  
  
As one can see, there is no very strict convention on when to use each level of event. However, these examples should illustrate their intended purpose.

## What About Exceptions?

Does that mean that we should stop using exceptions? No!

If your method ends up in a situation where it could not return any meaningful output, it should still throw an exception. Any method that catches an exception, on the other hand, should **ALWAYS** record something in the Log to make the user aware of what happened.

### Log errors as exceptions

You can also opt to catch BHoM Error Events as Exceptions if you so wish. By default, errors are just logged in the Log and not handled any further. However, you can call `BH.Engine.Base.Compute.ThrowError(false)` which will turn off the suppression of exception throwing.

If you choose to do this, any error recorded into the Log while this suppression is off will be thrown as an exception itself, which you can then catch in a `try/catch` statement.

If you want to turn the suppression back on after your use, you can call `BH.Engine.Base.Compute.ThrowError(true)` and this will revert the Log to work in the default manner.

## Good Log Messages

It's important to note that the events in the Log are designed to be seen by users as well as developers. Therefore care should be taken to ensure the event message is as informative as possible. Ideally, for errors or warnings, information should be provided on how the user could resolve the issue, to avoid them needing to contact a developer for help. Users enjoy problem solving, but we don't need to make it unnecessarily difficult!

Consider the following example:

```c#
public static bool MyMethod(List<BHoMObject> objects)
{
   for(int x = 0; x < objects.Count; x++)
   {
      if(objects[x] == null)
         BH.Engine.Base.Compute.RecordError("Object was null, could not compute object.");

      [...]
   }
}
```

Here we will have told the user the object is null and so we cannot work with it, which is fair enough, however, how could the user fix this error? If they have a list of several hundred (or thousand) objects, such as all the bars in a structures model, or all the panels in an environments model, simply telling them the object was null may not help them fix it. It's also worth considering that multiple objects in the list could be `null` and the user might get the same error multiple times on the component.

Therefore, ensure the message provides the user some information which they can use to fix the problem. Such as:

```c#
public static bool MyMethod(List<BHoMObject> objects)
{
   for(int x = 0; x < objects.Count; x++)
   {
      if(objects[x] == null)
         BH.Engine.Base.Compute.RecordError($"The object at index {x} was null, could not compute object.");

      [...]
   }
}
```

Here we've added only a small amount of extra information - the index of the object which is null - but in doing so, we've now empowered the user to inspect their objects at that specific index to identify the problem and potentially fix it.

On the flip side, don't oversaturate the user with information so that they're unable to process the important bits. Keep the information in the message factual and to the point for a positive user experience.

## Suppressing Events

There may be times when you don't want the user to be given events, for example when your method is handling expected errors occuring with the objects. You might not want to user to be told `Polyline is not planar` if it doesn't actually matter to your process and you do something different for planar vs non-planar polylines.

Obviously you can't always remove the events being logged from parts of the code base where they exist, particularly if building on top of the BHoM framework where the community has opted to put in event logging for when the methods are used on their own in one of the BHoM supported UIs.

Therefore, the option exists to suppress the event logging, and prevent events being logged to the user during the execution of your method.

To do this, call the `BH.Engine.Base.Compute.StartSuppressRecordingEvents(bool suppressErrors, bool suppressWarnings, bool suppressNotes)` method. Each `boolean` input corresponds to the type of event you wish to suppress. You can suppress all 3, or just certain combinations of the 3 as you wish depending on your use case.

When events are suppressed, they go into the suppressed log, which is separate from the Events Log. This is a mechanism deliberately put in for the event where suppression occurs by accident - events are not lost completely and can be retrieved as needed.

When calling `StartSuppressRecordingEvents` you provide the `booleans` for the events you want to suppress. However, if another method has opted to suppress events then this will also occur. Take the example:

```c#
public static bool MethodA(List<BHoMObject> objects)
{
   BH.Engine.Base.Compute.StartSuppressRecordingEvents(false, true, false); //Suppress Warnings but not Errors or Notes

   MethodB(objects);
}

public static bool MethodB(List<BHoMObject> objects)
{
   BH.Engine.Base.Compute.StartSuppressRecordingEvents(true, false, false); //Suppress Errors but not Warnings or Notes

   [...]
}
```

When `MethodA` is called by itself warnings will be suppressed, and when `MethodB` is called by itself errors will be suppressed. However because `MethodA` calls `MethodB` as part of its execution, `MethodA` will suppress warnings, and `MethodB` will suppress errors, meaning the end result will be BOTH errors and warnings are suppressed. This has been done so that `MethodB` could not override the suppression desires of `MethodA` by stating `false` to suppressing warnings.

### Stop suppressing events

When you're ready to stop suppressing events, simply call the method `BH.Engine.Base.Compute.StopSuppressRecordingEvents()`. This will reset event logging to the default state for all types of events.

**You should always stop event suppression at the end of the method you have started it, to prevent the Log system being suppressed for longer than necessary and risking events not being raised to users when they should.**

If you want to suppress warnings, then turn warnings back on and suppress errors, you would do so like this example:

```c#
public static bool MethodA(List<BHoMObject> objects)
{
   BH.Engine.Base.Compute.StartSuppressRecordingEvents(false, true, false); //Suppress Warnings but not Errors or Notes

   [...]

   BH.Engine.Base.Compute.StopSuppressRecordingEvents(); //Turn on all events
   BH.Engine.Base.Compute.StartSuppressRecordingEvents(true, false, false); //Suppress Errors
}
```

### Retrieving suppressed events

If you want to retrieve events raised during the suppressed time period, you can call `BH.Engine.Base.Compute.RetrieveSuppressedLog()`. This will move all events recorded during the suppressed period to the main Log, which can be accessed in the ways outlined at the top of this page.

The suppressed log will be reset once its events have been retrieved, so you don't need to worry about retrieving duplicates.

Retrieved events won't appear on the UI on components though, so users may still not know about them initially, but they can be queried using the same access components above in any of the BHoM supported UIs.