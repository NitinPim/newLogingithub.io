using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.VMmodel
{
    public class VMPanchaayat
    {
        public int P_ID { get; set; }
        public string P_District { get; set; }
        public string P_Taluka { get; set; }
        public string P_Panchayat { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
    }
}
