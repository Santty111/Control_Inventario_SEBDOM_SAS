using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Control_Inventario_SEBDOM_SAS.Models;

namespace Control_Inventario_SEBDOM_SAS.Data
{
    public class Control_Inventario_SEBDOM_SASContext : DbContext
    {
        public Control_Inventario_SEBDOM_SASContext (DbContextOptions<Control_Inventario_SEBDOM_SASContext> options)
            : base(options)
        {
        }

        
        public DbSet<Control_Inventario_SEBDOM_SAS.Models.Balance> Balance { get; set; } = default!;
    }
}
