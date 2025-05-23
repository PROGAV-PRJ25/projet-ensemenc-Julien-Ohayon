
public class Simulation
{
    public int tours = 1;

    private static Dictionary<string, Mode> modeDispo = new Dictionary<string, Mode> //dictionnaire du mode disponible
    {
        {"Classique", new ModeClassique()},
        {"Urgence", new ModeUrgence()}
    };


    private Mode modeEnCours;
    
    public static List<Terrain> Terrains {get;private set;}
    public Simulation (List<Terrain> terrains)
    {
        Terrains=terrains;
        modeEnCours=modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();
    } 

    public void Simuler(int nbTours)
    {
        Console.WriteLine("Bienvenue jeune jardinier!\n Le jardin suivant est composé de plusieurs type de terrains : des terrains argileux, sableux et terreux qui peuvent respectivement accueillir des tulipes, des jacinthes et asters.\nLe jardin se trouve aux Pays-Bas.");
        Console.WriteLine("A chaque mois passé, un évènement arrive : bonnes fées (qui aident les plantes à fleurir, ou les rajeunit en augmentant leur score global), et les obstacles (qui diminuent leur score global, les amenant petit à petit vers la mort...)");
        Console.WriteLine("Il existe au ")
        for (int i = 1; i <= nbTours; i++)
        {
            Thread.Sleep(3000); //freeze de 2sec
            Console.Clear();
            Console.WriteLine($"Tours n°{i}");
            if (modeEnCours is ModeClassique mc) //?    //sinon on ne peut pas appeler mode classique comme on aurait pu etre en mode urgence 
            {
                mc.ChangerMeteo(i);
                //Utiliser la fonction controler taux humidité
            }

            modeEnCours.Simuler(Terrains);

            if (Mode.evenementActuel == Mode.Evenement.Urgence)
            {
                modeEnCours = modeDispo.GetValueOrDefault("Urgence") ?? new ModeUrgence();
                modeEnCours.ObsBFActif = modeDispo["Classique"].ObsBFActif; // transmettre l'urgence en cours
                modeEnCours.Simuler(Terrains);
                modeEnCours = modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();  //retour mode classique
            }

            ChangerScore();

        }


    }

    public void ChangerScore()
    {
        foreach (Terrain t in Terrains)
        {
            foreach (Plante p in t.Plants)
            {
                p.MoisRestant--;
                if (p.MoisRestant == 0)     // si la plante a vécu toute son esperance de vie elle meurt dans tous lees cas 
                {
                    p.ScoreGlobal = 0;
                    t.EnleverPlante(p);
                }
                else
                {
                    p.ScoreGlobal--;
                }
                

            }
        }
    }

}