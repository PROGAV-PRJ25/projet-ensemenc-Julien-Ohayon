public class ModeUrgence : Mode
{

    public ModeUrgence() : base()
    { }

    public override void Simuler(List<Terrain> terrains)
    {
        Console.WriteLine($"Mode Urgence");
        Console.WriteLine($"Cause de l'urgence : {ObsBFActif}");
        for (int i = 1; i < 4; i++)
        {
            Console.WriteLine($"Dégradation des terrains en temps réel : h{i}...");
            foreach (Terrain terrain in terrains)   //afficher que terrain urgence 
            {
                terrain.Afficher();
            }
            Thread.Sleep(3000); //freeze de 2sec
            Console.Clear();
            AgirObstaclesUrg(ObsBFActif);

            
        }

        //AfficherActionsUrgence()
        //AgirActionUrgence(terrains)

        evenementActuel = Evenement.Classique;   //pour annoncer qu'on retourne mode classique
    }

    public void AgirObstaclesUrg(Obstacles obs)
    {
        switch (obs)
        {
            case ObstaclesUrgence.Grele:
                terrain.Greler();
                break;
            case ObstaclesUrgence.Tempete:
                terrain.Envoler();
                break;
            case ObstaclesUrgence.MaladieGrave:
                terrain.Mourir();
                break;
        }
    }



    public void AgirActionUrgence()
    {

        Console.WriteLine("1 pour mettre une serre\n2pour mettre un épouventail\n3pour donner une potion");
        //ça lit le chiffre en readline puis methode c'est dans les rangs
        Console.WriteLine($"Vous avez choisi d'uiliser : {(ActionsUrgences)i}");
        switch (i)
        {
            case 1:
                MettreSerre();
                break;
            case 2:
                MettreEpouventail();    //a enlever 
                break;
            case 3:
                DonnerPotion(); //fonctions à mettre dans terrains avec un foreach pour tous les terrains de la simu ou dans la simu non ?
        }



    }

    
}