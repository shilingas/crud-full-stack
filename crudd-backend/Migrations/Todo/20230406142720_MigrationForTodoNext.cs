using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudd_backend.Migrations.Todo
{
    /// <inheritdoc />
    public partial class MigrationForTodoNext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Todos",
                newName: "TextName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextName",
                table: "Todos",
                newName: "Text");
        }
    }
}
