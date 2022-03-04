using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradePersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int IdAddDossierCommand = 1;
            const int IdGetAllDossiersCommand = 2;
            const int IdDeleteDossierCommand = 3;
            const int IdExecuteExitCommand = 4;

            Dictionary<string, string> dictionaryDossiers = new Dictionary<string, string>();
            int userInput;
            bool isOpen = true;

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.CursorVisible = false;
            while (isOpen == true)
            {
                Console.ForegroundColor = defaultColor;
                Console.WriteLine($"Что вы хотите сделать?" +
                                  $"\n\n{IdAddDossierCommand}. Добавить досье" +
                                  $"\n{IdGetAllDossiersCommand}. Вывести все досье" +
                                  $"\n{IdDeleteDossierCommand}. Удалить досье" +
                                  $"\n{IdExecuteExitCommand}. Выход");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (userInput)
                {
                    case IdAddDossierCommand:
                        AddDossier(dictionaryDossiers);
                        break;
                    case IdGetAllDossiersCommand:
                        ShowAllDossiers(dictionaryDossiers);
                        break;
                    case IdDeleteDossierCommand:
                        DeleteDossier(dictionaryDossiers);
                        break;
                    case IdExecuteExitCommand:
                        isOpen = ExecuteExit();
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> dictionaryDossiers)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Заполните ФИО сотрудника:");
            string addedFullName = Console.ReadLine();
            Console.WriteLine("Заполните должность сотрудника:");
            string addedPosition = Console.ReadLine();
            
            if (dictionaryDossiers.ContainsKey(addedFullName) == false)
            {
                dictionaryDossiers.Add(addedFullName, addedPosition);
                Console.WriteLine($"Добавлено новое досье: ФИО: {addedFullName} | Позиция: {addedPosition}");
            }
            else
                Console.WriteLine("Не удалось добавить сотрудника.");

            Console.ReadKey();
            Console.Clear();
        }

        static void ShowAllDossiers(Dictionary<string, string> dictionaryDossiers)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Все досье:");

            foreach (var employee in dictionaryDossiers)
            {
                Console.Write($"ФИО: {employee.Key} | Должность: {employee.Value} - ");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(Dictionary<string, string> dictionaryDossiers)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Заполните ФИО сотрудника, которого хотите удалить из досье:");
            string remoteFullName = Console.ReadLine();

            if (dictionaryDossiers.ContainsKey(remoteFullName))
            {
                Console.WriteLine($"Удален сотрудник:" +
                                    $"ФИО: {remoteFullName} | Должность: {dictionaryDossiers[remoteFullName]}");
                dictionaryDossiers.Remove(remoteFullName);
            }
        }

        static bool ExecuteExit()
        {
            Console.WriteLine("Выход...");

            return false;
        }
    }
}