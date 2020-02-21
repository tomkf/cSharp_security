using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace roleDemo.Data {
    public class ToDo
    {
        [Key] // Enables auto-increment.
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }

    public class InvoiceVM
{
        internal string Id;

        [Key]
    public int InvoiceID { get; set; }
    public string UserName { get; set; }
    public DateTime Created { get; set; }
    public decimal Total { get; set; }

    // Parent.
    public virtual CustomUser CustomnUser { get; set; }
}

public class CustomUser
{
    [Key]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    // Child
    public virtual ICollection<InvoiceVM> Invoices { get; set; }
}

public class ApplicationDbContext : IdentityDbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define entity collections.
    public DbSet<InvoiceVM> Invoices { get; set; }
    public DbSet<CustomUser> CustomUsers { get; set; }

    public DbSet<ToDo> ToDos { get; set; }


        // Use this method to define composite primary keys and foreign keys.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // required.
        base.OnModelCreating(modelBuilder);

        //-------------------------------------------------------
        // *** Define composite primary keys here. ***

        // This is sample syntax for defining a primary key.
        // modelBuilder.Entity<ProductSupplier>()
        //             .HasKey(ps => new { ps.ProductID, ps.SupplierID });

        //-------------------------------------------------------
        // *** Define composite foreign keys here. ***
        modelBuilder.Entity<InvoiceVM>()
            .HasOne(c => c.CustomnUser)
            .WithMany(c => c.Invoices)
            .HasForeignKey(fk => new { fk.UserName })
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ToDo>().HasData(
                new { Id = 1, Description = "Finish work", IsComplete = false },
                new { Id = 2, Description = "Go to gym", IsComplete = false }
         );
     }
  }
}
