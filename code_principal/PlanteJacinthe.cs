public class PlanteJacinthe : Plante
{
    public PlanteJacinthe (List<int[]> coord) : base (coord) {
        this.Nature = "vivace";
        this.Saison = "automne";
        this.TerrainPref = "sable";
        this.Espacement = 2;    //12 à 15 cm entre les bulbes
        this.PlaceRequise = 2;  
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