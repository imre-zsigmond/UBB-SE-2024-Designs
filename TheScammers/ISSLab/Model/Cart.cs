using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Cart
    {
        private Guid groupId;
        private Guid userId;
        private List<Guid> fixedPosts;

        public Cart(Guid groupId, Guid userId, List<Guid> posts)
        {
            this.groupId = groupId;
            this.userId = userId;
            this.fixedPosts = posts;
        }
        public Cart()
        {
            this.groupId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.fixedPosts = new List<Guid>();


        }
        public Cart(Guid groupId, Guid userId)
        {
            this.groupId = groupId;
            this.userId = userId;
            this.fixedPosts = new List<Guid>();
        }

        public Guid GroupId { get => groupId; }
        public Guid UserId { get => userId; }
        public List<Guid> Posts { get => fixedPosts; }

        void addPostToCart(Guid post)
        {
            if (this.fixedPosts.Contains(post))
                throw new Exception("Post already in cart");
            fixedPosts.Add(post);
        }
        void removePostFromCart(Guid post)
        {
            if (!this.fixedPosts.Contains(post))
                throw new Exception("Post not in cart");
            fixedPosts.Remove(post);
        }


    }
}
