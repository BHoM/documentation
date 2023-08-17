# What is the BHoM for?

## Linking Meanings

The variety of AEC (Architecture, Engineering and Construction) commercial software does not always provide solutions to all needs, especially when it comes to collaborating with many people. We frequently encounter particular problems that require some special functionality not offered by any specific software, and we feel the need to implement it ourselves via, for example, custom scripts, or spreadsheets, or macros.

BHoM proposes a central Object Model, which is a _schema_ (in other words, a dictionary of terms) on which functionality can be built. By agreeing on common terminology, the output of a script created by one person can easily be used as the input for another script. 

So, at its core, the BHoM contains a collection of object definitions that we all agree on. The definitions are created by the same domain experts that use them everyday (e.g. Structural Engineers, Electrical Engineers, Architects...), and they are categorised per discipline (e.g. Structure, Architecture, ...). Each definition is simply a list of properties that an object should have (e.g. wall, beam, speaker, panel,...). We call this collection of definitions the **object Models** (oMs). 

By extension, the BHoM (Building and Habitats object Model) is the collection of these **object Models** and the functionality built on top of them.

## Linking Software

Across the AEC industry, regardless of our discipline, we have to work with multiple softwares during the course of any given project. Since there is rarely a simple solution to transfer the data from one software to another, we usually end up either doing it manually each time or writing some bespoke script to automate the transfer. Things get even more complex when we work across disciplines and with other collaborators. When the number of software to deal with becomes more than just a few, this one-to-one translation solution quickly becomes intractable.

This is where the BHoM comes in. Thanks to the central common language, it is possible to interoperate between many different programs. Instead of creating translators between every possible pair of applications, you just have to write one single translator between BHoM and a target software, to then connect to all the others.

We call those translators **Adapters**.

![](https://raw.githubusercontent.com/BHoM/documentation/main/Images/InteropA.png)



## Linking functionality
Most often, AEC industry experts create ad-hoc functions and tools when the need arises. Common examples are large, complex spreadsheets, VBA macros for Excel, but also small and large User Interface programs written in C#, Python or other tools.

In such a large sector, most problems you encounter are likely to have been solved before by someone in your organisation, or outside. What frequently happens is that the wheel gets reinvented. Additionally, when a script is created, it often exists in isolation, and is used only by a small group of people. 

Let's take the example of a user wanting to create some functionality in an Excel macro. This has several issues:

- **Maintanability issues**. Frequently, only the original creator of a Macro knows how to develop or maintain it. If they are not around and a problem arises, the Macro is often just thrown away.

- **Shareability issues**. For example, if the creator of a Macro that performs some function in a spreadsheet wants to share this functionality with one of their clients, they end up sharing the spreadsheet with the Macro in it, effectively sharing the source code (the fruit of their hard work), which could end up being copied.

- **Scalability issues**. Macros are hard to scale. If you need to add more features or more complex functionality in a Macro, the code soon becomes unmanageable.

- **Collaboration issues**. Collaborating on the code written in a Macro is a mess. Only one person can work on it at the same time. In order to merge the work of different people into a same Macro spreadsheet, either a library is created, or copy-paste is required.

BHoM proposes to create a common library of functionality in **Engine**s, which are simply tidy collections of functions. Like Adapters, Engines can be stored in Toolkits, which are simply GitHub repositories. GitHub repositories make it easy to share and collaborate on code (or not share, if privacy is chosen). BHoM makes it very easy to expose any functionality written in an Engine to Excel, Grasshopper, or other interfaces.

Thanks to the BHoM being exposed in various UIs such as Grasshopper and Excel, you don't even need to know how to write code to use the functionality created by other people. 


![](https://user-images.githubusercontent.com/16853390/50327328-8c784100-0529-11e9-85d0-3ea7285eb794.png)


## Linking people

By sharing terminology, functionality, and connectivity to software, BHoM allows us to shift the attention from "connecting data" to "connecting people together"!

BHoM also embraces Open Source as a practice: there is infinite value in opening up development efforts to the larger AEC community. Sharing effort pays big time!
