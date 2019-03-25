using System;
using System.Collections.Generic;
using StudentExercise4.Data;
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
            //NOTE: GetAllExercises and put them in a list of Exercises; print them to the console.
            List<Exercise> exercises = repository.GetAllExercises();

            Console.WriteLine("All Exercises:");
            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.Id}: {exercise.ExerciseName}, Language:  {exercise.ExerciseLanguage}");
            }
            //Console.Read();



            //NOTE: GetAllJsExercises 

            List<Exercise> exercisesByLangList =repository.GetExercisesByLanguage("Javascript");

            Console.WriteLine("All Javascript Exercises:");
            foreach(Exercise exerciseByLang in exercisesByLangList)
            {
                Console.WriteLine($"JS Exercise: {exerciseByLang.Id}: {exerciseByLang.ExerciseName},  {exerciseByLang.ExerciseLanguage}");
            }
            Console.Read();


        }

        //NOTE: Not sure if I want to use this yet:

        //    public static void Pause()
        //    {
        //        //Console.WriteLine();
        //        Console.Write("Press any key to continue...");
        //        Console.Read();
        //        Console.WriteLine();
        //        Console.WriteLine();
        //        Console.WriteLine();
        //        Console.WriteLine();

        //}
    }
}
