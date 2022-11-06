using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp_Candidate_Management_system
{
    public class Candidate
    {
        public string name;
        public string city;
        public double cgpa;
        public double averageMarks;
        
        public List<Project> projectList = new List<Project>();

        public Candidate(string cName, string cCity, double cCgpa = 3.2)
          {
              name = cName;
              city = cCity;
              cgpa = cCgpa;
          }
    }

    public class Project
    {
        int totalMarks;
        public int obtainedMarks;

        public Project(int oMarks, int tMarks = 100)
        {
            obtainedMarks = oMarks;
            totalMarks = tMarks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //*************TASK 1****************
            //***********************************

            List<Candidate> candidatesList = new List<Candidate>();
                        
            candidatesList.Add(new Candidate("Daud     ", "Karachi"));     //1st candidate
            candidatesList.Add(new Candidate("Arqam    ", "Gujranwala"));  //2nd candidate
            candidatesList.Add(new Candidate("Ahmed    ", "Lahore"));      //3rd candidate
            candidatesList.Add(new Candidate("Hasan    ", "Lahore"));      //4th candidate
            candidatesList.Add(new Candidate("Akbar    ", "Karachi"));     //5th candidate
            candidatesList.Add(new Candidate("Talha    ", "Gujranwala"));  //6th candidate
            candidatesList.Add(new Candidate("Asif     ", "Lahore"));      //7th candidate
            candidatesList.Add(new Candidate("Haider   ", "Islamabad"));   //8th candidate
            candidatesList.Add(new Candidate("Abdullah ", "Karachi"));      //9th candidate
            candidatesList.Add(new Candidate("Ali      ", "Pindi"));       //10th candidate
            candidatesList.Add(new Candidate("Danish  ", "Quetta"));      //11th candidate
            candidatesList.Add(new Candidate("Mubashir ", "Lahore"));      //12th candidate
            candidatesList.Add(new Candidate("Awais    ", "Islamabad"));   //13th candidate
            candidatesList.Add(new Candidate("Abdullah ", "Lahore"));      //14th candidate
            candidatesList.Add(new Candidate("Khalid   ", "Quetta"));      //15th candidate

            Random randC = new Random(); //To generate random cgpas for candidates

            for (int i = 0; i < 15; i++) //To assign random cgpas to candidates
            {
                double temp = ((int)((2.7 + randC.NextDouble())*100)) / 100.00; //To avoid large number of digits after decimal
                candidatesList[i].cgpa = temp;
            }

            //To display registered candidates
            Console.WriteLine("Data of candidates REGISTERED for Techlift BootCamp is given below:\n");
            DisplayStudentData(candidatesList);


            //*************TASK 2****************
            //***********************************

            List<Candidate> selectedCandidates = new List<Candidate>(); // New list for selected candidates

            for (int i = 0; i < candidatesList.Count; i++)
            {
                if (candidatesList[i].cgpa >= 3.0)
                {
                    selectedCandidates.Add(candidatesList[i]);
                }
            }

            //To display selected candidates
            Console.WriteLine("\n\nData of candidates SELECTED for Techlift BootCamp is given below:\n");
            DisplayStudentData(selectedCandidates);
            

            //*************TASK 3****************
            //***********************************

            int randMarks;
            Random randM = new Random(); //To generate random obtained marks for projects of candidates

            for (int i = 0; i < selectedCandidates.Count; i++) //assigning random project marks to selected candidates
            {
                //randMarks = randM.Next(85, 100);

                for (int j = 0; j < 2; j++) // Two projects per candidate
                {
                    randMarks = randM.Next(85, 100); // To Assign random values between 85 to 100
                    Project project = new Project(randMarks);
                    selectedCandidates[i].projectList.Add(project);
                }

            }

            //To display marks in projects
            Console.WriteLine("\n\nMarks of candidates in project 1 and project 2 are given below:\n"); 
            DisplayMarks(selectedCandidates);


            //*************TASK 4****************
            //***********************************

            List<Candidate> topCandidates = new List<Candidate>();

            for (int i = 0; i < selectedCandidates.Count; i++) //assigning average marks to selected candidates
            {
                selectedCandidates[i].averageMarks = (selectedCandidates[i].projectList[0].obtainedMarks + selectedCandidates[i].projectList[1].obtainedMarks) / 2;
            }

            for (int i = 0; i < selectedCandidates.Count; i++) //selecting Top candidates
            {

                if (selectedCandidates[i].averageMarks >= 90)
                {
                    topCandidates.Add(selectedCandidates[i]);
                }

            }

            //To display Top candidates marks in projects
            Console.WriteLine("\n\nStudents who scored >90% marks collectively are shown below:\n");
            DisplayMarks(topCandidates);


            //*************TASK 5****************
            //***********************************

            // To create a directory using dictionary for searching by city name
            Dictionary<string, List<Candidate>> studentsCityDirectory = new Dictionary<string, List<Candidate>>();
            for (int i = 0; i < candidatesList.Count; i++)
            {
                if (studentsCityDirectory.ContainsKey(candidatesList[i].city))
                {
                    studentsCityDirectory[candidatesList[i].city].Add(candidatesList[i]);
                }
                else
                {
                    List<Candidate> newCandidatesList = new List<Candidate>();
                    studentsCityDirectory.Add(candidatesList[i].city, newCandidatesList);
                    studentsCityDirectory[candidatesList[i].city].Add(candidatesList[i]);
                }
            }

            // To search the dictionary for candidates using city name
            Console.Write("\n\nEnter a city name to search candidates from that city: ");
            string inputCity = Console.ReadLine(); //To take city name as input from user
            
            List<Candidate> cityStudents = new List<Candidate>();

            if (studentsCityDirectory.TryGetValue(inputCity, out cityStudents))
            {
                Console.WriteLine("\nCandidates from " + inputCity + " are:\n");
                DisplayDictionary(cityStudents); // To display candidates from concerned city
            }
            else
            {
                Console.WriteLine("\nNo candidate from this city.");
            }

            Console.ReadKey();//Can also use Ctrl + Fn5
        }

        public static void DisplayStudentData(List<Candidate> clist)
        {
            Console.WriteLine("Name" + "\t\t" + "CGPA" + "\t" + "City\n");
            for (int i = 0; i < clist.Count; i++)
            {
                Console.WriteLine(clist[i].name + "\t" + clist[i].cgpa + "\t" + clist[i].city );
            }

        }

        public static void DisplayMarks(List<Candidate> slist)
        {
            Console.WriteLine("Name" + "\t\t" + "Project 1" + "\t" + "Project 2" + "\t" + "Average Marks\n");
            for (int i = 0; i < slist.Count; i++)
            {
                Console.WriteLine(slist[i].name + "\t" + slist[i].projectList[0].obtainedMarks + " \t\t" + slist[i].projectList[1].obtainedMarks + " \t\t" + ((slist[i].projectList[0].obtainedMarks + slist[i].projectList[1].obtainedMarks) / 2));
            }
         }

        public static void DisplayDictionary(List<Candidate> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].name);
            }
        }

    }
}
