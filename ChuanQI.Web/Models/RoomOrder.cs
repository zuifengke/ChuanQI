using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChuanQi.Web.Models
{

    public class RoomOrder
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Telphone { get; set; }
        public string School { get; set; }
        public string ExamType { get; set; }
        public DateTime? SubmitTime { get; set; }


    }
}
