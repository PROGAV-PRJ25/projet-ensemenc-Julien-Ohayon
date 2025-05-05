public class PlanteTulipe : Plante
{
    public PlanteTulipe (string nom) : base (nom) {
        this.Nature = "vivace";
        this.Saison = "automne";
        this.TerrainPref = TerrainArgile;
        this.Espacement = 10;    //10 à 15 cm entre les bulbes
        this.PlaceRequise = 10;  //10cm² par plant
        this.Vitesse = 5;   //fleuri 5 mois après la plantation
        this.BesoinEau = 10;     //modéré
        this.BesoinLumi = 100;     //plein soleil
        this.TempMin = 10;
        this.TempMax = 18;
        this.Maladies = new List<string> {"botrytis", "pourriture grise", "virus de la mosaïque"};
        this.EsperanceVie = 5; 
        this.NbPousses = 1; //1tige florale par bulbe

     }
} 
