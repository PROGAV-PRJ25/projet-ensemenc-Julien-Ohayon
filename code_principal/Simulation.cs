public class Simulation 
{
    public int tours =1;
    public Mois Date;
    private static Dictionary<string,Mode> modeDispo = new Dictionary<string, Mode>
    {
        {"Classique", new ModeClassique()},
        {"Urgence", new ModeUrgence()}
    };   


    private Mode modeEnCours;
    public enum Mois
    {
        Janvier=1, Fevrier=2, Mars=3, Avril=4, Mai=5, Juin=6, Juillet=7, Aout=8, Septembre=9, Octobre=10, Novembre=11, Decembre=12
    }
    List<Terrain> Terrains {get;set;}
    public Simulation (List<Terrain> Terrains)
    {
        this.Terrains=Terrains;
        modeEnCours=modeDispo.GetValueOrDefault("Classique") ?? new ModeClassique();
    } 

    public void Simuler(int nbTours)
    {
        Console.WriteLine("Consignes blablabla, vous pouvez faire 2 actions par tours");
        int dateNum = tours/12;
        Date = (Mois)dateNum;

        for(int i=1;i<=nbTours;i++)
        {
            
            Console.WriteLine($"Tours n°{tours}, Mois : {Date}");
            modeEnCours.Simuler();
            if (Mode.evenementActuel==Mode.Evenement.Urgence)
            {
                modeEnCours =modeDispo.GetValueOrDefault("Urgence") ?? new ModeUrgence();
                modeEnCours.Simuler();
            }
            AfficherTerrain();
            tours++;
        }
        
    }
    void AfficherTerrain()
    {       
        foreach Terrain terrain in Terrains
        {
            Console.WriteLine($"\nTerrain : {terrain.Numero}\n");
            for(int i=0;i<taille;i++)
            {
                for (int j=0;j<taille;j++)
                {
                    if (terrain.Tableau[i,j]=="+" || terrain.Tableau[i,j]==" ")
                    {
                        Console.Write($" {terrain.Tableau[i,j]} ");
                    }
                    else
                    Console.Write($"{terrain.Tableau[i,j]} ");
                }
                Console.Write("");
                Console.WriteLine();
            }
        }
        
    }
    

}