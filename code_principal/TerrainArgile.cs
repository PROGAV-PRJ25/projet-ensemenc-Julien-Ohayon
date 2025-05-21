public class TerrainArgile : Terrain
{
    //terrain des tulipes
    public TerrainArgile(List<Plante> Plants) : base(Plants)
    {
        EauTerrain = 80;
    }

    public override bool PouvoirPlanter(List<int[]> cases)      //fonction à déplacer dans terrain
    {
        bool planter = false;
        bool dispo = true;
        bool espaceHaut = true;
        bool espaceBas = true;
        bool espaceGauche = true;
        bool espaceDroite = true;


        foreach (int[] elem in cases)
        {
            //on regarde chaque case de la liste, et si c'est pas un plus sur le terrain, elle n'est pas dispo donc false
            if (tableau[elem[0], elem[1]] != "+")
            {
                dispo = false;
            }

            //si dispo false, pas besoin de regarder l'espacement : soit on parcourt une fois la liste, soit 2

            //on regarde si la case en dessous existe, puis si elle est libre 
            if (elem[0] + Plante.espacement  < taille)
            {
                if (tableau[elem[0] + Plante.espacement, elem[1]] != "+") //(ou x si on les met ensuite)
                {
                    espaceBas = false;
                }
            }

            //on regarde si la case au dessus existe, puis si elle est libre 
            if (elem[0] - Plante.espacement >= 0)
            {
                if (tableau[elem[0] - Plante.espacement, elem[1]] != "+") //(ou x si on les met ensuite)
                {
                    espaceHaut = false;
                }
            }

            //on regarde si la case à droite existe, puis si elle est libre 
            if (elem[1] + Plante.espacement < taille)
            {
                if (tableau[elem[0], elem[1] + Plante.espacement] != "+") //(ou x si on les met ensuite)
                {
                    espaceDroite = false;
                }
            }  
            
            //on regarde si la case à gauche existe, puis si elle est libre 
            if (elem[1] - Plante.espacement >= 0)
            {
                if (tableau[elem[0], elem[1] - Plante.espacement] != "+") //(ou x si on les met ensuite)
                {
                    espaceGauche = false;
                }
            }
        }



        if (dispo && espaceHaut && espaceBas && espaceGauche && espaceDroite) //on plante si la place requise et l'espacement sont vérifiés
        {
            planter = true;
        }

        return planter;

    }
    public override void Semer()
    {
        int ligne;
        int colonne;
        Console.WriteLine("Vous allez choisir les coordonnées de votre plante, elle occupera 1 case. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne sur laquelle vous souhaitez semer :");
        ligne = EtreEntier(1, 9);
        Console.WriteLine("Choisissez le numéro de la colonne sur laquelle vous souhaitez semer :");
        colonne = EtreEntier(1, 9);

        //vérifier s'il y a la place de planter -> if PouvoirPlanter(ligne,colonne)==true
        int[] coord = new int[] { ligne, colonne };
        PlanteTulipe tulipe = new PlanteTulipe(new List<int[]> { coord });


    }

    public override void Fertiliser()
    {

    }
}        