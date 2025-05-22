public abstract class Plante
{
    public List<int[]> CoordPlante {get; set;}
    public string Affichage { get; set; }
    public string Nature { get; set; }     // anuelle ou vivace
    public string Saison {get;set;}     //de semis
    public string TerrainPref {get;set;}
    public static int espacement = 1;
    public int PlaceRequise {get;set;}
    public int Vitesse {get;set;}
    public int BesoinEau {get;set;}
    public int BesoinLumi {get;set;}
    public int TempMin {get;set;}   //en °C
    public int TempMax {get;set;}   //en °C
    public List<string> Maladies {get;set;}
    public int EsperanceVie {get;set;}  //du plant, en années
    public int NbPousses {get;set;}

    public int ScoreGlobal { get; set; }     
    public int MoisRestant { get; set; }
    protected enum statutPlante
    {
        graine, jeunePousse, auTop, mourrante
    }

    public statutPlante etat = statutPlante.graine;     //toujours une graine au début


    //statut : enum ou 1=graine , 2 = jeune pousse, 3=

    public abstract void ChangerAffichage();  //ou juste console writeline ??

    public Plante(List<int[]> coord)
    {
        this.CoordPlante = coord;
        ScoreGlobal = EsperanceVie;
        MoisRestant = EsperanceVie;
    }

    //public Carotte (string nom) : base (nom, string saison="hiver"...) { }

    //tulipes jacinthes asters

    public override string ToString()
    {
        string message = base.ToString()+$"\nNom : {Nature}\n";
        message += $"Saison : {Saison}\n";
        message += $"Terrain préféré : {TerrainPref}\n";
        message += $"Espacement : {espacement}\n";
        message += $"Place requise : {PlaceRequise}\n";
        message += $"Vitesse de croissance : {Vitesse}\n";
        message += $"Besoin en eau : {BesoinEau}\n";
        message += $"Besoin en lumière : {BesoinLumi}\n";
        message += $"Températures préférées : {TempMin}°C-{TempMax}°C\n";
        message += $"Maladies : ";
        foreach (string maladies in Maladies)
        {
            message += maladies;
        }
        message += $"\nEspérance de vie : {EsperanceVie} an(s)\n";
        message += $"Nombre de fleur(s) par plant : {NbPousses}\n";
       
        return message;
    }
}
