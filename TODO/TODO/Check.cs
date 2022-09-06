using System;
using System.Collections.Generic;

namespace TODO
{
    public class Check : Task
    {
        //Contains the tasks
        public List<Task> tasklist = new List<Task>();

        //Contains the users
        public List<string> userlist = new List<string>();

        //Users coming from files go temporarily to here
        public List<string> tempusers = new List<string>();

        //The index of the chosen user
        public int currentuser = 0;

        /// <summary>
        /// Returns the task list (taskList) for the files to read
        /// </summary>
        public List<Task> ReturnTaskList()
        {
            return tasklist;
        }

        /// <summary>
        /// Returns the user list (userList) for the files to read
        /// </summary>
        public List<string> ReturnList()
        {
            return userlist;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        public void CreateUser()
        {
            Console.Write("Anna käyttäjän nimi: ");
            string name = Program.ui.ReadKeyAndLine();
            if (name != null)
            {
                userlist.Add(name);
                Program.file.WriteUsersToFile(userlist);
            }
            else if (name == null)
            {
                Program.ui.UserMenu();
            }


            while (true)
            {
                Console.WriteLine("Haluatko lisätä lisää käyttäjiä? (y/n)");
                ConsoleKeyInfo add = Console.ReadKey(true);
                if (add.KeyChar == 'y')
                {
                    Console.Write("Anna käyttäjän nimi: ");
                    string nimi2 = Program.ui.ReadKeyAndLine();
                    if (name != null)
                    {
                        userlist.Add(name);
                        Program.file.WriteUsersToFile(userlist);
                    }
                    else if (name == null)
                    {
                        Program.ui.UserMenu();
                    }

                }
                else if (add.KeyChar == 'n')
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Choose the current user
        /// </summary>
        public void SelectUser()
        {

            while (true)
            {
                int selectionparse = 0;
                bool success;

                try
                {
                    if (userlist.Count <= 0)
                    {
                        Console.WriteLine("Käyttäjiä ei ole. Haluatko lisätä uuden? (y/n)");
                        ConsoleKeyInfo question = Console.ReadKey(true);
                        if (question.KeyChar == 'y')
                        {
                            CreateUser();
                            Console.WriteLine();
                            Console.WriteLine("Minkä käyttäjän haluat valita? (numero)");
                            for (int i = 0; i < userlist.Count; i++)
                            {
                                Console.Write(userlist[i]);
                                Console.Write("(" + i + ")");
                                Console.WriteLine(Environment.NewLine);
                            }

                            string choise = Program.ui.ReadKeyAndLine();
                            if (choise != null)
                            {
                                success = int.TryParse(choise, out selectionparse);
                                if (success == true)
                                {
                                    currentuser = selectionparse;
                                }
                                Program.file.CheckFileListLenght(Program.check.ReturnList());
                                break;
                            }
                            else if (choise == null)
                            {
                                Program.ui.UserMenu();
                                break;
                            }
                        }
                        else if (question.KeyChar == 'n')
                        {
                            Console.Clear();
                            Program.ui.UserMenu();
                            Program.file.CheckFileListLenght(Program.check.ReturnList());

                            break;
                        }
                        else if (question.KeyChar != 'y' | question.KeyChar != 'n')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Antamasi kirjain ei ollut y tai n.");
                            Console.ResetColor();
                        }
                    }
                    else if (userlist.Count >= 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Minkä käyttäjän haluat valita? (numero)");
                        for (int i = 0; i < userlist.Count; i++)
                        {
                            Console.Write(userlist[i]);
                            Console.Write("(" + i + ")");
                            Console.WriteLine(Environment.NewLine);
                        }
                        string selection = Program.ui.ReadKeyAndLine();
                        if (selection != null)
                        {
                            selectionparse = int.Parse(selection);
                            currentuser = selectionparse;
                        }
                        else if (selection == null)
                        {
                            Program.ui.UserMenu();
                            break;
                        }

                        while (true)
                        {
                            if (selectionparse <= userlist.Count - 1)
                            {
                                selectionparse = currentuser;
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Käyttäjää ei ole olemassa, kokeile uudelleen");
                                Console.ResetColor();

                                selection = Program.ui.ReadKeyAndLine();
                                selectionparse = int.Parse(selection);
                                currentuser = selectionparse;
                            }
                        }
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antamasi luku ei ollut numero.");
                    Console.ResetColor();
                }
                catch (AccessViolationException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kyseistä käyttäjää ei ole olemassa.");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Deletes the chosen user
        /// </summary>
        public void DeleteUser()
        {

            while (true)
            {
                try
                {
                    if (userlist.Count > 0)
                    {
                        Console.WriteLine("Minkä käyttäjän haluat poistaa? (numero)");
                        for (int i = 0; i < userlist.Count; i++)
                        {
                            Console.Write(userlist[i]);
                            Console.Write("(" + i + ")");
                            Console.WriteLine(Environment.NewLine);
                        }

                        string valinta = Program.ui.ReadKeyAndLine();
                        if (valinta != null)
                        {
                            int valintaparse = int.Parse(valinta);
                            currentuser = valintaparse;
                            userlist.RemoveAt(currentuser);
                            Program.file.RemoveUser(currentuser);
                            break;
                        }
                        else if (valinta == null)
                        {
                            Program.ui.UserMenu();
                            break;
                        }
                    }
                    else if (userlist.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Et ole asettanut yhtäkään käyttäjää. Paina mitä tahansa näppäintä jatkaaksesi.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antamassasi indeksissä ei ole käyttäjää.");
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antamasi luku ei ollut numero.");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Adds new tasks to a list
        /// </summary>
        public void CreateTask()
        {
            Console.WriteLine("Anna tehtävän nimi");
            string task = Program.ui.ReadKeyAndLine();
            if (task != null)
            {
                tasklist.Add(new Task(task, false, currentuser));
                Program.file.CheckFileListLenght(Program.check.ReturnList());
            }
            else if (task == null)
            {
                Program.ui.Menu();
            }



            while (true)
            {
                Console.WriteLine("Haluatko lisätä lisää tehtäviä? (y/n)");
                ConsoleKeyInfo choise = Console.ReadKey(true);
                if (choise.KeyChar == 'y')
                {
                    Console.WriteLine("Anna tehtävän nimi");
                    string task2 = Program.ui.ReadKeyAndLine();
                    if (task2 != null)
                    {
                        tasklist.Add(new Task(task2, false, currentuser));
                        Program.file.CheckFileListLenght(Program.check.ReturnList());

                    }
                    else if (task2 == null)
                    {
                        Program.ui.Menu();
                        break;
                    }
                }
                else if (choise.KeyChar == 'n')
                {
                    Program.file.RewriteTaskFile(Program.check.tasklist, Program.check.currentuser);
                    break;
                }
            }
        }

        /// <summary>
        /// User can mark a chosen task to be marked as ready (User cannot mark other users tasks as ready)
        /// </summary>
        public void Ready()
        {

            while (true)
            {
                int index = 0;
                try
                {

                    if (tasklist.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sinulla ei ole yhtään tehtäviä. Paina mitä tahansa näppäintä jatkaaksesi.");
                        Console.ResetColor();
                        Console.ReadKey();
                        index++;
                        break;
                    }
                    else if (tasklist.Count != 0)
                    {
                        Console.WriteLine("Mikä tehtävä on valmis? (numero)");
                        for (int i = 0; i < tasklist.Count; i++)
                        {
                            Console.Write("(" + i + ") " + tasklist[i]._name + "(" + userlist[tasklist[i]._user] + ")" + "");
                            if (tasklist[i]._ready == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("[X]");
                                Console.ResetColor();
                            }
                            else if (tasklist[i]._ready == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("[\u221A]");
                                Console.ResetColor();
                            }

                        }
                        string choise = Program.ui.ReadKeyAndLine();
                        if (choise == null)
                        {
                            Program.ui.Menu();
                            break;
                        }
                        else if (choise != null)
                        {
                            int selectionparse = int.Parse(choise);
                            if (tasklist[selectionparse]._user == currentuser)
                            {
                                tasklist[selectionparse]._ready = true;
                                Program.file.CheckFileListLenght(Program.check.ReturnList());
                                Program.file.WriteTaskToFile(tasklist, currentuser);
                                Program.file.RewriteTaskFile(tasklist, currentuser);
                            }
                            else if (tasklist[selectionparse]._user != currentuser)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Et voi merkata toisen käyttäjän tehtäviä valmiiksi. Paina mitä tahansa jatkaaksesi.");
                                Console.ReadKey();
                                Console.ResetColor();

                            }

                            index++;
                            break;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antamassasi indeksissä ei ole tehtävää.");
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antamasi luku ei ollut numero.");
                    Console.ResetColor();

                }
            }
        }

        /// <summary>
        /// Prints all the tasks (every users tasks) and shows if whether are ready or not
        /// </summary>
        public void PrintAllTasks()
        {
            if (tasklist.Count != 0)
            {
                for (int i = 0; i < tasklist.Count; i++)
                {

                    Console.Write(tasklist[i]._name + "(" + userlist[tasklist[i]._user] + ")" + "");
                    if (tasklist[i]._ready == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[X]");
                        Console.ResetColor();
                    }
                    else if (tasklist[i]._ready == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[\u221A]");
                        Console.ResetColor();
                    }
                    Console.Write(Environment.NewLine);
                }
            }
            else if (tasklist.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sinulla ei ole yhtään tehtäviä.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Another version of PrintTask. Only prints the current users tasks.
        /// </summary>
        public void PrintUsersTasks()
        {
            if (tasklist.Count != 0)
            {
                for (int i = 0; i < tasklist.Count; i++)
                {
                    if (tasklist[i]._user == currentuser)
                    {
                        Console.Write(tasklist[i]._name + "(" + userlist[tasklist[i]._user] + ")" + "");
                        if (tasklist[i]._ready == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("[X]");
                            Console.ResetColor();
                        }
                        else if (tasklist[i]._ready == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[\u221A]");
                            Console.ResetColor();
                        }
                        Console.Write(Environment.NewLine);
                    }
                }
            }
            else if (tasklist.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sinulla ei ole yhtään tehtäviä.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Deletes the chosen file
        /// </summary>
        public void DeleteTask()
        {
            try
            {

                if (tasklist.Count > 0)
                {
                    Console.WriteLine("Minkä tehtävän haluat poistaa? (numero)");
                    for (int i = 0; i < tasklist.Count; i++)
                    {
                        Console.Write(tasklist[i]._name + "(" + userlist[tasklist[i]._user] + ")" + "(" + i + ")");
                        Console.Write(Environment.NewLine);
                    }
                    string valinta = Program.ui.ReadKeyAndLine();
                    if (valinta != null)
                    {
                        int valintaparse = int.Parse(valinta);
                        if (tasklist[valintaparse]._user == currentuser)
                        {
                            tasklist.RemoveAt(valintaparse);
                            Program.file.RewriteTaskFile(Program.check.tasklist, Program.check.currentuser);
                        }
                        else if (tasklist[valintaparse]._user != currentuser)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Et voi poistaa toisen käyttäjän tehtäviä. Paina mitä tahansa näppäintä jatkaaksesi");
                            Console.ResetColor();
                            Console.ReadKey(true);
                        }
                    }
                    else if (valinta == null)
                    {
                        Program.ui.Menu();
                    }
                }

                else if (tasklist.Count <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sinulla ei ole tehtäviä joita voi poistaa. Paina mitä tahansa näppäintä jatkaaksesi");
                    Console.ResetColor();
                    Console.ReadKey(true);
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kyseistä tehtävää ei ole olemassa.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Make sure this rund before the other methods in Program.cs
        /// </summary>
        public void Start()
        {
            //käyttäjähomma
            Program.file.CreateUserFile();
            Program.check.tempusers = Program.file.ReadUsersToList();
            Program.file.CheckFileListLenght(Program.check.tempusers);
            for (int i = 0; i < Program.check.tempusers.Count; i++)
            {
                Program.check.userlist.Add(Program.check.tempusers[i]);
            }
            Program.file.WriteUsersToFile(Program.check.userlist);
            //käyttäjähomma loppu

            //Combines all the tasks from a file
            List<Task> kokeilu = new List<Task>();
            for (int i = 0; i < Program.check.userlist.Count; i++)
            {
                Program.check.tasklist.AddRange(Program.file.ReturnTasksFromFile(i));
            }
            for (int i = 0; i < kokeilu.Count; i++)
            {
                try
                {
                    Program.check.tasklist[i] = kokeilu[i];
                }
                catch (Exception)
                {
                    Program.check.tasklist.Add(kokeilu[i]);
                }
            }
        }
    }
}
