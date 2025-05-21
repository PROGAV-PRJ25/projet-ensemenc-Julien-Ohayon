public class ModeClassique : Mode
{
    public string? Meteo { get; set; }
    public int Temperature { get; set; }
    public int Precipitation { get; set; }
    public string Date = "Janvier";
    private Dictionary<string, (string meteo, int temp, int pluie)> meteoParMois = new()
    {
        {"Janvier", ("Nuage", 4, 65)},
        {"Fevrier", ("Pluie fine", 4, 50)},
        {"Mars",("Nuage",6,50) },
        {"Avril",("Soleil",10,40)},
        {"Mai",("Nuage",13,60)},
        {"Juin",("Nuage",16,65)},
        {"Juillet",("Pluie",18,80)},
        {"Août",("Pluie",18,65)},
        {"Septembre",("Soleil",15,75)},
        {"Octobre",("Nuage",11,70)},
        {"Novembre",("Pluie",7,65)},
        {"Decembre",("Neige",4,70)}
    };

    private List<string> moisOrdre = new List<string>
    {
        "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin","Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"
    };

    public enum Actions { semer = 1, arroser = 2, recolter = 3 }

    public ModeClassique() : base()
    {
        ChangerMeteo(1);
    }

    /*public Terrain TrouverTerrain(int nbCible)      //faire pareil pour les plantes
    {
        foreach (Terrain elem in Terrains)
        {
            if (elem.Numero==nbCible)
            {
                return elem;
            }
            
        }
        return null;
    }
    */

    public void ChangerMeteo(int tours)  //? //on change la méteo, les température et les précipitations en fonction des mois
    {

        int dateNum = (tours - 1) % 12;
        Date = moisOrdre[dateNum];
        if (meteoParMois.TryGetValue(Date, out var valeurs))    //change la météo en fonction du dico
        {
            Meteo = valeurs.meteo;
            Temperature = valeurs.temp;
            Precipitation = valeurs.pluie;
        }

    }

    public override void Simuler(List<Terrain> terrains)
    {

        Console.WriteLine($"\nMode Classique - Mois : {Date} \n Météo : {Meteo}, Température : {Temperature}°C, Précipitation : {Precipitation}mm");
        ChoisirEvent();
        Console.WriteLine($"La bonne fée ou l'obstacle est :  {ObsBFActif}");

        for (int i = 0; i < 2; i++)
        {
            //AfficherActionsDispo();
            //Agir(terrains);
        }

    }

    public void ChoisirEvent(List<Terrain> terrains)
    {
        Random rnd = new Random();
        
        int nbrTerrains = terrains.Count;       //choisi aléatoire du terrain sur lequel va être l'obstacle ou la bonne fée
        int numAlea = rnd.Next(1,nbrTerrains + 1)
        Terrain terrainTrouve = null;
        foreach (Terrain t in terrains)
        {
            if (t.Numero == numeroRecherche)
            {
                terrainTrouve = t;
            }
        }

        int x = rnd.Next(1, 8);      // choisir si c'est une bonne fée, obstacles ou obstacles d'urgence
        if (x <= 3)
        {
            int y = rnd.Next(1, Enum.GetValues(typeof(BonnesFees)).Length + 1);
            ObsBFActif = ((BonnesFees)y).ToString();
            AgirBonnesFees(ObsBFActif, terrainTrouve);
        }
        else if (x <= 6)
        {
            int y = rnd.Next(1, Enum.GetValues(typeof(Obstacles)).Length + 1);
            ObsBFActif = ((Obstacles)y).ToString();
            AgirObstacles(ObsBFActif, terrainTrouve);
        }
        else
        {
            int y = rnd.Next(1, Enum.GetValues(typeof(ObstaclesUrgence)).Length + 1);
            ObsBFActif = ((ObstaclesUrgence)y).ToString();
            evenementActuel = Evenement.Urgence;
        }
    }

    public void AgirBonnesFee(BonnesFees bf, Terrain terrain)   //si on choisit de le faire sur un terrain particulier
    {
        switch (bf)
        {
            case BonnesFees.VerDeTerre:
                terrain.Fertiliser();
                break;
            case BonnesFees.Abeille:
                terrain.Florir();
                break;
            case BonnesFees.Herisson:
                terrain.Assainir();
                break;
        }
    }

    public void AgirObstacles(Obstacles obs, Terrain terrain)   //si on choisit de le faire sur un terrain particulier
    {
        switch (obs)
        {
            case Obstacles.Pietineur:
                terrain.DetruirePlante();
                break;
            case Obstacles.Taupe:
                terrain.Deranger();
                break;
            case Obstacles.Oiseaux:
                terrain.MangerGraine();
                break;
        }
    }


}