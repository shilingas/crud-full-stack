using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudd_backend.Migrations
{
    /// <inheritdoc />
    public partial class fixedforthelasttime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_FileModel_FileId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "FileModel");

            migrationBuilder.DropIndex(
                name: "IX_Persons_FileId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FileId",
                table: "Persons",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_FileModel_FileId",
                table: "Persons",
                column: "FileId",
                principalTable: "FileModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
