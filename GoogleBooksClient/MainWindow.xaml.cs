using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleBooksClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SuchButton_Click(object sender, RoutedEventArgs e)
        {
            Book[] books;
            try
            {
                books = BookSearchService.SearchBooks(tbSuchbegriff.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }

            listboxBuchanzeige.ItemsSource = books;
        }

        private void Favorite_Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.Tag is Book book)
            {
                if (book.IsFavorite)
                    FavoriteBookManager.RemoveFavoriteBook(book);
                else
                    FavoriteBookManager.AddFavoriteBook(book);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Hyperlink link)
            {
                Process.Start(link.NavigateUri.AbsoluteUri);
            }
        }

        private void Show_Favorites_Button_Click(object sender, RoutedEventArgs e)
        {
            if(FavoriteBookManager.FavoriteBooks.Count > 0)
            {
                listboxBuchanzeige.ItemsSource = FavoriteBookManager.FavoriteBooks;
            }
        }
    }
}
