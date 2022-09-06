using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TODO
{
    internal class Files
    {
        private string _fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Tiimi1TODO/";
        private string _fileName;
        private List<Files> _userFiles = new List<Files>();
        private string userFileLocation = "userFiles";

        public Files() { }
        public Files(string file)
        {
            _fileName = file + ".json";
        }

        //to make access easier
        public string FileName { get => _fileName; }
        public string FileLocation { get => _fileLocation; }
        public List<Files> UserFiles { get => _userFiles; }


        /// <summary>
        /// Deletes a file from drive
        /// </summary>
        public void DeleteFile()
        {
            File.Delete(_fileLocation + _fileName);
        }

        /// <summary>
        /// Takes the task list and current user index from memory and writes it to drive for local use
        /// </summary>
        /// <param name="tasks"></param>
        public void WriteTaskToFile(List<Task> tasks, int userNumber)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i]._user == userNumber)
                {
                    if (tasks[i]._ready == true)
                    {
                        File.AppendAllText(_fileLocation + UserFiles[userNumber]._fileName, tasks[i]._name + "//T" + "\n");
                    }
                    else
                    {
                        File.AppendAllText(_fileLocation + UserFiles[userNumber]._fileName, tasks[i]._name + "//F" + "\n");
                    }
                }
            }
        }

        /// <summary>
        /// Takes local file where tasks are located and returns it as a list for the program to merge to memory
        /// </summary>
        /// <returns></returns>
        public List<Task> ReturnTasksFromFile(int userNumber)
        {
            List<Task> listToReturn = new List<Task>();
            string name;
            bool ready;
            foreach (string line in File.ReadAllLines(_fileLocation + UserFiles[userNumber]._fileName))
            {
                if (line.Contains("//T"))
                {
                    name = line.Replace("//T", "");
                    ready = true;
                }
                else
                {
                    name = line.Replace("//F", "");
                    ready = false;
                }
                listToReturn.Add(new Task(name, ready, userNumber));
            }
            return listToReturn;
        }

        /// <summary>
        /// Deletes a user that is specified with the currentuser index
        /// </summary>
        /// <param name="userNumber"></param>
        public void RemoveUser(int userNumber)
        {
            string line = "//removed";
            int line_number = 0;
            int line_to_delete = userNumber;

            try
            {
                using (StreamWriter writer = new StreamWriter(_fileLocation + userFileLocation + ".json"))
                {
                    while (line_number != line_to_delete)
                    {
                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("RemoveUser");
            }
            File.Delete(_fileLocation + UserFiles[userNumber]._fileName);
            _userFiles.RemoveAt(userNumber);
        }

        public void RewriteTaskFile(List<Task> tasks, int userNumber)
        {
            File.Create(_fileLocation + UserFiles[userNumber]._fileName).Close();
            WriteTaskToFile(tasks, userNumber);
        }

        /// <summary>
        /// Writes a given list of users to file
        /// </summary>
        /// <param name=users></param>
        public void WriteUsersToFile(List<string> users)
        {
            File.Create(_fileLocation + userFileLocation + ".json").Close();
            foreach (string user in users)
            {
                File.AppendAllText(_fileLocation + userFileLocation + ".json", user + "\n");
            }
        }

        /// <summary>
        /// Return Users in a List<string>
        /// </summary>
        /// <returns>List</returns>
        public List<string> ReadUsersToList()
        {
            List<string> list = File.ReadAllLines(_fileLocation + userFileLocation + ".json").ToList();
            List<string> listtoreturn = new List<string>();
            foreach (string task in list)
            {
                if (task != "//removed")
                {
                    listtoreturn.Add(task);
                }
            }
            return listtoreturn;
        }

        /// <summary>
        /// Create file to save users in file. Runs in the beginning of the program
        /// </summary>
        public void CreateUserFile()
        {
            if (!Directory.Exists(_fileLocation))
            {
                Directory.CreateDirectory(_fileLocation);
            }
            if (!File.Exists(_fileLocation + userFileLocation + ".json"))
            {
                File.Create(_fileLocation + userFileLocation + ".json").Close();
            }
        }

        /// <summary>
        /// Creates a file if it doesn't already exist
        /// </summary>
        public void CreateFile(int userNumber)
        {
            if (!File.Exists(_fileLocation + UserFiles[userNumber]._fileName))
            {
                File.Create(_fileLocation + UserFiles[userNumber]._fileName).Close();
            }
        }

        /// <summary>
        /// Returns list of all lines in file
        /// </summary>
        /// <returns></returns>
        public List<string> ReturnFileToList(int userNumber)
        {
            return File.ReadAllLines(_fileLocation + UserFiles[userNumber]._fileName).ToList();
        }

        /// <summary>
        /// Checks if user amount in memory is same as file amount and creates a new file if file count is shorter 
        /// </summary>
        /// <param name="userList"></param>
        public void CheckFileListLenght(List<string> userList)
        {
            for (int i = _userFiles.Count(); i < userList.Count; i++)
            {
                _userFiles.Add(new Files(userList[i]));
                CreateFile(i);
            }
        }

        /// <summary>
        /// Remove users from file
        /// </summary>
        /// <param name="place"></param>
        ///
        public void RemoveFromList(int place)
        {
            _userFiles[place].DeleteFile();
            _userFiles.RemoveAt(place);
        }
    }
}
