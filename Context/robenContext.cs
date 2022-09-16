
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoginWebAPI.Data;
namespace LoginWebAPI.Context
{
    public partial class robenContext : DbContext
    {
        public robenContext()
        {
        }

        public robenContext(DbContextOptions<robenContext> options)
            : base(options)
        {
        }
        public DbSet<Reports>? Reports { get; set; }
        public virtual DbSet<SalesPreview> SalesPreviews { get; set; } = null!;
        public DbSet<Users>? UsersList { get; set; }
        public DbSet<SysLogin>? SysLogins { get; set; }
        public virtual DbSet<Activitiza> Activitizas { get; set; } = null!;
        public virtual DbSet<Boqlist> Boqlists { get; set; } = null!;
        public virtual DbSet<Boqmaterial> Boqmaterials { get; set; } = null!;
        public virtual DbSet<Casual> Casuals { get; set; } = null!;
        public virtual DbSet<Commodity> Commodities { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Firstweight> Firstweights { get; set; } = null!;
        public virtual DbSet<Fleetassigned> Fleetassigneds { get; set; } = null!;
        public virtual DbSet<Fuel> Fuels { get; set; } = null!;
        public virtual DbSet<Fuelsupply> Fuelsupplies { get; set; } = null!;
        public virtual DbSet<Machinery> Machineries { get; set; } = null!;
        public virtual DbSet<Mysupplier> Mysuppliers { get; set; } = null!;
        public virtual DbSet<Refuel> Refuels { get; set; } = null!;
        public virtual DbSet<Secondweight> Secondweights { get; set; } = null!;
        public virtual DbSet<Subtaska> Subtaskas { get; set; } = null!;
        public virtual DbSet<Taska> Taskas { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<Wbcustomerdeposit> Wbcustomerdeposits { get; set; } = null!;
        public virtual DbSet<Wbsaletb> Wbsaletbs { get; set; } = null!;
        public virtual DbSet<Weibrideaccount> Weibrideaccounts { get; set; } = null!;
        public virtual DbSet<Weighbridgesale> Weighbridgesales { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseMySql("server=localhost;uid=root;database=roben", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Activitiza>(entity =>
            {
                entity.ToTable("activitiza");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.ActCompCreteria).HasMaxLength(20);

                entity.Property(e => e.ActDependsOn).HasMaxLength(10);

                entity.Property(e => e.ActName).HasMaxLength(50);

                entity.Property(e => e.MyActivitiz)
                    .HasMaxLength(50)
                    .HasColumnName("MyACtivitiz");

                entity.Property(e => e.ProjectName).HasMaxLength(100);
            });

            modelBuilder.Entity<Boqlist>(entity =>
            {
                entity.ToTable("boqlist");

                entity.HasIndex(e => e.MatSerial, "MatSerial")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasMaxLength(240);

                entity.Property(e => e.MatSerial).HasMaxLength(12);

                entity.Property(e => e.Projectz).HasMaxLength(10);

                entity.Property(e => e.Uniti).HasMaxLength(8);
            });

            modelBuilder.Entity<Boqmaterial>(entity =>
            {
                entity.ToTable("boqmaterial");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MatSerial).HasMaxLength(10);

                entity.Property(e => e.Material).HasMaxLength(20);

                entity.Property(e => e.Uniti).HasMaxLength(10);
            });

            modelBuilder.Entity<Casual>(entity =>
            {
                entity.ToTable("casuals");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Department).HasMaxLength(20);

                entity.Property(e => e.Epin)
                    .HasMaxLength(10)
                    .HasColumnName("EPin");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(13)
                    .HasColumnName("EStatus");

                entity.Property(e => e.FirstName).HasMaxLength(15);

                entity.Property(e => e.MiddleName).HasMaxLength(16);

                entity.Property(e => e.NatId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("NatID");

                entity.Property(e => e.OvertimeRates).HasMaxLength(6);

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Supervisor).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(16);

                entity.Property(e => e.Wages).HasMaxLength(6);
            });

            modelBuilder.Entity<Commodity>(entity =>
            {
                entity.ToTable("commodities");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Materials)
                    .HasMaxLength(20)
                    .HasColumnName("materials");

                entity.Property(e => e.Matserial).HasMaxLength(10);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.Engineer).HasMaxLength(28);

                entity.Property(e => e.ProjectName).HasMaxLength(100);

                entity.Property(e => e.ProjectType).HasMaxLength(28);

                entity.Property(e => e.Resident).HasMaxLength(28);

                entity.Property(e => e.Road).HasMaxLength(100);

                entity.Property(e => e.Surveyor).HasMaxLength(28);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("drivers");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Driva).HasMaxLength(20);

