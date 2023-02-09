| Object | Create | Read | Update |
|-|-|-|-|
| BH.oM.Structure.Elements.Bar | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<Bar> bhomBars)<br>BH.Adapter.RAM.Convert.ToRAM(Bar bar, ILayoutBeams iLayoutBeams) | BH.Adapter.RAM.RAMAdapter.ReadBars(List<String> ids) | BH.Adapter.RAM.RAMAdapter.Update(IEnumerable<Bar> bars) |
| BH.oM.Structure.SectionProperties.ISectionProperty | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<ISectionProperty> sectionProperties) | BH.Adapter.RAM.RAMAdapter.ReadSectionProperties(List<String> ids) |  |
| BH.oM.Structure.MaterialFragments.IMaterialFragment | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<IMaterialFragment> materials)<br>BH.Adapter.RAM.Convert.ToRAM(IMaterialFragment material) | BH.Adapter.RAM.RAMAdapter.ReadMaterials(List<String> ids) |  |
| BH.oM.Structure.SurfaceProperties.ISurfaceProperty | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<ISurfaceProperty> srfProps) | BH.Adapter.RAM.RAMAdapter.ReadISurfaceProperties(List<String> ids) |  |
| BH.oM.Structure.Elements.Panel | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<Panel> bhomPanels) | BH.Adapter.RAM.RAMAdapter.ReadPanels(List<String> ids) |  |
| BH.oM.Geometry.SettingOut.Level | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<Level> bhomLevels)<br>BH.Adapter.RAM.<>c.<CreateCollection>b__6_0(Level o)<br>BH.Adapter.RAM.<>c.<CreateCollection>b__6_1(Level level)<br>BH.Adapter.RAM.<>c.<CreateCollection>b__6_2(Level level) | BH.Adapter.RAM.RAMAdapter.ReadLevel(List<String> ids) |  |
| BH.oM.Geometry.SettingOut.Grid | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<Grid> bhomGrid) | BH.Adapter.RAM.RAMAdapter.ReadGrid(List<String> ids) |  |
| BH.oM.Structure.Loads.UniformLoadSet | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<UniformLoadSet> loadSets) | BH.Adapter.RAM.RAMAdapter.ReadUniformLoadSets(List<String> ids) |  |
| BH.oM.Structure.Loads.ContourLoadSet | BH.Adapter.RAM.RAMAdapter.CreateCollection(IEnumerable<ContourLoadSet> loads) | BH.Adapter.RAM.RAMAdapter.ReadContourLoadSets(List<String> ids) |  |
| BH.oM.Structure.Elements.Node | BH.Adapter.RAM.<>c.<CreateCollection>b__1_0(Node x, Node y) |  |  |
| BH.oM.Geometry.Point | BH.Adapter.RAM.<>c.<CreateCollection>b__5_0(Point p)<br>BH.Adapter.RAM.Convert.ToRAM(Point point) |  |  |
| BH.oM.Base.IBHoMObject |  | BH.Adapter.RAM.RAMAdapter.Read(Type type, IList ids, ActionConfig actionConfig) |  |
| BH.oM.Structure.Loads.Loadcase |  | BH.Adapter.RAM.RAMAdapter.ReadLoadCase(List<String> ids) |  |
| BH.oM.Structure.Loads.LoadCombination |  | BH.Adapter.RAM.RAMAdapter.ReadLoadCombination(List<String> ids) |  |
| BH.oM.Adapters.RAM.RAMPointGravityLoad |  | BH.Adapter.RAM.RAMAdapter.ReadPointGravityLoad(List<String> ids) |  |
| BH.oM.Adapters.RAM.RAMLineGravityLoad |  | BH.Adapter.RAM.RAMAdapter.ReadLineGravityLoad(List<String> ids) |  |
| BH.oM.Structure.Results.NodeReaction |  | BH.Adapter.RAM.RAMAdapter.ReadNodeReaction(List<String> ids) |  |
| BH.oM.Structure.Results.BarDeformation |  | BH.Adapter.RAM.RAMAdapter.ReadBarDeformations(List<String> ids) |  |
| BH.oM.Adapters.RAM.RAMFactoredEndReactions |  | BH.Adapter.RAM.RAMAdapter.ReadBeamEndReactions(List<String> ids) |  |
