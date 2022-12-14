using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<ShopType, int, ShopType> ShopTypeDataAccess()
        {
            return new ShopTypeRepo();
        }
    }
}