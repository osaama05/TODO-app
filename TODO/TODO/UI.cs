using System;
using System.Windows.Forms;

namespace TODO
{
    internal class UI
    {
        private string version = "TODO-app  v 5.5";
        private string users = @"  _  __ _   _         _    _   _   _  _  _   _  _   
 | |/ /(_) (_)       | |  | | (_) (_)(_)(_) (_)| |  
 | ' /   __ _  _   _ | |_ | |_  __ _  _   __ _ | |_ 
 |  <   / _` || | | || __|| __|/ _` || | / _` || __|
 | . \ | (_| || |_| || |_ | |_| (_| || || (_| || |_ 
 |_|\_\ \__,_| \__, | \__| \__|\__,_|| | \__,_| \__|
                __/ |               _/ |            
               |___/               |__/             ";
        private string tasks = @"  _______     _      _   _   _        _   _  _   
 |__   __|   | |    | | (_) (_)      (_) (_)| |  
    | |  ___ | |__  | |_  __ _ __   __ __ _ | |_ 
    | | / _ \| '_ \ | __|/ _` |\ \ / // _` || __|
    | ||  __/| | | || |_| (_| | \ V /| (_| || |_ 
    |_| \___||_| |_| \__|\__,_|  \_/  \__,_| \__|
                                                 
                                                 ";
        private string menu = @"  __  __                     
 |  \/  |                    
 | \  / |  ___  _ __   _   _ 
 | |\/| | / _ \| '_ \ | | | |
 | |  | ||  __/| | | || |_| |
 |_|  |_| \___||_| |_| \__,_|
                             
                             ";
        public UI() { }

        /// <summary>
        /// Prints the menu, where you choose things related to users (choose user, make a new user, delete an user and show all the current tasks and their makers)
        /// </summary>
        public void UserMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.Title = version;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("ESC = Peruuta / Palaa takaisin");
                Console.ResetColor();
                Console.WriteLine(users);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Valitse mitä haluat tehdä (numero)");
                Console.ResetColor();
                Console.WriteLine("Sulje ohjelma (0)");
                Console.WriteLine("Valitse käyttäjä (1)");
                Console.WriteLine("Tee uusi käyttäjä (2)");
                Console.WriteLine("Poista käyttäjä (3)");
                Console.WriteLine("Näytä kaikki tehtävät (4)");
                Console.WriteLine();
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.KeyChar == '0')
                {

                    var confirm = MessageBox.Show("Oletko varma että haluat sulkea ohjelman?", "Varmistus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        //varmista että tämä tapahtuu ennen kun ohjelma sulkeutuu!!
                        Program.file.WriteUsersToFile(Program.check.userlist);
                        Environment.Exit(0);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input.KeyChar == '1')
                {

                    Program.check.SelectUser();
                    break;
                }
                else if (input.KeyChar == '2')
                {
                    Program.check.CreateUser();
                    Program.file.CheckFileListLenght(Program.check.ReturnList());
                }
                else if (input.KeyChar == '3')
                {
                    Program.check.DeleteUser();
                }
                else if (input.KeyChar == '4')
                {
                    Console.Clear();
                    Console.WriteLine(tasks);
                    Program.check.PrintAllTasks();
                    Console.WriteLine("Paina mitä tahansa näppäintä jatkaaksesi");
                    Console.ReadKey(true);
                }
            }
        }

        /// <summary>
        /// Prints the chosen users menu, where they can choose things related to tasks (show tasks, delete tasks, create tasks and mark a task as done)
        /// </summary>
        public void Menu()
        {
            while (true)
            {
                Console.Title = version;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("ESC = Peruuta / Palaa takaisin");
                Console.ResetColor();
                Console.WriteLine(menu);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Valitse mitä haluat tehdä (numero)");
                Console.ResetColor();
                Console.WriteLine("Sulje ohjelma (0)");
                Console.WriteLine("Näytä tehtävät (1)");
                Console.WriteLine("Merkkaa tehtävä valmiiksi (2)");
                Console.WriteLine("Luo uusi tehtävä (3)");
                Console.WriteLine("Poista tehtävä (4)");
                Console.WriteLine();
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.KeyChar == '0')
                {
                    var confirm2 = MessageBox.Show("Oletko varma että haluat sulkea ohjelman?", "Varmistus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm2 == DialogResult.Yes)
                    {
                        //varmista että tämä tapahtuu ennen kun ohjelma sulkeutuu!!
                        Program.file.WriteUsersToFile(Program.check.userlist);
                        Environment.Exit(0);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input.KeyChar == '1')
                {
                    Console.Clear();
                    Console.WriteLine(tasks);
                    Program.check.PrintUsersTasks();
                    Console.WriteLine("Paina mitä tahansa näppäintä jatkaaksesi");
                    Console.ReadKey(true);
                }
                else if (input.KeyChar == '2')
                {
                    Program.check.Ready();
                    Program.file.RewriteTaskFile(Program.check.tasklist, Program.check.currentuser);

                }
                else if (input.KeyChar == '3')
                {
                    Program.check.CreateTask();
                    Program.file.RewriteTaskFile(Program.check.tasklist, Program.check.currentuser);
                }
                else if (input.KeyChar == '4')
                {
                    Program.check.DeleteTask();
                    Program.file.RewriteTaskFile(Program.check.tasklist, Program.check.currentuser);

                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Program.ui.UserMenu();
                }
            }
        }

        /// <summary>
        /// Reads key presses and the written line simultaneously
        /// </summary>
        /// <returns></returns>
        public string ReadKeyAndLine()
        {
            string text = "";

            int index = 0;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                // handle Esc
                if (input.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    return null;

                }

                // handle Enter
                if (input.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return text;
                }

                // handle backspace
                if (input.Key == ConsoleKey.Backspace)
                {
                    if (index > 0)
                    {
                        text = text.Remove(text.Length - 1);
                        Console.Write(input.KeyChar);
                        Console.Write(' ');
                        Console.Write(input.KeyChar);
                        index--;
                    }
                }
                else
                // handle all other keypresses
                {
                    text += input.KeyChar;
                    Console.Write(input.KeyChar);
                    index++;
                }
            }
            while (true);
        }
    }
}
