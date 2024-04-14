using ISSLab.Model;
using ISSLab.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ISSLab.ViewModel
{
    class PostContentViewModel : ViewModelBase
    {
        private PostService postService;
        private UserService userService;
        private Guid groupId;
        private Post post;
        private Guid accountId;
        public User user;
        private string visible;
        private string favoriteDisplay;
        private string donationButtonVisible;
        private string buyButtonVisible;
        private string bidButtonVisible;
        private string bidPriceVisible;
        private DispatcherTimer timer;

       

        public PostContentViewModel(Post post, User user, Guid accountId, Guid groupId, UserService userService, PostService postService) : base()
        {
            this.postService = postService;
            this.userService = userService;
            this.groupId = groupId;
            this.accountId = accountId;
            this.post = post;
            this.user = user;
            this.visible = "Visible";
            this.donationButtonVisible = "Collapsed";
            this.buyButtonVisible = "Collapsed";
            this.bidButtonVisible = "Collapsed";
            this.bidPriceVisible = "Collapsed";
            if (post.Type == "Donation")
            {
                this.donationButtonVisible = "Visible";
            }
            else if (post.Type == "FixedPrice")
                this.buyButtonVisible = "Visible";
            else if(post.Type == "Auction")
            {
                this.buyButtonVisible = "Visible";
                this.bidButtonVisible = "Visible";
                this.bidPriceVisible = "Visible";
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public PostContentViewModel()
        {
            postService = new PostService();
            userService = new UserService();
            groupId = new Guid();
            accountId = Guid.NewGuid();
            post = new Post();
            user = new User();
            visible = "Visible";

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(AvailableFor));
        }



        public float Rating { get { return ((FixedPricePost)(post)).ReviewScore; } }


        public string Visible { get { return visible; } set { visible = value; OnPropertyChanged(nameof(Visible)); } }
        public string Description { get { return post.Description; } set { post.Description = value; } }
        public string Contact { get { return post.Contacts; } set { post.Contacts = value; } }
        public string Delivery {
            get
            {
                if (post.Type == "FixedPrice")
                {
                    FixedPricePost fixedPricePost = (FixedPricePost)post;
                    return fixedPricePost.Delivery;
                }
                else if (post.Type == "Auction")
                {
                    AuctionPost auctionPost = (AuctionPost)post;
                    return auctionPost.Delivery;
                }
                else
                {
                    DonationPost donationPost = (DonationPost)post;
                    return "";
                }
            }
            set
            {
                if (post.Type == "FixedPrice")
                {
                    FixedPricePost fixedPricePost = (FixedPricePost)post;
                    fixedPricePost.Delivery = value;
                }
                else if (post.Type == "Auction")
                {
                    AuctionPost auctionPost = (AuctionPost)post;
                    auctionPost.Delivery = value;
                }
            }
        }
        public string DonationButtonVisible
        {
            get { return donationButtonVisible; }
            set { donationButtonVisible = value; OnPropertyChanged(nameof(DonationButtonVisible)); }
        }

        public string BuyButtonVisible
        {
            get { return buyButtonVisible; }
            set { buyButtonVisible = value; OnPropertyChanged(nameof(BuyButtonVisible)); }
        }

        public string BidButtonVisible
        {
            get { return bidButtonVisible; }
            set { bidButtonVisible = value;OnPropertyChanged(nameof(BidButtonVisible)); }
        }

        public string BidPriceVisible
        {
            get { return bidPriceVisible; }
            set { bidPriceVisible = value;OnPropertyChanged(nameof(BidPriceVisible)); }
        }

        public string Username { get { return user.Username; } }
        public string Media { get { return post.Media; } }

        public string Location { get { return post.Location; } }
        public string ProfilePicture { get { return user.ProfilePicture; } }
        public string TimePosted {
          get {
                TimeSpan passed = DateTime.Now - post.CreationDate;
                if(passed.TotalSeconds < 60)
                    return Math.Ceiling(passed.TotalSeconds).ToString() + " seconds ago";
                if (passed.TotalMinutes < 60)
                    return Math.Ceiling(passed.TotalMinutes).ToString() + " minutes ago";
                if (passed.TotalHours < 24)
                    return Math.Ceiling(passed.TotalHours).ToString() + " hours ago";
       

                return Math.Ceiling(passed.TotalDays).ToString() + " days ago";
            }
        }

        public Post getPost()
        {
            return post;
        }

        public void AddPostToFavorites()
        {
            this.userService.AddItemToFavorites(groupId, post.Id, accountId);
        }
        public void AddPostToCart()
        {
            this.userService.AddItemToCart(groupId, post.Id, accountId);
        }
       public string AvailableFor
        {
            get
            {
                if (post.Type == "FixedPrice")
                {
                    FixedPricePost fixedPricePost = (FixedPricePost)post;
                    TimeSpan timeLeft = fixedPricePost.ExpirationDate - DateTime.Now;
                    if (timeLeft.TotalSeconds < 60)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalSeconds).ToString() + " seconds";
                    if (timeLeft.TotalMinutes < 60)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalMinutes).ToString() + " minutes";
                    if (timeLeft.TotalHours < 24)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalHours).ToString() + " hours";
                    return "Available for: " + Math.Ceiling(timeLeft.TotalDays).ToString() + " days";
                }
                else if (post.Type == "Auction")
                {
                     AuctionPost fixedPricePost = (AuctionPost)post;
                    TimeSpan timeLeft = fixedPricePost.ExpirationDate - DateTime.Now;
                    if (timeLeft.TotalSeconds < 60)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalSeconds).ToString() + " seconds";
                    if (timeLeft.TotalMinutes < 60)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalMinutes).ToString() + " minutes";
                    if (timeLeft.TotalHours < 24)
                        return "Available for: " + Math.Ceiling(timeLeft.TotalHours).ToString() + " hours";
                    return "Available for: " + Math.Ceiling(timeLeft.TotalDays).ToString() + " days";
                }
                else
                {
                    return "";
                }
                
            }
        }
        public string Price
        {
            get
            {
                if (post.Type == "FixedPrice")
                {
                    return "$" + ((FixedPricePost)(post)).Price;
                }
                else if (post.Type == "Auction")
                {
                    return "$" + ((AuctionPost)(post)).Price; 
                }
                else
                {
                    DonationPost donationPost = (DonationPost)post;
                    return "";
                }
            }
        }

        public void UpdateBidPrice()
        {
            AuctionPost auctionPost = (AuctionPost)post;
            TimeSpan timeLeft = auctionPost.ExpirationDate - DateTime.Now;
            TimeSpan timeSpan = TimeSpan.FromSeconds(30);

            if (timeLeft.TotalSeconds < 30)
            {
                auctionPost.add30SecondsToExpirationDate();
                OnPropertyChanged(nameof(AvailableFor));
            }

            ((AuctionPost)(post)).CurrentBidPrice += 5;
            ((AuctionPost)(post)).MinimumBidPrice += 5;
            OnPropertyChanged(nameof(BidPrice));
        }

        public string BidPrice
        {
            get
            {
                if (post.Type == "Auction")
                    return "$" + ((AuctionPost)(post)).CurrentBidPrice;
                else
                {
                    return "";
                }
            }
        }

        public string Interests
        {
            get
            {
                int interested = post.InterestStatuses.FindAll(interest => interest.Interested).Count;
                return interested.ToString() + " interested";
            }
        }


        public void AddInterests()
        {
            var existingInterest = post.InterestStatuses.FirstOrDefault(interest => interest.UserId == user.Id && interest.PostId == post.Id);

            if (existingInterest != null)
            {
                post.InterestStatuses.Remove(existingInterest);
            }
            else
            {
                post.InterestStatuses.Add(new InterestStatus(user.Id, post.Id, true));
            }

            OnPropertyChanged(nameof(Interests));
        }

        public string Uninterests
        {
            get
            {
                int uninterested = post.InterestStatuses.FindAll(interest => !interest.Interested).Count;
                return uninterested.ToString() + " uninterested";
            }
        }

        public void AddUniterests()
        {
            var existingUninterest = post.InterestStatuses.FirstOrDefault(interest => interest.UserId == user.Id && interest.PostId == post.Id && !interest.Interested);

            if (existingUninterest != null)
            {
                post.InterestStatuses.Remove(existingUninterest);
            }
            else
            {
                post.InterestStatuses.Add(new InterestStatus(user.Id, post.Id, false));
            }
            OnPropertyChanged(nameof(Uninterests));
        }

        public string Comments
        {
            get
            {
                return post.NrComments.Count + " comments";
            }
        }


    }

}
