using System;
using System.Collections.Generic;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public partial class GneProjectContext : DbContext
{
    public GneProjectContext()
    {
    }

    public GneProjectContext(DbContextOptions<GneProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<ApprovalDetail> ApprovalDetails { get; set; }

    public virtual DbSet<ApprovalLevel> ApprovalLevels { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ComplienceThreshold> ComplienceThresholds { get; set; }

    public virtual DbSet<CounterParty> CounterParties { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<GivenDetail> GivenDetails { get; set; }

    public virtual DbSet<GiverAttachment> GiverAttachments { get; set; }

    public virtual DbSet<GiverModel> GiverModels { get; set; }

    public virtual DbSet<GiverRecipient> GiverRecipients { get; set; }

    public virtual DbSet<PersonType> PersonTypes { get; set; }

    public virtual DbSet<ReceiverAttachment> ReceiverAttachments { get; set; }

    public virtual DbSet<ReceiverDetail> ReceiverDetails { get; set; }

    public virtual DbSet<ReceiverModel> ReceiverModels { get; set; }

    public virtual DbSet<ReceiverRecipient> ReceiverRecipients { get; set; }

    public virtual DbSet<Threshold> Thresholds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LLCENBA;Database=GneDb2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.ToTable("Approval");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReqEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApprovalDetail>(entity =>
        {
            entity.HasKey(e => e.ApprovalDetailId).HasName("PK_Approval Details");

            entity.Property(e => e.ApprovarName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApprovarTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusOn).HasColumnType("datetime");

            entity.HasOne(d => d.Approval).WithMany(p => p.ApprovalDetails)
                .HasForeignKey(d => d.ApprovalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approval Details_Approval");
        });

        modelBuilder.Entity<ApprovalLevel>(entity =>
        {
            entity.ToTable("ApprovalLevel");

            entity.Property(e => e.ApprovalPosition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ComplienceThreshold>(entity =>
        {
            entity.ToTable("ComplienceThreshold");

            entity.Property(e => e.Approve)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonType).WithMany(p => p.ComplienceThresholds)
                .HasForeignKey(d => d.PersonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComplienceThreshold_PersonType");
        });

        modelBuilder.Entity<CounterParty>(entity =>
        {
            entity.ToTable("CounterParty");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PartyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.StatusBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.HasIndex(e => e.CurrencyCode, "UQ__Currency__408426BF97EFD46E").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Symbol)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GivenDetail>(entity =>
        {
            entity.HasKey(e => e.GivenDetailsId);

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.GivenDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GivenDetails_Category");

            entity.HasOne(d => d.Given).WithMany(p => p.GivenDetails)
                .HasForeignKey(d => d.GivenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GivenDetails_GiverModel");
        });

        modelBuilder.Entity<GiverAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK_AttachmentTable");

            entity.ToTable("GiverAttachment");

            entity.Property(e => e.AttachmentPath)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AttachmentTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Giver).WithMany(p => p.GiverAttachments)
                .HasForeignKey(d => d.GiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiverAttachment_GiverModel");
        });

        modelBuilder.Entity<GiverModel>(entity =>
        {
            entity.ToTable("GiverModel");

            entity.HasIndex(e => e.FormCode, "UQ__GiverMod__F69A6BF7AD2099A0").IsUnique();

            entity.Property(e => e.BussinessStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ComplienceStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GivenDate).HasColumnType("datetime");
            entity.Property(e => e.GiverName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GiverOrganization)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GiverSubOrganization)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsSupplyChainVpapproved).HasColumnName("IsSupplyChainVPApproved");

            entity.HasOne(d => d.Currency).WithMany(p => p.GiverModels)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiverModel_Currency");
        });

        modelBuilder.Entity<GiverRecipient>(entity =>
        {
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Counterparty).WithMany(p => p.GiverRecipients)
                .HasForeignKey(d => d.CounterpartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiverRecipients_CounterParty");

            entity.HasOne(d => d.Giver).WithMany(p => p.GiverRecipients)
                .HasForeignKey(d => d.GiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiverRecipients_GiverModel");

            entity.HasOne(d => d.PersonType).WithMany(p => p.GiverRecipients)
                .HasForeignKey(d => d.PersonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiverRecipients_PersonType1");
        });

        modelBuilder.Entity<PersonType>(entity =>
        {
            entity.HasKey(e => e.PersonTypeId).HasName("PK_PersonType1");

            entity.ToTable("PersonType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PersonType");
        });

        modelBuilder.Entity<ReceiverAttachment>(entity =>
        {
            entity.ToTable("ReceiverAttachment");

            entity.Property(e => e.AttachmentPath)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AttachmentTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Receiver).WithMany(p => p.ReceiverAttachments)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverAttachment_ReceiverModel");
        });

        modelBuilder.Entity<ReceiverDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ReceiverDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverDetails_Category");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ReceiverDetails)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverDetails_ReceiverModel");
        });

        modelBuilder.Entity<ReceiverModel>(entity =>
        {
            entity.HasKey(e => e.ReceiverId);

            entity.ToTable("ReceiverModel");

            entity.HasIndex(e => e.FormCode, "UQ__Receiver__F69A6BF739D585C9").IsUnique();

            entity.Property(e => e.BussinessStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.ComplienceStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FormCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsSupplyChainVpapproved).HasColumnName("IsSupplyChainVPApproved");
            entity.Property(e => e.ReceiveDate).HasColumnType("datetime");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CounterParty).WithMany(p => p.ReceiverModels)
                .HasForeignKey(d => d.CounterPartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverModel_CounterParty");

            entity.HasOne(d => d.Currency).WithMany(p => p.ReceiverModels)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverModel_Currency");

            entity.HasOne(d => d.PersonType).WithMany(p => p.ReceiverModels)
                .HasForeignKey(d => d.PersonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverModel_PersonType");
        });

        modelBuilder.Entity<ReceiverRecipient>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Receiver).WithMany(p => p.ReceiverRecipients)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverRecipients_ReceiverModel");
        });

        modelBuilder.Entity<Threshold>(entity =>
        {
            entity.ToTable("Threshold");

            entity.Property(e => e.CategoryType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Approvallevel).WithMany(p => p.Thresholds)
                .HasForeignKey(d => d.ApprovallevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Threshold_ApprovalLevel");

            entity.HasOne(d => d.PersonType).WithMany(p => p.Thresholds)
                .HasForeignKey(d => d.PersonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Threshold_PersonType1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.UserEmail, "UQ__User__08638DF8459C3400").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserDepartment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Senior).WithMany(p => p.InverseSenior)
                .HasForeignKey(d => d.SeniorId)
                .HasConstraintName("FK_User_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
