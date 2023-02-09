| Object | Create | Read | Update |
|-|-|-|-|
| BH.oM.Geometry.Point | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Point point, Vector vector) |  |  |
| BH.oM.Environment.Analysis.Node | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Node node, Vector vector) |  |  |
| BH.oM.Environment.Analysis.AnalysisGrid | BH.Engine.Adapters.Radiance.Convert.ToRadiance(AnalysisGrid analysisGrid)<br>BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(AnalysisGrid analysisGrid, String projectDirectory) |  |  |
| BH.oM.Geometry.ICurve | BH.Engine.Adapters.Radiance.Convert.ToRadiance(ICurve curve, IRadianceMaterial material) |  |  |
| BH.oM.Geometry.PlanarSurface | BH.Engine.Adapters.Radiance.Convert.ToRadiance(PlanarSurface surface, IRadianceMaterial material) |  |  |
| BH.oM.Geometry.Mesh | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Mesh mesh, IRadianceMaterial material) |  |  |
| BH.oM.Environment.MaterialFragments.Roughness | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Roughness roughness) |  |  |
| BH.oM.Environment.MaterialFragments.SolidMaterial | BH.Engine.Adapters.Radiance.Convert.ToRadiance(SolidMaterial solidMaterial, Boolean blackMaterial) |  |  |
| BH.oM.Environment.Elements.Panel | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Panel panel)<br>BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(List<Panel> panels, String projectDirectory) |  |  |
| BH.oM.Adapters.Radiance.Sensor | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Sensor sensor)<br>BH.Engine.Adapters.Radiance.Convert.ToRadianceString(List<Sensor> sensors) | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Point point, Vector vector)<br>BH.Engine.Adapters.Radiance.Convert.ToRadiance(Node node, Vector vector)<br>BH.Engine.Adapters.Radiance.Convert.ToRadiance(AnalysisGrid analysisGrid) |  |
| BH.oM.Adapters.Radiance.Source | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Source source) |  |  |
| BH.oM.Adapters.Radiance.Polygon | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Polygon polygon)<br>BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(List<Polygon> polygons, String projectDirectory) | BH.Engine.Adapters.Radiance.Convert.ToRadiance(ICurve curve, IRadianceMaterial material)<br>BH.Engine.Adapters.Radiance.Convert.ToRadiance(PlanarSurface surface, IRadianceMaterial material)<br>BH.Engine.Adapters.Radiance.Convert.ToRadiance(Mesh mesh, IRadianceMaterial material) |  |
| BH.oM.Adapters.Radiance.Plastic | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Plastic plastic, Boolean blackMaterial) |  |  |
| BH.oM.Adapters.Radiance.Glass | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Glass glass, Boolean blackMaterial) |  |  |
| BH.oM.Adapters.Radiance.Light | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Light light) |  |  |
| BH.oM.Adapters.Radiance.Glow | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Glow glow) |  |  |
| BH.oM.Adapters.Radiance.BidirectionalScatteringDistributionFunction | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(BidirectionalScatteringDistributionFunction bsdf) |  |  |
| BH.oM.Lighting.Elements.Luminaire | BH.Engine.Adapters.Radiance.Convert.ToRadianceString(Luminaire luminaire, String userString) |  |  |
| BH.oM.Adapters.Radiance.View | BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(View view, String projectDirectory) |  |  |
| BH.oM.Adapters.Radiance.Executables.Dctimestep | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Dctimestep dctimestep, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Gendaymtx | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Gendaymtx gendaymtx, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Gensky | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Gensky gensky, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Gendaylit | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Gendaylit gendaylit, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Oconv | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Oconv oconv, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rcalc | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rcalc rcalc, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rcontrib | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rcontrib rcontrib, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rfluxmtx | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rfluxmtx rfluxmtx, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rmtxop | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rmtxop rmtxop, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rtrace | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rtrace rtrace, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Rpict | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Rpict rpict, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.Executables.Vwrays | BH.Engine.Adapters.Radiance.Convert.ToRadianceCommand(Vwrays vwrays, RadianceSettings radianceSettings) |  |  |
| BH.oM.Adapters.Radiance.IRadianceMaterial |  | BH.Engine.Adapters.Radiance.Convert.ToRadiance(SolidMaterial solidMaterial, Boolean blackMaterial) |  |
| BH.oM.Reflection.Output`2[[System.Collections.Generic.List`1[[BH.oM.Adapters.Radiance.Polygon, Radiance_oM, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.List`1[[BH.oM.Adapters.Radiance.Polygon, Radiance_oM, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] |  | BH.Engine.Adapters.Radiance.Convert.ToRadiance(Panel panel) |  |
| BH.oM.Reflection.Output`6[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] |  | BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(List<Polygon> polygons, String projectDirectory)<br>BH.Engine.Adapters.Radiance.Convert.ToRadianceFile(List<Panel> panels, String projectDirectory) |  |
