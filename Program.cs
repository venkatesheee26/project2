using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = ReadStudentData(@"D:\project\stduent.txt.txt");

        // Sort the student data by name (you can use LINQ or custom sorting here)
        // ...

        // Display the sorted data
        DisplayStudents(students);

        // Allow searching by name
        Console.Write("Enter the student name to search: ");
        string searchName = Console.ReadLine();
        Student searchedStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (searchedStudent != null)
        {
            Console.WriteLine($"Found: {searchedStudent.Name}, Class: {searchedStudent.Class}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static List<Student> ReadStudentData(string filename)
    {
        List<Student> students = new List<Student>();
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string studentClass = parts[1].Trim();
                    students.Add(new Student { Name = name, Class = studentClass });
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data: {ex.Message}");
        }
        return students;
    }

    static void DisplayStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
        }
    }
}

