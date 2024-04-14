using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Favorites
    {
        private Guid userId;
        private Guid groupId;
        private List<Guid> posts;
        public Favorites(Guid userId, Guid groupId)
        {
            this.userId = userId;
            this.groupId = groupId;
            this.posts = new List<Guid>();
        }

        public Favorites(Guid userId, Guid groupId, List<Guid> posts)
        {
            this.userId = userId;
            this.groupId = groupId;
            this.posts = posts;
        }

        public Favorites()
        {
            this.userId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
            this.posts = new List<Guid>();
        }

        public Guid UserId { get => userId; }
        public Guid GroupId { get => groupId; }
        public List<Guid> Posts { get => posts; }
        public void addPost(Guid post)
        {
            if(this.posts.Contains(post))
                throw new Exception("Post already in favorites");
            posts.Add(post);
        }
        public void removePost(Guid post)
        {
            if(!this.posts.Contains(post))
                throw new Exception("Post not in favorites");
            posts.Remove(post);
        }
    }
}
