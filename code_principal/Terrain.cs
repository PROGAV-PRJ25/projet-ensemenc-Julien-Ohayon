public abstract class Terrain
{
    public double EauTerrain { get; set; }
    public int Numero { get; }
    private static int numeroSuivant = 1;
    public List<Plante> Plants { get; set; }
    public string[,] tableau;
    public int Taille { get; } = 5;

    public Terrain()
    {
        Plants = new List<Plante>();
        tableau = new string[Taille, Taille];
        Numero = numeroSuivant;
        numeroSuivant++;
        for (int i = 0; i < Taille; i++)    //remplissage initial du tableau
        {
            for (int j = 0; j < Taille; j++)
            {
                tableau[i, j] = "+";
            }
        }
    }

    //actualise le contenu du tableau du terrain selon la liste des plantes
    public void Actualiser()
    {
        foreach (Plante plante in Plants)   //pour chaque plante du terrain 
        {
            plante.ChangerAffichage();  //on met à jour l'affichage de la plante selon son état
            foreach (int[] coord in plante.CoordPlante) //pour chaque case occupée par ces plantes
            {
                //on change la case correspondante du tableau en l'affichage de l'état de la plante
                tableau[coord[0], coord[1]] = plante.Affichage!;
            }
        }
    }


    public void Afficher()  
    {
        Actualiser();   //on actualise le tableau avant de l'afficher
        Console.WriteLine($"\nTerrain : {Numero} - Pourcentage d'eau {EauTerrain}\n");
        for (int i = 0; i < Taille; i++)
        {
            for (int j = 0; j < Taille; j++)
            {
                if (tableau[i, j] == "+")
                {
                    Console.Write($" {tableau[i, j]} ");
                }
                else
                    Console.Write($"{tableau[i, j]} ");
            }
            Console.Write("");
            Console.WriteLine();
        }
    }

    public int EtreEntier(int min, int max)  //pour vérifier que l'utilisateur entre les coordonnées d'une case qui existe, adapter min et max selon la taille de nos terrains
    {
        bool nombreOk = false;
        string stringNombre;
        int nombre;
        bool validation = true;

        do  //test si le nombre est compris entre les valeurs souhaitées
        {
            do  //test si l'utilisateur entre un entier
            {
                if (validation == false)
                {
                    Console.WriteLine("Erreur : réessayez");
                }
                Console.WriteLine($"Entrez un nombre entier compris entre {min} et {max} :");
                stringNombre = Console.ReadLine()!;
                nombreOk = int.TryParse(stringNombre, out int numericValue);
                validation = false;
            }
            while (nombreOk == false);
            nombre = Convert.ToInt32(stringNombre);
        }
        while (nombre < min || nombre > max);
        return nombre;
    }

    //vérifie qu'il y a assez de place pour planter sur la case sélectionnée par le joueur    
    public bool PouvoirPlanter(List<int[]> cases)
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


            //on regarde si la case en dessous existe, puis si elle est libre 
            if (elem[0] + Plante.espacement < Taille)
            {
                if (tableau[elem[0] + Plante.espacement, elem[1]] != "+") 
                {
                    espaceBas = false;
                }
            }

            //on regarde si la case au dessus existe, puis si elle est libre 
            if (elem[0] - Plante.espacement >= 0)
            {
                if (tableau[elem[0] - Plante.espacement, elem[1]] != "+")
                {
                    espaceHaut = false;
                }
            }

            //on regarde si la case à droite existe, puis si elle est libre 
            if (elem[1] + Plante.espacement < Taille)
            {
                if (tableau[elem[0], elem[1] + Plante.espacement] != "+")
                {
                    espaceDroite = false;
                }
            }

            //on regarde si la case à gauche existe, puis si elle est libre 
            if (elem[1] - Plante.espacement >= 0)
            {
                if (tableau[elem[0], elem[1] - Plante.espacement] != "+")
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


    //vérifie que les cases entrées par l'utilisateur soient alignées, virtual car seul le terrain argile n'a pas besoin de vérifier et retourne true (une seule case sera demandée à l'utilisateur)
    public virtual bool VerifierAlign(List<int[]> cases)
    {
        bool alignees = false;
        int ligneComp = (cases[0])[0];  //on prend la ligne de la 1e case pour comparer les suivantes, sera définie, car la méthode n'est appelée qu'une fois la liste contruite
        int colonneComp = (cases[0])[1];    //pareil pour colonnes

        bool memeLigne = cases.All(c => c[0] == ligneComp); //vrai si toutes les cases de la liste ont le même n° de ligne
        bool memeColonne = cases.All(c => c[1] == colonneComp); //vrai si toutes les cases de la liste ont le même n° de colonne

        //ou exclusif car si toutes les lignes et toutes les colonnes sont les mêmes, il n'y a qu'une seule case
        //si l'utilisateur a du entrer plusieurs cases, c'est que la plante en a besoin, donc le semis ne sera pas possible sinon
        if (memeLigne ^ memeColonne)
        {
            alignees = true;
        }

        return alignees;
    }
    public abstract void Semer();   //elle sera différente selon les terrains

    public void EnleverPlante(Plante plante)
    {
        foreach (int[] coord in plante.CoordPlante)
        {
            tableau[coord[0], coord[1]] = "+";  //on remet un + dans chaque case occupée par la plante
        }
        Plants.Remove(plante);

    }

    public Plante Cueillir()
    {
        int ligne;
        int colonne;
        Plante? cueillette = null;
        Console.WriteLine("Vous allez choisir les coordonnées de la plante que vous souhaitez cueillir.\nSi elle est plantée sur plusieurs cases, entrez les coordonnées d'une seule case, elle sera enlevée partout.");
        Console.WriteLine("Choisissez le numéro de la ligne sur laquelle vous souhaitez cueillir :");
        ligne = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la colonne sur laquelle vous souhaitez cueillir :");
        colonne = EtreEntier(1, Taille);

        int[] coord = new int[] { ligne - 1, colonne - 1};

        foreach (Plante plante in Plants)      //on regarde chaque plante du terrain
        {
            //si on la trouve, il n'y en a qu'une sur cette case donc on l'enlève et on la retourne pour la mettre dans un panier
            //if (plante.CoordPlante.Contains(coord))
            if (plante.CoordPlante.Any(c => c[0] == coord[0] && c[1] == coord[1]))
            {
                cueillette = plante;
            }
            /*else    //si on a rien trouvé, c'est qu'il n'y a pas de plante sur cette case
            {
                Console.WriteLine("Il n'y a pas de plante sur cette case");
            }*/

        }
        if (cueillette == null)
        {
            Console.WriteLine("Pas de plante sur cette case...");
        }
        else    //cueilette est forcément pas null car sinon, cueillie est false
        {
            EnleverPlante(cueillette);
            Console.WriteLine("La plante a été cueillie !");
        }

        return cueillette!;

    }

    public void Envoler()   //quand on a la tempête, on enlève une plante sur 2
    {
        for (int i = Plants.Count - 1; i >= 0; i--) //on commence par le dernier élément de la liste car dans l'autre sens si des éléments s'enlèvent, les index changent et on peut oublier des éléments
        {
            if (i % 2 == 0)
            {
                EnleverPlante(Plants[i]);
            }
        }
    }

    public void TomberMalade()  //obstacle d'urgence
    {
        foreach (Plante p in Plants)
        {
            p.ScoreGlobal = p.ScoreGlobal - p.EsperanceVie * 1 / 3; // chaque plante perd 1/3 de son score global initial
        }
    }

    public void Reconstruire()  //action d'urgence
    {
        for (int i = 0; i < 3; i++)     //on permet de planter 3 plantes 
        {
            Semer();
        }
    }

    public void DonnerPotion()  //action d'urgence
    {
        foreach (Plante p in Plants)
        {
            p.ScoreGlobal = p.ScoreGlobal + p.EsperanceVie * 1 / 4;     // la plante regagne 1/4 de son esperance de vie
        }
    }

    public void Fertiliser()    //bonne fee --> ver de terre
    {
        Console.WriteLine("Grâce aux vers de terre, votre terrain va être fertilisé et vos plantes rajeunissent !");
        foreach (Plante p in Plants)
        {
            p.ScoreGlobal = p.ScoreGlobal + p.EsperanceVie * 1 / 6;     
        }

    }


    //méthode virtual des bonnes fees
    public virtual void Fleurir()
    {
        Console.WriteLine("Grâce aux abeilles, votre terrain va fleurir");
    }


    //méthode obstacles
    public void DetruirePlante()
    {
        Console.WriteLine("A cause de piétineurs, une partie de vos plantes sont écrasées...");
        for (int i = Plants.Count - 1; i >= 0; i--)
        {
            if (i % 4 == 0)
            {
                EnleverPlante(Plants[i]);   //enlève une plante sur 4
            }
        }
    }

    public void MangerGraine()  
    {
        Console.WriteLine("Les oiseaux ont mangé toutes les graines de votre terrain :/ ...");
        for (int i = Plants.Count - 1; i >=0;i--)
        {
            if (Plants[i].etat == Plante.statutPlante.graine)
            {
                EnleverPlante(Plants[i]);   //enlève toutes les plantes sous forme de graine
            }
        }
    }

}