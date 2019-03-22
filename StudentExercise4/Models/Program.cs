using System;
using System.Collections.Generic;
using StudentExercise4.Models;

namespace StudentExercise4
{
    class Program
    {
        static void Main(string[] args)
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

            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();

        Console.WriteLine("All Exercises:");
            foreach (Exercise exercise in exercises)
            {

                Console.WriteLine($"{exercise.Id}: {exercise.ExerciseName}, Language:  {exercise.ExerciseLanguage}");
            }  
        Console.ReadLine();
        }
    }
}
