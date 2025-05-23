// instanciation des terrains argileux
TerrainArgile a1 = new TerrainArgile();  
TerrainArgile a2 = new TerrainArgile();

// instanciation des terrains sableux
TerrainSable s1 = new TerrainSable();
TerrainSable s2 = new TerrainSable();

// instanciation des terrains terreux
TerrainTerre t1 = new TerrainTerre();
TerrainTerre t2 = new TerrainTerre();

Simulation simu = new Simulation(new List<Terrain> { a1, a2, s1, s2, t1, t2 });

//simulation de 36 tours (36 mois)
simu.Simuler(36);