using System;
using System.Collections.Generic;

class Program
{
  // Lists to store student data
  static List<string> studentIDs = new List<string>();
  static List<string> studentNames = new List<string>();
  static List<List<string>> studentSubjects = new List<List<string>>();
  static List<List<double>> studentGrades = new List<List<double>>();

  static void Main()
  {
    bool running = true;

    while (running)
    {
      Console.WriteLine("\nStudent Grade Management System");
      Console.WriteLine("1. Add Student");
      Console.WriteLine("2. Add/Update Grade");
      Console.WriteLine("3. View Student Record");
      Console.WriteLine("4. Delete Student");
      Console.WriteLine("5. Exit");
      Console.Write("Enter choice: ");

      string input = Console.ReadLine();
      Console.WriteLine();

      switch (input)
      {
        case "1":
          AddStudent();
          break;
        case "2":
          AddOrUpdateGrade();
          break;
        case "3":
          ViewStudent();
          break;
        case "4":
          DeleteStudent();
          break;
        case "5":
          running = false;
          break;
        default:
          Console.WriteLine("Invalid choice. Try again.");
          break;
      }
    }

    Console.WriteLine("Program ended.");
  }

  static void AddStudent()
  {
    Console.Write("Enter student name: ");
    string name = Console.ReadLine();

    Console.Write("Enter unique student ID: ");
    string id = Console.ReadLine();

    if (studentIDs.Contains(id))
    {
      Console.WriteLine("Student ID already exists.");
      return;
    }

    studentNames.Add(name);
    studentIDs.Add(id);
    studentSubjects.Add(new List<string>());
    studentGrades.Add(new List<double>());

    Console.WriteLine("Student added.");
  }

  static void AddOrUpdateGrade()
  {
    Console.Write("Enter student ID: ");
    string id = Console.ReadLine();

    int index = studentIDs.IndexOf(id);
    if (index == -1)
    {
      Console.WriteLine("Student not found.");
      return;
    }

    Console.Write("Enter subject name: ");
    string subject = Console.ReadLine();

    Console.Write("Enter grade (0–100): ");
    if (!double.TryParse(Console.ReadLine(), out double grade) || grade < 0 || grade > 100)
    {
      Console.WriteLine("Invalid grade.");
      return;
    }

    int subjectIndex = studentSubjects[index].IndexOf(subject);
    if (subjectIndex != -1)
    {
      studentGrades[index][subjectIndex] = grade;
      Console.WriteLine("Grade updated.");
    }
    else
    {
      studentSubjects[index].Add(subject);
      studentGrades[index].Add(grade);
      Console.WriteLine("Grade added.");
    }
  }

  static void ViewStudent()
  {
    Console.Write("Enter student ID: ");
    string id = Console.ReadLine();

    int index = studentIDs.IndexOf(id);
    if (index == -1)
    {
      Console.WriteLine("Student not found.");
      return;
    }

    Console.WriteLine($"Name: {studentNames[index]}");
    Console.WriteLine($"ID: {studentIDs[index]}");

    if (studentSubjects[index].Count == 0)
    {
      Console.WriteLine("No grades available.");
      return;
    }

    double total = 0;
    int count = 0;

    Console.WriteLine("Grades:");
    for (int i = 0; i < studentSubjects[index].Count; i++)
    {
      Console.WriteLine($"  {studentSubjects[index][i]}: {studentGrades[index][i]}");
      total += studentGrades[index][i];
      count++;
    }

    double average = total / count;
    Console.WriteLine($"Average Grade: {average:F2}");
  }

  static void DeleteStudent()
  {
    Console.Write("Enter student ID: ");
    string id = Console.ReadLine();

    int index = studentIDs.IndexOf(id);
    if (index == -1)
    {
      Console.WriteLine("Student not found.");
      return;
    }

    studentIDs.RemoveAt(index);
    studentNames.RemoveAt(index);
    studentSubjects.RemoveAt(index);
    studentGrades.RemoveAt(index);

    Console.WriteLine("Student deleted.");
  }
}
