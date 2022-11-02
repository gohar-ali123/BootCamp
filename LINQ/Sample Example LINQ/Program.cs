using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        #region Data
        class Students
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public List<int> Scores;
        }

        class Teacher
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string City { get; set; }
        }
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }

        class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
               new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {99, 89, 91, 95}},
               new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {72, 81, 65, 84}},
               new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {97, 89, 85, 82}}
            };

            return students;
        }

        #endregion

        static void Main(string[] args)
        {
            Example1();
        }
        //filtering and selection
        public static void Example1()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }
        //double filter
        public static void Example2()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery = from num in numbers
                           where (num % 2) == 0 && (num % 3) == 0
                           select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }
        //ordering
        public static void Example3()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           orderby num descending
                           select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }
        //grouping
        public static void Example4()
        {

            // The Three Parts of a LINQ Query:
            // 1. Data source.
            List<Student> students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, 
                   Scores= new List<int> {97, 72, 81, 60}},
               new Student {First="Claire", Last="O'Donnell", ID=112, 
                   Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, 
                   Scores= new List<int> {99, 89, 91, 95}},
               new Student {First="Cesar", Last="Garcia", ID=114, 
                   Scores= new List<int> {72, 81, 65, 84}},
               new Student {First="Debra", Last="Garcia", ID=115, 
                   Scores= new List<int> {97, 89, 85, 82}}
            };
            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var studentQuery1 =
                        from student in students
                        group student by student.Last;

            // 3. Query execution.
            foreach (IGrouping<string, Student> studentGroup in studentQuery1)
            {
                Console.WriteLine(studentGroup.Key);
                // Explicit type for student could also be used here.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", 
                        student.Last, 
                        student.First);
                }
            }
        }
        //grouping into
        public static void Example5()
        {

            // The Three Parts of a LINQ Query:
            // 1. Data source.
            List<Student> students = GetStudents();
            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var studentQuery2 =
                        from student in students
                        group student by student.Last into g
                        select g;

            //3.Query execution.
            foreach (IGrouping<string, Student> studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                // Explicit type for student could also be used here.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }
        }
        //inner join
        public static void Example6()
        {
            List<Category> categories = new List<Category>()
            {
                new Category {Name="Beverages", ID=001},
                new Category {Name="Condiments", ID=002},
                new Category {Name="Vegetables", ID=003},
                new Category {Name="Grains", ID=004},
                new Category {Name="Fruit", ID=005}
            };

            // Specify the second data source.
            List<Product> products = new List<Product>()
            {
                new Product {Name="Cola",  CategoryID=001},
                new Product {Name="Tea",  CategoryID=001},
                new Product {Name="Mustard", CategoryID=002},
                new Product {Name="Pickles", CategoryID=002},
                new Product {Name="Carrots", CategoryID=003},
                new Product {Name="Bok Choy", CategoryID=003},
                new Product {Name="Peaches", CategoryID=005},
                new Product {Name="Melons", CategoryID=005},
                new Product {Name="Chocolate", CategoryID=006},
                new Product {Name="Sweets", CategoryID=006},
            };
            // Create the query that selects
            // a property from each element.
            var innerJoinQuery =
               from category in categories
               join prod in products on category.ID equals prod.CategoryID
               select new { Category = category.ID, Product = prod.Name, CategoryName=category.Name };

            Console.WriteLine("InnerJoin:");
            // Execute the query. Access results
            // with a simple foreach statement.
            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine("{0,-10}{1} {2}", item.Product, item.Category, item.CategoryName);
            }
            Console.WriteLine("InnerJoin: {0} items in 1 group.", innerJoinQuery.Count());
            Console.WriteLine(System.Environment.NewLine);
        }
        //Joining Multiple Inputs into One Output Sequence
        public static void Example7()
        {
            // Create the first data source.
            List<Students> students = new List<Students>()
            {
                new Students { First="Svetlana",
                    Last="Omelchenko",
                    ID=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> { 97, 92, 81, 60 } },
                new Students { First="Claire",
                    Last="O’Donnell",
                    ID=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> { 75, 84, 91, 39 } },
                new Students { First="Sven",
                    Last="Mortensen",
                    ID=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> { 88, 94, 65, 91 } },
            };

            // Create the second data source.
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
                new Teacher { First="Alex", Last="Robinson", ID=956, City="Seattle" },
                new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
            };

            // Create the query.
            var peopleInSeattle = (from student in students
                                   where student.City == "Seattle"
                                   select student.Last)
                        .Concat(from teacher in teachers
                                where teacher.City == "Seattle"
                                select teacher.Last);

            Console.WriteLine("The following students and teachers live in Seattle:");
            // Execute the query.
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }



    }
}
