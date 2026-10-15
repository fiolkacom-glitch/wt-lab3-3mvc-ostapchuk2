using wt_lab3_3mvc_ostapchuk.Models;

namespace wt_lab3_3mvc_ostapchuk.Views;

/// <summary>
/// Представление: только вывод данных.
/// </summary>
public class MemberView
{
    public void ShowMembers(List<Member> members)
    {
        Console.WriteLine("=== СПИСОК УЧАСТНИКОВ КЛУБА ===");

        if (members.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        foreach (var m in members)
        {
            Console.WriteLine(
                $"{m.Id}. {m.FullName} | " +
                $"Телефон: {m.Phone} | " +
                $"Абонемент: {m.SubscriptionType} | " +
                $"Цена: {m.Price} руб. | " +
                $"Активен: {(m.IsActive ? "да" : "нет")}"
            );
        }
    }

    public void ShowMember(Member member)
    {
        Console.WriteLine("=== УЧАСТНИК ===");
        Console.WriteLine($"ID: {member.Id}");
        Console.WriteLine($"ФИО: {member.FullName}");
        Console.WriteLine($"Телефон: {member.Phone}");
        Console.WriteLine($"Абонемент: {member.SubscriptionType}");
        Console.WriteLine($"Цена: {member.Price} руб.");
        Console.WriteLine($"Активен: {(member.IsActive ? "да" : "нет")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}