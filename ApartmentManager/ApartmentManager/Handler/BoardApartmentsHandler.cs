using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManager.ViewModel;

namespace ApartmentManager.Handler
{
     class BoardApartmentsHandler
    {
        public ApartmentsViewModel ApartmentsViewModel { get; set; }

        public BoardApartmentsHandler(ApartmentsViewModel apartmentsViewModel)
        {
            ApartmentsViewModel = apartmentsViewModel;
        }
    }
}
