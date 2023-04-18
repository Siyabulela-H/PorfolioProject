using System;
using System.IO;

namespace Multi_Level
{
    class Program
    {
        //Siyabulela Hlanjwa 
        static void Main(string[] args)
        {
            string[] currentRow; double branchAverage = 0, employeeAverage = 0, finalAverage = 0,
            countEmp = 0, countBranch = 0, countYear = 0, finalBranchAve = 0, finalEmployeeAve = 0;
            string holdEmployee, holdBranch;
            StreamReader myReader = new StreamReader("C:/Users/Vusi/Downloads/Documents/Second Year SD/PRT1030 TECHNICAL PROGRAMMING/Assignment2TextFile.txt");
            currentRow = myReader.ReadLine().Split('#');
            holdEmployee = currentRow[0];
            holdBranch = currentRow[1];

            PrintReportHeading();
            PrintMainSectionHeading(currentRow[0]);
            PrintSubSectionHeading(holdBranch);
            countBranch++;
            countYear++;
            PrintLine(currentRow[2], double.Parse(currentRow[3]));
            branchAverage += double.Parse(currentRow[3]);

            while (!myReader.EndOfStream)
            {
                currentRow = myReader.ReadLine().Split('#');


                if(holdEmployee != currentRow[0])
                {
                    countYear++;
                    countEmp++;
                    employeeAverage += finalBranchAve;
                    finalEmployeeAve = employeeAverage / countEmp;

                    PrintSubSectionFooter(finalBranchAve);
                    PrintSectionFooter(holdEmployee, (finalEmployeeAve));
                    finalAverage = finalAverage + finalEmployeeAve;
                    branchAverage = 0; finalBranchAve = 0; employeeAverage = 0; countEmp = 0; holdEmployee = currentRow[0];
                    holdBranch = currentRow[1];
                    PrintMainSectionHeading(currentRow[0]);
                    PrintSubSectionHeading(currentRow[1]);
                }
                else if (holdBranch != currentRow[1])
                {
                    countEmp++; finalBranchAve = branchAverage / countBranch;
                    PrintSubSectionFooter(finalBranchAve);
                    employeeAverage += finalBranchAve;
                    branchAverage = 0; countBranch = 0; holdBranch = currentRow[1];
                    PrintSubSectionHeading(currentRow[1]);
                }
                PrintLine(currentRow[2], double.Parse(currentRow[3])); countBranch++;
                branchAverage = branchAverage + double.Parse(currentRow[3]);
            }
            myReader.Close();
            countEmp++; finalBranchAve = branchAverage / countBranch;
            PrintSubSectionFooter(finalBranchAve); employeeAverage += finalBranchAve;
            finalEmployeeAve = employeeAverage / countEmp;

            PrintSectionFooter(holdEmployee, (finalEmployeeAve));
            finalAverage = finalAverage + finalEmployeeAve;
            PrintReportFooter(finalAverage / countYear);
            Console.ReadLine();
            
        }
        static void PrintReportHeading()
        {
            Console.WriteLine("COMPANY SALES FOR THE PAST 5 YEARS:");
            Console.WriteLine("===================================");
        }
        static void PrintMainSectionHeading(string diploma)
        {
            Console.WriteLine("YEAR:" + diploma); 
        }
        static void PrintSubSectionHeading(string module)
        {
            Console.WriteLine("\t" + module.ToUpper());
        }
        static void PrintLine(string testNumber, double average)
        {
            Console.WriteLine("\tEmployee Number {0}:\t{1}", testNumber, average);
        }
        static void PrintSubSectionFooter(double moduleAverage)
        {
            Console.WriteLine("\tBranch Average:\t{0}\n", moduleAverage);
        }
        static void PrintSectionFooter(string yearName, double yearAverage)
        {
            Console.WriteLine("Year Average {0}:".PadRight(40, ' ') + "\t{1}", yearName, yearAverage);
            Console.WriteLine();
        }
        static void PrintReportFooter(double totalAverage)
        {
            Console.WriteLine("5 Year Average:".PadRight(40, ' ') + "\t{0}", totalAverage);
        }
    }
}
