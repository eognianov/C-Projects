using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.StaticData;

namespace BashSoft.Models
{
    class Course
    {
        public const int NumberOfTaskOnExam = 5;
        public const int MaxScoreOnExamTask = 100;


        private string name;
        private Dictionary<string, Student> studentsByName;

        public string Name
        {
            get
            {
                return this.name;

            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.Name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get { return studentsByName; }
        }

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                //throw new DuplicateNameException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.name));
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.name));
                //return;
            }
            this.studentsByName.Add(student.UserName, student);
        }

    }
}
