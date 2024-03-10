namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;

public class Документ
{
    public Документ(string наименование)
    {
        Наименование = наименование;
    }

    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    
    public string Наименование { get; set; }

    public Guid? ЦифроваяПодпись { get; set; }

    public string? Содержание { get; set; }
}