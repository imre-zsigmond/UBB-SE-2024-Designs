using ISSLab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ISSLab.View
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        public ObservableCollection<Message> AllMessages { get; set; }
        Post post;
        internal Chat(User selectedUser,Post post)
        {
            InitializeComponent();
            DataContext = this;
            Username.Content = selectedUser.Username.ToString();
            AllMessages = new ObservableCollection<Message>();
            this.post = post;
        }


        public void SendMessage(string message, bool isMine, bool isSellingPost)
        {
            var newMessage = new Message
            {
                Content = message,
                Width = CalculateMessageWidth(message),
                IsMine = isMine,
                BubbleColor = isMine ? Brushes.LightBlue : Brushes.LightGray,
                HorizontalAlignment = isMine ? HorizontalAlignment.Right : HorizontalAlignment.Left
            };

            if (isSellingPost)
            {
                newMessage.Content = "SELLING POST: " + "";
                newMessage.BubbleColor = Brushes.YellowGreen;
            }

            AllMessages.Add(newMessage);

            MessageTextBox.Text = "";
        }
        public void SendBuyingMessage(string media)
        {
            var newMessage = new Message
            {
                Content = "I'm interested in buying your product!",
                Width = CalculateMessageWidth("I'm interested in buying your product!"),
                IsMine = false,
                BubbleColor = Brushes.YellowGreen,
                HorizontalAlignment = HorizontalAlignment.Left,
                ImagePath = media,
                ShowAcceptButton = true, 
                ShowRejectButton = true
            };

            AllMessages.Add(newMessage);
        }

  /*      public void SendSellingMessage(string message, bool isMine, bool isSellingPost, bool isSeller)
        {
            var newMessage = new Message
            {
                Content = message,
                Width = CalculateMessageWidth(message),
                IsMine = isMine,
                BubbleColor = isMine ? Brushes.LightBlue : Brushes.LightGray,
                HorizontalAlignment = isMine ? HorizontalAlignment.Right : HorizontalAlignment.Left
            };

            if (isSellingPost)
            {
                var postImage = new Image
                {
                    Source = new BitmapImage(new Uri("/path/to/post/image.jpg", UriKind.Relative)), 
                    Width = 100,
                    Height = 100,
                    Margin = new Thickness(0, 10, 0, 0)
                };

                var acceptButton = new Button
                {
                    Content = "Accept",
                    Margin = new Thickness(0, 10, 5, 0), 
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                acceptButton.Click += (sender, e) =>
                {
                    // Handle accept button click
                };

                var rejectButton = new Button
                {
                    Content = "Reject",
                    Margin = new Thickness(5, 10, 0, 0), 
                    HorizontalAlignment = HorizontalAlignment.Right 
                };
                rejectButton.Click += (sender, e) =>
                {
                    // Handle reject button click
                };

                var stackPanel = new StackPanel();

                stackPanel.Children.Add(postImage);

                stackPanel.Children.Add(new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap });

                stackPanel.Children.Add(acceptButton);
                stackPanel.Children.Add(rejectButton);

                //newMessage.Content = stackPanel;

                newMessage.BubbleColor = Brushes.YellowGreen;
            }

            AllMessages.Add(newMessage);

            MessageTextBox.Text = "";
        }*/

        private double CalculateMessageWidth(string message)
        {
            var textBlock = new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap };
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return textBlock.DesiredSize.Width;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(MessageTextBox.Text, true, false);
        }
        private Button FindVisualChild<Button>(DependencyObject parent, string name) where Button : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is Button && (child as FrameworkElement).Name == name)
                {
                    return child as Button;
                }
                else
                {
                    Button result = FindVisualChild<Button>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            TextBlock popupContent = new TextBlock();
            popupContent.Text = "This is a Popup!";
            popup.Child = popupContent;
            popup.IsOpen = true;
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
        private void OnAcceptButtonClicked(object sender, RoutedEventArgs e)
        {
            Button acceptButton = FindVisualChild<Button>((sender as Button).Parent as Grid, "AcceptButton");
            Button rejectButton = FindVisualChild<Button>((sender as Button).Parent as Grid, "RejectButton");
            Button sendButton = FindVisualChild<Button>((sender as Button).Parent as Grid, "SendButton");


            if (acceptButton != null && rejectButton != null)
            {
                MessageBox.Show("Buying Accepted", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                acceptButton.Visibility = Visibility.Collapsed;
                rejectButton.Visibility = Visibility.Collapsed;
                MessageTextBox.Visibility = Visibility.Collapsed;
                SendButton.Visibility = Visibility.Collapsed;
                
                

            }
        }

        private void OnRejectButtonClicked(object sender, RoutedEventArgs e)
        {
            Button acceptButton = FindVisualChild<Button>((sender as Button).Parent as Grid, "AcceptButton");
            Button rejectButton = FindVisualChild<Button>((sender as Button).Parent as Grid, "RejectButton");

            if (acceptButton != null && rejectButton != null)
            {
                MessageBox.Show("Buying Rejected", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                acceptButton.Visibility = Visibility.Collapsed;
                rejectButton.Visibility = Visibility.Collapsed;
                MessageTextBox.Visibility = Visibility.Collapsed;
                SendButton.Visibility = Visibility.Collapsed;
                
            }
        }
    }
}
