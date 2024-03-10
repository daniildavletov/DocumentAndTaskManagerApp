namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;

public class Задача
{
    public Задача(string наименование)
    {
        Наименование = наименование;
    }

    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    
    public string Наименование { get; set; }
    
    public string? Содержание { get; set; }
    
    public СтатусЗадачи Статус { get; set; }
}