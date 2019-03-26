using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercise4.Models;

namespace StudentExercise4.Data
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
                string _connectionString = "Server=localhost\\SQLEXPRESS; Database=StudentExercise3; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
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
                    cmd.CommandText = @"SELECT
                                            e.Id, 
                                            e.ExerciseName,                                             e.ExerciseLanguage
                                        FROM Exercise e";
                    
                    //? SQL Parameters for a "GET"? 

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

                        Exercise exercise = new Exercise()
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

        //=======================       GetAllExercisesByLanguage      ===========================
        //2. Find all the exercises in the database where the language is JavaScript.
        //NOTE: SELECT - FROM - WHERE

        public List<Exercise> GetExercisesByLanguage(string exerciseLanguage)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                            e.Id,
                                            e.ExerciseName,
                                            e.ExerciseLanguage
                                        FROM Exercise e
                                        WHERE e.ExerciseLanguage = @exerciseLanguage";
                   cmd.Parameters.Add(new SqlParameter("@exerciseLanguage", exerciseLanguage));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercisesByLangList = new List<Exercise>();
                    while (reader.Read())
                    {
                        Exercise exerciseByLang = new Exercise()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercisesByLangList.Add(exerciseByLang);
                    }

                    reader.Close();

                    return exercisesByLangList;
                }
            }
        }

        //============================  AddExercise   =====================================
        //3. Insert a new exercise into the database.
        //NOTE: INSERT INTO

        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Exercise (ExerciseName, ExerciseLanguage) Values (@ExerciseName, @ExerciseLanguage)";

                    cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));

                    cmd.Parameters.Add(new SqlParameter("@ExerciseLanguage", exercise.ExerciseLanguage));

                    cmd.ExecuteNonQuery();

                }
            }
        }


        //=======================       GetAllInstructors      ================================
        //4. Find all instructors in the database. Include each instructor's cohort.
        //NOTE: SELECT - FROM 

        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                            i.Id,
                                            i.InstructorFirstName,
                                            i.InstructorLastName,
                                            i.InstructorSlackHandle,
                                            i.instructor_cohort_id
                                        FROM Instructor i";

                    //? SQL Parameters for a "GET"? 

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int instructorFirstNameColumnPosition = reader.GetOrdinal("InstructorFirstName");
                        string instructorFirstNameValue = reader.GetString(instructorFirstNameColumnPosition);

                        int instructorLastNameColumnPosition = reader.GetOrdinal("InstructorLastName");
                        string instructorLastNameValue = reader.GetString(instructorLastNameColumnPosition);

                        int instructorSlackHandleColumnPosition = reader.GetOrdinal("InstructorSlackHandle");
                        string instructorSlackHandleValue = reader.GetString(instructorSlackHandleColumnPosition);

                        int instructor_cohort_idColumnPosition = reader.GetOrdinal("instructor_cohort_id");
                        int instructor_cohort_idValue = reader.GetInt32(instructor_cohort_idColumnPosition);


                        Instructor instructor = new Instructor()
                        {
                            Id = idValue,
                            InstructorFirstName = instructorFirstNameValue,
                            InstructorLastName = instructorLastNameValue,
                            InstructorSlackHandle = instructorSlackHandleValue,
                            instructor_cohort_id = instructor_cohort_idValue
                        };
                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }


        //==========================    GetAllCohorts   ====================================
        //NOTE: SELECT - FROM

        public List<Cohort> GetAllCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                            c.Id,
                                            c.CohortName
                                        FROM Cohort c";

                    //? SQL Parameters for a "GET"? 

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int cohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string cohortNameValue = reader.GetString(cohortNameColumnPosition);

                        Cohort cohort = new Cohort()
                        {
                            Id = idValue,
                            CohortName = cohortNameValue
                        };
                        cohorts.Add(cohort);
                    }
                    reader.Close();
                    return cohorts;
                }
            }
        }


        //========================  GetAllInstructorsWithCohort   ========================
        //NOTE: SELECT - FROM --- JOIN - ON
        //NOTE: The instructor object will contain all info from the instructor table + the FK for cohort (instructor_cohort_id) +  a new Cohort object (which will contain all info from cohort table)

        public List<Instructor> GetAllInstructorsWithCohort()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                            i.Id, 
                                            i.InstructorFirstName, 
                                            i.InstructorLastName,
                                            i.InstructorSlackHandle,
                                            i.instructor_cohort_id,
                                            c.CohortName
                                        FROM Instructor i INNER JOIN Cohort c ON i.instructor_cohort_id = c.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            InstructorFirstName = reader.GetString(reader.GetOrdinal("InstructorFirstName")),
                            InstructorLastName = reader.GetString(reader.GetOrdinal("InstructorLastName")),
                            InstructorSlackHandle = reader.GetString(reader.GetOrdinal("InstructorSlackHandle")),
                            instructor_cohort_id = reader.GetInt32(reader.GetOrdinal("instructor_cohort_id")),

                            Cohort = new Cohort //NOTE: See note in Instructor.cs about cohort prop

                            {
                                Id = reader.GetInt32(reader.GetOrdinal("instructor_cohort_id")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            }
                        };
                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }


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