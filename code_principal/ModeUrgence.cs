public class ModeUrgence : Mode
{
    
    public ModeClassique () : base(){}

    SimulerUrgence()
    {
        
    }
    public override string ToString()
    {
        string message = $"\nMode Urgence";
        message += "\ncause de l'urgence"
        
        return message;
    }
}