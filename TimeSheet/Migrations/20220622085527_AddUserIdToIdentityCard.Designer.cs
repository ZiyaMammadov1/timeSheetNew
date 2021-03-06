// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.DatabaseContext;

namespace TimeSheet.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220622085527_AddUserIdToIdentityCard")]
    partial class AddUserIdToIdentityCard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeSheet.Entities.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TimeSheet.Entities.IdentityCard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiredTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("fin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("govermentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("TimeSheet.Entities.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TimeSheet.Entities.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeSheet.Entities.RefreshToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshTokenString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TimeSheet.Entities.Salary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("incrementTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("TimeSheet.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("cid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("positionId")
                        .HasColumnType("int");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("departmentId");

                    b.HasIndex("fin")
                        .IsUnique()
                        .HasFilter("[fin] IS NOT NULL");

                    b.HasIndex("positionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeSheet.Entities.WorkType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("WorkType");
                });

            modelBuilder.Entity("TimeSheet.Entities.mainTimeSheet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("projectid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("uuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("workTypeid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MainTimeSheets");
                });

            modelBuilder.Entity("TimeSheet.Entities.IdentityCard", b =>
                {
                    b.HasOne("TimeSheet.Entities.User", "User")
                        .WithMany("userIdentityCards")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.RefreshToken", b =>
                {
                    b.HasOne("TimeSheet.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Salary", b =>
                {
                    b.HasOne("TimeSheet.Entities.User", "User")
                        .WithMany("userSalaries")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.User", b =>
                {
                    b.HasOne("TimeSheet.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("positionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
