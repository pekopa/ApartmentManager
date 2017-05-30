using System;

namespace ApartmentManager.Model
{
    public class ChangeComment
    {
        public int CommentId { get; set; }
        public int ChangeId { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
