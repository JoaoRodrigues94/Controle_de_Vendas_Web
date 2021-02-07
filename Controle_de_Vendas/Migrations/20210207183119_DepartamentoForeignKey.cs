using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_de_Vendas.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoID",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoID",
                table: "Vendedores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoID",
                table: "Vendedores",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoID",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoID",
                table: "Vendedores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoID",
                table: "Vendedores",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
