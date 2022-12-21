# Continuous Integration (CI)

Continuous Integration (CI) is the name given to the process of assisting our PR checks and resolving uncertainty in code status.

CI checks are built and maintained by the BHoM CI/CD team, but are operated automatically by our CI systems (including, but not limited to, AppVeyor, Azure DevOps and associated bots.<sup>1</sup>) 
 

The aim of CI checks is to increase confidence in our code, without unduly hindering our ability to prototype, develop, and extend the BHoM.

The pages within this section detail the CI checks we currently have operating, so that everyone can see how the checks are running and help ensure their PRs pass the checks.


***

| Check  | Provider | Command |
| ------------- | ------------- | ------------- | 
| [Check PR Builds](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-PR-Builds) | AppVeyor | Triggered automatically, can only be retriggered by CI/CD | 
| [Check Core](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Core) | BHoMBot & Azure DevOps | Triggered automatically, can be retriggered by commenting on the PR. For BHoMBot do `@BHoMBot check core`. For Azure do `/azp run <Your_Toolkit>.CheckCore` |
| [Check Installer](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Installer) | BHoMBot & Azure DevOps | Triggered by PR comment. For BHoMBot do `@BHoMBot check installer`. For Azure do `/azp run <Your_Toolkit>.CheckInstaller` |  
| [Check Project Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Project-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check project-compliance` | 
| [Check Code Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Code-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check code-compliance` | 
| [Check Documentation Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Documentation-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check documentation-compliance` | 
| [Check Copyright Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Copyright-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check copyright-compliance` | 
| [Check Dataset Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Dataset-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check dataset-compliance` | 
| [Check Branch Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Branch-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check branch-compliance` | 
| [Check Unit Tests](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Unit-Tests) | BHoMBot | Triggered by PR Comment `@BHoMBot check unit-tests` | 
| [Check Null Handling](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Null-Handling) | BHoMBot | Triggered by PR Comment `@BHoMBot check null-handling` | 
| [Check Serialisation](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Serialisation) | BHoMBot | Triggered by PR Comment `@BHoMBot check serialisation` | 
| [Check Versioning](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Versioning) | BHoMBot | Triggered by PR Comment `@BHoMBot check versioning` | 
| [Check Ready To Merge](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Ready-To-Merge) | BHoMBot | Triggered by PR Comment `@BHoMBot check ready-to-merge` |
| [Check Compliance](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check compliance` |  
| [Check Required](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/Check-Required) | BHoMBot | Triggered by PR Comment `@BHoMBot check required` |  

***

<sup>1</sup> See more notes on our approach to using and interacting with bots and automated processes as part of our [Code of Conducts](/documentation/Code%20Compliance%20and%20CI/CI%20Checks/https://github.com/BHoM/BHoM/blob/master/docs/CODE_OF_CONDUCT_FOR_BOTS).