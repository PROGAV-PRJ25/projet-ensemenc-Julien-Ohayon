public class ModeClassique : Simulation 
{
    public string Meteo {get;set;}
    public int Temperature {get;set;}
    public int Precipitation {get;set;}
    public int tours =1;
    private static int toursSuivant = 1;
    public string Date {get;set;}
    public enum Mois
    {
        Janvier=1, Fevrier=2, Mars=3, Avril=4, Mai=5, Juin=6, Juillet=7, Aout=8, Septembre=9, Octobre=10, Novembre=11, Decembre=12
    }
    
    public ModeClassique ()
    {
        tours = toursSuivant;
        toursSuivant++;
        this.Meteo=Meteo;
        this.Temperature=Temperature;
        this.Precipitation=Precipitation;
        ChangerMeteo();
    }

    public void ChangerMeteo()  //on change la méteo, les température et les précipitations en fonction des mois
    {
        int dateNum = tours/12;
        Date = (Mois)dateNum;
        if (Date=="Janvier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Mars")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Avril")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
    }

    public override string ToString()
    {
        string message = $"\nMode Classique \n Mois : {Date}, Météo : {Meteo}, Température : {Temperature}°C, Préipitation : {Precipitation}cm";
        
        return message;
    }
}