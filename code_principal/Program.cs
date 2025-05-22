//test instance tulipe
//PlanteTulipe tulipe1 = new PlanteTulipe("première tulipe");
//Console.WriteLine(t1);

List<Plante> l1 = new List<Plante>();
List<Plante> l2 = new List<Plante>();
TerrainArgile t1 = new TerrainArgile(l1);   //changer dans constructeur
TerrainSable t2 = new TerrainSable(l2);
Simulation s1 = new Simulation(new List<Terrain> { t1, t2 });
s1.Simuler(3);