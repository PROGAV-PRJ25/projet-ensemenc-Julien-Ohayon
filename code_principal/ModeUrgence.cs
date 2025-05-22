public class ModeUrgence : Mode
{

    public ModeUrgence() : base() { }

    public override void Simuler(List<Terrain> terrains)
    {
        Console.WriteLine($"Mode Urgence");
        Console.WriteLine($"Cause de l'urgence : {ObsBFActif}");

        Terrain terrainChoisi = ChoisirAleaTerrain(terrains);

        for (int i = 1; i < 4; i++)
        {
            Console.WriteLine($"Dégradation des terrains en temps réel : h{i}...");
            foreach (Terrain terrain in terrains)   //afficher que terrain urgence 
            {
                terrain.Afficher();
                AgirObstaclesUrg(ObsBFActif, terrain);
            }

            Thread.Sleep(3000); //freeze de 2sec
            Console.Clear();
            AgirObstaclesUrg(ObsBFActif, terrainChoisi);

        }

        //AfficherActionsUrgence()
        AgirActionUrgence(terrainChoisi);

        evenementActuel = Evenement.Classique;   //pour annoncer qu'on retourne mode classique
    }

    public void AgirObstaclesUrg(ObsBF obs, Terrain terrain)
    {
    
        switch (obs)
        {
            case ObsBF.Tempête:
                terrain.Envoler();
                break;
            case ObsBF.MaladieGrave:
                terrain.Mourir();
                break;
        //default ?  
        }
                
    }

    public int ChoisirActionUrgence()
    {
        int i = 0;
        return i;

    }

    public void AgirActionUrgence(Terrain terrain)
    {

        Console.WriteLine("1 pour mettre une serre\n2pour mettre un épouventail\n3pour donner une potion");
        //ça lit le chiffre en readline puis methode c'est dans les rangs
        Console.WriteLine($"Vous avez choisi d'utiliser : {(ActionsUrgence)ChoisirActionUrgence()}");
        switch (ChoisirActionUrgence())
        {
            case 1:
                MettreSerre();
                break;
            case 2:
                DonnerPotion(); //fonctions à mettre dans terrains avec un foreach pour tous les terrains de la simu ou dans la simu non ?
                break;
        }
    }

    
    private void MettreSerre()
    {

    }

    private void DonnerPotion()
    {

    }

    
}