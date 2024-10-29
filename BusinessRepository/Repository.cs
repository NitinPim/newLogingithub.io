using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using ViewModel.VMmodel;

namespace BusinessRepository
{
    public class Repository : IRepository
    {
        IndiaEntities db = new IndiaEntities();
        Status status = new Status();

        public Status AddPanchayat(VMPanchaayat vmpanchayat)
        {
            try
            {
                Panchaayat paan = db.Panchaayats.Where(x => x.P_ID == vmpanchayat.P_ID).FirstOrDefault();

                if(paan == null)
                {
                    paan = new Panchaayat();
                    paan.P_ID = vmpanchayat.P_ID;
                    paan.P_District = vmpanchayat.P_District;
                    paan.P_Taluka = vmpanchayat.P_Taluka;
                    paan.P_Panchayat = vmpanchayat.P_Panchayat;

                    paan.IsActive = true;

                    paan.createdBy = 1;
                    paan.createdDate = DateTime.Now;
                    db.Panchaayats.Add(paan);        //=========Method for changes====
                    db.SaveChanges();

                    status.code = System.Net.HttpStatusCode.OK;
                    status.message = "Meeting Location Added Successfully";

                }
                else
                {
                    paan.P_ID = vmpanchayat.P_ID;
                    paan.P_District = vmpanchayat.P_District;
                    paan.P_Taluka = vmpanchayat.P_Taluka;
                    paan.P_Panchayat = vmpanchayat.P_Panchayat;

                    paan.IsActive = true;

                    paan.modifiedBy = 1;
                    paan.modifiedDate = DateTime.Now;

                    db.Entry(paan).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    status.code = System.Net.HttpStatusCode.OK;                    status.message = "Data Update successfully";
                }

            }
            catch(Exception ex)
            {
                status.code = System.Net.HttpStatusCode.BadRequest;
                status.message = "Errorrrrrrrrrr................";
                throw;
            }
            return status;
        }

        //=======list==============
        public List<VMPanchaayat> getPanchayatList()
        {
            List<VMPanchaayat> vmpaan = new List<VMPanchaayat>();
            try
            {
                vmpaan = (from e in db.Panchaayats
                             where e.IsActive == true
                             select new VMPanchaayat
                             {
                                 P_ID = e.P_ID,
                                 P_District = e.P_District,
                                 P_Taluka = e.P_Taluka,
                                P_Panchayat = e.P_Panchayat,

                             }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return vmpaan;
        }


        //===edit================

        public VMPanchaayat getPanchayatbyid(int paanid)
        {
            VMPanchaayat vmpaan = new VMPanchaayat();
            try
            {
                vmpaan = (from e in db.Panchaayats
                             where
                              e.P_ID == paanid
                             select new VMPanchaayat
                             {
                                 P_ID = e.P_ID,
                                 P_District = e.P_District,
                                 P_Taluka = e.P_Taluka,
                                 P_Panchayat = e.P_Panchayat,


                             }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                status.code = System.Net.HttpStatusCode.BadGateway;
                throw;
            }
            return vmpaan;
        }

        ////==========delete=======

        public Status deletePanchayat(int id)
        {
            try
            {
                var delete = db.Panchaayats.Where(x => x.P_ID == id).FirstOrDefault();
                if (delete != null)
                {
                    delete.IsActive = false;
                    db.Entry(delete).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    status.code = System.Net.HttpStatusCode.OK;
                    status.message = "Delete Sucessfully";
                }
                else
                {
                    status.code = System.Net.HttpStatusCode.OK; ;
                    status.message = " Review not deleted";
                }

            }
            catch (Exception ex)
            {
                status.code = System.Net.HttpStatusCode.BadRequest;
                status.isErrorInService = true;
                status.message = " Something went wrong, please try again later.";
                return status;
            }
            return status;
        }









    }
}
