﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCompany;

namespace projectcompany.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181127155210_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity("ProjectCompany.Models.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id");

                    b.Property<int>("ProjectId")
                        .HasColumnName("project_id");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("contributions");
                });

            modelBuilder.Entity("ProjectCompany.Models.ContributionSkill", b =>
                {
                    b.Property<int>("ContributionId")
                        .HasColumnName("contribution_id");

                    b.Property<int>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("ContributionId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("contributions_skills");
                });

            modelBuilder.Entity("ProjectCompany.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("ProjectCompany.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id");

                    b.Property<int>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("EmployeeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("employees_skills");
                });

            modelBuilder.Entity("ProjectCompany.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("ProjectCompany.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("skills");
                });

            modelBuilder.Entity("ProjectCompany.Models.Contribution", b =>
                {
                    b.HasOne("ProjectCompany.Models.Employee", "Employee")
                        .WithMany("Contributions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectCompany.Models.Project", "Project")
                        .WithMany("Contributions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("ProjectCompany.Models.DatePeriod", "DatePeriod", b1 =>
                        {
                            b1.Property<int>("ContributionId");

                            b1.Property<DateTime>("From")
                                .HasColumnName("from_date");

                            b1.Property<DateTime>("To")
                                .HasColumnName("to_date");

                            b1.ToTable("contributions");

                            b1.HasOne("ProjectCompany.Models.Contribution")
                                .WithOne("DatePeriod")
                                .HasForeignKey("ProjectCompany.Models.DatePeriod", "ContributionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ProjectCompany.Models.ContributionSkill", b =>
                {
                    b.HasOne("ProjectCompany.Models.Contribution", "Contribution")
                        .WithMany("ContributionSkills")
                        .HasForeignKey("ContributionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectCompany.Models.Skill", "Skill")
                        .WithMany("ContributionSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCompany.Models.EmployeeSkill", b =>
                {
                    b.HasOne("ProjectCompany.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectCompany.Models.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectCompany.Models.Project", b =>
                {
                    b.OwnsOne("ProjectCompany.Models.DatePeriod", "DatePeriod", b1 =>
                        {
                            b1.Property<int>("ProjectId");

                            b1.Property<DateTime>("From")
                                .HasColumnName("from_date");

                            b1.Property<DateTime>("To")
                                .HasColumnName("to_date");

                            b1.ToTable("projects");

                            b1.HasOne("ProjectCompany.Models.Project")
                                .WithOne("DatePeriod")
                                .HasForeignKey("ProjectCompany.Models.DatePeriod", "ProjectId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}