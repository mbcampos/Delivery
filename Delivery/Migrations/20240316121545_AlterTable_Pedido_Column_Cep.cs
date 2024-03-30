using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    public partial class AlterTable_Pedido_Column_Cep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Endereco2",
                table: "Pedidos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Pedidos",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco2",
                table: "Pedidos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
