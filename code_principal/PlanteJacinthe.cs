public class PlanteJacinthe : Plante
{
    public PlanteTulipe (string nom) : base (nom) {
        this.Nature = "vivace";
        this.Saison = "automne";
        this.TerrainPref = TerrainSable;
        this.Espacement = 12;    //12 à 15 cm entre les bulbes
        this.PlaceRequise = 12;  //10cm² par plant
        this.Vitesse = 5;   //fleuri 5 mois après la plantation
        this.BesoinEau = 10;     //modéré
        this.BesoinLumi = 75;     //soleil à mi-ombre
        this.TempMin = 12;
        this.TempMax = 18;
        this.Maladies = new List<string> {"fusariose", "pourriture", "mouches de bulbe"};
        this.EsperanceVie = 3; 
        this.NbPousses = 1; //1tige florale par bulbe

     }
} 