using System.Collections.Generic;
using System;
using monopoly.monopoly.cases;

namespace monopoly
{
    public class Plateau
    {
        public List<Case> cases;
        private Dictionary<Couleur, List<Terrain>> groupesTerrains;
        private List<Gare> gares;
        private List<Compagnie> compagnies;

        public Plateau()
        {
            cases = new List<Case>();
            groupesTerrains = new Dictionary<Couleur, List<Terrain>>();
            gares = new List<Gare>();
            compagnies = new List<Compagnie>();

            groupesTerrains.Add(Couleur.Bleu, new List<Terrain>());
            groupesTerrains.Add(Couleur.Cyan, new List<Terrain>());
            groupesTerrains.Add(Couleur.Jaune, new List<Terrain>());
            groupesTerrains.Add(Couleur.Marron, new List<Terrain>());
            groupesTerrains.Add(Couleur.Orange, new List<Terrain>());
            groupesTerrains.Add(Couleur.Rose, new List<Terrain>());
            groupesTerrains.Add(Couleur.Rouge, new List<Terrain>());
            groupesTerrains.Add(Couleur.Vert, new List<Terrain>());

            //TODO: Creer toutes les cases
            AjouterCase(new Depart());
            //============
            AjouterCase(new Terrain("Boulevard de Belleville", 60, 2 ,Couleur.Marron, this, 50));
            //==================
            
            
            //Console.WriteLine("nb groupes terrains Marron : " + groupesTerrains[Couleur.Marron].Count);
            AjouterCase(new Vide("Casse de Communauté"));
            AjouterCase(new Terrain("Rue Lecourbe", 60, 2, Couleur.Marron, this, 50));

            

            AjouterCase(new Impots("Impôts sur le revenu", 200));
            AjouterCase(new Gare("Gare Montparnasse", this));
            AjouterCase(new Terrain("Rue de Vaugirard", 100, 2, Couleur.Cyan, this, 50));
            AjouterCase(new Vide("Chance"));
            AjouterCase(new Terrain("Rue de Courcelles", 100, 2, Couleur.Cyan, this, 50));
            AjouterCase(new Terrain("Avenue de la république", 120, 2, Couleur.Cyan, this, 50));
            AjouterCase(new Vide("Simple visite"));
            AjouterCase(new Terrain("Boulevard de la villette", 140, 2, Couleur.Rose, this, 100));
            AjouterCase(new Compagnie("Compagnie de distribution d'électricité", this));
            AjouterCase(new Terrain("Avenue de Neuilly", 140, 2, Couleur.Rose, this, 100));
            AjouterCase(new Terrain("Rue de Paradis", 160, 2, Couleur.Rose, this, 100));
            AjouterCase(new Gare("Gare de Lyon", this));
            AjouterCase(new Terrain("Avenue Mozart", 180, 2, Couleur.Orange, this, 100));
            AjouterCase(new Vide("Caisse de communauté"));
            AjouterCase(new Terrain("Boulevard Saint-Michel", 180, 2, Couleur.Orange, this, 100));
            AjouterCase(new Terrain("Place Pigalle", 200, 2, Couleur.Orange, this, 100));
            AjouterCase(new Vide("Parc Gratuit"));
            AjouterCase(new Terrain("Avenue Matignon", 220, 2, Couleur.Rouge, this, 150));
            AjouterCase(new Vide("Chance"));
            AjouterCase(new Terrain("Boulevard Malesherbes", 220, 2, Couleur.Rouge, this, 150));
            AjouterCase(new Terrain("Avenue Henri-Martin", 240, 2, Couleur.Rouge, this, 150));
            AjouterCase(new Gare("Gare du Nord", this));
            AjouterCase(new Terrain("Faubourg Saint-Honoré", 260, 2, Couleur.Jaune, this, 150));
            AjouterCase(new Terrain("Place de la bourse", 260, 2, Couleur.Jaune, this, 150));
            AjouterCase(new Compagnie("Compagnie de distribution des eaux", this));
            AjouterCase(new Terrain("Rue de la Fayette", 280, 2, Couleur.Jaune, this, 150));
            AjouterCase(new Vide("Allez en prison"));

            AjouterCase(new Terrain("Avenue de Breteuil", 300, 2, Couleur.Vert, this, 200));
            AjouterCase(new Terrain("Avenue de Foch", 300, 2, Couleur.Vert, this, 200));
            AjouterCase(new Vide("Allez en prison"));
            AjouterCase(new Terrain("Boulevard des Capucines", 320, 2, Couleur.Vert, this, 200));
            AjouterCase(new Gare("Gare Saint-Lazare", this));
            AjouterCase(new Vide("Chance"));
            AjouterCase(new Terrain("Avenue des Champs-Élysées", 350, 2, Couleur.Bleu, this, 200));
            AjouterCase(new Impots("Taxe de Luxe", 100));
            AjouterCase(new Terrain("Rue de la Paix", 400, 2, Couleur.Bleu, this, 200));


            //AfficherLePlateau();
        }

