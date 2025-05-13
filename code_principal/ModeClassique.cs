public class ModeClassique : Mode 
{
    public string ? Meteo {get;set;}
    public int Temperature {get;set;}
    public int Precipitation {get;set;}    
    
    public ModeClassique () : base ()
    {
        this.Meteo=Meteo;
        this.Temperature=Temperature;
        this.Precipitation=Precipitation;
        ChangerMeteo();
    }

    public void ChangerMeteo()  //on change la méteo, les température et les précipitations en fonction des mois
    {
        if (Simulation.Date=="Janvier")
        {
            Meteo="Nuage";
            Temperature=4;
            Precipitation=65;
        }
        if (Simulation.Date=="Fevrier")
        {
            Meteo="Pluie fine";
            Temperature=4;
            Precipitation=50;
        }
        if (Simulation.Date=="Mars")
        {
            Meteo="Nuage";
            Temperature=6;
            Precipitation=50;
        }
        if (Simulation.Date=="Avril")
        {
            Meteo="Soleil";
            Temperature=10;
            Precipitation=40;
        }
        if (Simulation.Date=="Mai")
        {
            Meteo="Nuage";
            Temperature=13;
            Precipitation=60;
        }
        if (Simulation.Date=="Juin")
        {
            Meteo="Nuage";
            Temperature=16;
            Precipitation=65;
        }
        if (Simulation.Date=="Juillet")
        {
            Meteo="Pluie";
            Temperature=18;
            Precipitation=80;
        }
        if (Simulation.Date=="Août")
        {
            Meteo="Pluie";
            Temperature=18;
            Precipitation=85;
        }
        if (Simulation.Date=="Septembre")
        {
            Meteo="Soleil";
            Temperature=15;
            Precipitation=75;
        }
        if (Simulation.Date=="Octobre")
        {
            Meteo="Nuage";
            Temperature=11;
            Precipitation=70;
        }
        if (Simulation.Date=="Novembre")
        {
            Meteo="Pluie";
            Temperature=7;
            Precipitation=65;
        }
        if (Simulation.Date=="Décembre")
        {
            Meteo="Neige";
            Temperature=4;
            Precipitation=70;
        }
    }

    public override void Simuler()
    {
        ChangerMeteo();
        string message = $"\nMode Classique \n Météo : {Meteo}, Température : {Temperature}°C, Préipitation : {Precipitation}mm";
        Console.WriteLine(message);
        Random rnd = new Random();
        int x = rnd.Next(1,8);      // choisi si c'est une bonne fée, obstacles ou obstacles d'urgence
        if (x<=3)
        {
           int l = Enum.GetValues(typeof(BonnesFees)).Length;
           int y = rnd.Next(1,l+1);
           ObsBF=(BonnesFees)y;
        }
        else if (x<=6)
        {
            int l = Enum.GetValues(typeof(Obstacles)).Length;
            int y = rnd.Next(1,l+1);
        }
        else
        {
            int l = Enum.GetValues(typeof(ObstaclesUrgence)).Length;
            int y = rnd.Next(1,l+1);
            evenementActuel=Evenement.Urgence;
        }

        for (int i=0;i<2;i++)
        {
            Agir();
        }

        
    }
}