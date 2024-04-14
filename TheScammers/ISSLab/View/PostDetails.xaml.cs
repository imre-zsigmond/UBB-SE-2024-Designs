using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for PostDetails.xaml
    /// </summary>
    public partial class PostDetails : UserControl

    {
        //public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(PostContent));
        //public static readonly DependencyProperty ContactProperty = DependencyProperty.Register("Contact", typeof(string), typeof(PostContent));
        //public static readonly DependencyProperty DeliveryProperty = DependencyProperty.Register("Delivery", typeof(string), typeof(PostContent));

        //public String Description
        //{
        //    get { return (String)GetValue(DescriptionProperty); }
        //    set { SetValue(DescriptionProperty, value); }
        //}

        //public String Contact
        //{
        //    get { return (String)GetValue(ContactProperty); }
        //    set { SetValue(ContactProperty, value); }
        //}

        //public String Delivery
        //{
        //    get { return (String)GetValue(DeliveryProperty); }
        //    set { SetValue(DeliveryProperty, value); }
        //}

        
        public PostDetails()
        {
            InitializeComponent();
        }
    }
}
