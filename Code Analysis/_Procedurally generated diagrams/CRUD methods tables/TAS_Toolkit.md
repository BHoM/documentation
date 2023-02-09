| Object | Create | Read | Update |
|-|-|-|-|
| BH.oM.Environment.Elements.Space | BH.Adapter.TAS.TasTBDAdapter.Create(IEnumerable<Space> spaces) | BH.Adapter.TAS.TasTBDAdapter.ReadSpaces(List<String> ids) |  |
| BH.oM.Environment.Elements.Building | BH.Adapter.TAS.TasTBDAdapter.Create(IEnumerable<Building> buildings) | BH.Adapter.TAS.TasTBDAdapter.ReadBuilding(List<String> ids) |  |
| BH.oM.Environment.Elements.Panel | BH.Adapter.TAS.TasTBDAdapter.Create(IEnumerable<Panel> buildingElements, Construction tbdConstruction) | BH.Adapter.TAS.TasTBDAdapter.ReadPanels(List<String> ids)<br>BH.Adapter.TAS.TasTBDAdapter.ReadBuildingElements(List<String> ids) |  |
| BH.oM.Physical.Constructions.Construction | BH.Adapter.TAS.TasTBDAdapter.Create(IEnumerable<Construction> constructions) | BH.Adapter.TAS.TasTBDAdapter.ReadConstruction(List<String> ids) |  |
| BH.oM.Physical.Constructions.Layer | BH.Adapter.TAS.TasTBDAdapter.Create(IEnumerable<Layer> layers, Construction tbdConstruction) | BH.Adapter.TAS.TasTBDAdapter.ReadMaterials(List<String> ids) |  |
| BH.oM.Base.IBHoMObject |  | BH.Adapter.TAS.TasTBDAdapter.Read(Type type, IList indices, ActionConfig actionConfig)<br>BH.Adapter.TAS.TasTBDAdapter.Read() |  |
| BH.oM.Architecture.Elements.Level |  | BH.Adapter.TAS.TasTBDAdapter.ReadLevels(List<String> ids) |  |
