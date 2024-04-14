using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using ISSLab.Model;
using ISSLab.ViewModel;

namespace ISSLab.View
{
    public partial class AllConversationsWindow : UserControl
    {
        private ObservableCollection<Model.User> AllProfiles { get; set; }


        public AllConversationsWindow()
        {
            InitializeComponent();
            DataContext = this;

            AllProfiles = new ObservableCollection<ISSLab.Model.User>();
            AllProfiles.Add(new ISSLab.Model.User { Username = "John Doe", ProfilePicture = @"D:\UBBprojects\ISS\Isslab2\Isslab2\user.JPG" });
            AllProfiles.Add(new ISSLab.Model.User { Username = "Jane Smith", ProfilePicture = @"D:\UBBprojects\ISS\Isslab2\Isslab2\user.JPG" });
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is ISSLab.Model.User selectedUser)
            {
                Window parentWindow = Window.GetWindow(this);
                parentWindow?.Close();

                var viewModel = DataContext as PostContentViewModel;
                Post post = viewModel.getPost();

                Chat chat = new Chat(selectedUser,post);
                parentWindow.Content = chat;
            }
        }

    }
}
