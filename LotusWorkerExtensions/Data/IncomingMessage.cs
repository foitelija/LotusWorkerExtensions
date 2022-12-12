using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusWorkerExtensions.Data
{
    public class IncomingMessage
    {
        [Key]
        public int MessageId { get; set; }
        public int Age1 { get; set; }
        public int Age2 { get; set; }
        public int Age3 { get; set; }
    }
}
