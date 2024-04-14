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
    /// Interaction logic for CreationPost.xaml
    /// </summary>
    public partial class CreationPost : UserControl
    {
        private readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register("PhoneNumber", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty DeliveryProperty = DependencyProperty.Register("Delivery", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty ConditionPropery = DependencyProperty.Register("Condition", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty AvailabilityProperty = DependencyProperty.Register("Availability", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty PhoneVisibleProperty = DependencyProperty.Register("PhoneVisible", typeof(bool), typeof(CreationPost));
        private readonly DependencyProperty PriceVisibleProperty = DependencyProperty.Register("PriceVisible", typeof(bool), typeof(CreationPost));
        private readonly DependencyProperty ConditionVisibleProperty = DependencyProperty.Register("ConditionVisible", typeof(bool), typeof(CreationPost));
        private readonly DependencyProperty AvailabilityVisibleProperty = DependencyProperty.Register("AvailabilityVisible", typeof(bool), typeof(CreationPost));
        private readonly DependencyProperty DeliveryVisibleProperty = DependencyProperty.Register("DeliveryVisible", typeof(bool), typeof(CreationPost));
        private readonly DependencyProperty IsDonationProperty = DependencyProperty.Register("IsDonation", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty DonationLinkProperty = DependencyProperty.Register("DonationLink", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty IsAuctionProperty = DependencyProperty.Register("IsAuction", typeof(string), typeof(CreationPost));
        private readonly DependencyProperty MinimumBidProperty = DependencyProperty.Register("MinimumBid", typeof(string), typeof(CreationPost));
        
        public string MinimumBid
        {
            get { return (string)GetValue(MinimumBidProperty); }
            set { SetValue(MinimumBidProperty, value); }
        }
        public string IsAuction
        {
            get { return (string)GetValue(IsAuctionProperty); }
            set { SetValue(IsDonationProperty, value); }
        }

        public string IsDonation
        {
            get { return (string)GetValue(IsDonationProperty); }
            set { SetValue(IsDonationProperty, value); }
        }

        public string DonationLink
        {
            get { return (string)GetValue(DonationLinkProperty); }
            set { SetValue(DonationLinkProperty, value);}
        }
        public string PhoneVisible
        {
            get { return (string)GetValue(PhoneVisibleProperty); }
            set { SetValue(PhoneVisibleProperty, value); }
        }
        public string PriceVisible
        {
            get { return (string)GetValue(PriceVisibleProperty); }
            set { SetValue(PriceVisibleProperty, value); }
        }
        public string ConditionVisible
        {
            get { return (string)GetValue(ConditionVisibleProperty); }
            set { SetValue(ConditionVisibleProperty, value); }
        }
        public string AvailabilityVisible
        {
            get { return (string)GetValue(AvailabilityVisibleProperty); }
            set { SetValue(AvailabilityVisibleProperty, value); }
        }
        public string DeliveryVisible
        {
            get { return (string)GetValue(DeliveryVisibleProperty); }
            set { SetValue(DeliveryVisibleProperty, value); }
        }


        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public string Delivery
        {
            get { return (string)GetValue(DeliveryProperty); }
            set { SetValue(DeliveryProperty, value); }
        }
        public string Condition
        {
            get { return (string)GetValue(ConditionPropery); }
            set { SetValue(ConditionPropery, value); }
        }
        public string Availability
        {
            get { return (string)GetValue(AvailabilityProperty); }
            set { SetValue(AvailabilityProperty, value); }
        }

        public CreationPost()
        {
            InitializeComponent();
        }

        public void CreationButtonClick(Object sender, RoutedEventArgs e)
        {
            this.DataContext.GetType ().GetMethod("CreatePost").Invoke(this.DataContext, null);
        }
    }
}
