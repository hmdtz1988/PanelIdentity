using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Model;

public partial class PanelIdentityContext : DbContext
{
    public PanelIdentityContext()
    {
    }

    public PanelIdentityContext(DbContextOptions<PanelIdentityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<LoginStatus> LoginStatuses { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAccountType> ProjectAccountTypes { get; set; }

    public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

    public virtual DbSet<QRLoginTransaction> QRLoginTransactions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<RoleServiceItem> RoleServiceItems { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceAction> ServiceActions { get; set; }

    public virtual DbSet<ServiceItem> ServiceItems { get; set; }

    public virtual DbSet<TempRole> TempRoles { get; set; }

    public virtual DbSet<TempRolePermission> TempRolePermissions { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantProject> TenantProjects { get; set; }

    public virtual DbSet<TenantWalletTransaction> TenantWalletTransactions { get; set; }

    public virtual DbSet<UserDevice> UserDevices { get; set; }

    public virtual DbSet<UserInRole> UserInRoles { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    public virtual DbSet<UserServiceItem> UserServiceItems { get; set; }

    public virtual DbSet<UserTenant> UserTenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=188.213.196.174;Database=PanelIdentity;user id=sa;password=%Hmd0914%;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.ToTable("AccountType");

            entity.Property(e => e.AccountTypeId).ValueGeneratedNever();
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(100);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.FlagUrl).HasMaxLength(500);
            entity.Property(e => e.PhoneCode).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.Currency).WithMany(p => p.Countries)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Country_Currency");

            entity.HasOne(d => d.Language).WithMany(p => p.Countries)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Country_Language");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(5);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.LanguageId).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.LoginHistoryId).HasName("PK__LoginHistory");

            entity.ToTable("LoginHistory");

            entity.Property(e => e.AccessToken).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Chanel).HasMaxLength(50);
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.LoginDateTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserHostAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Version).HasMaxLength(50);

            entity.HasOne(d => d.LoginStatus).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.LoginStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoginHistory_LoginStatus");

            entity.HasOne(d => d.Project).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoginHistory_Project");

            entity.HasOne(d => d.Tenant).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_LoginHistory_Tenant");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.UserInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoginHistory_UserInfo");
        });

        modelBuilder.Entity<LoginStatus>(entity =>
        {
            entity.HasKey(e => e.LoginStatusId).HasName("PK__LoginSta__2D041BA01773ECFD");

            entity.ToTable("LoginStatus");

            entity.HasIndex(e => e.TitleFa, "UQ_LoginStatus_TitleFa").IsUnique();

            entity.Property(e => e.LoginStatusId).ValueGeneratedNever();
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(100);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();
            entity.Property(e => e.Icon).HasMaxLength(500);
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(50);
            entity.Property(e => e.TitleEn).HasMaxLength(100);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(500);

            entity.HasOne(d => d.ProjectCategory).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectCategoryId)
                .HasConstraintName("FK_Project_ProjectCategory");
        });

        modelBuilder.Entity<ProjectAccountType>(entity =>
        {
            entity.ToTable("ProjectAccountType");

            entity.Property(e => e.Amount).HasColumnType("money");

            entity.HasOne(d => d.AccountType).WithMany(p => p.ProjectAccountTypes)
                .HasForeignKey(d => d.AccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAccountType_AccountType");

            entity.HasOne(d => d.Currency).WithMany(p => p.ProjectAccountTypes)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAccountType_Currency");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectAccountTypes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAccountType_Project");
        });

        modelBuilder.Entity<ProjectCategory>(entity =>
        {
            entity.ToTable("ProjectCategory");

            entity.Property(e => e.ProjectCategoryId).ValueGeneratedNever();
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(50);
            entity.Property(e => e.TitleEn).HasMaxLength(100);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);
        });

        modelBuilder.Entity<QRLoginTransaction>(entity =>
        {
            entity.HasKey(e => e.QRLoginTransactionId).HasName("PK_QRLoginTransactions");

            entity.ToTable("QRLoginTransaction");

            entity.Property(e => e.DeviceKey).HasMaxLength(256);
            entity.Property(e => e.DeviceLocalKey).HasMaxLength(256);
            entity.Property(e => e.TransactionToken).HasMaxLength(256);

            entity.HasOne(d => d.UserInfo).WithMany(p => p.QRLoginTransactions)
                .HasForeignKey(d => d.UserInfoId)
                .HasConstraintName("FK_QRLoginTransaction_UserInfo");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_dbo.Roles");

            entity.ToTable("Role");

            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Project).WithMany(p => p.Roles)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Project");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Roles)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Tenant");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK_dbo.RolePermissions");

            entity.ToTable("RolePermission");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");

            entity.HasOne(d => d.ServiceAction).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.ServiceActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_ServiceAction");

            entity.HasOne(d => d.Tenant).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Tenant");
        });

        modelBuilder.Entity<RoleServiceItem>(entity =>
        {
            entity.ToTable("RoleServiceItem");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK_Services");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).ValueGeneratedNever();
            entity.Property(e => e.Controller).HasMaxLength(200);
            entity.Property(e => e.Icon).HasMaxLength(500);
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(100);
            entity.Property(e => e.TitleEn).HasMaxLength(100);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Service_Service");

            entity.HasOne(d => d.Project).WithMany(p => p.Services)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Service_Project");
        });

        modelBuilder.Entity<ServiceAction>(entity =>
        {
            entity.HasKey(e => e.ServiceActionId).HasName("PK_ServiceActions");

            entity.ToTable("ServiceAction");

            entity.Property(e => e.ApiController).HasMaxLength(256);
            entity.Property(e => e.ApiService).HasMaxLength(256);
            entity.Property(e => e.TitleAr).HasMaxLength(256);
            entity.Property(e => e.TitleDu).HasMaxLength(256);
            entity.Property(e => e.TitleEn).HasMaxLength(256);
            entity.Property(e => e.TitleFa).HasMaxLength(256);
            entity.Property(e => e.TitleFr).HasMaxLength(256);
            entity.Property(e => e.TitleTr).HasMaxLength(256);

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceActions)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceAction_Service");
        });

        modelBuilder.Entity<ServiceItem>(entity =>
        {
            entity.ToTable("ServiceItem");

            entity.Property(e => e.PropertyName1).HasMaxLength(150);
            entity.Property(e => e.PropertyName2).HasMaxLength(150);
            entity.Property(e => e.PropertyValue2).HasMaxLength(150);

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceItems)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceItem_Service");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ServiceItems)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceItem_Tenant");
        });

        modelBuilder.Entity<TempRole>(entity =>
        {
            entity.ToTable("TempRole");

            entity.Property(e => e.TempRoleId).ValueGeneratedNever();
            entity.Property(e => e.TitleAr).HasMaxLength(100);
            entity.Property(e => e.TitleDu).HasMaxLength(100);
            entity.Property(e => e.TitleEn).HasMaxLength(100);
            entity.Property(e => e.TitleFa).HasMaxLength(100);
            entity.Property(e => e.TitleFr).HasMaxLength(100);
            entity.Property(e => e.TitleTr).HasMaxLength(100);
        });

        modelBuilder.Entity<TempRolePermission>(entity =>
        {
            entity.HasKey(e => e.TempRolePermissionId).HasName("PK_dbo.TempRolePermissions");

            entity.ToTable("TempRolePermission");

            entity.HasOne(d => d.ServiceAction).WithMany(p => p.TempRolePermissions)
                .HasForeignKey(d => d.ServiceActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TempRolePermission_ServiceAction");

            entity.HasOne(d => d.TempRole).WithMany(p => p.TempRolePermissions)
                .HasForeignKey(d => d.TempRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TempRolePermission_TempRole");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.ToTable("Tenant");

            entity.Property(e => e.InviteKey)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(500);

            entity.HasOne(d => d.Country).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Tenant_Country");

            entity.HasOne(d => d.Currency).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_Tenant_Currency");

            entity.HasOne(d => d.Language).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Tenant_Language");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Tenant_Tenant");
        });

        modelBuilder.Entity<TenantProject>(entity =>
        {
            entity.HasKey(e => e.TenantProjectId).HasName("PK_TenentProject");

            entity.ToTable("TenantProject");

            entity.HasOne(d => d.Project).WithMany(p => p.TenantProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TenantProject_Project");

            entity.HasOne(d => d.Tenant).WithMany(p => p.TenantProjects)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TenantProject_Tenant");
        });

        modelBuilder.Entity<TenantWalletTransaction>(entity =>
        {
            entity.ToTable("TenantWalletTransaction");

            entity.Property(e => e.AuthCode).HasMaxLength(50);
            entity.Property(e => e.BatchNo).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Credit).HasColumnType("money");
            entity.Property(e => e.Debit).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.HostDate).HasMaxLength(50);
            entity.Property(e => e.PanCode).HasMaxLength(50);
            entity.Property(e => e.RefrenceNumber).HasMaxLength(200);
            entity.Property(e => e.ResultCode).HasMaxLength(10);
            entity.Property(e => e.ResultDetail).HasMaxLength(500);
            entity.Property(e => e.TransactionNumber).HasMaxLength(200);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_TenantWalletTransaction_TenantWalletTransaction");

            entity.HasOne(d => d.Tenant).WithMany(p => p.TenantWalletTransactions)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TenantWalletTransaction_Tenant");
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.ToTable("UserDevice");

            entity.Property(e => e.AppStoreId).HasMaxLength(256);
            entity.Property(e => e.DeviceKey).HasMaxLength(256);
            entity.Property(e => e.DeviceLocalKey).HasMaxLength(256);
            entity.Property(e => e.DeviceName).HasMaxLength(256);
            entity.Property(e => e.DeviceType).HasMaxLength(256);
            entity.Property(e => e.Version).HasMaxLength(10);

            entity.HasOne(d => d.UserInfo).WithMany(p => p.UserDevices)
                .HasForeignKey(d => d.UserInfoId)
                .HasConstraintName("FK_UserDevice_UserInfo");
        });

        modelBuilder.Entity<UserInRole>(entity =>
        {
            entity.ToTable("UserInRole");

            entity.HasOne(d => d.Role).WithMany(p => p.UserInRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInRole_Role");

            entity.HasOne(d => d.Tenant).WithMany(p => p.UserInRoles)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInRole_Tenant");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.UserInRoles)
                .HasForeignKey(d => d.UserInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInRole_UserInfo");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK_dbo.Users");

            entity.ToTable("UserInfo");

            entity.Property(e => e.ActivationCode).HasMaxLength(6);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.NationalCode).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.PhoneCode).HasMaxLength(50);
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.ToTable("UserPermission");

            entity.HasOne(d => d.ServiceAction).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.ServiceActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_ServiceAction");

            entity.HasOne(d => d.Tenant).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_Tenant");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_UserInfo");
        });

        modelBuilder.Entity<UserServiceItem>(entity =>
        {
            entity.ToTable("UserServiceItem");

            entity.HasOne(d => d.ServiceItem).WithMany(p => p.UserServiceItems)
                .HasForeignKey(d => d.ServiceItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServiceItem_ServiceItem");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.UserServiceItems)
                .HasForeignKey(d => d.UserInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServiceItem_UserInfo");
        });

        modelBuilder.Entity<UserTenant>(entity =>
        {
            entity.ToTable("UserTenant");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Tenant).WithMany(p => p.UserTenants)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTenant_Tenant");

            entity.HasOne(d => d.User).WithMany(p => p.UserTenants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTenant_UserTenant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
