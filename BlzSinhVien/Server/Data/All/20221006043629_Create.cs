using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlzSinhVien.Server.Data.All
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocKys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocKyOn = table.Column<int>(type: "int", nullable: false),
                    HocKyIn = table.Column<int>(type: "int", nullable: false),
                    HocKyOut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    SoTietLyThuyet = table.Column<int>(type: "int", nullable: false),
                    SoTietThucHanh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BLUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChucVuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BLUsers_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NganhHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NganhHocs_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHocKhoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaId = table.Column<int>(type: "int", nullable: false),
                    MonHocID = table.Column<int>(type: "int", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocKhoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHocKhoa_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHocKhoa_MonHocs_MonHocID",
                        column: x => x.MonHocID,
                        principalTable: "MonHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    MaGiaoVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoViens_BLUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "BLUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaoViens_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLopHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLopHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NganhHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocs_NganhHocs_NganhHocId",
                        column: x => x.NganhHocId,
                        principalTable: "NganhHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHocChuyenNganhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NganhHocId = table.Column<int>(type: "int", nullable: false),
                    MonHocKhoaId = table.Column<int>(type: "int", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocChuyenNganhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHocChuyenNganhs_MonHocKhoa_MonHocKhoaId",
                        column: x => x.MonHocKhoaId,
                        principalTable: "MonHocKhoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MonHocChuyenNganhs_NganhHocs_NganhHocId",
                        column: x => x.NganhHocId,
                        principalTable: "NganhHocs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSinhVien = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LopHocId = table.Column<int>(type: "int", nullable: true),
                    GiaoViensId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    HocKyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhViens_BLUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BLUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhViens_GiaoViens_GiaoViensId",
                        column: x => x.GiaoViensId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhViens_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopHocs_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHocs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiangDuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaoVienId = table.Column<int>(type: "int", nullable: false),
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    MonHocChuyenNganhId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HocKyId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangDuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangDuongs_GiaoViens_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangDuongs_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangDuongs_LopHocs_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHocs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiangDuongs_MonHocChuyenNganhs_MonHocChuyenNganhId",
                        column: x => x.MonHocChuyenNganhId,
                        principalTable: "MonHocChuyenNganhs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLUsers_ChucVuId",
                table: "BLUsers",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDuongs_GiaoVienId",
                table: "GiangDuongs",
                column: "GiaoVienId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDuongs_HocKyId",
                table: "GiangDuongs",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDuongs_LopHocId",
                table: "GiangDuongs",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDuongs_MonHocChuyenNganhId",
                table: "GiangDuongs",
                column: "MonHocChuyenNganhId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_KhoaId",
                table: "GiaoViens",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_UsersId",
                table: "GiaoViens",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_NganhHocId",
                table: "LopHocs",
                column: "NganhHocId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocChuyenNganhs_MonHocKhoaId",
                table: "MonHocChuyenNganhs",
                column: "MonHocKhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocChuyenNganhs_NganhHocId",
                table: "MonHocChuyenNganhs",
                column: "NganhHocId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocKhoa_KhoaId",
                table: "MonHocKhoa",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocKhoa_MonHocID",
                table: "MonHocKhoa",
                column: "MonHocID");

            migrationBuilder.CreateIndex(
                name: "IX_NganhHocs_KhoaId",
                table: "NganhHocs",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_GiaoViensId",
                table: "SinhViens",
                column: "GiaoViensId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_HocKyId",
                table: "SinhViens",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_LopHocId",
                table: "SinhViens",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_UserId",
                table: "SinhViens",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiangDuongs");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "MonHocChuyenNganhs");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "HocKys");

            migrationBuilder.DropTable(
                name: "LopHocs");

            migrationBuilder.DropTable(
                name: "MonHocKhoa");

            migrationBuilder.DropTable(
                name: "BLUsers");

            migrationBuilder.DropTable(
                name: "NganhHocs");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
