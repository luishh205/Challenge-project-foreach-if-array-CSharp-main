using System;

class Program
{
    static void Main()
    {
        int examAssignments = 5;

        string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

        int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
        int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
        int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
        int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

        int[] studentScores = new int[10];

        string currentStudentLetterGrade = "";

        // Display the header row for scores/grades
        Console.Clear();
        Console.WriteLine("Student\t\tExam Score\tOverall Grade\tLetter Grade\tExtra Credit\n");

        /*
        The outer foreach loop is used to:
        - iterate through student names 
        - assign a student's grades to the studentScores array
        - calculate exam and extra credit sums (inner foreach loop)
        - calculate numeric and letter grade
        - write the score report information
        */
        foreach (string name in studentNames)
        {
            string currentStudent = name;

            if (currentStudent == "Sophia")
                studentScores = sophiaScores;
            else if (currentStudent == "Andrew")
                studentScores = andrewScores;
            else if (currentStudent == "Emma")
                studentScores = emmaScores;
            else if (currentStudent == "Logan")
                studentScores = loganScores;

            int gradedAssignments = 0;
            int gradedExtraCreditAssignments = 0;

            int sumExamScores = 0;
            int sumExtraCreditScores = 0;

            decimal currentStudentGrade = 0;
            decimal currentStudentExamScore = 0;
            decimal currentStudentExtraCreditScore = 0;

            /* 
            The inner foreach loop: 
            - sums the exam and extra credit scores
            - counts the extra credit assignments
            */
            foreach (int score in studentScores)
            {
                gradedAssignments += 1;

                if (gradedAssignments <= examAssignments)
                {
                    sumExamScores += score;
                }
                else
                {
                    gradedExtraCreditAssignments += 1;
                    sumExtraCreditScores += score;
                }
            }

            currentStudentExamScore = (decimal)(sumExamScores) / examAssignments;
            currentStudentExtraCreditScore = gradedExtraCreditAssignments > 0 ? (decimal)(sumExtraCreditScores) / gradedExtraCreditAssignments : 0;

            currentStudentGrade = (decimal)(sumExamScores + (sumExtraCreditScores / 10)) / examAssignments;

            if (currentStudentGrade >= 97)
                currentStudentLetterGrade = "A+";
            else if (currentStudentGrade >= 93)
                currentStudentLetterGrade = "A";
            else if (currentStudentGrade >= 90)
                currentStudentLetterGrade = "A-";
            else if (currentStudentGrade >= 87)
                currentStudentLetterGrade = "B+";
            else if (currentStudentGrade >= 83)
                currentStudentLetterGrade = "B";
            else if (currentStudentGrade >= 80)
                currentStudentLetterGrade = "B-";
            else if (currentStudentGrade >= 77)
                currentStudentLetterGrade = "C+";
            else if (currentStudentGrade >= 73)
                currentStudentLetterGrade = "C";
            else if (currentStudentGrade >= 70)
                currentStudentLetterGrade = "C-";
            else if (currentStudentGrade >= 67)
                currentStudentLetterGrade = "D+";
            else if (currentStudentGrade >= 63)
                currentStudentLetterGrade = "D";
            else if (currentStudentGrade >= 60)
                currentStudentLetterGrade = "D-";
            else
                currentStudentLetterGrade = "F";

            // Student         Exam Score      Overall Grade   Extra Credit
            // Sophia          92.2            95.88   A       92 (3.68 pts)
            Console.WriteLine($"{currentStudent}\t\t{currentStudentExamScore:F1}\t\t{currentStudentGrade:F2}\t{currentStudentLetterGrade}\t{sumExtraCreditScores} ({(sumExtraCreditScores / 10m):F2} pts)");
        }

        // Required for running in VS Code (keeps the Output window open to view results)
        Console.WriteLine("\n\rPress the Enter key to continue");
        Console.ReadLine();
    }
}
