
public class Simulation
{
    public int tours = 1;

    private static Dictionary<string, Mode> modeDispo = new Dictionary<string, Mode> //dictionnaire du mode disponible
    {
        {"Classique", new ModeClassique()},
        {"Urgence", new ModeUrgence()}
    };


    private Mode modeEnCours;

    public static List<Terrain> Terrains = new List<Terrain>();
    public Simulation (List<Terrain> terrains)
    {
        Terrains=terrains;
        modeEnCours=modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();
    } 

    public void Simuler(int nbTours)
    {
        Console.WriteLine("Bienvenue jeune jardinier!\n Le jardin suivant est composé de plusieurs type de terrains : des terrains argileux (1), sableux (2) et terreux (3) qui peuvent respectivement accueillir des tulipes, des jacinthes et asters.\nSouvenez-vous en bien !\nLe jardin se trouve aux Pays-Bas.");
        Console.WriteLine("A chaque mois passé, le jardin s'affiche en mode classique et un évènement arrive : bonnes fées (qui aident les plantes à fleurir, ou les rajeunissent en augmentant leur score global), et les obstacles (qui diminuent leur score global, les amenant petit à petit vers la mort...)");
        Console.WriteLine("Veillez bien au pourcentage d'eau dans vos terrains !");
        Console.WriteLine("A chaque tour, le jardinier peut effectuer 2 actions parmi semer une graine, arroser le terrain et cueillir une plante. Il peut aussi ne rien faire.");
        Console.WriteLine("Vous avez un panier dans lequel seront rangées les plantes cueillies au meilleur de leur forme.\nAttention, si vous les cueillez trop tôt ou trop tard, elles ne seront pas comptabilisées.");
        Console.WriteLine("Il existe aussi des obstacles qui engendre un mode d'urgence où il est possible de prendre des mesures drastiques.\nBonne partie !");
        for (int i = 1; i <= nbTours; i++)
        {
            Thread.Sleep(3000); //freeze de 3sec
            //Console.Clear();
            Console.WriteLine($"Tours n°{i}");
            if (modeEnCours is ModeClassique mc)  //sinon on ne peut pas appeler mode classique comme on aurait pu etre en mode urgence 
            {
                mc.ChangerMeteo(i);

                foreach (Terrain terrain in Terrains)   //changer le pourcentage d'eau des terrains
                {
                    if (mc.Precipitation >= 65)
                    {
                        if (terrain.EauTerrain >= 95)
                        {
                            terrain.EauTerrain = 100;
                        }
                        else
                        {
                            terrain.EauTerrain += 5;
                        }
                    }
                    else
                    {
                        if (terrain.EauTerrain < 5)
                        {
                            terrain.EauTerrain = 0;
                        }
                        else
                        {
                            terrain.EauTerrain -= 5;
                        }
                    }                      
                    
                }       
            }

            modeEnCours.Simuler(Terrains);      //simulation  mode classique

            if (Mode.evenementActuel == Mode.Evenement.Urgence)     //si on passe en mode urgence
            {
                modeEnCours = modeDispo.GetValueOrDefault("Urgence") ?? new ModeUrgence();
                modeEnCours.ObsBFActif = modeDispo["Classique"].ObsBFActif; // transmettre l'urgence en cours
                modeEnCours.Simuler(Terrains!);
                modeEnCours = modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();  //retour mode classique
            }

            ChangerScore();
            Console.WriteLine(modeEnCours);

        }


    }

    public void ChangerScore()
    {
        foreach (Terrain t in Terrains)
        {
            foreach (Plante p in t.Plants)
            {
                p.MoisRestant--;
                if (p.MoisRestant == 0)     // si la plante a vécu toute son esperance de vie elle meurt dans tous les cas 
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