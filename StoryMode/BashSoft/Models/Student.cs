using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.StaticData;

namespace BashSoft.Models
{
    class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public string UserName
        {
            get
            {
                return this.userName;

            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                    //throw new ArgumentNullException(nameof(this.userName), ExceptionMessages.NullOrEmptyValue);
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get
            {
                return enrolledCourses;

            }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get
            {
                return marksByCourseName;

            }
        }

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
                //throw new DuplicateNameException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, this.userName, course.Name));

            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();

            }

            if (scores.Length > Course.NumberOfTaskOnExam)
            {
                throw new InvalidFileNameException(ExceptionMessages.InvalidNumberOfScores);
                //throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                //return;
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam =
                scores.Sum() / (double)(Course.NumberOfTaskOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}
