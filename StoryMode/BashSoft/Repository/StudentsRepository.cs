using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        public bool isDataInitialized = false;


        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (!isDataInitialized)
            {
                this.students = new Dictionary<string, Student>();
                this.courses = new Dictionary<string, Course>();
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        public void UnloadDate()
        {
            if (!this.isDataInitialized)
            {
                throw new InvalidFileNameException(ExceptionMessages.DataNotInitializedExceptionMessage);
                //throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + '\\' + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoreStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoreStr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                            if (scores.Any(x=>x>100 || x < 0))
                            {
                                //throw new ArgumentException(ExceptionMessages.InvalidScore);
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > Course.NumberOfTaskOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new Student(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }


                            Course course = this.courses[courseName];
                            Student student = this.students[userName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);

                        }
                        catch (FormatException fex)
                        {
                            throw new FormatException(fex.Message + $"at line: {line}");
                            //OutputWriter.DisplayException(fex.Message + $"at line: {line}");
                        }
                        //string[] tokens = allInputLines[line].Split(' ');
                        //string course = tokens[0];
                        //string student = tokens[1];
                        //int mark = int.Parse(tokens[2]);


                    }
                }
                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            if (this.courses.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter,studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks,comparison,studentsToTake.Value);
            }
        }
    }
}
