# BHoM JSON Schema

## General

The object model (oM) of the BHoM and a majority BHoM Toolkits exists as [Json-Schemas](https://json-schema.org/) stored in the [BHoM_JSONSChema](https://github.com/BHoM/BHoM_JSONSchema) repository. All schemas are currently being automatically [generated](#generation) based on the C# types in selected repositories in the [BHoM organisation](https://github.com/BHoM).

### Id
All schemas are assigned an [$id](https://json-schema.org/understanding-json-schema/structuring#id). This id is a uri linking to the exact storage location of the particular file on github, in its [raw format](https://docs.github.com/en/repositories/working-with-files/using-files/viewing-and-understanding-files#viewing-or-copying-the-raw-file-content). Using this principle means that the schemas can be [validated](#validation) using online validators including handling of [references](#references). The exact link will be containing the name of the current branch on which the file is currently stored, see examples in the section below, all on taken from schemas on the develop branch. This has an implication in how releases are handled, as the exact link to the schema, and hence its id will vary based on its current release.  For more information, see the [release](#releases) section.

### References

The BHoM JSON schemas make use of [references ($ref)](https://json-schema.org/understanding-json-schema/structuring#dollarref) for handling dependencies between types, in particular for handling properties as well as interfaces. The reference across to another type is used using the [id](#id) of the type that is being referenced.

A major benfit of using this type of structure is that in reduces the size and complexity of the schemas, especially for cases when a property is targeting an [interface](#interfaces).

#### Properties
For properties that target another IObject, the property is linked across via $ref. This allows for greater flexibility as well as simpler composition, especially for more complex schemas. As an example, the [Line](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/Line/) class has two properties, start and end, that are of type [Point](https://bhom.xyz/api/oM/Dimensional/Geometry/Vector/Point/). These properties are referenced in via the ref keyword:

!!! example

    ``` JSON hl_lines="8 11" title="Line.json" linenums="1"
    {
    "$id" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Line.json",
    "title" : "Line",
    "type" : ["object", "null"],
    "description" : "Line: A straight segment in space defining the shortest distance between two points in three-dimensional Euclidean geometry.\nThe Vector from Start to End defines the Line direction, which can be important for some applications.",
    "properties" : {
        "Start" : {
        "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Point.json"
        },
        "End" : {
        "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Point.json"
        },
        "Infinite" : {
        "type" : "boolean",
        "description" : "Defines the Line as a ray of infinite extents in both directions"
        },
        "_t" : {
        "type" : ["string", "null"],
        "description" : "Optional type disciminator.",
        "const" : "BH.oM.Geometry.Line"
        },
        "_bhomVersion" : {
        "type" : ["string", "null"],
        "description" : "Optional version of BHoM used as part of automatic versioning and schema upgrades."
        }
    },
    "required" : ["Start", "End", "Infinite"]
    }
    ```

    ``` JSON hl_lines="2" title="Point.json" linenums="1"
    {
    "$id" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Point.json",
    "title" : "Point",
    "type" : ["object", "null"],
    "description" : "Point: Defines a dimensionless location in three-dimensional space.",
    "properties" : {
        "X" : {
        "type" : "number",
        "description" : "Position along global X coordinate axis."
        },
        "Y" : {
        "type" : "number",
        "description" : "Position along global Y coordinate axis."
        },
        "Z" : {
        "type" : "number",
        "description" : "Position along global Z coordinate axis."
        },
        "_t" : {
        "type" : ["string", "null"],
        "description" : "Optional type disciminator.",
        "const" : "BH.oM.Geometry.Point"
        },
        "_bhomVersion" : {
        "type" : ["string", "null"],
        "description" : "Optional version of BHoM used as part of automatic versioning and schema upgrades."
        }
    },
    "required" : ["X", "Y", "Z"]
    }
    ```

In the example above, you can see that the Point class is referenced across using the $ref keyword, and that the $id of the point is exactly matching the ref used.

#### Interfaces
Interface schemas has been set up to help validate a schema as a particular interface. To acheive this, the interface schemas are set up to be aware of all subtypes available as schemas. 

For a json object to validate against a interface schema it requires the type discriminator "_t" to be set on the object. This is then being used to first check that the type is of a type that is known to be a subtype of the interface via the [enum](https://json-schema.org/understanding-json-schema/reference/enum) keyword.

!!! note
    The type discriminator "_t" is not generally set as required across the BHoM JSON schemas for validation against a known class schema. When validating against a interface schema, at base level or as a property, however it is required to determine the schema to validate against.

!!! warning
    To successfully evaluate a type that is implementing an interface agaist the schema of that interface, the subtype needs to known at the point of creation of the interface schema. This means a class in a repo not set to be part of the [generation](#generation) wont be able to be validated against its base interface, even if it is implementing that inferface in C#.

It then uses the [if then + all of](https://json-schema.org/understanding-json-schema/reference/conditionals#ifthenelse) pattern to validate the object against the appropriate type.

!!! note
    The benefit of this approach over using the [one of](https://json-schema.org/understanding-json-schema/reference/combining#oneOf) or [any of](https://json-schema.org/understanding-json-schema/reference/combining#anyOf) pattern is that it makes the validation and messaging a lot clearer. When the chosen aproach is failing to validate the type againt the know type _t, it will showcase the exact reason that particular validation is failing. In contrast, using the oneOf or anyOf pattern will instead showcase the failures against all listed schemas.

    As an example, a [Line](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/Line/) with a start point missing the required property Z validated as an [ICurve](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/ICurve/) with the allof-if then pattern show the missing Z and just that as the reason for the validation failure. In contrast, a oneOf/anyOf aproach would instead show that failure, but also show why it was failing to validate as all other ICurve types, such as Arc, Circle, NurbsCurve etc.

An example JSON Schema for the [IPolyline](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/IPolyline/) can be seen below.
Here it can be noted that the `"_t"` property is required (line 3), and need to be set to exactly match one of the two classes that implement this interface, the [Polyline](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/Polyline/) and [Polygon](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/Polygon/) (line 6).

Then the all-of + if-the pattern follows, which can be read as: If the value `"_t"` is equal to `"BH.oM.Geometry.Polyline"` (line 14), then the schema should evaluate against the schema of the Polyline (line 20), and similarly for the Polygon (line 27 and 33).

The initial part of requiring `"_t"` to exist and match one of the types guarantiues that only valid types are validated as correct. The allOf if, then ensures that this subtime is valid against the matching schema.

!!! example

    ``` JSON title="IPolyline" linenums="1" hl_lines="3 6 14 20 27 33"
    {
    "$id" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/IPolyline.json",
    "required" : ["_t"],
    "properties" : {
        "_t" : {
        "enum" : ["BH.oM.Geometry.Polyline", "BH.oM.Geometry.Polygon"]
        }
    },
    "allOf" : [{
        "if" : {
            "properties" : {
            "_t" : {
                "type" : ["string", "null"],
                "const" : "BH.oM.Geometry.Polyline"
            }
            },
            "required" : ["_t"]
        },
        "then" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Polyline.json"
        }
        }, {
        "if" : {
            "properties" : {
            "_t" : {
                "type" : ["string", "null"],
                "const" : "BH.oM.Geometry.Polygon"
            }
            },
            "required" : ["_t"]
        },
        "then" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Polygon.json"
        }
        }]
    }
    ```

## Releases

The BHoMJsonSchemas are released in a similar fashion as general [BHoM releases](<../DevOps/BHoM releases.md>), with some caveats and additions.

### Develop state

Throughout a BHoM [Milestone](<../DevOps/Development Cycle/index.md#milestones>) the JSON schemas are updated each week by the use of [github actions](#github-actions) that trigger each weekend and re-generates all BHoM JSON schemas according to the current state of the C# classes throughout the BHoM organisation. 

This means that targeting a schema on the develop branch is guarantiued to be validating against the up to date schema and definition of that particular object. It however also means that you are validating against something that has the potential to change - be it the particular object itself or one of its sub properties.

### Beta releases
At the end of each [Milestone](<../DevOps/Development Cycle/index.md#milestones>) a  [BHoM beta is released](<../DevOps/BHoM releases.md#beta-releases>), and with it a set of JSON schemas matching that particular release.

The JSON schemas for this release will be frozen, and generally not change. To acheive this it means that their [$id](#id) property as well as storage link needs to be updated, which in turn has the implication that all of the [references](#references) need to be updated.

To achieve this a new branch is created at the end of each milestone, with name as `v.MajorNumber.MinorNumber` matching the current release, see example [here](https://github.com/BHoM/BHoM_JSONSchema/tree/v8.2).

On this branch, all schemas are then re-generated with the [branch](#branch) set to the name of the current branch being released. This will update all `$id` as well as `$ref` keywords to be pointing to the version at this particular branch.

Once this is done, the branch is then tagged, and a release created the same way as it is done for the rest of the BHoM.

The release branches will then be left unchanged, making it possible to retreive the frozen versions of the schemas as the develop versions progress.

!!! example

    This showcases the Json schema for the [Line](https://bhom.xyz/api/oM/Dimensional/Geometry/Curve/Line/) object. Pay attention to the highlighted lines to see the difference between the develop and 8.2 version of the line, where the $id as well as the $ref is changed with the context.
    === "develop"

        ``` json linenums="1" hl_lines="2 8 11"
        {
        "$id" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Line.json",
        "title" : "Line",
        "type" : ["object", "null"],
        "description" : "Line: A straight segment in space defining the shortest distance between two points in three-dimensional Euclidean geometry.\nThe Vector from Start to End defines the Line direction, which can be important for some applications.",
        "properties" : {
            "Start" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Point.json"
            },
            "End" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Point.json"
            },
            "Infinite" : {
            "type" : "boolean",
            "description" : "Defines the Line as a ray of infinite extents in both directions"
            },
            "_t" : {
            "type" : ["string", "null"],
            "description" : "Optional type disciminator.",
            "const" : "BH.oM.Geometry.Line"
            },
            "_bhomVersion" : {
            "type" : ["string", "null"],
            "description" : "Optional version of BHoM used as part of automatic versioning and schema upgrades."
            }
        },
        "required" : ["Start", "End", "Infinite"]
        }
        ```

    === "v8.2"

        ``` Json linenums="1" hl_lines="2 8 11"
        {
        "$id" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/v8.2/Geometry_oM/Line.json",
        "title" : "Line",
        "type" : ["object", "null"],
        "description" : "Line: A straight segment in space defining the shortest distance between two points in three-dimensional Euclidean geometry.\nThe Vector from Start to End defines the Line direction, which can be important for some applications.",
        "properties" : {
            "Start" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/v8.2/Geometry_oM/Point.json"
            },
            "End" : {
            "$ref" : "https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/v8.2/Geometry_oM/Point.json"
            },
            "Infinite" : {
            "type" : "boolean",
            "description" : "Defines the Line as a ray of infinite extents in both directions"
            },
            "_t" : {
            "type" : ["string", "null"],
            "description" : "Optional type disciminator.",
            "const" : "BH.oM.Geometry.Line"
            },
            "_bhomVersion" : {
            "type" : ["string", "null"],
            "description" : "Optional version of BHoM used as part of automatic versioning and schema upgrades."
            }
        },
        "required" : ["Start", "End", "Infinite"]
        }
        ```

## Validation

THe BHoM ecosystem currently does not contain any internal tools for validation of a json object against a schema, but relies of external packages for this task.

There are plenty of tools available online to help with this, please see https://json-schema.org/tools for a long list of available tools and packages in multiple languages.

Some tools have however been tested internally with success:

### Online validators

#### https://www.jsonschemavalidator.net/

To use this tool, simply put the Id of the schema you want to evalusate against as a `$ref` in the left hand pane, and the Json of the object you want to validate in the right hand pane. For example, to evaluate against a [Line](https://github.com/BHoM/BHoM_JSONSchema/blob/develop/Geometry_oM/Line.json), put the following in the left hand side pane:

```JSON
{
 "$ref":"https://raw.githubusercontent.com/BHoM/BHoM_JSONSchema/develop/Geometry_oM/Line.json"
}
```

To find the Id of the object you want to validate, please locate the schema in the folders of this repo and look at the `$id` property. Alternatively, you can navigate to the file in the browser and hit the "raw" button, and copy the link as the `$ref`.

#### https://nebula.packetcoders.io/json-schema-validator/
Use a similar process as with the jsonschemavalidator outlined above.

### DotNet validators

#### [JsonEverything](https://docs.json-everything.net/schema/basics/#schema-evaluation-2)

Has been tested and working for validation within the C# environment, building your custom evaluator. An example of this can be found [here](https://github.com/BHoM/BHoM_JSONSchema/blob/develop/.ci/unit-tests/BHoM_JSONSchema_Tests/BHoM_JSONSchema_Tests/ValidateSchemas.cs)

## Generation

The [JsonSchema_Toolkit](https://github.com/BHoM/JSONSchema_Toolkit) has been set up to help facilitate generation of BHoM JSON schemas. This toolkit contains schemas and methods to help turning a C# type into a JSON Schema as well as to write the schema out to text.

### Schema generator
A simple console app has been set up in the [.ci](https://github.com/BHoM/BHoM_JSONSchema/tree/develop/.ci/Generation/SchemaGeneration) folder of the [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema) repository. This console app can be run to (re)generate all schemas for BHoM objects.

Before running locally, please do ensure that you have all repositories stated in the [Included-repositories.txt](https://github.com/BHoM/BHoM_JSONSchema/blob/develop/Included-repositories.txt) cloned and built on your machine.

The app loads all available BHoM oM (object model) assemblies available. For each assembly, it then cleans the corresponding schema folder and then generates a up to date version schema for each type in the assembly.

!!! warning

    The schemas should always be generated as a full package across all assemblies listed, never just partwise generated. Reason for this is that base level interfaces need to be made aware of all sub-types that implement it. Please see the section on interfaces for more information.

When generating the schemas for the [develop](#develop-state) [branch](#branch) the code can be run as is, after the above prerequisite of making sure all repos available has been met.

When generating schemas for release, the app should be run either with providing the approriate branch name as an input arg to the app, or by temporarily changing the default value of the [branch config](#branch) to the appropriate value.

After all schemas have been generated, they should be [tested](#testing) to ensure the (re)generated schemas are correct. Once testing has passed, the schemas can be updated and pushed up to the remote using standard github procedures.

### Testing
Unit tests have been set up in the [.ci](https://github.com/BHoM/BHoM_JSONSchema/tree/develop/.ci/Generation/SchemaGeneration) folder of the [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema) repository.

This contains tests that:
- Valid obejcts validate as valid
- Invalid objects validates as invalid (added to give confidence that the validation is correct)
- Tests to ensure all assemblies are available on the machine execution the tests.


### Config

The [Convert config](https://github.com/BHoM/JSONSchema_Toolkit/blob/develop/JsonSchema_oM/ConvertConfig.cs) given control for how the JSON Schemas should be generated. It currently primarlily hadles settings relating to how ids and references should be handled.

The convert config is passed along with the C# type in the type to JSONSchema method.

#### IncludeId 
Controls wether the [id](#id) keyword should be added to the top level document or not. This is by default set to true, and true for the schemas stored on [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema).

#### TypesAsRef 
Bool indicating if types used by the parent type should be linked to as [ref](#references), or fully expanded. Generally strongly recomended to set this boolean to true for the general case, which is also the default value as well as what is used for the schemas stored on [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema). Ssetting this to false will expand content of all inner types, as well as their subtype, into the main schema file. For types with abstract or interface properties, this will get even more extreme as all option will be populated. Generally only consider setting this to false for types with few levels of nested property types, and no interface types as properties.

#### IncludeInnerIds
Control for if the [id](#id) keyword should be added for inner schemas. Only applicable if [TypeAsRef](#typesasref) is false, hence never used for the schemas stored on [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema). Defaults to false.

#### Branch
String controling the branch to be used for the [id](#id) as well as [ref](#references) keywords. This defaults to `"develop"` which is the value that should be used when generating the [live updates](#develop-state). When a new [release](#beta-releases) is made, this should be changed to the name of that release, i.e., v<i>MajorVersion</i>.<i>MinorVersion</i>, for example `v8.2`

#### OrganisationsToInclude
List of organisations to include when generating schema. Only types in these organisations will be included. This is checked by inspection of the AssemblyDescriptionAttribute, which requires the assembly to link the the github organisation matching one of the organisations in this list. This defaults to only include the BHoM organisation, which also is what is being used for the schemas stored on [BHoM_JSONSchema](https://github.com/BHoM/BHoM_JSONSchema).

### Github actions

To help keep the schemas up to date with current state of develop branch, github actions has been set up to run every weekend, at the night between friday and saturday.

This action automatically runs clones all repos from the [Included-repositories.txt](https://github.com/BHoM/BHoM_JSONSchema/blob/develop/Included-repositories.txt), then runs the [generation](#schema-generator), runs the [test](#testing) and finally raises a pull request with changes. This Pullrequest will then need to be reviewed and merged in to develop.