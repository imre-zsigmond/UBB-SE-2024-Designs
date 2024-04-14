using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class FixedPricePost : Post
    {
        private double price;
        private DateTime expirationDate;
        private float reviewScore;
        private List<Review> reviews;
        private string delivery;
        private Guid buyerId;

        public FixedPricePost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, double price, DateTime expirationDate, string delivery, List<Review> reviews, float reviewScore, Guid buyerId, string type, bool confirmed) : base(media, authorId, groupId, location, description, title, contacts, type, confirmed)
        {
            this.price = price;
            this.expirationDate = expirationDate;
            this.reviews = reviews;
            this.delivery = delivery;
            this.reviewScore = reviewScore;
            this.buyerId = buyerId;
        }

        public FixedPricePost() : base()
        {
            this.price = 0;
            this.expirationDate = DateTime.Now;
            this.reviewScore = 0;
            this.reviews = new List<Review>();
            this.delivery = "";
            this.buyerId = Guid.Empty;
        }
        public FixedPricePost(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, List<Comment> comments, string media, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string location, string description, string title, List<InterestStatus> interestStatuses, string contacts, List<Report> reports, double price, DateTime expirationDate, string delivery, List<Review> reviews, float reviewScore, Guid buyerId, string type, bool confirmed, int views) : base(id, usersThatShared, usersThatLiked, comments, media, creationDate, authorId, groupId, promoted, usersThatFavorited, location, description, title, interestStatuses, contacts, reports, type, confirmed, views)
        {
            this.price = price;
            this.expirationDate = expirationDate;
            this.reviewScore = reviewScore;
            this.delivery = delivery;
            this.reviews = reviews;
            this.buyerId = buyerId;
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public float ReviewScore
        {
            get { return reviewScore; }
            set { reviewScore = value; }
        }

        public string Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }

        public Guid BuyerId
        {
            get { return buyerId; }
        }

        public List<Review> Reviews
        {
            get { return reviews; }
        }
        public void addReview(Review review)
        {
            if(reviews.Contains(review))
            {
                throw new Exception("Review already exists. Edit the existing one if you want");
            }
            reviews.Add(review);
        }
        public void removeReview(Review review)
        {
            if(!reviews.Contains(review))
            {
                throw new Exception("Review does not exist");
            }   
            reviews.Remove(review);
        }

        public void buyProduct(Guid buyerId)
        {
            if(this.buyerId != Guid.Empty)
            {
                throw new Exception("Product already bought");
            }
            this.buyerId = buyerId;
        }

      }
}
