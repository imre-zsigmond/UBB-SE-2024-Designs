using ISSLab.Model;
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
    /// Interaction logic for PostContent.xaml
    /// </summary>
    public partial class PostContent : UserControl
    {


        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty UsernameProperty =  DependencyProperty.Register("Username", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty MediaProperty = DependencyProperty.Register("Media", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty ProfilePictureProperty = DependencyProperty.Register("ProfilePicture", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty TimePostedProperty = DependencyProperty.Register("TimePosted", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty AvailableForProperty  = DependencyProperty.Register("AvailableFor", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty InterestsProperty = DependencyProperty.Register("Interests", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty UninterestsProperty = DependencyProperty.Register("Uninterests", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty CommentsProperty = DependencyProperty.Register("Comments", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty ContactProperty = DependencyProperty.Register("Contact", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty DeliveryProperty = DependencyProperty.Register("Delivery", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register("Visible", typeof(string), typeof(PostContent));

        public static readonly DependencyProperty DonationButtonVisibleProperty = DependencyProperty.Register("DonationButtonVisible", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty BuyButtonVisibleProperty = DependencyProperty.Register("BuyButtonVisible", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty BidButtonVisibleProperty = DependencyProperty.Register("BidButtonVisible", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty BidPriceVisibleProperty = DependencyProperty.Register("BidPriceVisible", typeof(string), typeof(PostContent));
        public static readonly DependencyProperty BidPriceProperty = DependencyProperty.Register("BidPrice", typeof(string), typeof(PostContent));
        public String DonationButtonVisible
        {
            get { return (String)GetValue(DonationButtonVisibleProperty); }
            set {SetValue(VisibleProperty, value);  }

        }

        public String BuyButtonVisible
        {
            get { return (String)GetValue(DonationButtonVisibleProperty); }
            set { SetValue(VisibleProperty, value); }

        }

        public string BidButtonVisible
        {
            get { return (String)GetValue(BidButtonVisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public string BidPriceVisible
        {
            get { return (String)GetValue(BidPriceVisibleProperty); }
            set { SetValue(VisibilityProperty, value); }
        }

        public String BidPrice
        {
            get { return (String)GetValue(BidPriceProperty); }
            set { SetValue(BidPriceProperty, value); }
        }
        public static readonly DependencyProperty RatingProperty = DependencyProperty.Register("Rating", typeof(float), typeof(PostContent));


        public String Title
        {
            get { return (String)GetValue(TitleProperty); } 
            set { SetValue(TitleProperty, value);}
        }
        public float Rating
        {
            get { return (float)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        public String Username
        {
            get { return (String)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public String Media
        {
            get { return (String)GetValue(MediaProperty); }
            set { SetValue(MediaProperty, value); }
        }
        public String Location
        {
            get { return (String)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
        public String ProfilePicture
        {
            get { return (String)GetValue(ProfilePictureProperty); }
            set { SetValue(ProfilePictureProperty, value); }
        }
        public String TimePosted
        {
            get { return (String)GetValue(TimePostedProperty); }
            set { SetValue(TimePostedProperty, value); }
        }
        public String AvailableFor
        {
            get { return (String)GetValue(AvailableForProperty); }
            set { SetValue(AvailableForProperty, value); }
        }
        public String Price
        {
            get { return (String)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public String Interests
        {
            get { return (String)GetValue(InterestsProperty); }
            set { SetValue(InterestsProperty, value); }
        }
        public String Uninterests
        {
            get { return (String)GetValue(UninterestsProperty); }
            set { SetValue(UninterestsProperty, value); }
        }
        public String Comments
        {
            get { return (String)GetValue(CommentsProperty); }
            set { SetValue(CommentsProperty, value); }
        }

        public String Description
        {
            get { return (String)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public String Contact
        {
            get { return (String)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        public String Delivery
        {
            get { return (String)GetValue(DeliveryProperty); }
            set { SetValue(DeliveryProperty, value); }
        }

        public String Visible
        {
            get { return (String)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }


        public event EventHandler MoreButtonClicked;
        public event EventHandler OptionsButtonClicked;
        public PostContent()
        {

            InitializeComponent();
            if(this.Rating < 2)
            {
                this.star2.Visibility = Visibility.Collapsed;
                this.star3.Visibility = Visibility.Collapsed;
                this.star4.Visibility = Visibility.Collapsed;
                this.star5.Visibility = Visibility.Collapsed;

            }
            else
                if(this.Rating < 3)
            {
                this.star3.Visibility = Visibility.Collapsed;
                this.star4.Visibility = Visibility.Collapsed;
                this.star5.Visibility = Visibility.Collapsed;
            }
            else
                if(this.Rating < 4)
            {
                this.star4.Visibility = Visibility.Collapsed;
                this.star5.Visibility = Visibility.Collapsed;
            }
            else
                if(this.Rating < 5)
            {
                this.star5.Visibility = Visibility.Collapsed;
            }
        }

        private void OnMoreButtonClick(object sender, RoutedEventArgs e)
        {
            if (GridOptions.IsVisible)
                GridOptions.Visibility = Visibility.Collapsed;
            if (GridDetails.IsVisible)
                GridDetails.Visibility = Visibility.Collapsed;
            else
                GridDetails.Visibility = Visibility.Visible;
        }

        private void DisplayOptions(object sender, RoutedEventArgs e)
        {
            if (GridDetails.IsVisible)
                GridDetails.Visibility = Visibility.Collapsed;
            if (GridOptions.IsVisible)
                GridOptions.Visibility = Visibility.Collapsed;
            else
                GridOptions.Visibility = Visibility.Visible;
        }

        private void onInterestedClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as PostContentViewModel;
            if (viewModel != null)
            {
                viewModel.AddInterests();
            }
        }

        private void onUninterestedClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as PostContentViewModel;
            if (viewModel != null)
            {
                viewModel.AddUniterests();
            }
        }

        private void onBuyButtonClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as PostContentViewModel;
            User user = viewModel.user;
            Post post = viewModel.getPost();
            
            Chat chat = new Chat(user,post);
            chat.SendBuyingMessage(Media);
            chat.Show();
        }



        private void onBidButtonClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as PostContentViewModel;
            if(viewModel != null)
            {
                viewModel.UpdateBidPrice();
            }
        }

        private void onDonationButtonClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as PostContentViewModel;
            DonationPost post = (DonationPost)viewModel.getPost();
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = post.DonationPageLink,
                UseShellExecute = true
            });
        }

    }
}
