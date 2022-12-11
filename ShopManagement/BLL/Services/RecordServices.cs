using BLL.BEnt;
using DAL.Database;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecordServices
    {
        public static List<RecordsModel>GetUserRecords(int id)
        {
            var data = RecordsRepo.GetUserRecords(id);
            List<RecordsModel> records = new List<RecordsModel>();  
            foreach (Record record in data)
            {
                RecordsModel rs = new RecordsModel();
                rs.Id = record.Id;
                rs.UserId = record.UserId;
                rs.ProductId=record.ProductId;
                rs.Tot_amount = record.Tot_amount;
                rs.ProductQuantity = record.ProductQuantity;
                records.Add(rs);
            }
            return records;
        }

        public static int EditRecords(RecordsModel rm)
        {
            Record r = new Record();
            r.Id = rm.Id;
            r.UserId = rm.UserId;
            r.ProductId = rm.ProductId;
            r.Tot_amount = rm.Tot_amount;   
            r.ProductQuantity = rm.ProductQuantity;
            return RecordsRepo.EditRecords(r);
        }

        public static int DeleteRecords(RecordsModel rm)
        {
            Record r = new Record();
            r.Id = rm.Id;
            r.UserId = rm.UserId;
            r.ProductId = rm.ProductId;
            r.Tot_amount = rm.Tot_amount;
            r.ProductQuantity = rm.ProductQuantity;
            return RecordsRepo.deleteRecords(r);
        }

    }
}
