using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlzSinhVien.Server.Data.ChucVu
{
    public partial class create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BLChucVuId",
                table: "BLUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLUsers_BLChucVuId",
                table: "BLUsers",
                column: "BLChucVuId");

            migrationBuilder.AddForeignKey(
                name: "FK_BLUsers_ChucVus_BLChucVuId",
                table: "BLUsers",
                column: "BLChucVuId",
                principalTable: "ChucVus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLUsers_ChucVus_BLChucVuId",
                table: "BLUsers");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropIndex(
                name: "IX_BLUsers_BLChucVuId",
                table: "BLUsers");

            migrationBuilder.DropColumn(
                name: "BLChucVuId",
                table: "BLUsers");
        }
    }
}
