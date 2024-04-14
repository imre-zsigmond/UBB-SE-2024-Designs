using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ISSLab.Model
{
    class User
    {
        private Guid id;
        private string username;
        private string realName;
        private DateOnly dateOfBirth;
        private string profilePicture;
        private string password;
        private int nrOfSells;
        private DateTime creationDate;
        private List<Guid> groupsWithSellingPrivelage;
        private List<SellingUserScore> userScores;
        private List<Guid> groupsWithActiveRequestToSell;
        private List<Cart> carts;
        private List<Favorites> favorites;
        private List<Guid> groups;
        private List<Review> receivedReviews;






        public User(string username, string realName, DateOnly dateOfBirth, string profilePicture, string password)
        {
            this.id = Guid.NewGuid();
            this.username = username;
            this.realName = realName;
            this.dateOfBirth = dateOfBirth;
            this.profilePicture = profilePicture;
            this.password = password;
            this.creationDate = DateTime.Now;
            this.groupsWithSellingPrivelage = new List<Guid>();
            this.groupsWithActiveRequestToSell = new List<Guid>();
            this.userScores = new List<SellingUserScore>();
            this.carts = new List<Cart>();
            this.favorites = new List<Favorites>();
            this.groups = new List<Guid>();
            this.receivedReviews = new List<Review>();
            this.nrOfSells = 0;
        }
        public User(Guid id, string username, string realName, DateOnly dateOfBirth, string profilePicture, string password, DateTime creationDate, List<Guid> groupsWithSellingPrivelage, List<Guid> groupsWithActiveRequestToSell,List<SellingUserScore> userScores, List<Cart> carts, List<Favorites> favorites, List<Guid> groups, List<Review> receivedReviews, int nrOfSells)
        {
            this.id = id;
            this.username = username;
            this.realName = realName;
            this.dateOfBirth = dateOfBirth;
            this.profilePicture = profilePicture;
            this.password = password;
            this.creationDate = creationDate;
            this.groupsWithSellingPrivelage = groupsWithSellingPrivelage;
            this.groupsWithActiveRequestToSell = groupsWithActiveRequestToSell;
            this.userScores = userScores;
            this.receivedReviews = receivedReviews;
            this.carts = carts;
            this.favorites = favorites;
            this.groups = groups;
            this.nrOfSells = nrOfSells;
            this.carts = carts;
            this.favorites = favorites;
            this.groups = groups;
            this.receivedReviews = receivedReviews;
        }

        public User()
        {
            this.id = Guid.NewGuid();
            this.username = "";
            this.realName = "";
            this.dateOfBirth = new DateOnly();
            this.profilePicture = "";
            this.password = "";
            this.creationDate = DateTime.Now;
            this.groupsWithSellingPrivelage = new List<Guid>();
            this.groupsWithActiveRequestToSell = new List<Guid>();
            this.userScores = new List<SellingUserScore>();
            this.nrOfSells = 0;
            this.carts = new List<Cart>();
            this.favorites = new List<Favorites>();
            this.groups = new List<Guid>();
            this.receivedReviews = new List<Review>();

        }

        public List<SellingUserScore> sellingUserScores { get => userScores; set => userScores = value; }
        public Guid Id { get => id; }
        public string Username { get => username; set => username = value; }
        public string RealName { get => realName; set => realName = value; }
        public DateOnly DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }
        public string Password { get => password; set => password = value; }
        public DateTime CreationDate { get => creationDate; }

        public List<Cart> Carts { get => carts; }

        public List<Favorites> Favorites { get => favorites; }

        public List<Guid> Groups { get => groups; }

        public List<Review> Reviews { get => receivedReviews; }


        public List<Guid> GroupsWithSellingPrivelage { get => groupsWithSellingPrivelage; }

        public List<Guid> GroupsWithActiveRequestToSell { get => groupsWithSellingPrivelage;}


        public ImageSource ProfilePictureImageSource
        {
            get
            {
                try
                {
                    return new BitmapImage(new Uri(profilePicture));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void AddCarts(Cart newCart)
        {
            carts.Add(newCart);
        }

        public void AddFavorites(Favorites newFavorite)
        {
            favorites.Add(newFavorite);
        }
        public void AddGroup(Guid newGroup)
        {
            groups.Add(newGroup);
        }
     

        
        public void AddReview(Review newReview)
        {
            receivedReviews.Add(newReview);
        }
        public void addNewUserScore( SellingUserScore userScor)
        {
            this.userScores.Add(userScor);
        }


        public int NrOfSells { get => nrOfSells; set => nrOfSells = value; }

        public void removeUserScore(SellingUserScore userScore)
        {
            this.userScores = this.userScores.FindAll(val => val.GroupId != userScore.GroupId);
        }  

        public void requestSellingAccess(Guid groupId)
        {
            if(groupsWithActiveRequestToSell.Contains(groupId))
                throw new Exception("Already requested access to sell in this group");
            if(groupsWithSellingPrivelage.Contains(groupId))
                throw new Exception("Already have access to sell in this group");
            groupsWithActiveRequestToSell.Append(groupId);
        }
        public void accessToSellDenied(Guid groupId)
        {
            if(!groupsWithActiveRequestToSell.Contains(groupId))
                throw new Exception("No active request to sell in this group");
            if(groupsWithSellingPrivelage.Contains(groupId))
                throw new Exception("Already have access to sell in this group");
            groupsWithActiveRequestToSell = groupsWithActiveRequestToSell.FindAll(val => val != groupId);
        }
        public void accessToSellWasTaken(Guid groupId)
        {
            if(!groupsWithSellingPrivelage.Contains(groupId))
                throw new Exception("No access to sell in this group");
            if(groupsWithActiveRequestToSell.Contains(groupId))
                throw new Exception("No access to sell in this group yet, but request is active");
            groupsWithSellingPrivelage = groupsWithSellingPrivelage.FindAll(val => val != groupId);
        }


        public void receivedPrivelageToSell(Guid groupId)
        {
            if (groupsWithSellingPrivelage.Contains(groupId))
                throw new Exception("You can already sell in this group");
            groupsWithActiveRequestToSell = groupsWithActiveRequestToSell.FindAll(val => val != groupId);
            groupsWithSellingPrivelage.Add(groupId);
        }

        public bool hasAccessToSell(Guid groupId)
        {
            if(!groupsWithSellingPrivelage.Contains(groupId))
                return false;
            return true;
        }

    }
}
