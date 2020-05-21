using System;
using System.IO;
using System.Linq;

namespace hmd
{
    class Program
    {

        //------------------------FILE PATHS-----------------------

        static string path = @"G:\jamshed_uni\PF\project\hmd\drs__info.txt";
        static string Covid__guides = @"G:\jamshed_uni\PF\project\hmd\covid__19-guide.txt";
        static string Covid__symptoms = @"G:\jamshed_uni\PF\project\hmd\covid__19-symptoms.txt";
        static string Pass_path = @"G:\jamshed_uni\PF\project\hmd\pass.txt";
        static string Username_path = @"G:\jamshed_uni\PF\project\hmd\username_info.txt";
        static string covid__report = @"G:\jamshed_uni\PF\project\hmd\covid__reports.txt";
        static string patient_info = @"G:\jamshed_uni\PF\project\hmd\patient_info.txt";
        static string drs_info = @"G:\jamshed_uni\PF\project\hmd\drs__info.txt";

        //-----------------------------------------------------------

        //------------------------MAIN METHOD-----------------------
        static void Main(string[] args)
        {
            WelcomeScreen();
        }

        //------------------------WELCOME WINDOW OF HMD-----------------------
        static void WelcomeScreen()
        {
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
                    LoginWindow();
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

        //----------------------------------------------------------------------

        //------------------------ACCOUNT REGISTRATION/LOG IN WINDOW OF HMD-----------------------
        static void LoginWindow()
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
                    LoginWindow();
                    break;
            }
        }

        //-----------------------------------------------------------------------

        //------------------------LOGIN WINDOW OF HMD-----------------------
        static void Pass()
        {
            //StreamWriter a = new StreamWriter(Username_path);
            //Console.Write("\t\t\tEnter your Username:\t");
            //string user_name = Console.ReadLine();
            //user_name = user_name.ToLower();
            //a.WriteLine("user b");
            //a.WriteLine("pass b");
            //a.Close();
            //string username = Console.ReadLine();
            //string pass = Console.ReadLine();
            //StreamReader ab = new StreamReader(username);

            //string line1 = ab.ReadLine();
            //string line2 = ab.ReadLine();
            ////int counter1 = 0;
            ////int x = 1;

            //while ((line1 != null) && (line2 != null))
            //{
            //    if ((line1 == username) && (line2 == pass))
            //    {
            //        Console.WriteLine("Welcome");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Try Again");
            //    }

            //    username = Console.ReadLine();
            //    pass = Console.ReadLine();
            //}
            //Console.WriteLine();


            //ab.Close();
            int i = 0;
            string user_pass;
            do
            {
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

                if (i == 3)
                {
                    Console.WriteLine("\n\t\t\tTry Again!!\n");
                }
            } while (i < 3);

            Console.WriteLine("\t\t 3. \t Press any key to go back\n");
            Console.WriteLine("\t\t 4. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'q':
                    LoginWindow();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    LoginWindow();
                    break;
            }
        }

        //-----------------------------------------------------------------------


        //------------------------ACCOUNT REGISTRATION WINDOW OF HMD-----------------------
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
            Console.WriteLine("\n\t\t\tData entered success\n");
            Console.WriteLine();

