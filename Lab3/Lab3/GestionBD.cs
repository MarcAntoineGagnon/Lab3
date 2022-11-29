using Microsoft.UI.Xaml.Shapes;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace Lab3
{
    class GestionBD
    {
        static GestionBD gestionBD = null;
        MySqlConnection con;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1827906-marc-antoine-gagnon;Uid=1827906;Pwd=1827906;"); ;
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        //Commande Employe
        public ObservableCollection<Employe> getEmploye()
        {
            ObservableCollection<Employe> liste = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Employe(r.GetString(0), r.GetString(1), r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public ObservableCollection<Employe> getEmployeRecherche(string nom)
        {
            if (nom.Trim() == "")
            {
                return null;
            }
            
            ObservableCollection<Employe> liste = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select * from employe where nom like '%" + nom + "%'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Employe(r.GetString(0), r.GetString(1), r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterEmploye(Employe e)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values(@matricule, @nom, @prenom)";

                commande.Parameters.AddWithValue("@matricule", e.Matricule);
                commande.Parameters.AddWithValue("@nom", e.Nom);
                commande.Parameters.AddWithValue("@prenom", e.Prenom);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }
        }

        //Commande Projet
        public ObservableCollection<Projet> getProjet()
        {
            ObservableCollection<Projet> liste = new ObservableCollection<Projet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Projet(r.GetString(0), r.GetDateTime(1), r.GetInt32(2), r.GetString(3), r.GetString(4)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterProjet(Projet p)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select @nom and @prenom from employe;";
                commande.CommandText = "insert into projet values(@numero, @debut, @budget, @description, @employe)";

                commande.Parameters.AddWithValue("@numero", p.Numero);
                commande.Parameters.AddWithValue("@debut", p.Debut);
                commande.Parameters.AddWithValue("@budget", p.Budget);
                commande.Parameters.AddWithValue("@description", p.Description);
                commande.Parameters.AddWithValue("@employe", p.Employe);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }
        }
    }

}
