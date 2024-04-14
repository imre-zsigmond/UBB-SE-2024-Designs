using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_lab4_post_options
{
    /// <summary>
    /// Interaction logic for PostOptions.xaml
    /// </summary>
    public partial class PostOptions : Window
    {
        public PostOptions()
        {
            InitializeComponent();
            string userType = "Admin";
            string userID = "1234";
            string postUserId = "1244";
            
            if(userID != postUserId)
            {
                postOptions.RowDefinitions.Remove(deletePostRow);
            }
        }

        private void addToFavouritesButton_Click(object sender, RoutedEventArgs e)
        {
            // We can have for each user a list of favourites and add the post to that list
        }

        private void hidePostButton_Click(object sender, RoutedEventArgs e)
        {
            //Here, we would access the post element and basically rmeove it using code
        }

        private void addToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // We can have for each user a cart(list) and add the post to that list
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