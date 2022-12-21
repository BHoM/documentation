# Continuous Integration (CI)

Continuous Integration (CI) is the name given to the process of assisting our PR checks and resolving uncertainty in code status.

CI checks are built and maintained by the BHoM CI/CD team, but are operated automatically by our CI systems (including, but not limited to, AppVeyor, Azure DevOps and associated bots<sup>1</sup>).
 

The aim of CI checks is to increase confidence in our code, without unduly hindering our ability to prototype, develop, and extend the BHoM.

The pages within this section detail the CI checks we currently have operating, so that everyone can see how the checks are running and help ensure their PRs pass the checks.


***

| Check  | Provider | Command |
| ------------- | ------------- | ------------- | 
| [Check Core](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Core) | BHoMBot | Trigger by PR comment `@BHoMBot check core` |
| [Check Installer](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Installer) | BHoMBot | Triggered by PR comment `@BHoMBot check installer` |  
| [Check Project Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Project-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check project-compliance` | 
| [Check Code Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Code-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check code-compliance` | 
| [Check Documentation Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Documentation-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check documentation-compliance` | 
| [Check Copyright Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Copyright-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check copyright-compliance` | 
| [Check Dataset Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Dataset-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check dataset-compliance` | 
| [Check Branch Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Branch-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check branch-compliance` | 
| [Check Unit Tests](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Unit-Tests) | BHoMBot | Triggered by PR Comment `@BHoMBot check unit-tests` | 
| [Check Null Handling](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Null-Handling) | BHoMBot | Triggered by PR Comment `@BHoMBot check null-handling` | 
| [Check Serialisation](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Serialisation) | BHoMBot | Triggered by PR Comment `@BHoMBot check serialisation` | 
| [Check Versioning](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Versioning) | BHoMBot | Triggered by PR Comment `@BHoMBot check versioning` | 
| [Check Ready To Merge](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Ready-To-Merge) | BHoMBot | Triggered by PR Comment `@BHoMBot check ready-to-merge` |
| [Check Compliance](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Compliance) | BHoMBot | Triggered by PR Comment `@BHoMBot check compliance` |  
| [Check Required](/documentation/DevOps/Code%20Compliance%20and%20CI/CI%20Checks/Check-Required) | BHoMBot | Triggered by PR Comment `@BHoMBot check required` |  

***

## Use of CI checks

Not all checks are required on all repositories or on all branches, depending on the lifecycle state of the repository. The table below indicates which checks are required for a given repository state.

| Check | Prototype | Alpha | Beta (`develop`) | Beta (`main`) |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Core | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Installer | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Project Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Code Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Documentation Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Copyright Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Dataset Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Branch Compliance | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) |
| Unit Tests | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Null Handling | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Serialisation | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Versioning | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |
| Ready to Merge | ![image](https://user-images.githubusercontent.com/18049174/208926050-7b098444-3c70-4771-a2cd-ae1a98f4bbb2.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) | ![image](https://user-images.githubusercontent.com/18049174/208926129-2f462802-36b4-443e-b545-1356e481832d.png) |

<sup>1</sup> See more notes on our approach to using and interacting with bots and automated processes as part of our [Code of Conducts](https://github.com/BHoM/BHoM/blob/master/docs/CODE_OF_CONDUCT_FOR_BOTS).