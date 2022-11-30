using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Projet : IEquatable<Projet>, INotifyPropertyChanged
    {
        string numero;
        DateTime debut;
        int budget;
        string description;
        string employe;
   
      

        public Projet(string numero, DateTime debut, int budget, string description, string employe)
        {
            this.numero = numero;
            this.debut = debut;
            this.budget = budget;
            this.description = description;
            this.employe = employe;
        }


        public string Numero
        {
            get { return numero; }
            set{numero = value; this.OnPropertyChanged(); }
        }

        public DateTime Debut
        {
            get { return debut; }
            set { debut = value; this.OnPropertyChanged(); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; this.OnPropertyChanged(); }
        }
        
        public int Budget
        {
            get { return budget; }
            set { budget = value; this.OnPropertyChanged(); }
        }

        public string Employe
        {
            get { return employe; }
            set { employe = value; this.OnPropertyChanged(); }
        }

        public object Nom { get; internal set; }

        bool IEquatable<Projet>.Equals(Projet other)
        {
            if( this.numero.Equals(other.numero) && this.debut.Equals(other.debut) && this.description.Equals(other.description) && this.budget.Equals(other.budget) && this.employe.Equals(other.employe))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return numero + " " + debut + " " + description + " " + budget + " " + employe;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
