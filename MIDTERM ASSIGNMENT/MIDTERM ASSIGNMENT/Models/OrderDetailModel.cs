using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDTERM_ASSIGNMENT.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public int EmployeeId { get; set; }

    }
}