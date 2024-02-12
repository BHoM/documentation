# BHoMBot

BHoMBot is our friendly neighbourhood bot who helps us with various tasks across the BHoM Community. BHoMBot adheres to our [Code of Conduct for Bots](https://github.com/BHoM/BHoM/blob/develop/docs/CODE_OF_CONDUCT_FOR_BOTS.md).

### BHoMBot: A History

BHoMBot launched in August 2020 as a prototype codebase to initially assist in checking our compliance regulations of the time were being followed without needing human effort. This was supported by the development of [Test_Toolkit](https://github.com/BHoM/Test_Toolkit), a key component in BHoMBot's infrastructure for running those compliance checks.

BHoMBot quickly expanded and took on additional tasks to support the community, taking over the installer checks that had previously been handled by Azure, and compilation checks handled by AppVeyor. A key component of our [distributed working](https://bhom.xyz/documentation/Basics/Technical-philosophy-of-the-BHoM/#the-approach-to-coding) is on the distribution of code via many repositories, and while it can take some getting used to, members of the BHoM Community will recognise the additional challenge this presents in ensuring our code is deliverable to the world beta-to-beta. Thus, BHoMBot took on this additional challenge early on, assisting our community in checking how downstream repositories would react to upstream changes.

BHoMBot quickly became a staple of our community and grew from the initial prototype to a tool the community relied on, with the checks provided by BHoMBot to pull requests quickly becoming a required part of our workflows.

In 2022, BHoMBot underwent their first major upgrade, being transformed from a simple bot covering simple compliance and compilation based checks, to a modular bot capable of handling additional tasks programmed for them to perform. Stability and reliability of BHoMBot also increased in this upgrade, as early BHoMBot had been developed on the initial prototype. Since this upgrade, BHoMBot has provided us with our usual array of pull request checks, our installer files for distribution, our change logs, our analytics, and most recently our [Nuget packages](https://www.nuget.org/profiles/BHoM) as we expand our BHoM Community to include support for .Net6 tools.

In 2024, BHoMBot is getting their next upgrade, changing how we interact with them to perform our work and solve our development challenges within our Community.

### Interacting with BHoMBot

BHoMBot operates on a call-and-response model, devised from radio call communications used by various organisations in the non-digital world. This communication model works on the listener repeating back key parts of information they've heard to confirm they've heard the correct instruction.

BHoMBot naturally has a large number of repositories to look after to support our community, and some pull requests take longer to be ready for the community than others as they go through various prototyping, discussion, and refinement stages as draft or WIP pull requests. Therefore, BHoMBot responds only to the direct request for them to perform an action triggered by any community member on a pull request. Typically this is done by calling to BHoMBot in the way you would to any other community member - `@BHoMBot` and then asking them to perform an action, typically a set of checks. BHoMBot will then respond with the list of checks they have queued up to work on for you.

In 2024, we are changing the strategy on how we interact with BHoMBot in order to reduce noise on pull requests and allow meaningful discussion around code suggestions as opposed to polluting the pull request with these call-and-response commands. While nice to receive a friendly message back from our friend, BHoMBot, we've decided the time is right to switch to a quieter mode of working. As such, while you can request BHoMBot to perform actions on your pull request as usual, from the 7.2 milestone BHoMBot will no longer comment a response but instead provide an emoji response as depicted below. This emoji response of a thumbs-up will be given by BHoMBot to acknowledge your request has been queued in their queue system, and will be actioned as soon as they have resource to do so.

![image](https://github.com/BHoM/Mongo_Toolkit/assets/18049174/46bc68a5-c916-46fc-830b-ba06b416de54)

### BHoMBot's interactions with our community

From the 7.2 milestone, BHoMBot will change how they interact with our code. As part of our switch from the call-and-response model outlined above, BHoMBot will also start automatically queueing up certain pull request checks as commits are done. This will be limited to the small checks, focused primarily around compliance and local compilation (of the repository being changed, rather than all downstream and upstream repositories) to reduce the need for us to ask BHoMBot to perform actions. We can still ask if we want extra, however, BHoMBot will start to perform the mandatory checks automatically.

Some of the heavier checks, such as those which require compilation of all upstream and downstream repositories, will instead occur overnight in a batch processing operation. When BHoMBot does this, they will flag any issues they find as new issues on affected repositories. Repository maintainers should take note of issues BHoMBot raises and ensure they are actioned before the next beta release ideally, as they will likely be items which could impact our beta delivery.

Where BHoMBot raises issues for us, or otherwise interacts with our community, they will be bound to follow our [Code of Conduct for Bots](https://github.com/BHoM/BHoM/blob/develop/docs/CODE_OF_CONDUCT_FOR_BOTS.md).