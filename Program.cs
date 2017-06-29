using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, GradeGroup> Groups = new Dictionary<string, GradeGroup>();
            string Name = null;
            string Weighting = null;

            Console.WriteLine("Please enter the grade weighting for each group by percentage.\n" +
                "If there is no weighting and all assignments represent a total\n" +
                "percentage, just add one group for 100%.\n\n" +
                "Press enter after you have input all groups.");

            do
            {
                Console.Write("Name: ");
                Name = Console.ReadLine();

                if (Name == "")
                {
                    break;
                }

                Console.Write("Weighting: ");
                Weighting = Console.ReadLine();

                Groups.Add(Name.ToLower(), new GradeGroup(Name, Weighting));
            } while (true);

        CheckGradeGroups:
            Console.WriteLine("\nYou entered the groups:\n");
            Console.WriteLine("NAME\t\tWEIGHTING");

            decimal TotalWeighting = 0;
            foreach (KeyValuePair<string, GradeGroup> Item in Groups)
            {
                TotalWeighting += Item.Value.Weight;
                Console.WriteLine(String.Format("{0}\t\t{1}", Item.Value.Name, Item.Value.Weight));
            }

            if (TotalWeighting != 1)
            {
                Console.WriteLine("\nWarning: Grade weighting does not add to 100%");
            }

            Console.Write("\nDoes this look okay? (y)/n: ");
            ConsoleKeyInfo InputCheckGradeGroup = Console.ReadKey();
            if (InputCheckGradeGroup.KeyChar == 'n')
            {
            ChangeGradeGroups:
                Console.Write("\nName of group to change: ");
                string GroupKey = Console.ReadLine();

                if (Groups.ContainsKey(GroupKey.ToLower()))
                {
                    Name = Groups[GroupKey.ToLower()].Name;
                    Weighting = String.Format("{0}%", (Groups[GroupKey.ToLower()].Weight) * 100);

                    Console.Write(String.Format("Name ({0}): ", Name));
                    string NameChange = Console.ReadLine();
                    if (NameChange != "") Name = NameChange;

                    Console.Write(String.Format("Weighting ({0}): ", Weighting));
                    string WeightingChange = Console.ReadLine();
                    if (WeightingChange != "") Weighting = WeightingChange;

                    Groups.Remove(GroupKey.ToLower());
                    Groups.Add(GroupKey.ToLower(), new GradeGroup(Name, Weighting));

                    goto CheckGradeGroups;
                }
                else
                {
                    if (GroupKey == "")
                    {
                        goto GradeInput;
                    }
                    else
                    {
                        Console.WriteLine("Group doesn't exist!");
                        goto ChangeGradeGroups;
                    }
                    
                }
            }

        GradeInput:
            Console.WriteLine("Please enter the grades for each group, separated by comma.\n" +
                              "Example: 12/13, 10/10, 90%/30\n");

            foreach (KeyValuePair<string, GradeGroup> Item in Groups)
            {
            AttempGradeInput:
                Console.Write(String.Format("{0}: ", Item.Value.Name));
                string GradesListInput = Console.ReadLine();
                string[] GradesListEx = GradesListInput.Split(',');

                List<Grade> GradesList = new List<Grade>();
                try
                {
                    foreach (string Grade in GradesListEx)
                    {
                        GradesList.Add(new Grade(Grade));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nCouldn't parse your input, please try again.");
                    goto AttempGradeInput;
                }


                Groups[Item.Key].Grades = GradesList;
            }

        //CalculateTotalGrade:
            List<decimal> GroupGrades = new List<decimal>();
            foreach (KeyValuePair<string, GradeGroup> Item in Groups)
            {
                decimal Scores = 0;
                decimal Totals = 0;
                foreach (Grade GradeItems in Item.Value.Grades)
                {
                    Scores = Scores + GradeItems.Score;
                    Totals = Totals + GradeItems.Total;
                }

                Console.WriteLine(String.Format("{0} Scores: {1}", Item.Value.Name, Scores));
                Console.WriteLine(String.Format("{0} Totals: {1}", Item.Value.Name, Totals));

                Console.WriteLine(String.Format("{0} Weighted: {1}\n", Item.Value.Name, Item.Value.Weight * (Scores / Totals)));
                GroupGrades.Add(Item.Value.Weight * (Scores / Totals));
            }

            decimal OverallGrade = GroupGrades.Sum();
            Console.WriteLine(String.Format("Overall Grade: {0}%", OverallGrade * 100));
        }
    }
}
