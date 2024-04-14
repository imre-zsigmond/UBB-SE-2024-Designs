using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Comment
    {
        private Guid id;
        private string content;
        private Guid userId;
        private List<Comment> replies;

        public Comment(Guid userId, string content)
        {
            this.id = Guid.NewGuid();
            this.userId = userId;
            this.content = content;
            this.replies = new List<Comment>();
        }
        public Comment()
        {
            this.id = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.content = "";
            this.replies = new List<Comment>();
        }

        public Comment(Guid id, Guid userId, string content, List<Comment> replies)
        {
            this.id = id;
            this.userId = userId;
            this.content = content;
            this.replies = replies;
        }

        public Guid Id { get => id; }
        public Guid UserId { get => userId; }
        public string Content { get => content; set => content = value; }
        public List<Comment> Replies { get => replies; }
        public void addReply(Comment reply)
        {
            replies.Add(reply); 
        }

    }
}
