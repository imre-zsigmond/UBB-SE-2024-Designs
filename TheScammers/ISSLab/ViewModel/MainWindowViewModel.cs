using ISSLab.Model;
using ISSLab.Model.Repositories;
using ISSLab.Services;
using ISSLab.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ISSLab.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        PostService postService;
        UserService userService;
        GroupRepository groupRepository;
        ObservableCollection<PostContentViewModel> shownPosts;
        Guid userId;
        Guid groupId;
        CreatePostViewModel postCreationViewModel;

        public ViewModelBase CurrentViewModel { get; }
        public MainWindowViewModel() 
        {
            userId = Guid.NewGuid();
            groupId = Guid.NewGuid();
            DataSet dataSet = new DataSet();
            PostRepository postRepo = new PostRepository(dataSet, groupId);
            UserRepository userRepo = new UserRepository(dataSet);
            User connectedUser = new User(userId, "Soundboard1", "Dorian", DateOnly.Parse("15.12.2003"), "../Resources/Images/Dorian.jpeg", "fsdgfd", DateTime.Parse("10.04.2024"), new List<Guid>(), new List<Guid>(), new List<SellingUserScore>(), new List<Cart>(), new List<Favorites>(), new List<Guid>(), new List<Review>(), 0);
            User tempUser1 = new User("Vini", "Vinicius Junior", DateOnly.Parse("15.12.2003"), "../Resources/Images/Vini.png", "fdsfsdfds");
            User tempUser2 = new User("DDoorian", "Pop Dorian", DateOnly.Parse("12.12.2003"), "../Resources/Images/Dorian.jpeg", "bcvbc");
            userRepo.AddUser(tempUser2);
            userRepo.AddUser(connectedUser);
            userRepo.AddUser(tempUser1);

            DonationPost donationPost = new DonationPost("../Resources/Images/catei.jpeg", tempUser1.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", "https://www.unicef.org/romania/ro", "Donation", true);
            AuctionPost auctionPost = new AuctionPost("../Resources/Images/catei.jpeg", tempUser1.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddSeconds(80), "InPerson", new List<Review>(), 4, Guid.Empty,Guid.Empty,100,105, "Auction", true);
            postRepo.addPost(new FixedPricePost("../Resources/Images/catei.jpeg", tempUser1.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddMonths(2), "InPerson", new List<Review>(), 4, Guid.Empty, "FixedPrice", true));

            FixedPricePost post1 = new FixedPricePost("../Resources/Images/catei.jpeg", tempUser1.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddMonths(2), "InPerson", new List<Review>(), 4, Guid.Empty, "FixedPrice", true);
            post1.ReviewScore = 4;
            postRepo.addPost(post1);

            postRepo.addPost(new FixedPricePost("../Resources/Images/catei.jpeg", tempUser2.Id, groupId, "Bistrita", "Some great dogs", "Something else", "0222111333", 350, DateTime.Now.AddDays(6), "shipping", new List<Review>(), 4, Guid.Empty, "FixedPrice", true));
            postRepo.addPost(donationPost);
            postRepo.addPost(auctionPost);
            shownPosts = new ObservableCollection<PostContentViewModel>();
            groupRepository = new GroupRepository(dataSet);
            postService = new PostService(postRepo,userRepo,groupRepository);
            userService = new UserService(userRepo,postRepo,groupRepository);
            
            
            postCreationViewModel = new CreatePostViewModel(userId, groupId, userService, postService);

            LoadPostsCommand(postRepo.getAll());


        }


        public CreatePostViewModel PostCreationViewModel
        {
            get { return postCreationViewModel; }
            set
            {
                postCreationViewModel = value;
                OnPropertyChanged(nameof(PostCreationViewModel));
            }
        }

        public ObservableCollection<PostContentViewModel> ShownPosts { get { return shownPosts; } set
            {
                ShownPosts = value;
                OnPropertyChanged(nameof(ShownPosts));
            }
        }

        public void ChangeToFavorites()
        {
            List<Post> favoritedPosts = userService.GetFavoritePosts(groupId, userId);
            LoadPostsCommand(favoritedPosts);
        }

        public void ChangeToMarketPlace()
        {
            List<Post> posts = postService.GetPosts();
            LoadPostsCommand(posts);
        }

        public void ChangeToCart()
        {
            List<Post> cart = userService.GetItemsFromCart(userId, groupId);
            LoadPostsCommand(cart);
            
        }

        public void ChangeToMarketplacePost()
        {
            
        }

        public void LoadPostsCommand(List<Post> posts)
        {
            
            shownPosts.Clear();
            foreach(Post p in posts)
            {
                User originalPoster = userService.GetUserById(p.AuthorId);
                //shownPosts.Add(p);
                shownPosts.Add(new PostContentViewModel(p, originalPoster, this.userId, this.groupId, this.userService, this.postService));
            }

            OnPropertyChanged(nameof(ShownPosts));
        }

       

    }
}
