using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Library.Migrations
{
    public partial class CreatingStorePeocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
							table: "Genders",
							columns: new[] { "GenderName" },
							values: new object[] { "Male" });
			migrationBuilder.InsertData(
							table: "Genders",
							columns: new[] { "GenderName" },
							values: new object[] { "Female" });

			string getProcedureById = @"CREATE PROCEDURE spGetStudentById
								@Id int
							AS
							BEGIN
								SELECT
								S.StudentId,S.StudentName,S.DateOfBirth,G.GenderId,G.GenderName as Gender,S.PicturePath
								FROM Students S
								JOIN Genders G 
								ON
								S.GenderId=G.GenderId 
								WHERE StudentId=@Id
							END";
			migrationBuilder.Sql(getProcedureById);

			string getProcedure = @"CREATE PROCEDURE spGetStudents
						AS
						BEGIN
							SELECT
							S.StudentId,S.StudentName,S.DateOfBirth,G.GenderId,G.GenderName as Gender,S.PicturePath
							FROM Students S
							JOIN Genders G 
							ON
							S.GenderId=G.GenderId 
						END";
			migrationBuilder.Sql(getProcedure);


			string insertProcedure = @"CREATE PROCEDURE spInsertStudent
								@Name varchar(50),
								@DOB datetime,
								@GenderId int,
								@PicturePath varchar(max)
							AS
							BEGIN
								INSERT INTO Students
								VALUES(@Name,@DOB,@GenderId,@PicturePath)
							END";
			migrationBuilder.Sql(insertProcedure);

			string updateProcedure = @"CREATE PROCEDURE spUpdateStudent
								@Id int,
								@Name varchar(50),
								@DOB datetime,
								@GenderId int,
								@PicturePath varchar(max)
							AS
							BEGIN
								UPDATE Students
								SET
								StudentName=@Name,
								DateOfBirth=@DOB,
								GenderId=@GenderId,
								PicturePath=@PicturePath
								WHERE StudentId=@Id
							END";
			migrationBuilder.Sql(updateProcedure);

			string deleteProcedure = @"CREATE PROCEDURE spDeleteStudent
								@Id int
							AS
							BEGIN
								DELETE FROM Students
								WHERE StudentId=@Id
							END";
			migrationBuilder.Sql(deleteProcedure);

		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
			string dropGetProcedureById = @"DROP PROCEDURE spGetStudentById";
			migrationBuilder.Sql(dropGetProcedureById);

			string dropGetProcedure = @"DROP PROCEDURE spGetStudents";
			migrationBuilder.Sql(dropGetProcedure);

			string dropInsertProcedure = @"DROP PROCEDURE spInsertStudent";
			migrationBuilder.Sql(dropInsertProcedure);

			string dropUpdateProcedure = @"DROP PROCEDURE spUpdateStudent";
			migrationBuilder.Sql(dropUpdateProcedure);

			string dropDeleteProcedure = @"DROP PROCEDURE spDeleteStudent";
			migrationBuilder.Sql(dropDeleteProcedure);
		}
    }
}
