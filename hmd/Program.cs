using System;

namespace hmd
{
    class Program
    {
        public static void WelcomeScreen()
        {
            //------------welcome screen---------
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t*************** HOSPITAL MANAGEMENT SYSTEM ***************");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press D to select to get Docters Information\n");
            Console.WriteLine("\t\t 2. \t Press P to select to get Patients Information\n");
        }

        public static void DrsWindow()
        {
            //------------DOCTORS WINDOW---------
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
                    Console.WriteLine("\t\t\tDocters Timings");
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\t Please select right option");
                    break;
            }
        }

        public static void patientsWindow()
        {
            //------------PATIENT WINDOW---------
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
                    Console.WriteLine("\t\t\t Please select right option");
                    WelcomeScreen();
                    break;
            }
        }
        static void Main(string[] args)
        {
            WelcomeScreen();

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
                    Console.WriteLine("\t\t\t Please select right option");
                    break;
            }


            //-----------------------------------

        }

        //------------Doctor info window-------
    }
}
