using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudd_backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Persons",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
