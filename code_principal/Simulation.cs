public class Simulation 
{
    
    public int tours =1;
    public string Date = "Janvier";
    public enum Mois
    {
        Janvier=1, Fevrier=2, Mars=3, Avril=4, Mai=5, Juin=6, Juillet=7, Aout=8, Septembre=9, Octobre=10, Novembre=11, Decembre=12
    }
    List<Terrain> Terrains {get;set;}
    public Simulation (List<Terrain> Terrains)
    {
        this.Terrains=Terrains;
    } 

    public void Simuler(int nbTours)
    {
        Console.WriteLine("Consignes blablabla, vous pouvez faire 2 actions par tours");
        int dateNum = tours/12;
        Date = (Mois)dateNum;
        Random rnd = new Random();

        for(int i=1;i<=nbTours;i++)
        {
            int x = rnd.Next(1,8);
            Console.WriteLine($"Tours n°{tours}, Mois : {Date}");
            ModeClassique.SimulerClassique();
            if (x==1)
            {
                ModeUrgence.SimulerUrgence();
            }
            AfficherTerrain();
            tours++;
        }
    }
    void AfficherTerrain()
    {       
        foreach Terrain terrain in Terrains 
        {
            for(int i=0;i<taille;i++)
            {
                for (int j=0;j<taille;j++)
                {
                    if (terrain.tableau[i,j]=="+" || terrrain.tableau[i,j]==" ")
                    {
                        Console.Write($" {terrain.tableau[i,j]} ");
                    }
                    else
                    Console.Write($"{terrain.tableau[i,j]} ");

                    
                }
                Console.Write("");
                Console.WriteLine();
            }
        }
        
    }
    

}