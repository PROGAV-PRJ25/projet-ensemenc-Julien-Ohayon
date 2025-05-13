public class ModeUrgence : Mode
{
    public string EvenementDeclancheur {get;set;}
    public ModeUrgence() : base()
    {
        this.EvenementDeclancheur=EvenementDeclancheur;
    }

    public override void Simuler()
    {
        string message = $"\nMode Urgence";
        message += $"\ncause de l'urgence : {EvenementDeclancheur}";
        Console.WriteLine(message);
        evenementActuel=Evenement.Classique;
    }
    
}