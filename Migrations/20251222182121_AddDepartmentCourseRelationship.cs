using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentCourseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesCrsId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesCrsId, x.DepartmentsDepartmentId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_CoursesCrsId",
                        column: x => x.CoursesCrsId,
                        principalTable: "Courses",
                        principalColumn: "CrsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_DepartmentsDepartmentId",
                        column: x => x.DepartmentsDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDepartmentId",
                table: "CourseDepartment",
                column: "DepartmentsDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");
        }
    }
}
