public class ModeUrgence : Mode
{

    public enum ActionsUrgence
    {
        Reconstruction = 1, PotionMagique = 2
    }

    public ModeUrgence() : base() { }

    public override void Simuler(List<Terrain> terrains)
    {
        Console.WriteLine($"Mode Urgence 🚨");
        Console.WriteLine($"Cause de l'urgence : {ObsBFActif}");
        Terrain terrainChoisi = ChoisirAleaTerrain(terrains);   //choix du terrain aléatoire
        Console.WriteLine("Terrain avant l'obstacle d'urgence");
        terrainChoisi.Afficher();
        AgirObstaclesUrg(ObsBFActif, terrainChoisi);    //obstacle d'urgence qui agit
        terrainChoisi.Afficher();
        AgirActionUrgence(terrainChoisi);   //choix  par l'utilisateur et action de l'action d'urgence 
        terrainChoisi.Afficher();
        evenementActuel = Evenement.Classique;   //pour annoncer qu'on retourne mode classique
    }

    private void AgirObstaclesUrg(ObsBF obs, Terrain terrain)
    {
    
        switch (obs)
        {
            case ObsBF.Tempête:
                terrain.Envoler();
                break;
            case ObsBF.MaladieGrave:
                terrain.TomberMalade();
                break;
        }
                
    }

    private void AgirActionUrgence(Terrain terrainChoisi)
    {
        
        bool nombreOk = false;
        string stringNombre;
        int action;
        bool validation = true;

        Console.WriteLine("Indiquez le numéro de l'action que vous souhaitez effectuer :");
        Console.WriteLine("1 : reconstruire");
        Console.WriteLine("2 : donner une potion magique");
        
        do  //test si le nombre est compris entre les valeurs souhaitées
        {
            do  //test si l'utilisateur entre un entier
            {
            if (validation == false)
            {
                Console.WriteLine("Erreur : réessayez");
            } 
            stringNombre = Console.ReadLine()!;
            nombreOk = int.TryParse(stringNombre, out int numericValue);
            validation = false;
            } while (nombreOk == false);

            action = Convert.ToInt32(stringNombre);

        } while (action<1 || action>2);

        if (action == 1)   //on met une serre sur le terrain
        {
            Console.WriteLine("Vous avez choisi de replanter des plantes après la tempête");
            terrainChoisi.Reconstruire();   
        }


        if (action == 2)   //on donne une potion aux plantes du terrain
        {
            Console.WriteLine("Vous avez choisi de donner une potion aux plantes");
            terrainChoisi.DonnerPotion();
        }

    }
    
}