using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using gesperLiaisonDonnées;



namespace gesperLinq2018
{
    delegate void RequeteLinq();
    public partial class FmReqLinq : Form
    {
        private List<RequeteLinq> lesRequetes;
        private Donnees bd;
        MySqlConnection Cnx;
        string sCnx;
        
        public FmReqLinq()
        {
            InitializeComponent();
            lesRequetes = new List<RequeteLinq>();
            listerRequetes();
            bd = new Donnees();
            // connexion à la base de données
            sCnx = "server=localhost;uid=root;database=gespertds;port=3306;pwd=siojjr";
            //création d'un objet connexion
            try
            {
                Cnx = new MySqlConnection(sCnx);
                Cnx.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            bd.ToutCharger(Cnx);

        }
        private void listerRequetes()
        {
            ccbReq.Items.Add("Requête 0 : liste des noms des  employés");
            lesRequetes.Add(requete0);
            ccbReq.Items.Add("Requête 1 : liste des noms et prénoms des employés");
            lesRequetes.Add(requete1);
            ccbReq.Items.Add("Requête 2 : service des employés");
            lesRequetes.Add(requete2);
            ccbReq.Items.Add("Requête 3 : nom des employés et désignation de leur service");
            lesRequetes.Add(requete3);
            ccbReq.Items.Add("Requête 4 : nom des employés et désignation de leur service avec un type anonyme");
            lesRequetes.Add(requete4);
            ccbReq.Items.Add("Requête 5 : nom et prénom des employés masculins");
            lesRequetes.Add(requete5);
            ccbReq.Items.Add("Requête 6 : nom et prénom des employés masculins gagnant plus de 3000€");
            lesRequetes.Add(requete6);
            ccbReq.Items.Add("Requête 7 : nom et prénom des employés du service commercial");
            lesRequetes.Add(requete7);
            ccbReq.Items.Add("Requête 8 : nom et prénom des employés cadres");
            lesRequetes.Add(requete8);
            ccbReq.Items.Add("Requête 9 : nom et prénom des employés dont le nom contient 'du'  (contains)");
            lesRequetes.Add(requete9);
            ccbReq.Items.Add("Requête 10 : nom et prénom des employés travaillant dans un atelier (StartsWith)");
            lesRequetes.Add(requete10);
            ccbReq.Items.Add("Requête 11 : liste des services productifs (ofType)");
            lesRequetes.Add(requete11);
            ccbReq.Items.Add("Requête 12 : employés masculins triés par nom (orderby)");
            lesRequetes.Add(requete12);
            ccbReq.Items.Add("Requête 13 : employés masculins triés par longueur de prénom (Length)");
            lesRequetes.Add(requete13);
            ccbReq.Items.Add("Requête 14 : employés triés par sexe et prénom");
            lesRequetes.Add(requete14);
            ccbReq.Items.Add("Requête 15 : nombre d'employés");
            lesRequetes.Add(requete15);
            ccbReq.Items.Add("Requête 16 : nombre de cadres (expression lambda)");
            lesRequetes.Add(requete16);
            ccbReq.Items.Add("Requête 17 : salaire maximum, plus petit nom et salaire moyen");
            lesRequetes.Add(requete17);
            ccbReq.Items.Add("Requête 18 : masse salariale des cadres");
            lesRequetes.Add(requete18);
            ccbReq.Items.Add("Requête 19 : effectifs par diplômes");
            lesRequetes.Add(requete19);
            ccbReq.Items.Add("Requête 20 : nom des employés qui possèdent un bts avec une jointure");
            lesRequetes.Add(requete20);
            ccbReq.Items.Add("Requête 21 : nom des employés avec la désignation de leur service, ou non affecté");
            lesRequetes.Add(requete21);
            ccbReq.Items.Add("Requête 22 : effectifs des services (group ... by)");
            // lesRequetes.Add(requete22);
            ccbReq.Items.Add("Requête 23 : salaire moyen des services");
            // lesRequetes.Add(requete23);
            ccbReq.Items.Add("Requête 24 : salaire maximum des employés masculins par service employant plus d'un homme");
            // lesRequetes.Add(requete24);
            ccbReq.Items.Add("Requête 25 : employés gagnant plus que l'employé n° 1");
            // lesRequetes.Add(requete25);
            ccbReq.Items.Add("Requête 26 : employés gagnant plus la moyenne des salaires du service n° 1");
            // lesRequetes.Add(requete26);
            ccbReq.Items.Add("Requête 27 : employés gagnant plus la moyenne des salaires de leur service");
            // lesRequetes.Add(requete27);
            ccbReq.Items.Add("Requête 28 : service employant des personnes non diplomées");
            // lesRequetes.Add(requete28);
            ccbReq.Items.Add("Requête 29 : employés de sexe féminin ou travaillant dans un atelier (union)");
            // lesRequetes.Add(requete29);
            ccbReq.Items.Add("Requête 30 : liste des femmes ne travaillant pas dans un atelier (différence)");
            // lesRequetes.Add(requete30);
            ccbReq.Items.Add("Requête 31 : liste des femmes ne travaillant dans un atelier (intersection)");
            // lesRequetes.Add(requete31);
        }
        private void requete0()
        {
            rtbResultat.AppendText("liste des noms des  employés");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      select emp.Nom;
            foreach (string nom in req)
            {
                rtbResultat.AppendText(nom);
                rtbResultat.AppendText(Environment.NewLine);
            }

        }
        private void requete1()
        {
            rtbResultat.AppendText("liste des noms et prenoms des  employés");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Identite);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }
        private void requete2()
        {
            rtbResultat.AppendText("désignations des services des  employés");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      select emp.LeService;
            foreach (Service S in req.Distinct())
            {
                rtbResultat.AppendText(S.Designation);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete3()
        {
            rtbResultat.AppendText("nom des employés et désignation de leur service");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Nom+" travaille au service " + E.LeService.Designation);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete4()
        {
            rtbResultat.AppendText("nom des employés et désignation de leur service avec un type anonyme");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      select new { leNom = emp.Nom, laDesignation = emp.LeService.Designation };
            foreach (var resultat in req)
            {
                rtbResultat.AppendText(resultat.leNom + " travaille au service " + resultat.laDesignation);
                rtbResultat.AppendText(Environment.NewLine);  
            }
        }

        private void requete5()
        {
            rtbResultat.AppendText("nom et prénom des employés masculins");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Sexe == 'M'
                      select new { leNom = emp.Nom, lePrenom = emp.Prenom };
            foreach (var resultat in req)
            {
                rtbResultat.AppendText(resultat.leNom + resultat.lePrenom);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete6()
        {
            rtbResultat.AppendText("nom et prénom des employés masculins gagnant plus de 3000€");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Sexe == 'M'
                      where emp.Salaire > 3000 
                      select new { leNom = emp.Nom, lePrenom = emp.Prenom, leSalaire = emp.Salaire };
            foreach (var resultat in req)
            {
                rtbResultat.AppendText(resultat.leNom + " " + resultat.lePrenom + " gagne " + resultat.leSalaire);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete7()
        {
            rtbResultat.AppendText("nom et prénom des employés du service commercial");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from ser in bd.LesServices
                      where ser.Designation == "Commercial"
                      select ser;
            foreach (Service S in req)
            {
                foreach(Employe E in S.LesEmployesDuService)
                {
                    rtbResultat.AppendText(E.Nom + " " + E.Prenom);
                    rtbResultat.AppendText(Environment.NewLine);
                }
            }
        }

        private void requete8()
        {
            rtbResultat.AppendText("nom et prénom des employés cadres");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Cadre == 1
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Nom + " " + E.Prenom + " est cadre");
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete9()
        {
            rtbResultat.AppendText("nom et prénom des employés dont le nom contient 'du' (contains)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Nom.Contains("Du")
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Nom + " " + E.Prenom);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete10()
        {
            rtbResultat.AppendText("nom et prénom des employés travaillant dans un atelier (StartsWith)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from ser in bd.LesServices
                      where ser.Designation.StartsWith("Atelier")
                      select ser;
            foreach (Service S in req)
            {
                foreach(Employe E in S.LesEmployesDuService)
                {
                    rtbResultat.AppendText(E.Nom + " " + E.Prenom);
                    rtbResultat.AppendText(Environment.NewLine);
                }
            }
        }

        private void requete11()
        {
            rtbResultat.AppendText("liste des services productifs (ofType)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from ser in bd.LesServices
                      where ser.Type.ToString() == "P"
                      select ser;
            foreach (Service S in req)
            {
                rtbResultat.AppendText(S.ToString());
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete12()
        {
            rtbResultat.AppendText("employés masculins triés par nom (orderby)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Sexe == 'M'
                      orderby emp.Nom
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Nom);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete13()
        {
            rtbResultat.AppendText("employés masculins triés par longueur de prénom (Length)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      where emp.Sexe.ToString() == "M"
                      orderby emp.Prenom.Length
                      select new { lePrneom = emp.Prenom };
            foreach (var resultat in req)
            {
                rtbResultat.AppendText(resultat.lePrneom);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete14()
        {
            rtbResultat.AppendText("employés triés par sexe et prénom");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      orderby emp.Sexe, emp.Prenom
                      select emp;
            foreach (Employe E in req)
            {
                rtbResultat.AppendText(E.Prenom);
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete15()
        {
            rtbResultat.AppendText("nombre d'employés");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = (from emp in bd.LesEmployes
                       select emp).Count();
            rtbResultat.AppendText("Il y a " + req + " employés.");
            rtbResultat.AppendText(Environment.NewLine);
        }


        private void requete16()
        {
            rtbResultat.AppendText("nombre de cadres (expression lambda)");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            int nb = bd.LesEmployes.Count(emp => emp.Cadre == 1);
            rtbResultat.AppendText("Il y a " + Convert.ToString(nb) + " cadres.");
            rtbResultat.AppendText(Environment.NewLine);
        }

        private void requete17()
        {
            rtbResultat.AppendText("salaire maximum, plus petit nom et salaire moyen");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var salMax = (from emp in bd.LesEmployes
                          select emp.Salaire).Max();

            var salMoy = (from emp in bd.LesEmployes
                         select emp.Salaire).Average();

            var nomMin = (from emp in bd.LesEmployes
                          select emp.Nom.Length).Min();

            var req = from emp in bd.LesEmployes
                      where emp.Nom.Length == nomMin
                      select emp.Nom;

            rtbResultat.AppendText("Le salaire maximum est " + salMax + ".\nLe salaire moyen est " + salMoy + ".");

            foreach (var resultat in req)
            {
                rtbResultat.AppendText("\nLe plus petit nom est " + resultat + ".");
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete18()
        {
            rtbResultat.AppendText("masse salariale des cadres");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = (from emp in bd.LesEmployes
                       where emp.Cadre == 1
                       select emp.Salaire).Sum();
            
            rtbResultat.AppendText("La masse salariale des cadres équivaut à " + req + " euros.");
            rtbResultat.AppendText(Environment.NewLine);
        }

        private void requete19()
        {
            rtbResultat.AppendText("effectifs par diplômes");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from dip in bd.LesDiplomes
                         select dip;
            foreach(var resultat in req)
            {
                rtbResultat.AppendText("Il y a " + resultat.LesEmployes.Count() + " empoyés qui ont un(e) " + resultat.Libelle + ".");
                rtbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete20()
        {
            rtbResultat.AppendText("nom des employés qui possèdent un bts avec une jointure");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from dip in bd.LesDiplomes
                      where dip.Id == 2
                      select dip;
            foreach(Diplome D in req)
            {
                foreach(Employe E  in D.LesEmployes)
                {
                    rtbResultat.AppendText(E.Nom + " possède un bts.");
                    rtbResultat.AppendText(Environment.NewLine);
                }
            }
        }

        private void requete21()
        {
            rtbResultat.AppendText("nom des employés avec la désignation de leur service, ou non affecté");
            rtbResultat.AppendText(Environment.NewLine);
            rtbResultat.AppendText(Environment.NewLine);
            var req = from emp in bd.LesEmployes
                      join ser in bd.LesServices on emp.Id equals ser.Id
                      select emp;
            foreach(Employe E in req)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ccbReq.SelectedIndex != -1)
            {
                rtbResultat.Clear();
                lesRequetes[ccbReq.SelectedIndex]();
            }
        }
    }
}
