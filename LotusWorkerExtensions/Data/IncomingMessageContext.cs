using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusWorkerExtensions.Data
{
    public class IncomingMessageContext :DbContext
    {
        public IncomingMessageContext(DbContextOptions<IncomingMessageContext> options) : base(options)
        {

        }

        public DbSet<IncomingMessage> incomingMessages { get; set; }

    }
}
