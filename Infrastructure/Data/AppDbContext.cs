using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<CheckStatus> CheckStatus { get; set; } = null!;
        public virtual DbSet<CheckType> CheckType { get; set; } = null!;
        public virtual DbSet<DispositionType> DispositionType { get; set; } = null!;
        public virtual DbSet<Location> Location { get; set; } = null!;
        public virtual DbSet<ServiceType> ServiceType { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionType { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
    }
}
