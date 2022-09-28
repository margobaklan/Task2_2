using System;
using System.Collections.Generic;

namespace Task2_2
{
    abstract class Worker
    {
        public string Name;
        public string Position;
        public string WorkDay = "workday";
        public Worker(string Name)
        {
            this.Name = Name;
        }

        public void Call()
        {

        }
        public void WriteCode()
        {

        }
        public void Relax()
        {

        }
        public abstract void FillWorkDay();

    }
    class Developer : Worker
    {
        
        public Developer(string Name) : base(Name)
        {
            Position = "Розробник";
        }
        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }
    class Manager : Worker
    {
        private Random r;
        public Manager(string Name) : base(Name)
        {
            Position = "Менеджер";
        }

        public override void FillWorkDay()
        {
            r = new Random();
            for (int i = 0; i<r.Next(1,10); i++)
            {
                Call();
            }
            Relax();
            for (int i = 0; i < r.Next(1, 5); i++)
            {
                Call();
            }
            
        }
    }
 
    class Team
    {
        public List<Worker> workers = new();
        public string Name;
        public Team(string Name)
        {
            this.Name = Name;
        }
        public void AddWorker(string pos, string name)
        {
            if (pos == "Розробник")
            {
                Developer developer = new(name);
                workers.Add(developer);
            }
            else if (pos == "Менеджер")
            {
                Manager manager = new(name);
                workers.Add(manager);
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine(Name);
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine(workers[i].Name);
            }
        }
        public void ShowDetails()
        {
            Console.WriteLine(Name);
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{workers[i].Name} - {workers[i].Position} - {workers[i].WorkDay}");
            }
        }
      /*  public void CreateTeam()
        {
            Console.WriteLine("Введіть кількість співробітників");
            int q = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine($"Введіть ім'я співробітника №{i+1}");
                string workerName = Console.ReadLine();
                Console.WriteLine($"Введіть посаду (Менеджер/Розробник) співробітника №{i+1}");
                string workerPosition = Console.ReadLine();
                AddWorker(workerPosition, workerName);
            }
        }*/

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            List<Team> teams = new(); // список команд

            int FindTeam(string teamname) // дізнатися чи існує команда за назвою
            {
                int k = -1;
                int j = teams.Count;
                for (int i = 0; i < j; i++)
                {
                    if (teams[i].Name == teamname)
                    {
                        k = i;
                    }
                }
                return k;
            }
            string PositionRight() // правильність вводу посади
            {
                bool k = true;
                string pos = " ";
                do
                {
                    Console.WriteLine("Введіть посаду співробітника (Менеджер/Розробник)");
                    string position = Console.ReadLine();
                    if (position == "Розробник" || position == "Менеджер")
                    {
                        k = false;
                        pos = position;
                    }
                } while (k);
                return pos;
            }
        
            do
            {
                Console.WriteLine("1 - створити команду");
                Console.WriteLine("2 - додати співробітника до команди");
                Console.WriteLine("3 - Вивести інформацію про команду");
                Console.WriteLine("4 - Вивести детальну інформацію про команду");
                int a = Convert.ToInt16(Console.ReadLine());

                if (a == 1) // створити команду
                {
                    Console.WriteLine("Введіть назву команди");
                    string name = Console.ReadLine();
                    Team team = new Team(name);
                    teams.Add(team);
                    Console.WriteLine($"Команду {name} додано!");
                }
                else if (a == 2) // додати співробітника до команди
                {
                    Console.WriteLine("Введіть назву команди");
                    string teamname = Console.ReadLine();

                    bool k = true;
                    do
                    {
                        if (FindTeam(teamname) == -1)
                        {
                            Console.WriteLine($"Команди з назвою {teamname} не існує");
                            Console.WriteLine("Введіть назву команди");
                            teamname = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Введіть ім'я співробітника");
                            string name = Console.ReadLine();
                            string position = PositionRight();
                            teams[FindTeam(teamname)].AddWorker(position, name);
                            k = false;
                        }
                    } while (k);

                }
                else if (a == 3) // Вивести інформацію про команду
                {
                    Console.WriteLine("Введіть назву команди");
                    string teamname = Console.ReadLine();

                    // Шукаємо команду з введеною назвою
                    bool k = true;
                    do
                    {
                        if (FindTeam(teamname) == -1)
                    {
                        Console.WriteLine($"Команди з назвою {teamname} не існує");
                        Console.WriteLine("Введіть назву команди");
                        teamname = Console.ReadLine();
                        }
                    else
                    {
                        teams[FindTeam(teamname)].ShowInfo();
                        k = false;
                    }
                    } while (k);
                }
                else if (a == 4) // Вивести детальну інформацію про команду
                {
                    Console.WriteLine("Введіть назву команди");
                    string teamname = Console.ReadLine();

                    // Шукаємо команду з введеною назвою
                    bool k = true;
                    do
                    {
                        if (FindTeam(teamname) == -1)
                        {
                            Console.WriteLine($"Команди з назвою {teamname} не існує");
                            Console.WriteLine("Введіть назву команди");
                            teamname = Console.ReadLine();
                        }
                        else
                        {
                            teams[FindTeam(teamname)].ShowDetails();
                            k = false;
                        }
                    } while (k);
                }
                else
                {
                    Console.WriteLine("Виберіть одну з команд");
                }
            } while (true);
        }
    }
}
