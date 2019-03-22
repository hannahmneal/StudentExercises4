using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercise4.Models;

namespace StudentExercise4
{
    public class Repository
    {

        //(^_^) INSTRUCTIONS:

        /*
             Write the necessary C# code in Repository.cs and Program.cs to perform the following actions. Make sure to print results of each action to the console.
                     1. Query the database for all the Exercises.
                    2. Find all the exercises in the database where the language is JavaScript.
                    3. Insert a new exercise into the database.
                    4. Find all instructors in the database. Include each instructor's cohort.
                    5. Insert a new instructor into the database.Assign the instructor to an existing cohort.
                    6. Assign an existing exercise to an existing student.
         * /*/

        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=HNEAL-PC\\SQLEXPRESS;Initial Catalog=StudentExercise3; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                return new SqlConnection(_connectionString);
            }
        }

        //=====================      Get All Exercises       ==================================
        //1. Query the database for all the Exercises.
        //NOTE: SELECT - FROM   

        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ExerciseLanguage FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int exerciseLanguageColumnPosition = reader.GetOrdinal("ExerciseLanguage");
                        string exerciseLanguageValue = reader.GetString(exerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            ExerciseLanguage = exerciseLanguageValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();

                    return exercises;
                }
            }
        }

        //=======================       GetAllJsExercises      ===============================
        //2. Find all the exercises in the database where the language is JavaScript.
        //NOTE: SELECT - FROM - WHERE


        //============================  AddExercise   =====================================
        //3. Insert a new exercise into the database.
        //NOTE: INSERT INTO


        //=======================       GetAllInstructors      ================================
        //4. Find all instructors in the database. Include each instructor's cohort.
        //NOTE: SELECT - FROM 


        //==========================    GetAllCohorts   ====================================
        //NOTE: SELECT - FROM


        //========================  GetAllInstructorsWithCohort   ========================
        //NOTE: SELECT - FROM --- JOIN - ON
        //NOTE: The instructor object will contain all info from the instructor table + the FK for cohort (instructor_cohort_id) +  a new Cohort object (which will contain all info from cohort table)


        //===============GetAllInstructorsWithCohortById(int CohortId)==================
        //NOTE: SELECT - FROM - WHERE
        //NOTE: The instructor object will contain all information from the instructor table + the FK for cohort (instructor_cohort_id) + a new Cohort object (which will contain all info from cohort table)


        //==========================    AddInstructor   =================================
        //5. Insert a new instructor into the database. Assign the instructor to an existing cohort.
        //NOTE: INSERT INTO 
        //NOTE: Include instructor info and make allowances for the FK cohort id in the SQL params.


        //========================      UpdateInstructor        ============================
        //NOTE: UPDATE - SET - WHERE


        //=========================     GetAllStudents      ===============================
        //6. Assign an existing exercise to an existing student.
        //NOTE: SELECT - FROM


        //=====================     GetAllStudentExercises      ===========================
        //NOTE: SELECT - FROM --- JOIN - ON
        //NOTE: This will handle data retrieval for the "StudentExercises" join table in the ERD. This method needs to join the StudentExercises and Student tables.


        //=====================     GetAllAssignedExercises     ===========================
        //NOTE: SELECT - FROM --- JOIN - ON
        //NOTE: This will handle data retrieval for the "StudentExercises" join table in the ERD. This method needs to join the AssignedStudentExercises and Student tables.


        //======================    GetAllStudentsWithExercises     =======================
        //NOTE: SELECT - FROM --- JOIN - ON

    }
}