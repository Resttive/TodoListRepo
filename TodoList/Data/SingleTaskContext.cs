using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class SingleTaskContext : DbContext
    {
        public SingleTaskContext (DbContextOptions<SingleTaskContext> options)
            : base(options)
        {
        }

        public DbSet<TodoList.Models.SingleTaskModel> SingleTaskModel { get; set; }
    }
}
