using System;

namespace ApartmentManager.Model
{
    public class DefectComment
    {
        public int CommentId { get; set; }
        public int DefectId { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
