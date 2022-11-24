## Summary

**Severity** - Warning

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasDescriptionAttribute.cs)

## Details

The `HasDescriptionAttribute` check ensures that a method has a `Description` attribute explaining what the method is doing for users.

You can add a `Description` attribute with the following syntax sitting above the method:

`[Description("Your description here")]`

If you have not used any attributes in your file previously, you may need to add the following usings:

`using BH.oM.Reflection.Attributes;`

`using System.ComponentModel;`

You may also need to add a reference to the `Reflection_oM` to your project if you have not previously used it.

---

### Description authoring guidelines 


We should be aiming for _all_ properties, objects and methods to have a description. With only the very simplest of self explanatory properties to not require a description by exception - and indeed only where the below guidelines can not be reasonably satisfied. 

So what makes a good description?

1. A description must impart additional useful information beyond the property name, object and namespace. 
2. Further to a definition, the description is an opportunity to include usage guidance, tips or additional context.
3. The description is a place you can include synonyms etc. to help clarify for others in different regions/domains, being inclusive as possible.
4. Also don't forget the addition of a Quantity Attribute can be used now, appropriate for Doubles and Vectors.