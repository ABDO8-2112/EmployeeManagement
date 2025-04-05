using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementData.Migrations
{
    public partial class AddEmployeeTestingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Employees",
            columns: new[] { "FirstName", "LastName", "Position", "Salary", "DateHired" },
            values: new object[,]
            {
                { "Aamir", "Bhatti", "Software Engineer", 100000m, new DateTime(2022, 1, 15) },
                { "Jonathan", "Twite", "Project Manager", 115000, new DateTime(2021, 5, 20) },
                { "Michael", "Gould", "QA Engineer", 70000, new DateTime(2023, 3, 10) },
                { "Mary", "Jane", "UX Designer", 60000, new DateTime(2022, 8, 5) },
                { "Peter", "Parker", "DevOps Engineer", 50000, new DateTime(2021, 11, 30) }
            });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees WHERE FirstName IN ('Aamir', 'Jonathan', 'Michael', 'Mary', 'Peter')");
        }
    }
}
