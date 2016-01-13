using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("First name cannot be null or emtpty!");
            }

            this.firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Last name cannot be null or emtpty!");
            }

            this.lastName = value;
        }
    }
    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }
        set
        {
            if (this.exams == null)
            {
                this.exams = new List<Exam>();
            }

            this.exams = value;
        }
    }
    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Exams cannot be null or empty!");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams!");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Cannot calculate average on missing exams!");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