                entity.Property(e => e.DriverId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("driverId");

                entity.Property(e => e.DriverPhone)
                    .HasMaxLength(12)
                    .HasColumnName("driverPhone");

                entity.Property(e => e.Plate).HasMaxLength(8);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(13)
                    .HasColumnName("country");

                entity.Property(e => e.County).HasMaxLength(20);

                entity.Property(e => e.Epin)
                    .HasMaxLength(16)
                    .HasColumnName("EPin");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(10)
                    .HasColumnName("EStatus");

                entity.Property(e => e.FirstName).HasMaxLength(15);

                entity.Property(e => e.Krapin)
                    .HasMaxLength(15)
                    .HasColumnName("KRAPin");

                entity.Property(e => e.MiddleName).HasMaxLength(15);

                entity.Property(e => e.NatId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("NatID");

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Profession).HasMaxLength(15);

                entity.Property(e => e.Role).HasMaxLength(15);

                entity.Property(e => e.Salary).HasColumnType("bigint(20)");

                entity.Property(e => e.SubCounty).HasMaxLength(20);

                entity.Property(e => e.Supervisor).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(15);

                entity.Property(e => e.Village).HasMaxLength(20);
            });

            modelBuilder.Entity<Firstweight>(entity =>
            {
                entity.ToTable("firstweight");

                entity.HasIndex(e => e.Ticket, "Ticket")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Driver).HasMaxLength(20);

                entity.Property(e => e.Material).HasMaxLength(20);

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Plate).HasMaxLength(10);

                entity.Property(e => e.Ticket).HasColumnType("int(11)");

