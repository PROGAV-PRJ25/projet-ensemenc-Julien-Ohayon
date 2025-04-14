public abstract class Plante
{
    private string NomPlante {get;}
    private string Nature {get;}
    private string Saison {get;}
    private Terrain TerrainPref {get;}
    private int Espacement {get;}
    private int PlaceRequise {get;}
    private int Vitesse {get;}
    private int BesoinEau {get;}
    private int BesoinLumi {get;}
    private int TempMin {get;}
    private int TempMax {get;}
    private List<string> Maladies {get;}
    private int EsperanceVie {get;}
    private int NbPousses {get;}
    private int CondResp {get;}

    public Plante(string nom)
    {
        this.NomPlante = nom;
    } 

    //public Carotte (string nom) : base (nom, string saison="hiver"...) { }




}