using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudd_backend.Migrations.Todo
{
    /// <inheritdoc />
    public partial class UpdatedTodo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextName",
                table: "Todos",
                newName: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Todos",
                newName: "TextName");
        }
    }
}
