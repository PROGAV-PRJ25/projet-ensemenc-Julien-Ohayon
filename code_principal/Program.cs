//test instance tulipe
//PlanteTulipe tulipe1 = new PlanteTulipe("première tulipe");
//Console.WriteLine(t1);

TerrainArgile t1 = new TerrainArgile();   //changer dans constructeur
TerrainSable t2 = new TerrainSable();
Simulation s1 = new Simulation(new List<Terrain> { t1, t2 });
s1.Simuler(3);