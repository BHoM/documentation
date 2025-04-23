# Revit Push modes



`PushType` is being set when specifying the Push action. It drives what is meant to happen depending on whether a Revit element correspondent to the pushed BHoM object already exists in the model. The way in which the Revit elements get linked to BHoM objects is explained in [BHoM vs Revit identity section](../../Revit Adapter/BHoM vs Revit Identity).

Currently following `PushTypes` are provided by the [Adapter](https://github.com/BHoM/documentation/wiki/Adapter-Actions#push), with following actions being taken for each:

| PushType      | Revit element exists     | Revit element does not exist     |
|----------------|:--------------:|:--------------:|
| `CreateOnly` | do nothing | create new element  |
| `UpdateOnly` | update existing element | do nothing |
| `DeleteThenCreate` | delete existing element and create new one | create new element |
| `CreateNonExisting` | not implemented | not implemented |
| `FullPush` | not implemented | not implemented  |

Default `PushType` for Revit Adapter is `PushType.DeleteThenCreate`.