using ISSLab.ViewModel;
using System;
using System.Collections.Generic;
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

namespace ISSLab.View
{
    /// <summary>
    /// Interaction logic for PostOptionControl.xaml
    /// </summary>
    public partial class PostOptionControl : UserControl
    {
        public PostOptionControl()
        {
            InitializeComponent();
            string userType = "Admin";
            string userID = "1234";
            string postUserId = "1244";
            if (userID != postUserId)
            {
                postOptions.RowDefinitions.Remove(deletePostRow);
            }
        }

        private void addToFavouritesButton_Click(object sender, RoutedEventArgs e)
        {
            // We can have for each user a list of favourites and add the post to that list
            this.DataContext.GetType().GetMethod("AddPostToFavorites").Invoke(this.DataContext, null);
        }

        private void hidePostButton_Click(object sender, RoutedEventArgs e)
        {
            //Here, we would access the post element and basically rmeove it using code
            this.DataContext.GetType().GetProperty("Visible").SetValue(this.DataContext, "Collapsed");
        }

        private void addToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // We can have for each user a cart(list) and add the post to that list
            this.DataContext.GetType().GetMethod("AddPostToCart").Invoke(this.DataContext, null);
        }

        private void reportPostButton_Click(object sender, RoutedEventArgs e)
        {
            // again, for each user or post(post might be better) a field of "reports" and just increment that field
        }

        private void deletePostButton_Click(object sender, RoutedEventArgs e)
        {
            // again, we could have a list the user's own posts and delete the post from the list
        }
    }
}
