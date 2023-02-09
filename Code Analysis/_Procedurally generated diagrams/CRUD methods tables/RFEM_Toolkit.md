| Object | Create | Read | Update |
|-|-|-|-|
| BH.oM.Structure.Elements.Bar | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<Bar> bars)<br>BH.Adapter.RFEM.Convert.ToRFEM(Bar bar, Int32 barId, Int32 lineId) | BH.Adapter.RFEM.RFEMAdapter.ReadBars(List<String> ids) |  |
| BH.oM.Structure.Elements.Edge | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<Edge> edges) |  |  |
| BH.oM.Structure.MaterialFragments.IMaterialFragment | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<IMaterialFragment> materialFragments)<br>BH.Adapter.RFEM.Convert.ToRFEM(IMaterialFragment materialFragment, Int32 materialId) | BH.Adapter.RFEM.RFEMAdapter.ReadMaterials(List<String> ids) |  |
| BH.oM.Structure.Elements.Node | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<Node> nodes)<br>BH.Adapter.RFEM.Convert.ToRFEM(Node node, Int32 nodeId) | BH.Adapter.RFEM.RFEMAdapter.ReadNodes(List<String> ids) |  |
| BH.oM.Structure.Elements.Panel | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<Panel> panels)<br>BH.Adapter.RFEM.Convert.ToRFEM(Panel panel, Int32 panelId, Int32[] boundaryIdArr) | BH.Adapter.RFEM.RFEMAdapter.ReadPanels(List<String> ids) |  |
| BH.oM.Structure.Elements.RigidLink | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<RigidLink> links) | BH.Adapter.RFEM.RFEMAdapter.ReadLinks(List<String> ids) |  |
| BH.oM.Structure.SectionProperties.ISectionProperty | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<ISectionProperty> sectionProperties)<br>BH.Adapter.RFEM.Convert.ToRFEM(ISectionProperty sectionProperty, Int32 sectionPropertyId, Int32 materialId) | BH.Adapter.RFEM.RFEMAdapter.ReadSectionProperties(List<String> ids) |  |
| BH.oM.Structure.SurfaceProperties.ISurfaceProperty | BH.Adapter.RFEM.RFEMAdapter.CreateCollection(IEnumerable<ISurfaceProperty> surfaceProperties)<br>BH.Adapter.RFEM.Convert.ToRFEM(ISurfaceProperty surfaceProperty) | BH.Adapter.RFEM.RFEMAdapter.ReadSurfaceProperties(List<String> ids) |  |
| BH.oM.Structure.Constraints.Constraint6DOF | BH.Adapter.RFEM.Convert.ToRFEM(Constraint6DOF constraint, Int32 constraintId, Int32 nodeId) | BH.Adapter.RFEM.RFEMAdapter.ReadConstraints(List<String> ids) |  |
| BH.oM.Base.IBHoMObject |  | BH.Adapter.RFEM.RFEMAdapter.Read(Type type, IList ids, ActionConfig actionConfig) |  |
