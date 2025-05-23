// instanciation du terrain argileux
TerrainArgile a1 = new TerrainArgile();  

// instanciation du terrain sableux
TerrainSable s1 = new TerrainSable();

// instanciation du terrain terreux
TerrainTerre t1 = new TerrainTerre();

Simulation simu = new Simulation(new List<Terrain> { a1, s1, t1 });

//simulation de 36 tours (36 mois)
simu.Simuler(36);