        /// <summary>
        /// Affiche au joueur les cases et les couleurs des cases sur lesquelles il peut construire.
        /// </summary>
        internal Terrain AfficheCasesConstructiblesEtChoixTerrain(Joueur j)
        {
            List<Couleur> _couleursConstructibles = GetCouleursConstructible(j);
            if (_couleursConstructibles.Count == 0)
            {
                Console.WriteLine("Vous ne pouvez pas construire de maisons pour le moment.");
                return null;
            }
            else
            {
                int indiceTerrain = 0; //Un indice sur chaque terrain qui permettra au joueur de choisir où construire

                List<Terrain> _terrainsConstructibles = GetTerrainsConstructible(j, _couleursConstructibles);
                foreach (var _couleur in _couleursConstructibles)
                {
                    Console.WriteLine($"Dans le groupe {_couleur} : ");
                    foreach (var _terrain in _terrainsConstructibles)
                    {
                        indiceTerrain++;
                        Console.WriteLine($"{indiceTerrain} : {_terrain.nom} qui a déjà {_terrain.maisonsConstruites} maisons.");
                    }
                    Console.WriteLine("---");
                }

                Console.WriteLine("Indiquez le numéro du terrain sur lequel vous voulez construire, et 0 si vous ne voulez pas construire.");
                //TODO : gestion d'erreur si le choix donné n'est pas un entier.
                int choixTerrain = Convert.ToInt32(Console.ReadLine().ToLower());
                if (!(choixTerrain <= 0 && choixTerrain > _terrainsConstructibles.Count))
                {
                    return _terrainsConstructibles[choixTerrain - 1];
                }
                else
                {
                    Console.WriteLine("Veuillez indiquer un nombre correspondant aux indices donnés plus haut.");
                    return null;
                }
            }
        }

        /// <summary>
        /// Renvoie la liste des terrains dans lesquelles le joueur peut construire des maisons
        /// </summary>
        /// <param name="j"></param>
        /// <param name="couleursConstructibles"></param>
        /// <returns></returns>
        private List<Terrain> GetTerrainsConstructible(Joueur j, List<Couleur> couleursConstructibles)
        {
            List<Terrain> _terrainsConstructibles = new List<Terrain>();

            foreach (KeyValuePair<Couleur, List<Terrain>> _colorAndTerrain in groupesTerrains)
            {
                //Pas la peine de regarder les terrains s'ils ne font pas partie des couleurs repérées.
                if (couleursConstructibles.Contains(_colorAndTerrain.Key)) 
                {
                    //Les terrains de la couleur observées
                    foreach (Terrain _terrain in groupesTerrains[_colorAndTerrain.Key])
                    {
                        //Si le terrain est à l'état constructible et que j en est le proprio.
                        if (typeof(EtatConstructible).IsInstanceOfType(_terrain.etat) && _terrain.proprietaire == j)
                        {
                            
                            _terrainsConstructibles.Add(_terrain);
                        }
                    }
                }
            }
            return _terrainsConstructibles;
        }

        /// <summary>
        /// Renvoie une liste de couleur contenant les couleurs dans lesquelles j peut construire des maisons.
        /// </summary>
        /// <param name="j"></param>
        private List<Couleur> GetCouleursConstructible(Joueur j)
        {
            List<Couleur> _couleurConstructibles = new List<Couleur>();
            foreach (KeyValuePair<Couleur, List<Terrain>> _colorAndTerrain in groupesTerrains)
            {
                //Console.WriteLine($"clé : {_colorAndTerrain.Key} ... valeur : {_colorAndTerrain.Value[0]}");
                Couleur _couleur = _colorAndTerrain.Key;

                //Console.WriteLine($"Vous pouvez construire sur des terrains des couleurs suivantes :");
                if (typeof(EtatConstructible).IsInstanceOfType(_colorAndTerrain.Value[0].etat) && _colorAndTerrain.Value[0].proprietaire == j)
                {
                    _couleurConstructibles.Add(_couleur);
                }
            }
            return _couleurConstructibles;
        }

