using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace PizzaBox.Domain.Entities
{
    public partial class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
        }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cheese> Cheeses { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderP> OrderPizza { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Sauce> Sauces { get; set; }
        public virtual DbSet<StoreP> StorePizzas { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Toppings> Topping { get; set; }
        public virtual DbSet<Users> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9K2Q9T1\\SQLEXPRESS;Database=PizzaBoxDB; Trusted_Connection=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheese>(entity =>
            {

                entity.ToTable("Cheese", "PizzaBox");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Cheeses")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "PizzaBox");
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Crusts")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrderP>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PizzaId })
                    .HasName("PK__Order_Piz");

                entity.ToTable("Order_Pizzas", "PizzaBox");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Piz__order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Piz__pizza");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "PizzaBox");
                entity.Property(e => e.OrderId).HasColumnName("id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TotalCost)
                    .HasColumnName("total price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__store_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__user_id");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {

                entity.ToTable("Pizzas", "PizzaBox");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheeseId).HasColumnName("cheese id");

                entity.Property(e => e.CrustId).HasColumnName("crust id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SauceId).HasColumnName("sauce id");

                entity.Property(e => e.SizeId).HasColumnName("size id");

                entity.Property(e => e.ToppingId).HasColumnName("topping id");


                entity.HasOne(d => d.Cheese)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CheeseId)
                    .HasConstraintName("FK__Pizzas__cheese_id");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK__Pizzas__crust_id");

                entity.HasOne(d => d.Sauce)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.SauceId)
                    .HasConstraintName("FK__Pizzas__sauce_id");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Pizzas__size_id");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzasTopping)
                    .HasForeignKey(d => d.ToppingId)
                    .HasConstraintName("FK__Pizzas__topping");
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.ToTable("Sauces", "PizzaBox");
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Sauces")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Sizes", "PizzaBox");
                entity.HasIndex(e => e.SizeName)
                    .HasName("UQ__Sizes")
                    .IsUnique();

                entity.Property(e => e.SizeId).HasColumnName("id");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");
            });


            modelBuilder.Entity<StoreP>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.PizzaId })
                    .HasName("PK__Store_Piz");

                entity.ToTable("Store", "PizzaBox");

                entity.Property(e => e.StoreId).HasColumnName("store id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza id");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.StorePizzas)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Store_Piz");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StorePizzas)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Store_Piz__store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Stores", "PizzaBox");
                entity.HasIndex(e => e.StoreName)
                    .HasName("UQ__Stores")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("id");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.ToTable("Toppings", "PizzaBox");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Toppings")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "PizzaBox");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}



