using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoogleBooksClient
{
    public class FavoriteBookManager
    {
        public static ObservableCollection<Book> FavoriteBooks;

        //Statischer Konstruktor
        static FavoriteBookManager()
        {
            FavoriteBooks = new ObservableCollection<Book>();

            //Bücher laden
            if (!File.Exists(Favorite_Books_Filename))
                return;

            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = new FileStream(Favorite_Books_Filename, FileMode.Open))
            {
                try
                {
                    FavoriteBooks = (ObservableCollection<Book>)serializer.Deserialize(stream);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        const string Favorite_Books_Filename = "FavoriteBooks.fb";

        public static void AddFavoriteBook(Book book)
        {
            book.IsFavorite = true;
            FavoriteBooks.Add(book);

            //In Datei speichern
            SaveBooks();
        }

        public static void RemoveFavoriteBook(Book bookToRemove)
        {
            bookToRemove.IsFavorite = false;
            if (FavoriteBooks.Any(book => book.id == bookToRemove.id))
            {
                FavoriteBooks.Remove(bookToRemove);
                SaveBooks();
            }
        }

        public static void SaveBooks()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = new FileStream(Favorite_Books_Filename, FileMode.Create))
            {
                try
                {
                    serializer.Serialize(stream, FavoriteBooks);
                }

                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
    }
}