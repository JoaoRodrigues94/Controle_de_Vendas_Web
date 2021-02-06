﻿// <auto-generated />
using Controle_de_Vendas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Controle_de_Vendas.Migrations
{
    [DbContext(typeof(Controle_de_VendasContext))]
    [Migration("20210206211924_Departamento")]
    partial class Departamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Controle_de_Vendas.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("DepartamentoID");

                    b.ToTable("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}
