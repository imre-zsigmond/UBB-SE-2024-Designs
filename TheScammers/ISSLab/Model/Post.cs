using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Post
    {
        private Guid id;
        private int views;
        private List<Guid> usersThatShared;
        private List<Guid> usersThatLiked;
        private List<Comment> comments;
        private string media;
        private DateTime creationDate;
        private Guid authorId;
        private Guid groupId;
        private bool promoted;
        private List<Guid> usersThatFavorited;
        private List<Report> reports;
        private string location;
        private bool confirmed;
        private string description;
        private string title;
        private List<InterestStatus> interestStatuses;
        private string contacts;
        private string type;


        public Post(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, string type, bool confirmed)
        {
            this.confirmed = confirmed;
            this.id = Guid.NewGuid();
            this.usersThatShared = new List<Guid>();
            this.usersThatLiked = new List<Guid>();
            this.comments = new List<Comment>();
            this.media = media;
            this.creationDate = DateTime.Now;
            this.authorId = authorId;
            this.groupId = groupId;
            this.promoted = false;
            this.usersThatFavorited = new List<Guid>();
            this.location = location;
            this.description = description;
            this.title = title;
            this.views = 0;
            this.interestStatuses = new List<InterestStatus>();
            this.contacts = contacts;
            this.reports = new List<Report>();
            this.type = type;
        }

        public Post(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, List<Comment> comments, string media, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string location, string description, string title, List<InterestStatus> interestStatuses, string contacts, List<Report> reports, string type, bool confirmed, int views)
        {
            this.id = id;
            this.usersThatShared = usersThatShared;
            this.usersThatLiked = usersThatLiked;
            this.comments = comments;
            this.media = media;
            this.creationDate = creationDate;
            this.authorId = authorId;
            this.groupId = groupId;
            this.promoted = promoted;
            this.usersThatFavorited = usersThatFavorited;
            this.location = location;
            this.description = description;
            this.title = title;
            this.interestStatuses = interestStatuses;
            this.contacts = contacts;
            this.reports = reports;
            this.type = type;
            this.views = views;
            this.confirmed = confirmed; 
        }

        public Post()
        {
            this.id = Guid.NewGuid();
            this.usersThatShared = new List<Guid>();
            this.usersThatLiked = new List<Guid>();
            this.comments = new List<Comment>();
            this.reports = new List<Report>();
            this.media = "";
            this.creationDate = DateTime.Now;
            this.authorId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
            this.promoted = false;
            this.usersThatFavorited = new List<Guid>();
            this.location = "";
            this.description = "";
            this.title = "";
            this.interestStatuses = new List<InterestStatus>();
            this.contacts = "";
            this.type = "post";
            this.confirmed = false;
        }


        public int Views { get => views; set => views = value; }
        public string Type { get => type; set => type = value; }

        public Guid Id { get => id; }
        public List<Guid> UsersThatShared { get => usersThatShared; }
        public List<Guid> UsersThatLiked { get => usersThatLiked; }
        public List<Comment> NrComments { get => comments; }
        public string Media { get => media; set => media = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public Guid AuthorId { get => authorId; }
        public Guid GroupId { get => groupId; }
        public bool Promoted { get => promoted; set => promoted = value; }
        public List<Guid> UsersThatFavorited { get => usersThatFavorited; }
        public List<Report> Reports { get => reports; }
        public string Location { get => location; set => location = value; }
        public string Description { get => description; set => description = value; }
        public string Title { get => title; set => title = value; }
        public List<InterestStatus> InterestStatuses { get => interestStatuses; }
        public string Contacts { get => contacts; set => contacts = value; }

        public bool Confirmed { get => confirmed; set => confirmed = value; }
        public void addReport(Report report)
        {
            reports.Add(report);
        }
        public void removeReport(Guid userId)
        {
            reports.RemoveAll(x => x.UserId == userId);
        }

        public void toggleFavorite(Guid userId)
        {
            if(usersThatFavorited.Contains(userId))
            {
                usersThatFavorited.Remove(userId);
            }
            else
            {
                usersThatFavorited.Add(userId);
            }
        }

        public void toggleLike(Guid userId)
        {
            if(usersThatLiked.Contains(userId))
            {
                usersThatLiked.Remove(userId);
            }
            else
            {
                usersThatLiked.Add(userId);
            }
        }

        public void toggleShare(Guid userId)
        {
            if(usersThatShared.Contains(userId))
            {
                usersThatShared.Remove(userId);
            }
            else
            {
                usersThatShared.Add(userId);
            }
        }

        public void addComment(Comment commentId)
        {
            comments.Add(commentId);
        }

        public void removeComment(Comment commentId)
        {
            comments.Remove(commentId);
        }

        public int interestLevel()
        {

            return interestStatuses.FindAll(i => i.Interested).Count - interestStatuses.FindAll(i => !i.Interested).Count;
        }

        public void addInterestStatus(InterestStatus interestStatus)
        {
            interestStatuses.Add(interestStatus);
        }

        public void removeInterestStatus(Guid userId)
        {
            interestStatuses.RemoveAll(x => x.UserId == userId);
        }
        public void toggleInterestStatus(Guid userId)
        {
            int index = interestStatuses.FindIndex(x => x.UserId == userId);
            if(index == -1)
                throw new Exception("Interest status not found");
            else
            {
                interestStatuses[index].toggleInterested();
            }

        }


    }
}
