
public class Simulation
{
    public int tours = 1;

    private static Dictionary<string, Mode> modeDispo = new Dictionary<string, Mode> //dictionnaire du mode disponible
    {
        {"Classique", new ModeClassique()},
        {"Urgence", new ModeUrgence()}
    };


    private Mode modeEnCours;

    private List<Terrain> Terrains { get; set; }
    public Simulation(List<Terrain> Terrains)
    {
        this.Terrains = Terrains;
        modeEnCours = modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();
    }

    public void Simuler(int nbTours)
    {
        Console.WriteLine("Consignes blablabla, début simu");

        for (int i = 1; i <= nbTours; i++)
        {
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
                }
                else
                {
                    p.ScoreGlobal--;
                }
                

            }
        }
    }

}