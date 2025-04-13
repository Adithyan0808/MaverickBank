using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Context
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Loan>? Loans { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<Branch>? Branches { get; set; }
        public DbSet<AccountTypeMaster>? AccountTypes { get; set; }
        public DbSet<LoanTypeMaster>? LoanTypes { get; set; }
        public DbSet<LoanStatusMaster>? LoanStatuses { get; set; }
        public DbSet<TransactionTypeMaster>? TransactionTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Customer-User Relationship
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserID);

            // Admin-User Relationship
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserID);

            // BankEmployee-User Relationship
            modelBuilder.Entity<BankEmployee>()
                .HasOne(be => be.User)
                .WithOne(u => u.BankEmployee)
                .HasForeignKey<BankEmployee>(be => be.UserID);

            // BankEmployee-Branch Relationship
            modelBuilder.Entity<BankEmployee>()
                .HasOne(be => be.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(be => be.BranchID);

            // Account-Customer Relationship
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerID);

            // Account-AccountTypeMaster Relationship
            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountType)
                .WithMany(at => at.Accounts)
                .HasForeignKey(a => a.AccountTypeID);

            // Account-Branch Relationship
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchID);

            modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.SourceAccount) // A Transaction has one Source Account
                        .WithMany(a => a.SourceTransactions) // An Account can be the source of many Transactions
                        .HasForeignKey(t => t.SourceAccountID) // Foreign key is SourceAccountID in Transaction
                         .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Transaction-DestinationAccount Relationship
            modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.DestinationAccount) // A Transaction has one Destination Account
                        .WithMany(a => a.DestinationTransactions) // An Account can be the destination of many Transactions
                        .HasForeignKey(t => t.DestinationAccountID)
                        .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Transaction-TransactionTypeMaster Relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeID);

            // Loan-Customer Relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.Loans)
                .HasForeignKey(l => l.CustomerID);

            // Loan-LoanTypeMaster Relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.LoanType)
                .WithMany(lt => lt.Loans)
                .HasForeignKey(l => l.LoanTypeID);

            // Loan-LoanStatusMaster Relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.LoanStatus)
                .WithMany(ls => ls.Loans)
                .HasForeignKey(l => l.LoanStatusID);
        }

    }
    
}