            Console.WriteLine("\t\t 3. \t Press b to go back\n");
            Console.WriteLine("\t\t 4. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'b':
                    LoginWindow();
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

        //-----------------------------------------------------------------------

        //------------------------COVID HELP DESK WINDOW-----------------------
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

        //----------------------------------------------------------------------------

        //------------------------COVID SELF TEST WINDOW-----------------------
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
                    Console.WriteLine("\n\t\t\tEnter Right Input!!\n");
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
                    Console.WriteLine("\n\t\t\tEnter Right Input!!\n");

                }
            }
            else
            {
                Console.WriteLine("\n\t\t\tEnter Right Input!!\n");
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

            File.AppendAllText(covid__report, Environment.NewLine + "\t" + report_id + "\t\t" + name + "\t" + age + "\t" + health_cond + "\t\t " + test_result + "\t" + remarks);
            Console.WriteLine("\n\t\t\tData entered success\n");
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

        //---------------------------------------------------------------------------------

        //------------------------COVID-19 PREVENTION GUIDLINES WINDOW-----------------------
        static void CovidGuides()
        {
            string[] lines = File.ReadAllLines(Covid__guides);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press any key to go to Covid-19 Help Desk\n");
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

        //----------------------------------------------------------------------------------

        //------------------------COVID-19 SYPMTOMS WINDOW-----------------------
        static void CovidSymptoms()
        {
            string[] lines = File.ReadAllLines(Covid__symptoms);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press any key to go to Covid-19 Help Desk\n");
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

        //----------------------------------------------------------------------------------

        //------------------------COVID TEST REPORT WINDOW-----------------------
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

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press any key to Covid-19 Help Desk\n");
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

        //--------------------------------------------------------------------------------

        //------------------------HMD MENU SCREEN-----------------------
        static void MenuScreen()
        {
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t==========================================================================");
            Console.WriteLine("\t\t\t\t*************** HOSPITAL MANAGEMENT SYSTEM MENU***************");
            Console.WriteLine("\t\t\t==========================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press D to select to get Docters Information\n");
            Console.WriteLine("\t\t 2. \t Press P to select to get Patients Information\n");
            Console.WriteLine("\t\t 3. \t Press C to go to Covid-19 Help Desk\n");
            Console.WriteLine("\t\t 4. \t Press Q to go to Log out of HMS\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);

            switch (selection_key)
            {
                case 'd':
                    DrsInfo();
                    break;
                case 'p':
                    PatientsWindow();
                    break;
                case 'c':
                    CovidDesk();
                    break;
                case 'q':
                    WelcomeScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    WelcomeScreen();
                    break;
            }
        }

        //----------------------------------------------------------------------------

        //------------------------DOCTORS INFORMATION WINDOW-----------------------
        static void DrsInfo()
        {

            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Information ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press E to enter Docters Timings\n");
            Console.WriteLine("\t\t 2. \t Press V to view Doctor Timings\n");
            Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n\n\n");

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
                case 'q':
                    MenuScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    DrsInfo();
                    break;
            }
        }

        //----------------------------------------------------------------------------

        //------------------------DOCTORS TIMING INSERTING WINDOW-----------------------
        static void InsertDrsInfo()
        {
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


                File.AppendAllText(path, Environment.NewLine + "\t\t\t" + DID + "\t, " + D_name + "   \t, " + D_timing + " \t, " + D_cell_no + " \t, " + D_dept);
                Console.WriteLine("\n\t\t\tData entered success\n");
                Console.WriteLine();

                Console.WriteLine("\t\t 1. \t Press C to Continue\n");
                Console.WriteLine("\t\t 2. \t Press B to to go to Doctors Timing Window\n");
                Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n\n\n");

                char selection_key = Console.ReadKey().KeyChar;
                selection_key = char.ToLower(selection_key);
                Console.WriteLine("\n\n");

                switch (selection_key)
                {
                    case 'c':
                        InsertDrsInfo();
                        break;
                    case 'b':
                        DrsInfo();
                        break;
                    case 'q':
                        MenuScreen();
                        break;
                    default:
                        Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                        InsertDrsInfo();
                        break;
                }

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
        }

        //-------------------------------------------------------------------------------------

        //------------------------DOCTORS TIMING VIEWING WINDOW-----------------------
        static void PrintAllDrsInfo()
        {
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Timing ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("\t\t\tID\t    Name\t        Timing\t         Cell No.\tDepartment\n");

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t ===================================================================\n\n");
            Console.WriteLine("\t\t 1. \t Press B to to go to Doctors Timing Window\n");
            Console.WriteLine("\t\t 2. \t Press Q to to go to Main Menu\n\n\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'b':
                    DrsInfo();
                    break;
                case 'q':
                    MenuScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    PrintAllDrsInfo();
                    break;
            }
        }

        //------------------------------------------------------------------------------

        //------------------------PATIENTS WINDOW-----------------------
        static void PatientsWindow()
        {
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
                    PatientRecords();
                    break;
                case 'a':
                    DoctorsAppointment();
                    break;
                case 'q':
                    MenuScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    PatientsWindow();
                    break;
            }
        }

        //----------------------------------------------------------------------------------

        //------------------------PATIENTS INFORMATION WINDOW-----------------------
        static void PatientRecords()
        {
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Patient Records ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            Console.WriteLine("Patient Name\tPatient Cell\tAge\tPatient ID\t\t\tDr ID\t  Doctor Name\t\tDoctor Timing\tDoctor Cell\tDepartment\n");

            string[] lines = File.ReadAllLines(patient_info);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine();
            Console.WriteLine("\t\t 1. \t Press A to to go to Doctor Appointment Window\n");
            Console.WriteLine("\t\t 2. \t Press S to to search specific Patient\n");
            Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n");

            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'a':
                    DoctorsAppointment();
                    break;
                case 's':
                    SearchPatient();
                    break;
                case 'q':
                    MenuScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    PatientRecords();
                    break;
            }
        }

        //-------------------------------------------------------------------------

        //------------------------PATIENTS SEARCH WINDOW-----------------------
        static void SearchPatient()
        {
            int c = 1;
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Patient Search Window ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            do
            {
                Console.Write("\t\t\tEnter Paitent's ID:\t");
                string patient_id = Console.ReadLine();
                FileStream inFile = new FileStream(patient_info, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                Console.WriteLine();
                try
                {
                    //the program reads the record and displays it
                    record = reader.ReadLine();
                    while (record != null)
                    {
                        if (record.Contains(patient_id))
                        {
                            Console.WriteLine("\t\t\t-------------------------------------------------------------------");
                            Console.WriteLine("\t\t\t\t*************** Patient Details ***************");
                            Console.WriteLine("\t\t\t-------------------------------------------------------------------\n\n");
                            Console.WriteLine(record);

                        }
                        record = reader.ReadLine();
                    }
                }
                finally
                {
                    //after the record is done being read, the progam closes
                    reader.Close();
                    inFile.Close();
                }
                Console.WriteLine();
                Console.Write("\t\tPress C if you want to Continue:\t");
                string key = Console.ReadLine();
                key = key.ToLower();

                if (key == "c")
                {
                    c--;
                }
                else
                {
                    c++;
                }

            } while (c < 1);
            Console.WriteLine("\t\t 1. \t Press I for Patients Info\n");
            Console.WriteLine("\t\t 2. \t Press A to select to book Doctors Appointment\n");
            Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n");
            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'i':
                    PatientRecords();
                    break;
                case 'a':
                    DoctorsAppointment();
                    break;
                case 'q':
                    MenuScreen();
                    break;
                case 'p':
                    PatientsWindow();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    SearchPatient();
                    break;
            }
        }

        //-----------------------------------------------------------------------------------

        //------------------------DOCTORS APPOINTMNET WINDOW-----------------------
        static void DoctorsAppointment()
        {
            string doc_details;
            int c = 1;
            Console.WriteLine(DateTime.Now.ToString("\t\t\tHH:mm:ss\t\t\t\t\t\tdd-MM-yyyy"));
            Console.WriteLine("\t\t\t===================================================================");
            Console.WriteLine("\t\t\t\t*************** Doctors Appoitnment ***************");
            Console.WriteLine("\t\t\t===================================================================\n\n");
            do
            {
                int patient_id = 0;
                Random random = new Random();
                patient_id = random.Next(100, 999);
                Console.Write("\t\t\tEnter Patients Name:\t");
                string p_name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\t\t\tEnter Patients Contact Number:\t");
                long contact = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine();
                Console.Write("\t\t\tEnter Patients Age:\t");
                int age = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("\t\t\tPatient ID assigned to patient " + p_name + " is : " + patient_id);
                Console.WriteLine();
                Console.Write("\t\t\tDoctors List:\t");
                Console.WriteLine();
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
                Console.Write("\t\t\tEnter Doctor's ID, patient want appoiintment for:\t");
                string d_id = Console.ReadLine();
                FileStream inFile = new FileStream(drs_info, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                Console.WriteLine();
                try
                {
                    //the program reads the record and displays it
                    record = reader.ReadLine();
                    while (record != null)
                    {
                        if (record.Contains(d_id))
                        {
                            doc_details = record;
                            File.AppendAllText(patient_info, Environment.NewLine + "\t" + p_name + "\t" + contact + "\t" + age + "\t" + patient_id + doc_details);
                            Console.WriteLine();
                            Console.WriteLine("\t\t\t\t\t-----------------------------");
                            Console.WriteLine("\t\t\t\t\tAppointment Confirmed.!");
                            Console.WriteLine("\t\t\t\t\tData Entered Succesfully.!");
                            Console.WriteLine("\t\t\t\t\t-----------------------------");
                        }
                        record = reader.ReadLine();
                    }
                }
                finally
                {
                    //after the record is done being read, the progam closes
                    reader.Close();
                    inFile.Close();
                }
                Console.WriteLine();
                Console.Write("\t\tPress C if you want to Continue:\t");
                string key = Console.ReadLine();
                key = key.ToLower();

                if (key == "c")
                {
                    c--;
                }
                else
                {
                    c++;
                }
            } while (c < 1);
            Console.WriteLine();
            Console.WriteLine("\t\t 1. \t Press I to to go to Patient Info Window Window\n");
            Console.WriteLine("\t\t 2. \t Press S to to search specific Patient\n");
            Console.WriteLine("\t\t 3. \t Press Q to to go to Main Menu\n");


            char selection_key = Console.ReadKey().KeyChar;
            selection_key = char.ToLower(selection_key);
            Console.WriteLine("\n\n");

            switch (selection_key)
            {
                case 'i':
                    PatientRecords();
                    break;
                case 's':
                    SearchPatient();
                    break;
                case 'q':
                    MenuScreen();
                    break;
                default:
                    Console.WriteLine("\t\t\tPlease Select Right Options\n\n");
                    DoctorsAppointment();
                    break;
            }


        }

        //------------------------------------------------------------------------------------

        //------------------------PASSWORD MASKING METHOD-----------------------
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

    }
}
