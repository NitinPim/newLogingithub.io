using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.VMmodel;

namespace BusinessRepository
{
    public interface IRepository
    {
        Status AddPanchayat(VMPanchaayat vmpanchayat);

        List<VMPanchaayat> getPanchayatList();

        VMPanchaayat getPanchayatbyid(int paanid);

        Status deletePanchayat(int id);
    }
}
