namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.MainVM;

public class ItemViewModel
{
    public IDisplayItem? Item { get; set; }

    public string Наименование => Item?.ПолучитьНаименование() ?? "";
    
    public string Тип => Item?.ПолучитьТип() ?? "";
}