                entity.Property(e => e.Time).HasMaxLength(10);
            });

            modelBuilder.Entity<Fleetassigned>(entity =>
            {
                entity.ToTable("fleetassigned");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Assigneed).HasMaxLength(20);

                entity.Property(e => e.Epin)
                    .HasMaxLength(16)
                    .HasColumnName("EPin");

                entity.Property(e => e.FullName).HasMaxLength(20);

                entity.Property(e => e.NatId).HasColumnName("NatID");

                entity.Property(e => e.Plate).HasMaxLength(10);

                entity.Property(e => e.Projectz).HasMaxLength(100);

                entity.Property(e => e.Statuss).HasMaxLength(15);
            });

            modelBuilder.Entity<Fuel>(entity =>
            {
                entity.ToTable("fuel");

                entity.HasIndex(e => e.Fuel1, "fuel")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fuel1)
                    .HasMaxLength(20)
                    .HasColumnName("fuel");
            });

            modelBuilder.Entity<Fuelsupply>(entity =>
            {
                entity.ToTable("fuelsupply");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Driva).HasMaxLength(20);

                entity.Property(e => e.FuelType).HasMaxLength(15);

                entity.Property(e => e.NumberPlate).HasMaxLength(8);

                entity.Property(e => e.SuppliedLitters).HasPrecision(10);

                entity.Property(e => e.Supplier).HasMaxLength(20);

                entity.Property(e => e.SupplierPhone).HasColumnType("bigint(12)");

                entity.Property(e => e.SupplyTime).HasMaxLength(6);

                entity.Property(e => e.VehicleId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Machinery>(entity =>
            {
                entity.ToTable("machinery");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ChasisNo).HasMaxLength(20);

                entity.Property(e => e.EngineNo).HasMaxLength(16);

                entity.Property(e => e.Logbook)
                    .HasMaxLength(5)
                    .HasColumnName("logbook");

                entity.Property(e => e.Mcondition)
                    .HasMaxLength(13)
                    .HasColumnName("MCondition");

                entity.Property(e => e.RegNo).HasMaxLength(20);

                entity.Property(e => e.UsedStatus).HasMaxLength(15);

                entity.Property(e => e.VehiclType).HasMaxLength(20);

                entity.Property(e => e.Yearz).HasMaxLength(6);
            });

            modelBuilder.Entity<Mysupplier>(entity =>
            {
                entity.ToTable("mysuppliers");

                entity.HasIndex(e => e.Plate, "Plate")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Driver).HasMaxLength(28);

                entity.Property(e => e.Plate).HasMaxLength(10);

                entity.Property(e => e.Supplier).HasMaxLength(50);

                entity.Property(e => e.SupplierPhone).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Refuel>(entity =>
            {
                entity.ToTable("refuel");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Driver).HasMaxLength(20);

                entity.Property(e => e.FuelType).HasMaxLength(12);

                entity.Property(e => e.NumberPlate).HasMaxLength(10);

                entity.Property(e => e.RefuelTime).HasMaxLength(10);

                entity.Property(e => e.RefueliedLitters).HasPrecision(10);

                entity.Property(e => e.Refuelier).HasMaxLength(16);

                entity.Property(e => e.VehicleId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Secondweight>(entity =>
            {
                entity.ToTable("secondweight");

                entity.HasIndex(e => e.Ticket, "Ticket")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FirstWeightCode).HasColumnType("int(11)");

                entity.Property(e => e.Sweight).HasColumnName("SWeight");

                entity.Property(e => e.Ticket).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Subtaska>(entity =>
            {
                entity.ToTable("subtaska");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ActId).HasColumnType("int(11)");

                entity.Property(e => e.Casuals).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Machines).HasMaxLength(100);

                entity.Property(e => e.Materials).HasMaxLength(100);

                entity.Property(e => e.RdSection).HasMaxLength(50);

                entity.Property(e => e.SubTaski).HasMaxLength(60);

                entity.Property(e => e.Trucks).HasMaxLength(100);
            });

            modelBuilder.Entity<Taska>(entity =>
            {
                entity.ToTable("taskas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ActId).HasColumnType("int(11)");

                entity.Property(e => e.Activitiz).HasMaxLength(20);

                entity.Property(e => e.TasCompCreteria).HasMaxLength(50);

                entity.Property(e => e.TasDependsOn).HasMaxLength(5);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ChasisNo).HasMaxLength(20);

                entity.Property(e => e.EngineNo).HasMaxLength(16);

                entity.Property(e => e.Logbook)
                    .HasMaxLength(5)
                    .HasColumnName("logbook");

                entity.Property(e => e.Plate).HasMaxLength(20);

                entity.Property(e => e.UsedStatus).HasMaxLength(15);

                entity.Property(e => e.Vcondition)
                    .HasMaxLength(13)
                    .HasColumnName("VCondition");

                entity.Property(e => e.VehiclType).HasMaxLength(20);

                entity.Property(e => e.Yearz).HasMaxLength(6);
            });

            modelBuilder.Entity<Wbcustomerdeposit>(entity =>
            {
                entity.ToTable("wbcustomerdeposit");

                entity.HasIndex(e => new { e.Phone, e.Plate }, "Phone")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AccountNo).HasMaxLength(16);

                entity.Property(e => e.Driva).HasMaxLength(20);

                entity.Property(e => e.Material).HasMaxLength(20);

                entity.Property(e => e.MpesaUid).HasMaxLength(15);

                entity.Property(e => e.PaidOn).HasMaxLength(20);

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Plate).HasMaxLength(10);
            });
            modelBuilder.Entity<SalesPreview>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("salespreview");
            });

            modelBuilder.Entity<Wbsaletb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wbsaletb");

                entity.Property(e => e.AccountNo).HasMaxLength(16);

                entity.Property(e => e.Driver).HasMaxLength(20);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Material).HasMaxLength(20);

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Plate).HasMaxLength(10);

                entity.Property(e => e.Sweight).HasColumnName("SWeight");

                entity.Property(e => e.Ticket).HasColumnType("int(11)");

                entity.Property(e => e.Time).HasMaxLength(10);
            });

            modelBuilder.Entity<Weibrideaccount>(entity =>
            {
                entity.ToTable("weibrideaccount");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AccountNo).HasMaxLength(13);

                entity.Property(e => e.Plate).HasMaxLength(10);
            });

            modelBuilder.Entity<Weighbridgesale>(entity =>
            {
                entity.ToTable("weighbridgesales");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Driva).HasMaxLength(20);

                entity.Property(e => e.Material).HasMaxLength(16);

                entity.Property(e => e.Phone).HasColumnType("bigint(20)");

                entity.Property(e => e.Plate).HasMaxLength(10);

                entity.Property(e => e.Ticket).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
