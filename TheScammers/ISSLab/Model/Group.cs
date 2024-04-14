using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Group
    {
        private Guid id;
        private string name;
        private int memberCount;
        private List<Guid> members;
        private List<Guid> posts;
        private List<Guid> bigSellers;
        private List<Guid> admins;
        private List<Guid> sellingUsers;
        private List<Guid> requestedUsers;

        private string description;
        private string type;
        private string banner;
        private DateTime creationDate;

        public Group(string name, string description, string type, string banner)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.memberCount = 0;
            this.members = new List<Guid>();
            this.posts = new List<Guid>();
            this.admins = new List<Guid>();
            this.sellingUsers = new List<Guid>();
            this.description = description;
            this.type = type;
            this.banner = banner;
            this.creationDate = DateTime.Now;
            this.bigSellers = new List<Guid>();
            this.requestedUsers = new List<Guid>();

            
        }
        public Group()
        {
            this.id = Guid.NewGuid();
            this.name = "";
            this.memberCount = 0;
            this.members = new List<Guid>();
            this.posts = new List<Guid>();
            this.admins = new List<Guid>();
            this.sellingUsers = new List<Guid>();
            this.description = "";
            this.type = "";
            this.banner = "";
            this.creationDate = DateTime.Now;
            this.bigSellers = new List<Guid>();
            this.sellingUsers = new List<Guid>();
        }
        public Group(Guid id, string name, int memberCount, List<Guid> members, List<Guid> posts, List<Guid> admins, List<Guid> sellingUsers, string description, string type, string banner, DateTime creationDate, List<Guid> bigSellers, List<Guid> requestedUsers)

        {
            this.id = id;
            this.name = name;
            this.memberCount = memberCount;
            this.members = members;
            this.posts = posts;
            this.admins = admins;
            this.sellingUsers = sellingUsers;
            this.description = description;
            this.type = type;
            this.banner = banner;
            this.creationDate = creationDate;
            this.bigSellers = bigSellers;
            this.requestedUsers = requestedUsers;

        }
        

        public List<Guid> UsersWithSellRequests { get => this.sellingUsers; set => this.sellingUsers = value; }
        public void AddUserWithSellRequest(Guid userID)
        {
            this.sellingUsers.Add(userID);
        }
        public void RemoveUserWithSellRequest(Guid userID)
        {
            this.sellingUsers.Remove(userID);
        }

        public List<Guid> BigSellers { get => this.bigSellers; set => this.bigSellers = value; }
        public void AddBigSeller(Guid userID)
        {
            this.bigSellers.Add(userID);
        }
        public void RemoveBigSeller(Guid userID)
        {
            this.bigSellers.Remove(userID);
        }

    

        public Guid Id { get => id; }
        public string Name { get => name; set => name = value; }
        public int MemberCount { get => memberCount; }
        public List<Guid> Members { get => members; }
        public List<Guid> Posts { get => posts; }
        public List<Guid> Admins { get => admins; }
        public List<Guid> SellingUsers { get => sellingUsers; }

        public List<Guid> RequestedUsers { get => requestedUsers; }
        public string Description { get => description; set => description = value; }
        public string Type { get => type; set => type = value; }
        public string Banner { get => banner; set => banner = value; }
        public DateTime CreationDate { get => creationDate; }

        public void AddMember(Guid user)
        {
            if(!members.Contains(user))
            {
                members.Add(user);
                memberCount++;
            }
            else
                throw new Exception("User is already a member of this group");
        }
        public void RemoveMember(Guid user)
        {
            if(members.Contains(user))
            {
                members.Remove(user);
                memberCount--;
            }
            else
                throw new Exception("User is not a member of this group");
        }
        public void AddPost(Guid post)
        {
            posts.Add(post);
        }
        public void RemovePost(Guid post)
        {
            posts.Remove(post);
        }
        public void AddAdmin(Guid user)
        {
            if(!members.Contains(user))
                throw new Exception("User is not a member of this group");
            if(admins.Contains(user))
                throw new Exception("User is already an admin of this group");
            admins.Add(user);
        }
        public void removeAdmin(Guid user)
        {
            if(!members.Contains(user))
                throw new Exception("User is not a member of this group");
            if(!admins.Contains(user))
                throw new Exception("User is not an admin of this group");
            admins.Remove(user);
        }
        public void AddSellingUser(Guid user)
        {
            if(!members.Contains(user))
                throw new Exception("User is not a member of this group");
            if(sellingUsers.Contains(user))
                throw new Exception("User is already a selling user of this group");
            sellingUsers.Add(user);
        }
        public void RemoveSellingUser(Guid user)
        {
            if(!members.Contains(user))
                throw new Exception("User is not a member of this group");
            if(!sellingUsers.Contains(user))
                throw new Exception("User is not a selling user of this group");
            sellingUsers.Remove(user);
        }

        public void AddRequestedUser(Guid user)
        {
            if (!members.Contains(user))
                throw new Exception("User is not a member of this group");
            if (sellingUsers.Contains(user))
                throw new Exception("User is already a selling user of this group");
            sellingUsers.Add(user);
        }
        public void RemoveRequestedUser(Guid user)
        {
            if (!requestedUsers.Contains(user))
                throw new Exception("User is not a member of this group");
            if (!requestedUsers.Contains(user))
                throw new Exception("User is not a selling user of this group");
            requestedUsers.Remove(user);
        }

    }
}