        //
        internal bool VerifCompagniesPossedeesPar(Joueur joueur)
        {
            bool sontPossedeesParJoueur = true;

            foreach (Compagnie _compagnie in compagnies)
            {
                if (_compagnie.proprietaire != joueur)
                {
                    sontPossedeesParJoueur = false;
                }
            }
            return sontPossedeesParJoueur;
        }


        /// <summary>
        /// Vérifie que tous les terrains de la même couleur ont le même propriétaire.
        /// Passe les terrains à l'état constructible si c'est le cas.
        /// </summary>
        /// <param name="couleur"></param>
        public void SwitchConstructible(Couleur couleur)
        {
            bool toSwitch = true;
            Joueur proprio = null;

            //Verifie que les terrains sont achetes par le meme proprio
            foreach (var _terrain in groupesTerrains[couleur])
            {
                if (!typeof(EtatAchete).IsInstanceOfType(_terrain.etat))
                {
                    toSwitch = false;
                } else {
                    if (proprio == null) {
                        proprio = _terrain.proprietaire;
                    }
                    else
                    {
                        if (proprio != _terrain.proprietaire) {
                            toSwitch = false;
                        }
                        proprio = _terrain.proprietaire;
                    }
                }
            }
            if (toSwitch)
            {
                foreach (var _terrain in groupesTerrains[couleur])
                {
                    _terrain.etat = new EtatConstructible();
                    Console.WriteLine("SWITCHAROOOOOO");
                }
            }
        }   

        /// <summary>
        /// Vérifie les autres terrains de couleur pour voir s'il sont tous possédé par j
        /// </summary>
        /// <param name="_couleur"></param>
        /// <param name="_j"></param>
        /// <param name="_terrainActuel"></param>
        internal bool VerifAutreTerrainPossedeGroupe(Couleur _couleur, Joueur _j, Terrain _terrainActuel)
        {
            bool result = true;
            foreach (var _terrain in groupesTerrains[_couleur])
            {
                if (_terrain.proprietaire != _j && _terrain != _terrainActuel)
                {
                    result = false;
                }
            }
            return result;
        }

        private void AfficherLePlateau()
        {
            Case _first = cases[0];
            Case _current = _first.GetCaseSuivante();

            Console.WriteLine(_first);

            while (_current != _first)
            {
                Console.WriteLine(_current);
                _current = _current.GetCaseSuivante();
            }
        }

        private void AjouterCase(Case c)
        {
            if (typeof(Terrain).IsInstanceOfType(c))
            {
                if (groupesTerrains.ContainsKey(((Terrain) c).GetCouleur()))
                {
                    groupesTerrains[((Terrain) c).GetCouleur()].Add((Terrain) c);
                }
                else
                {
                    throw new Exception();
                }
            }
            if (typeof(Gare).IsInstanceOfType(c))
            {       
                gares.Add((Gare) c);
            }
            if (typeof(Compagnie).IsInstanceOfType(c))
            {
                compagnies.Add((Compagnie) c);
            }

            cases.Add(c);
            c.SetCaseSuivante(cases[0]); //la case suivante est toujours la case départ quand on ajouter à la fin de la liste

            //La case précédente doit pointer sur la nouvelle.
            if (cases.Count > 1)
            {
                cases[cases.Count - 2].SetCaseSuivante(c);
            }
        }

        public Case GetDepart()
        {
            foreach (Case c in cases)
            {
                if (typeof(Depart).IsInstanceOfType(c))
                {
                    return c;
                }
            }
            return null;
        }

        public Case GetPrison()
        {
            foreach (Case c in cases)
            {
                if (typeof(Prison).IsInstanceOfType(c))
                {
                    return c;
                }
            }
            return null;
        }

        public int NombreGaresPourJoueur(Joueur j)
        {
            int nb = 0;
            foreach(Gare _gare in gares)
            {
                if (_gare.PossedeePar(j))
                {
                    ++nb;
                }
            }
            return nb;
        }


        public bool PossedeGroupeCouleur(Joueur j, Couleur c)
        {
            foreach(Terrain t in groupesTerrains[c])
            {
                if (!t.PossedeePar(j))
                {
                    return false;
                }
            }
            return true;
        }
    }
}