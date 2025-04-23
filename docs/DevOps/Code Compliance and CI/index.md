# Code compliance

## What is code compliance?

Code Compliance is the phrase used to determine how much the code written within the BHoM framework is in line with the rules/regulations/guidelines of BHoM development. The compliance rules have evolved following the initial ethos of BHoM and been carefully refined as BHoM has developed.

The core of the rules however remains the same - that the code should be architected in such a way to facilitate, and promote, adoption and collaboration by any engineer using the BHoM. The components they see on the UI, should reflect what they can see in the code, the code should be easy to navigate by those wishing to find information, and the style from toolkit to toolkit should be consistent. All of this allows new members of BHoM to quickly get to grips with the basics, and the ability for multiple people to work on multiple toolkits is enhanced as a result.

The rules, regulations, and guidelines set out in this section of the wiki are there to give us reference for writing sustainable, maintainable, and compliant code within the framework of BHoM. They are our standards by which we should all follow.

The compliance laid out in the following pages does undergo periodic review by the DevOps team, as styles develop, and the guidance evolves, so if you feel something isn't quite right or is unclear, please feel free to open a discussion.

## Types of compliance

Compliance can be broken into the following categories.

 - Code Compliance - this is the compliance of code which is written within the BHoM framework
 - Documentation Compliance - this is the compliance of the documentation that aids users and wraps around code
 - Project Compliance - this is the compliance of the repository, its associated project files, and planning operations

## Compliance results

Compliance results can form one of three outcomes.

 - Pass - everything is good, compliant, and meets the guidance available
 - Warning - a piece of code is not compliant, but it is deemed not to be so severe as to prevent a PR being merged, but it should be addressed as quick as possible
 - Fail - a piece of code is not compliant, and it is critical to resolve it before the PR is merged

Toolkit and Discipline Leads are responsible for deciding whether `warning` results are acceptable on their toolkit on a case-by-case basis.

## Current compliance checks

Correct at time of writing.

| Check  | Severity | Compliance Type | 
| ------------- | ------------- | ------------- |
| [**Assembly Information**](/documentation/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/AssemblyInfo-compliance) | Fail | Project |
| [**AttributeHasEndingPunctuation**](Compliance%20Checks/AttributeHasEndingPunctuation) | Warning | Documentation |
| [**EngineClassMatchesFilePath**](Compliance%20Checks/EngineClassMatchesFilePath) | Fail | Code |
| [**HasConstructor**](Compliance%20Checks/HasConstructor) | Fail | Code |
| [**HasDescriptionAttribute**](Compliance%20Checks/HasDescriptionAttribute) | Fail | Documentation |
| [**HasOneConstructor**](Compliance%20Checks/HasOneConstructor) | Fail | Code |
| [**HasOutputAttribute**](Compliance%20Checks/HasOutputAttribute) | Warning | Documentation |
| [**HasPublicGet**](Compliance%20Checks/HasPublicGet) | Fail | Code |
| [**HasSingleClass**](Compliance%20Checks/HasSingleClass) | Fail | Code |
| [**HasSingleNamespace**](Compliance%20Checks/HasSingleNamespace) | Fail | Code |
| [**HasUniqueOutputAttribute**](Compliance%20Checks/HasUniqueOutputAttribute) | Fail | Documentation |
| [**HasUniqueMultiOutputAttributes**](Compliance%20Checks/HasUniqueMultiOutputAttributes) | Fail | Documentation |
| [**HasValidConstructor**](Compliance%20Checks/HasValidConstructor) | Fail | Code |
| [**HasValidCopyright**](Compliance%20Checks/HasValidCopyright) | Fail | Copyright |
| [**HasValidOutputAttribute**](Compliance%20Checks/HasValidOutputAttribute) | Fail | Documentation |
| [**HasValidMultiOutputAttributes**](Compliance%20Checks/HasValidMultiOutputAttributes) | Fail | Documentation |
| [**HasValidPreviousVersionAttribute**](Compliance%20Checks/HasValidPreviousVersionAttribute) | Fail | Documentation |
| [**HiddenInputsAreLast**](Compliance%20Checks/HiddenInputsAreLast) | Warning | Documentation |
| [**InputAttributeHasMatchingParameter**](Compliance%20Checks/InputAttributeHasMatchingParameter) | Fail | Documentation |
| [**InputAttributeIsUnique**](Compliance%20Checks/InputAttributeIsUnique) | Fail | Documentation |
| [**InputAttributesAreInOrder**](Compliance%20Checks/InputAttributesAreInOrder) | Fail | Documentation |
| [**InputParameterStartsLower**](Compliance%20Checks/InputParameterStartsLower) | Fail | Code |
| [**IsDocumentationURLValid**](Compliance%20Checks/IsDocumentationURLValid) | Fail | Documentation |
| [**IsExtensionMethod**](Compliance%20Checks/IsExtensionMethod) | Fail | Code |
| [**IsInputAttributePresent**](Compliance%20Checks/IsInputAttributePresent) | Warning | Documentation |
| [**IsPublicClass**](Compliance%20Checks/IsPublicClass) | Fail | Code |
| [**IsPublicProperty**](Compliance%20Checks/IsPublicProperty) | Fail | Code |
| [**IsStaticClass**](Compliance%20Checks/IsStaticClass) | Fail | Code |
| [**IsUsingCustomData**](Compliance%20Checks/IsUsingCustomData) | Warning | Code |
| [**IsValidCreateMethod**](Compliance%20Checks/IsValidCreateMethod) | Fail | Code |
| [**IsValidConvertMethodName**](Compliance%20Checks/IsValidConvertMethodName) | Fail | Code |
| [**IsValidCreateMethodName**](Compliance%20Checks/IsValidCreateMethodName) | Fail | Code |
| [**IsValidDataset**](Compliance%20Checks/IsValidDataset) | Fail | Dataset |
| [**IsValidEngineClassName**](Compliance%20Checks/IsValidEngineClassName) | Fail | Code |
| [**IsValidIImmutableObject**](Compliance%20Checks/IsValidIImmutableObject) | Fail | Code |
| [**IsVirtualProperty**](Compliance%20Checks/IsVirtualProperty) | Fail | Code |
| [**MethodNameContainsFileName**](Compliance%20Checks/MethodNameContainsFileName) | Fail | Code |
| [**MethodNameStartsUpper**](Compliance%20Checks/MethodNameStartsUpper) | Fail | Code |
| [**ModifyReturnsDifferentType**](Compliance%20Checks/ModifyReturnsDifferentType) | Fail | Code |
| [**ObjectNameMatchesFileName**](Compliance%20Checks/ObjectNameMatchesFileName) | Fail | Code |
| [**PreviousInputNamesAttributeHasMatchingParameter**](Compliance%20Checks/PreviousInputNamesAttributeHasMatchingParameter) | Fail | Documentation |
| [**PreviousInputNamesAttributeIsUnique**](Compliance%20Checks/PreviousInputNamesAttributeIsUnique) | Fail | Documentation |
| [**Project References and Build Paths**](Compliance%20Checks/Project-References-and-Build-Paths) | Fail | Project |
| [**PropertyAccessorsHaveNoBody**](Compliance%20Checks/PropertyAccessorsHaveNoBody) | Fail | Code |
| [**UIExposureHasDefaultValue**](Compliance%20Checks/UIExposureHasDefaultValue) | Fail | Documentation |
