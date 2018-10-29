using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleBooksClient
{
    //Autogeneriert durch Edit->Paste Special->Paste from JSON
    public class BookSearchResult
    {
        [JsonProperty("items")]
        public Book[] Books { get; set; }
    }

    [Serializable]
    public class Book : INotifyPropertyChanged, ISerializable
    {
        private bool _isFavorite = false;
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            set
            {
                _isFavorite = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFavorite)));
            }
        }
        public string id { get; set; }
        public Volumeinfo volumeInfo { get; set; }

        //Achtung: Events können nicht serialisiert werden, nur Delegate-Variablen
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        
        //Ladevorgang (Deserialiserung)
        protected Book(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetString("id");
            this.volumeInfo = info.GetValue("volumeInfo", typeof(Volumeinfo)) as Volumeinfo;
            _isFavorite = true;
        }
        
        //Speichervorgang (Serialisierung)
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        { 
            info.AddValue("id", id);
            info.AddValue("volumeInfo", volumeInfo, typeof(Volumeinfo));
        }
    }

    [Serializable]
    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string previewLink { get; set; }
    }

    [Serializable]
    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }
}
