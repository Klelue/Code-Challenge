﻿// <auto-generated />
using Code_Challenge.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Code_Challenge.Migrations
{
    [DbContext(typeof(CodeChallengeDbContext))]
    partial class CodeChallengeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Code_Challenge.Models.People", b =>
                {
                    b.Property<string>("LdapUser")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameAddition")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("LdapUser");

                    b.HasIndex("RoomNumber");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Code_Challenge.Models.Room", b =>
                {
                    b.Property<string>("RoomNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomNumber");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Code_Challenge.Models.People", b =>
                {
                    b.HasOne("Code_Challenge.Models.Room", null)
                        .WithMany("Residents")
                        .HasForeignKey("RoomNumber");
                });

            modelBuilder.Entity("Code_Challenge.Models.Room", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
