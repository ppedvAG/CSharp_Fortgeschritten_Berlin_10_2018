using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{

    public class SyncTree<KnotenType> where KnotenType : ISyncronizable, IHasChildren<KnotenType>, INotifyPropertyChanged
    {
        public SyncTree(KnotenType wurzel)
        {
            Wurzel = wurzel;
        }

        public void Add(KnotenType newItem, KnotenType parent = default)
        {
            if (parent == default)
            {
                Wurzel.Children.Add(newItem);
            }
            else
            {
                parent.Children.Add(newItem);
            }

            //Synchronisierung vorbereiten
            newItem.PropertyChanged += (sender, args) =>
            {
                
                var syncProperties = parent.GetType().GetProperties().Where(propertyInfo =>
                {
                    var attributes = propertyInfo.GetCustomAttributes(typeof(SyncPropertyAttribute), false);
                    return attributes.Length > 0;
                });
                string changedPropertyName = args.PropertyName;

                if(syncProperties.Any(property => property.Name == changedPropertyName))
                {
                    parent.Synchronize();
                    Console.WriteLine("Syncronisierung!");
                }
            };

            //Wichtig, damit direkt nach Hinzufügen des neuen Elements die
            //Synchronisierung angestoßen wird
            parent.Synchronize();
        }

        public KnotenType Wurzel { get; set; }


        //TODO: Wie viele KinderKnoten hat ein Knoten (rekursiv)
        public List<KnotenType> FindeKnoten(Func<KnotenType, bool> suchKriterium, KnotenType startKnoten = default)
        {
            if (startKnoten == default)
                startKnoten = Wurzel;

            List<KnotenType> trefferListe = new List<KnotenType>();
            if (suchKriterium(startKnoten))
            {
                trefferListe.Add(startKnoten);
            }
            foreach (var child in startKnoten.Children)
            {
                trefferListe.AddRange(FindeKnoten(suchKriterium, child));
            }
            return trefferListe;
        }
    }
}
