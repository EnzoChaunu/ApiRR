﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RRelationnelle.Migrations
{
    [DbContext(typeof(RrelationnelApiContext))]
    partial class RrelationnelApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RessourcesRelationelles.Class", b =>
                {
                    b.Property<int>("id_role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_role");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Category", b =>
                {
                    b.Property<int>("Id_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idcreator")
                        .HasColumnType("int");

                    b.HasKey("Id_Category");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Comments", b =>
                {
                    b.Property<int>("id_comments")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_Ressource")
                        .HasColumnType("int");

                    b.Property<int?>("Id_User")
                        .HasColumnType("int");

                    b.Property<bool>("activation")
                        .HasColumnType("bit");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("dislikes")
                        .HasColumnType("int");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("modificationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("modified")
                        .HasColumnType("bit");

                    b.HasKey("id_comments");

                    b.HasIndex("ID_Ressource");

                    b.HasIndex("Id_User");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Ressource", b =>
                {
                    b.Property<int>("ID_Ressource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_Category")
                        .HasColumnType("int");

                    b.Property<bool>("_activation")
                        .HasColumnType("bit");

                    b.Property<string>("_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_views")
                        .HasColumnType("int");

                    b.HasKey("ID_Ressource");

                    b.HasIndex("Id_Category");

                    b.ToTable("Ressource");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Stats", b =>
                {
                    b.Property<int>("id_stat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStat")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbLike")
                        .HasColumnType("int");

                    b.Property<int>("NbSharing")
                        .HasColumnType("int");

                    b.HasKey("id_stat");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("_activation")
                        .HasColumnType("bit");

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_fName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_lName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("id_role")
                        .HasColumnType("int");

                    b.HasKey("Id_User");

                    b.HasIndex("id_role");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Comments", b =>
                {
                    b.HasOne("RessourcesRelationelles.Class.Ressource", "id_ressource")
                        .WithMany()
                        .HasForeignKey("ID_Ressource");

                    b.HasOne("RessourcesRelationelles.Class.User", "id_user")
                        .WithMany()
                        .HasForeignKey("Id_User");

                    b.Navigation("id_ressource");

                    b.Navigation("id_user");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.Ressource", b =>
                {
                    b.HasOne("RessourcesRelationelles.Class.Category", "category")
                        .WithMany()
                        .HasForeignKey("Id_Category");

                    b.Navigation("category");
                });

            modelBuilder.Entity("RessourcesRelationelles.Class.User", b =>
                {
                    b.HasOne("RRelationnelle.dto.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("id_role");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
