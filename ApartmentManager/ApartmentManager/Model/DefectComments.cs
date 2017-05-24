using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Model
{
    public class DefectComments
    {
        
        public int CommentId { get; set; }
        public int DefectId { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
