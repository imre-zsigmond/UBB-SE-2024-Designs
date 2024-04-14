using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class Report
    {
        private Guid id;
        private Guid userId;
        private Guid postId;
        private string reason;
        private DateTime date;

        public Report(Guid userId, Guid postId, string reason)
        {
            this.id = new Guid(userId.ToString() + postId.ToString());
            this.userId = userId;
            this.postId = postId;
            this.reason = reason;
            this.date = DateTime.Now;
        }

        public Report(Guid id, Guid userId, Guid postId, string reason, DateTime date)
        {
            this.id = id;
            this.userId = userId;
            this.postId = postId;
            this.reason = reason;
            this.date = date;
        }

        public Report()
        {
            this.id = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.postId = Guid.NewGuid();
            this.reason = "";
            this.date = DateTime.Now;
        }

        public Guid Id { get => id; }
        public Guid UserId { get => userId; }
        public Guid PostId { get => postId; }
        public string Reason { get => reason; set => reason = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
