# Code compliance

## What is code compliance?

Code Compliance is the phrase used to determine how much the code written within the BHoM framework is in line with the rules/regulations/guidelines of BHoM development. The compliance rules have evolved following the initial ethos of BHoM and been carefully refined as BHoM has developed.

The core of the rules however remains the same - that the code should be architected in such a way to facilitate, and promote, adoption and collaboration by any engineer using the BHoM. The components they see on the UI, should reflect what they can see in the code, the code should be easy to navigate by those wishing to find information, and the style from toolkit to toolkit should be consistent. All of this allows new members of BHoM to quickly get to grips with the basics, and the ability for multiple people to work on multiple toolkits is enhanced as a result.

The rules, regulations, and guidelines set out in this section of the wiki are there to give us reference for writing sustainable, maintainable, and compliant code within the framework of BHoM. They are our standards by which we should all follow.

The compliance laid out in the following pages does undergo periodic review by the Governance, Framework and CI/CD teams, as styles develop, and the guidance evolves, so if you feel something isn't quite right or is unclear, please feel free to open a discussion.

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
| [**Assembly Information**](AssemblyInfo-compliance) | Fail | Project |
| [**AttributeHasEndingPunctuation**](AttributeHasEndingPunctuation) | Warning | Documentation |
| [**EngineClassMatchesFilePath**](EngineClassMatchesFilePath) | Fail | Code |
| [**HasConstructor**](HasConstructor) | Fail | Code |
| [**HasDescriptionAttribute**](HasDescriptionAttribute) | Warning | Documentation |
| [**HasOneConstructor**](HasOneConstructor) | Fail | Code |
| [**HasOutputAttribute**](HasOutputAttribute) | Warning | Documentation |
| [**HasPublicGet**](HasPublicGet) | Fail | Code |
| [**HasSingleClass**](HasSingleClass) | Fail | Code |
| [**HasSingleNamespace**](HasSingleNamespace) | Fail | Code |
| [**HasUniqueOutputAttribute**](HasUniqueOutputAttribute) | Fail | Documentation |
| [**HasUniqueMultiOutputAttributes**](HasUniqueMultiOutputAttributes) | Fail | Documentation |
| [**HasValidConstructor**](HasValidConstructor) | Fail | Code |
| [**HasValidCopyright**](HasValidCopyright) | Fail | Copyright |
| [**HasValidOutputAttribute**](HasValidOutputAttribute) | Fail | Documentation |
| [**HasValidMultiOutputAttributes**](HasValidMultiOutputAttributes) | Fail | Documentation |
| [**HasValidPreviousVersionAttribute**](HasValidPreviousVersionAttribute) | Fail | Documentation |
| [**InputAttributeHasMatchingParameter**](InputAttributeHasMatchingParameter) | Fail | Documentation |
| [**InputAttributeIsUnique**](InputAttributeIsUnique) | Fail | Documentation |
| [**InputParameterStartsLower**](InputParameterStartsLower) | Fail | Code |
| [**IsExtensionMethod**](IsExtensionMethod) | Fail | Code |
| [**IsInputAttributePresent**](IsInputAttributePresent) | Warning | Documentation |
| [**IsPublicClass**](IsPublicClass) | Fail | Code |
| [**IsPublicProperty**](IsPublicProperty) | Fail | Code |
| [**IsStaticClass**](IsStaticClass) | Fail | Code |
| [**IsUsingCustomData**](IsUsingCustomData) | Warning | Code |
| [**IsValidCreateMethod**](IsValidCreateMethod) | Fail | Code |
| [**IsValidConvertMethodName**](IsValidConvertMethodName) | Fail | Code |
| [**IsValidCreateMethodName**](IsValidCreateMethodName) | Fail | Code |
| [**IsValidDataset**](IsValidDataset) | Fail | Dataset |
| [**IsValidEngineClassName**](IsValidEngineClassName) | Fail | Code |
| [**IsValidIImmutableObject**](IsValidIImmutableObject) | Fail | Code |
| [**IsVirtualProperty**](IsVirtualProperty) | Fail | Code |
| [**MethodNameContainsFileName**](MethodNameContainsFileName) | Fail | Code |
| [**MethodNameStartsUpper**](MethodNameStartsUpper) | Fail | Code |
| [**ModifyReturnsDifferentType**](ModifyReturnsDifferentType) | Fail | Code |
| [**ObjectNameMatchesFileName**](ObjectNameMatchesFileName) | Fail | Code |
| [**PreviousInputNamesAttributeHasMatchingParameter**](PreviousInputNamesAttributeHasMatchingParameter) | Fail | Documentation |
| [**PreviousInputNamesAttributeIsUnique**](PreviousInputNamesAttributeIsUnique) | Fail | Documentation |
| [**Project References and Build Paths**](Project-References-and-Build-Paths) | Fail | Project |
| [**PropertyAccessorsHaveNoBody**](PropertyAccessorsHaveNoBody) | Fail | Code |