using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.Sql("INSERT INTO public.\"Categorias\"(\"CategoriaNome\", \"Descricao\") VALUES ('Normal', 'Lanches feitos com ingredientes normais');");
            migrationBuilder.Sql("INSERT INTO public.\"Categorias\"(\"CategoriaNome\", \"Descricao\") VALUES ('Natural', 'Lanches feitos com ingredientes naturais');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Categorias\"");
        }
    }
}