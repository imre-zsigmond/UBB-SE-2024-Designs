using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    class InterestStatus
    {
        private Guid userId;
        private Guid postId;
        private Guid interestId;
        private bool interested;

        public InterestStatus(Guid userId, Guid postId, bool interested)
        {
            this.userId = userId;
            this.postId = postId;
            this.interestId = new Guid();
            this.interested = interested;
        }

        public InterestStatus()
        {
            this.userId = Guid.NewGuid();
            this.postId = Guid.NewGuid();
            this.interestId = new Guid(userId.ToString() + postId.ToString());
            this.interested = false;
        }

        public Guid UserId { get => userId; }
        public Guid PostId { get => postId; }
        public Guid InterestId { get => interestId; }
        public bool Interested { get => interested; }
        public bool toggleInterested()
        {
            interested = !interested;
            return interested;
        }



    }
}
