namespace wt_lab3_3mvc_ostapchuk.Models;

/// <summary>
/// Модель предметной области «Спортивный клуб».
/// </summary>
public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string SubscriptionType { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}