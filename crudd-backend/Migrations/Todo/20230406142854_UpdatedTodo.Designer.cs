﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudd_backend.Contexts;

#nullable disable

namespace crudd_backend.Migrations.Todo
{
    [DbContext(typeof(TodosContext))]
    [Migration("20230406142854_UpdatedTodo")]
    partial class UpdatedTodo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("crudd_backend.Models.TodoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TextName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
