using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.Models
{
    public class CourseGraph
    {
        private Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();
        private Dictionary<string, CourseNode> courses = new Dictionary<string, CourseNode>();
        private Dictionary<string, int> inDegree = new Dictionary<string, int>();
        // ✅ Declare groupedCourses and electives as class attributes
        public Dictionary<int, Dictionary<int, List<CourseNode>>> groupedCourses;
        public List<CourseNode> electives;

        public CourseGraph(Dictionary<int, Dictionary<int, List<CourseNode>>> groupedCourses, List<CourseNode> electivesList)
        {
            // ✅ Initialize the attributes with the provided arguments
            this.groupedCourses = groupedCourses;
            this.electives = electivesList;

            // Populate Graph with Courses
            foreach (var year in groupedCourses)
            {
                foreach (var term in year.Value)
                {
                    foreach (var course in term.Value)
                    {
                        AddCourse(course);
                    }
                }
            }

            // Add electives
            electives = electivesList;
            foreach (var elective in electives)
            {
                AddCourse(elective);
            }
        }

        public void AddCourse(CourseNode course)
        {
            if (!courses.ContainsKey(course.Code))
            {
                courses[course.Code] = course;
                adjacencyList[course.Code] = new List<string>();
                inDegree[course.Code] = 0;
            }

            foreach (var prerequisite in course.Prerequisites)
            {
                if (courses.ContainsKey(prerequisite))
                {
                    adjacencyList[prerequisite].Add(course.Code);
                    inDegree[course.Code]++;
                }
            }
        }

        public void AddPrerequisite(string courseCode, string prerequisite)
        {
            if (!adjacencyList.ContainsKey(courseCode))
            {
                adjacencyList[courseCode] = new List<string>();
            }

            adjacencyList[prerequisite].Add(courseCode);
            inDegree[courseCode] = inDegree.ContainsKey(courseCode) ? inDegree[courseCode] + 1 : 1;
        }

        public List<Tuple<CourseNode, string>> GetNextAvailableCourses(int enrolledTerm, HashSet<string> completedCourses)
        {
            List<Tuple<CourseNode, string>> availableCourses = new List<Tuple<CourseNode, string>>();
            PriorityQueue<CourseNode, (int, int, string)> queue = new PriorityQueue<CourseNode, (int, int, string)>();

            // Step 1: Initialize queue with courses that have all prerequisites completed
            foreach (var course in courses.Values)
            {
                bool prerequisitesMet = course.Prerequisites.All(prerequisite => completedCourses.Contains(prerequisite));

                if (prerequisitesMet && !completedCourses.Contains(course.Code))
                {
                    queue.Enqueue(course, (course.YearLevel, course.Term, course.Code));
                }
            }

            // Step 2: Process courses using Kahn’s Algorithm with priority queue
            while (queue.Count > 0)
            {
                var course = queue.Dequeue();
                string colorCode = course.RegularTerms.Contains(enrolledTerm) ? "green" : "orange";
                availableCourses.Add(Tuple.Create(course, colorCode));

                foreach (var dependent in adjacencyList[course.Code])
                {
                    inDegree[dependent]--;

                    if (inDegree[dependent] == 0 && !completedCourses.Contains(dependent))
                    {
                        queue.Enqueue(courses[dependent], (courses[dependent].YearLevel, courses[dependent].Term, courses[dependent].Code));
                    }
                }
            }

            // Step 3: Process electives
            foreach (var elective in electives)
            {
                if (!completedCourses.Contains(elective.Code))
                {
                    availableCourses.Add(Tuple.Create(elective, "blue"));
                }
            }

            return availableCourses;
        }
    }
}
