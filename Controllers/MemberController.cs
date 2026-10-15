using wt_lab3_3mvc_ostapchuk.Models;
using wt_lab3_3mvc_ostapchuk.Views;

namespace wt_lab3_3mvc_ostapchuk.Controllers;

/// <summary>
/// Контроллер: принимает команды, работает с моделью, передаёт данные во View.
/// </summary>
public class MemberController
{
    private readonly List<Member> members;
    private readonly MemberView view;

    public MemberController()
    {
        members = new List<Member>
        {
            new Member { Id = 1, FullName = "Анна Смирнова", Phone = "+375 29 111-11-11",
                         SubscriptionType = "Месячный", Price = 50, IsActive = true },
            new Member { Id = 2, FullName = "Пётр Иванов", Phone = "+375 29 222-22-22",
                         SubscriptionType = "Годовой", Price = 500, IsActive = true },
            new Member { Id = 3, FullName = "Мария Козлова", Phone = "+375 29 333-33-33",
                         SubscriptionType = "Разовый", Price = 10, IsActive = false }
        };

        view = new MemberView();
    }

    public void Index()
    {
        view.ShowMembers(members);
    }

    public void Show(int id)
    {
        var member = members.FirstOrDefault(m => m.Id == id);
        if (member == null)
        {
            view.ShowMessage("Участник не найден.");
            return;
        }
        view.ShowMember(member);
    }

    public void Add(Member member)
    {
        members.Add(member);
        view.ShowMessage("Участник успешно добавлен.");
    }

    public void Delete(int id)
    {
        var member = members.FirstOrDefault(m => m.Id == id);
        if (member == null)
        {
            view.ShowMessage("Участник не найден.");
            return;
        }
        members.Remove(member);
        view.ShowMessage("Участник успешно удалён.");
    }

    public void Search(string text)
    {
        var result = members
            .Where(m => m.FullName.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
        {
            view.ShowMessage("Ничего не найдено.");
            return;
        }
        view.ShowMembers(result);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать участников");
            Console.WriteLine("2. Найти участника по ID");
            Console.WriteLine("3. Добавить участника");
            Console.WriteLine("4. Удалить участника");
            Console.WriteLine("5. Поиск по ФИО");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowMemberByUserInput(); break;
                case "3": AddMemberByUserInput(); break;
                case "4": DeleteMemberByUserInput(); break;
                case "5": SearchMemberByUserInput(); break;
                case "0": return;
                default: view.ShowMessage("Неизвестная команда."); break;
            }
        }
    }

    private void ShowMemberByUserInput()
    {
        Console.Write("Введите ID участника: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddMemberByUserInput()
    {
        Console.Write("ФИО: ");
        string fullName = Console.ReadLine() ?? "";
        Console.Write("Телефон: ");
        string phone = Console.ReadLine() ?? "";
        Console.Write("Тип абонемента (Месячный/Годовой/Разовый): ");
        string sub = Console.ReadLine() ?? "";
        Console.Write("Цена: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        int newId = members.Count == 0 ? 1 : members.Max(m => m.Id) + 1;

        var member = new Member
        {
            Id = newId,
            FullName = fullName,
            Phone = phone,
            SubscriptionType = sub,
            Price = price,
            IsActive = true
        };

        Add(member);
    }

    private void DeleteMemberByUserInput()
    {
        Console.Write("Введите ID участника для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void SearchMemberByUserInput()
    {
        Console.Write("Введите текст для поиска по ФИО: ");
        string text = Console.ReadLine() ?? "";
        Search(text);
    }
}