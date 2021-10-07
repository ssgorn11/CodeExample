using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLoader.DBCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTag = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDirectoryParameter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Func = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditMoment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntervalDirection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervalDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchedule = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountValues = table.Column<int>(type: "int", nullable: false),
                    EditMoment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepeatInterval = table.Column<int>(type: "int", nullable: false),
                    RepeatIntervalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorderSeachInterval = table.Column<int>(type: "int", nullable: false),
                    BorderSeachIntervalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorderSeachIntervalDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchedule = table.Column<int>(type: "int", nullable: false),
                    StoreInterval = table.Column<int>(type: "int", nullable: true),
                    StoreIntervalType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag2Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTag = table.Column<int>(type: "int", nullable: false),
                    IdSchedule = table.Column<int>(type: "int", nullable: false),
                    TypeOfIntervalSearch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag2Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag2TagGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTag = table.Column<int>(type: "int", nullable: false),
                    IdTagGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag2TagGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTag = table.Column<int>(type: "int", nullable: false),
                    IdDirectoryParameter = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePHD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confidence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeIntervalType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeIntervalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfIntervalSearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfIntervalSearch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DP_IdTag",
                table: "DP",
                column: "IdTag");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Tag",
                table: "Tag",
                column: "Tag");

            migrationBuilder.CreateIndex(
                name: "IX_Tag2Schedule_IdSchedule",
                table: "Tag2Schedule",
                column: "IdSchedule");

            migrationBuilder.CreateIndex(
                name: "IX_Tag2Schedule_IdTag",
                table: "Tag2Schedule",
                column: "IdTag");

            migrationBuilder.CreateIndex(
                name: "IX_Tag2TagGroup_IdTag",
                table: "Tag2TagGroup",
                column: "IdTag");

            migrationBuilder.CreateIndex(
                name: "IX_Tag2TagGroup_IdTagGroup",
                table: "Tag2TagGroup",
                column: "IdTagGroup");

            migrationBuilder.CreateIndex(
                name: "IX_TagValue_DatePHD",
                table: "TagValue",
                column: "DatePHD");

            migrationBuilder.CreateIndex(
                name: "IX_TagValue_IdTag",
                table: "TagValue",
                column: "IdTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DP");

            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "IntervalDirection");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ScheduleStore");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Tag2Schedule");

            migrationBuilder.DropTable(
                name: "Tag2TagGroup");

            migrationBuilder.DropTable(
                name: "TagGroup");

            migrationBuilder.DropTable(
                name: "TagValue");

            migrationBuilder.DropTable(
                name: "TimeIntervalType");

            migrationBuilder.DropTable(
                name: "TypeOfIntervalSearch");
        }
    }
}
