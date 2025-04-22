# Development FAQ

- [What does it mean when a piece of code is _locked_? How do I lock code?](Development-FAQ.md#what-does-it-mean-when-a-piece-of-code-is-locked-how-do-i-lock-code)
- [I am using Windows 10. Is anything different for me ?](Development-FAQ.md#i-am-using-windows-10-is-anything-different-for-me)

## What does it mean when a piece of code is _locked_? How do I lock code?

A piece of code is locked when it is being developed by someone else.
You can check if some code is locked if its related issue is mentioned in the “In Progress” or “In Review” column of the [BHoM _Project Board_](https://github.com/orgs/BHoM/projects/3).

You shouldn't touch code that is locked, until the current task ends or is archived.
If you urgently need that some new code to be pushed into the main stream - an important bug fix for example - reach out to the person assigned to the issue that is locking the code and speak to her/him.

Read the wiki pages on [naming conventions](../Resolving-an-Issue.md#branch-naming-conventions) and [avoiding clashes](Coding-together-avoiding-conflicts.md) for more information.

## I am using Windows 10. Is anything different for me?

If you are using a computer which runs on windows 10, you might find that when you reference dlls in a project, the path of those will be pointing to your OneDrive folder. This will obviously lead to the issue that the code will not compile for other people. 

![img](https://raw.githubusercontent.com/BHoM/documentation/main/Images/Wikidllpath.PNG)

If this id the case, re-referencing the dlls might not solve the issue and then you will have to manually edit that in the project folder. You do this by opening the project file (.csproj) in a text-editor and you will find some of the dlls being referenced as 

![](https://user-images.githubusercontent.com/16853390/50329263-60f95480-0531-11e9-9c3b-5f92aa3394e1.png)

which you will have to replace by

![image](https://user-images.githubusercontent.com/16853390/50329270-73738e00-0531-11e9-9ea7-e6e9ce55f15f.png)

Note that the path in visual studio will still be pointing to your OneDrive, but now the referencing will not create issues for others.
Do NOT FORGET TO COMMIT this changes!