using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.MainVM;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.VMBuildingBlocks;

namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.ЗадачаVM;

public class ЗадачаViewModel : ViewModelBase, IDisplayItem
{
    private readonly Задача _задача;
    
    public ЗадачаViewModel(Задача задача)
    {
        _задача = задача;
    }

    public ЗадачаViewModel()
    {
        _задача = new Задача("Новая задача");
    }

    public int Id
    {
        get => _задача.Id;
        set
        {
            _задача.Id = value;
            OnPropertyChanged();
        }
    }
    
    public string Наименование
    {
        get => _задача.Наименование;
        set
        {
            _задача.Наименование = value;
            OnPropertyChanged();
        }
    }

    public string? Содержание
    {
        get => _задача.Содержание;
        set
        {
            _задача.Содержание = value;
            OnPropertyChanged();
        }
    }
    
    public СтатусЗадачи Статус
    {
        get
        {
            return _задача.Статус;
        }
        set
        {
            _задача.Статус = value;
            OnPropertyChanged();
        }
    }
    
    public string Тип => nameof(Задача);
    
    public string ПолучитьНаименование()
    {
        return Наименование;
    }

    public string ПолучитьТип()
    {
        return Тип;
    }
}