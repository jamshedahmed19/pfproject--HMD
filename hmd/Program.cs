using System;
using System.IO;

namespace hmd
{
    class Program
    {
        static string path = @"G:\jamshed_uni\PF\project\hmd\drs__info.txt";
        static void WelcomeScreen()
        {
            //------------welcome screen---------
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t*************** HOSPITAL MANAGEMENT SYSTEM ***************");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press D to select to get Docters Information\n");
            Console.WriteLine("\t\t 2. \t Press P to select to get Patients Information\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'd':
                    DrsWindow();
                    break;
                case 'p':
                    patientsWindow();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    WelcomeScreen();
                    break;
            }
        }

        static void PrintAllDrsInfo()
        {
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Timing ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t\tID\tName\t\t\tTiming\t\tCell No.\tDepartment\n");
            
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 2. \t Press B to to go to Doctors Timing Window\n\n\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'b':
                    DrsTimming();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    PrintAllDrsInfo();
                    break;
            }
        }

        static void InsertDrsInfo()
        {
            int i = 1;
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Timing ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            do
            {
                Console.Write("\t\t\tEnter Doctors ID:\t");
                string DID = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\t\t\tEnter Doctors NAME:\t");
                string D_name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\t\t\tEnter Doctor Timing:\t");
                string D_timing = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\t\t\tEnter Doctor Cell NO:\t");
                string D_cell_no = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\t\t\tEnter Doctor Department:\t");
                string D_dept = Console.ReadLine();
                Console.WriteLine();


                File.AppendAllText(path, Environment.NewLine + "\t\t\t" + DID + "\t, " + D_name + " \t, " + D_timing + " \t, " + D_cell_no + " \t, " + D_dept);
                Console.WriteLine("Data entered success");
                Console.WriteLine();

                Console.Write("Press C if you want to Continue:\t");
                string key = Console.ReadLine();
                key = key.ToLower();

                if (key == "c")
                {
                    i--;
                }
                else
                {
                    i++;
                }

            } while (i < 1);
            Console.WriteLine("\t\t 2. \t Press B to to go to Doctors Timing Window\n\n\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'b':
                    DrsTimming();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    InsertDrsInfo();
                    break;
            }
        }

        static void DrsTimming()
        {
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Timing ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press E to enter Docters Timings\n");
            Console.WriteLine("\t\t 2. \t Press V to view Doctor Timings\n");
            Console.WriteLine("\t\t 2. \t Press B to to go to Doctors Information Window\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'e':
                    InsertDrsInfo();
                    break;
                case 'v':
                    PrintAllDrsInfo();
                    break;
                case 'b':
                    DrsWindow();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    DrsTimming();
                    break;
            }
        }

        static void DrsWindow()
        {
            //------------DOCTORS WINDOW---------
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Information ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press T Docters Timings\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 't':
                    DrsTimming();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    DrsWindow();
                    break;
            }
        }

        static void patientsWindow()
        {
            //------------PATIENT WINDOW---------
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Patients Information ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press I for Patients Info\n");
            Console.WriteLine("\t\t 2. \t Press A to select to book Doctors Appointment\n");
            Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'i':
                    Console.WriteLine("\t\t\tPatient info");
                    break;
                case 'a':
                    Console.WriteLine("\t\t\tDoctors Appointment");
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                case 'p':
                    patientsWindow();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    patientsWindow();                   
                    break;
            }
        }
        static void Main(string[] args)
        {
            WelcomeScreen();
        }

        //------------Doctor info window-------
    }
}
