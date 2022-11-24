# What is the BHoM for?
## Linking Software

Across our industry, regardless of our discipline, we will generally have to work with multiple softwares during the course of any given project. Since there is rarely a simple solution to transfer the data from one software to another, we usually end up either doing it manually each time or writing some bespoke script to automate the transfer. Things get even more complex when we work across disciplines and with other collaborators. When the number of software to deal with becomes more than just a few, this one to one ad-hoc transfer solution quickly becomes intractable.


![](https://raw.githubusercontent.com/BuroHappoldEngineering/documentation-page/main/docs/_images/InteropA.png)

This is where the BHoM comes in. It provides a single common language between all those applications. Instead of creating translators between every possible pair of software, you just have to write one single link per application to connect to all the others. So, at its core, the BHoM is really straightforward, it contains:
- A collection of object definitions that we all agree on as a collective. Each definition is simply a list of properties that an object should have (e.g. wall, beam, speaker, panel,...). We call that collection the **BHoM (Buildings and Habitats object Model)**.
- A collection of translators to convert objects between the BHoM and the external software. We call those translators **Adapters**. 
- And when the adapter doesn't just send data to and from the external software but also exposes the BHoM within its interface, we then call it **UI** for user interface. This is the case for example for Grasshopper, Dynamo and Excel.

## Linking People

The commercial softwares that we are using in our work do not always provide solutions for 100% of our needs. The bespoke scripts/spreadsheets/programs that we end up creating are rarely shared with more than a few people. This means that the same problem has often been solved by multiple people across the company. Such solutions have often also not been designed with scalability in mind. So, it will rarely be usable for anything but the very specific problem it was meant to solve and will not connect with other bespoke scripts other people might have written.

Through its central object model, the BHoM provides a common platform for everyone to write scripts in a scalable way. A common language means that the output of a script created by one person can easily be used as the input for another script. Thanks to the BHoM being exposed in various UIs such as Grasshopper and Excel, you don't even need to know how to write code in C# to use the functionality created by other people. We call this large collection of "scripts" the **Engine** where we have organised them in a way it is easy to find a specific method or figure out where to create a new one.   

![](https://user-images.githubusercontent.com/16853390/50327328-8c784100-0529-11e9-85d0-3ea7285eb794.png)
