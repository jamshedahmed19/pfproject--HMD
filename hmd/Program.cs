using System;
using System.IO;
using System.Linq;

namespace hmd
{
    class Program
    {
        static string path = @"G:\jamshed_uni\PF\project\hmd\drs__info.txt";
        static string Covid__guides = @"G:\jamshed_uni\PF\project\hmd\covid__19-guide.txt";
        static string Covid__symptoms = @"G:\jamshed_uni\PF\project\hmd\covid__19-symptoms.txt";
        static string Pass_path = @"G:\jamshed_uni\PF\project\hmd\pass.txt";
        static string Username_path = @"G:\jamshed_uni\PF\project\hmd\username_info.txt";
        static string covid__report = @"G:\jamshed_uni\PF\project\hmd\covid__reports.txt";

        static void WelcomeScreen()
        {
            //login window
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t******** WELCOME TO HOSPITAL MANAGEMENT SYSTEM ********");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press L to Login to HOSPITAL MANAGEMENT SYSTEM\n");
            Console.WriteLine("\t\t 2. \t Press C to go to Covid-19 Help Desk\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'l':
                    loginWindow();
                    break;
                case 'c':
                    CovidDesk();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    WelcomeScreen();
                    break;
            }
        }

        static void loginWindow()
        {
            //login window
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t**** WELCOME TO HOSPITAL MANAGEMENT SYSTEM LOGIN WINDOW ****");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press L to Login to your account\n");
            Console.WriteLine("\t\t 2. \t Press C to Create an account\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'l':
                    Pass();
                    break;
                case 'c':
                    AccountReg();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    loginWindow();
                    break;
            }
        }

        static void Pass()
        {
            int i = 0;
            string user_pass;
            do {
                Console.Write("\t\t\tEnter your Username:\t");
                string user_name = Console.ReadLine();
                user_name = user_name.ToLower();


                if (File.ReadLines(Username_path).Any(line => line.Contains(user_name)))
                {
                    Console.Write("\t\t\tEnter your Password:\t");
                    user_pass = ReadPassword();

                    if (File.ReadLines(Pass_path).Any(line => line.Contains(user_pass)))
                    {
                        MenuScreen();
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tEnter Correct Password");
                        i++;
                    }

                }
                else
                {
                    Console.WriteLine("\t\t\tEnter Correct Username");
                    i++;
                }

                if(i == 3)
                {
                    Console.WriteLine("Try Again later!!");
                }
            } while (i<3);

            Console.WriteLine("\t\t 3. \t Press any key to go back\n");
            Console.WriteLine("\t\t 4. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    loginWindow();
                    break;
            }
        }
    
        static void AccountReg()
        {
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t********* Account Registration window *********");
            Console.WriteLine("\t\t\t==========================================================================\n\n");

            Console.Write("\t\t\tCreate your Username:\t");
            string user_name = Console.ReadLine();
            user_name = user_name.ToLower();

            Console.Write("\t\t\tCreate your Password:\t");
            string user_pass = ReadPassword();

            File.AppendAllText(Username_path, Environment.NewLine + user_name);
            File.AppendAllText(Pass_path, Environment.NewLine + user_pass);
            Console.WriteLine("Data entered success");
            Console.WriteLine();

            Console.WriteLine("\t\t 3. \t Press b to go back\n");
            Console.WriteLine("\t\t 4. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'b':
                    loginWindow();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    AccountReg();
                    break;
            }
        }

        public static string ReadPassword()
        {
            
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            password = password.ToLower();
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        static void MenuScreen()
        {
            //------------welcome screen---------
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t*************** HOSPITAL MANAGEMENT SYSTEM MENU***************");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press D to select to get Docters Information\n");
            Console.WriteLine("\t\t 2. \t Press P to select to get Patients Information\n");
            Console.WriteLine("\t\t 2. \t Press C to go to Covid-19 Help Desk\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'd':
                    DrsWindow();
                    break;
                case 'p':
                    patientsWindow();
                    break;
                case 'c':
                    CovidDesk();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    WelcomeScreen();
                    break;
            }
        }

        static void CovidDesk()
        {
            // Coronavirus Help Desk
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Covid-19 Help Desk ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press T for Covid-19 Self Test\n");
            Console.WriteLine("\t\t 2. \t Press P to Read Prevention Guidlines\n");
            Console.WriteLine("\t\t 3. \t Press S to Read Covid-19 Symptoms\n");
            Console.WriteLine("\t\t 4. \t Press V to View Your Covid-19 Report\n");
            Console.WriteLine("\t\t 5. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 't':
                    CoronaTest();
                    break;
                case 'p':
                    CovidGuides();
                    break;
                case 'c':
                    CovidDesk();
                    break;
                case 's':
                    CovidSymptoms();
                    break;
                case 'v':
                    CovidReport();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    CovidDesk();
                    break;
            }
        }

        static void CoronaTest()
        {
            string remarks = "", test_result = "";
            int report_id = 0;

            Random random = new Random();
            report_id = random.Next(1000, 9999);


            // Corona Virus Self Test
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Covid-19 Self Test ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t\tPress Y for yes or N for No from your Keyboard:\n\n\n");

            Console.Write("\t\t\tEnter Your Name:\t");
            string name = Console.ReadLine();

            Console.Write("\t\t\tEnter Your Age:\t");
            int age = int.Parse(Console.ReadLine());

            Console.Write("\t\t\tEnter Your Health Condition Either good or bad:\t");
            string health_cond = Console.ReadLine();
            health_cond = health_cond.ToLower();

            Console.Write("\t\t\tDo you have fever?\t");
            char fever__ans = Console.ReadKey().KeyChar;
            fever__ans = char.ToLower(fever__ans);

            Console.Write("\n\t\t\tDo you feel Tired?\t");
            char tired__ans = Console.ReadKey().KeyChar;
            tired__ans = char.ToLower(tired__ans);

            Console.Write("\n\t\t\tDo you have dry cough?\t");
            char cough__ans = Console.ReadKey().KeyChar;
            cough__ans = char.ToLower(cough__ans);
            Console.WriteLine("\n\n");

            if ((age >= 45) || (age <= 6))
            {
                if (fever__ans == 'y' && tired__ans == 'y' && cough__ans == 'y')
                {
                    test_result = "Positive";
                    remarks = "Should Go to Hospital";
                }
                else if ((fever__ans == 'y' && tired__ans == 'y' && cough__ans == 'n') || (fever__ans == 'n' && tired__ans == 'y' && cough__ans == 'y') || (fever__ans == 'y' && tired__ans == 'n' && cough__ans == 'y'))
                {
                    test_result = "Uncomfirmed";
                    remarks = "Get Yourself Tested";
                }
                else if ((fever__ans == 'y' && tired__ans == 'n' && cough__ans == 'n') || (fever__ans == 'n' && tired__ans == 'n' && cough__ans == 'y') || (fever__ans == 'n' && tired__ans == 'y' && cough__ans == 'n'))
                {
                    test_result = "Uncomfirmed";
                    remarks = "Should Go to Hospital";
                }
                else if (fever__ans == 'n' && tired__ans == 'n' && cough__ans == 'n')
                {
                    test_result = "Negative";
                    remarks = "You/'re fine, still maintain social distancing";
                }
                else
                {
                    Console.WriteLine("Enter Right Input!!");
                }
            }
            else if (age > 6 && age < 45)
            {
                if (fever__ans == 'y' && tired__ans == 'y' && cough__ans == 'y')
                {
                    test_result = "Positive";
                    remarks = "Should Go to Hospital";
                }
                else if ((fever__ans == 'y' && tired__ans == 'y' && cough__ans == 'n') || (fever__ans == 'n' && tired__ans == 'y' && cough__ans == 'y') || (fever__ans == 'y' && tired__ans == 'n' && cough__ans == 'y'))
                {
                    test_result = "Uncomfirmed";
                    remarks = "Get Yourself Tested";
                }
                else if ((fever__ans == 'y' && tired__ans == 'n' && cough__ans == 'n') || (fever__ans == 'n' && tired__ans == 'n' && cough__ans == 'y') || (fever__ans == 'n' && tired__ans == 'y' && cough__ans == 'n'))
                {
                    test_result = "Uncomfirmed";
                    remarks = "Should Go to Hospital";
                }
                else if (fever__ans == 'n' && tired__ans == 'n' && cough__ans == 'n')
                {
                    test_result = "Negative";
                    remarks = "You/'re fine, still maintain social distancing";
                }
                else
                {
                    Console.WriteLine("Enter Right Input!!");

                }
            }
            else
            {
                Console.WriteLine("Enter Right Input!!");
            }

            Console.WriteLine("\t\t\t-----------------------------------------------------------");
            Console.WriteLine("\t\t\t\t {0}\'s Covid-19 Seflf Test Report", name);
            Console.WriteLine();
            Console.WriteLine("\t\t\t\tSymptoms\t\tYes/No\n");
            Console.WriteLine("\t\t\t\t 1.Fever\t\t{0}", fever__ans);
            Console.WriteLine("\t\t\t\t 2.Tiredness\t\t{0}", tired__ans);
            Console.WriteLine("\t\t\t\t 3.Dry Cough\t\t{0}\n\n", cough__ans);
            Console.WriteLine("\t---------------------------------------------------------------------------------------------");
            Console.WriteLine("\tReport ID\tAge\tHealth Cond.\tTest Result\t\tRemarks");
            Console.WriteLine("\t{0}\t\t{1}\t{2}\t\t{3}\t{4}", report_id, age, health_cond, test_result, remarks);

            File.AppendAllText(covid__report, Environment.NewLine + "\t" + report_id + "\t\t" + name + "\t" + age + "\t" + health_cond + "\t\t "  + test_result + "\t" + remarks);
            Console.WriteLine("Data entered success");
            Console.WriteLine();

            Console.WriteLine("\t\t 1. \t Press any key to Covid-19 Help Desk");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    CovidDesk();
                    break;
            }
        }

        static void CovidReport()
        {
            Console.Write("\n\n\t\t\tEnter Report ID to View:\t");
            string id = Console.ReadLine().Trim();
            Console.WriteLine();

            foreach (string line in System.IO.File.ReadAllLines(covid__report))
            {
                if (line.Contains(id))
                {
                    Console.WriteLine("\t---------------------------------------------------------------------------------------------");
                    Console.WriteLine("\tReport ID\tName\t\tAge\tHealth Cond.\tTest Result\t\tRemarks");
                    Console.WriteLine(line);
                    break;
                }
            }
        }

        static void CovidSymptoms()
        {
            string[] lines = File.ReadAllLines(Covid__symptoms);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 2. \t Press any key to go to Covid-19 Help Desk\n\n\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    CovidDesk();
                    break;
            }
        }

        static void CovidGuides()
        {
            string[] lines = File.ReadAllLines(Covid__guides);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 2. \t Press any key to go to Covid-19 Help Desk\n\n\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    CovidDesk();
                    break;
            }
        }

        static void PrintAllDrsInfo()
        {
            // Doctor Timing View Window
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
            //Doctor Timing Registering Window 
            int i = 1;
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Timing ***************");
            Console.WriteLine("\t\t\t===================================================================\n");
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
            Console.WriteLine("\t\t 2. \t Press B to to go to Doctors Timing Window\n");
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
            //Doctor Timing Window 

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
