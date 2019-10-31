using System;

namespace WeddingPlanner.Models
{
    public class Association
    {
        public int AssociationId { get; set; }
        public int WeddingId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Wedding Wedding { get; set; }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public Association()
        {
            // constructor
        }

        public Association(User user, int userId, Wedding wedding, int weddingId)
        {
            User = user;
            UserId = userId;
            Wedding = wedding;
            WeddingId = weddingId;
        }
    }
}