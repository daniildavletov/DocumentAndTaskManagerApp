using System.Windows.Input;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.MainVM;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.VMBuildingBlocks;

namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.ДокументVM;

public class ДокументViewModel : ViewModelBase, IDisplayItem
{
    private readonly Документ _документ;
    
    public ICommand КомандаПодписанияДокумента { get; private set; }
    
    public ДокументViewModel(Документ документ)
    {
        _документ = документ;
        КомандаПодписанияДокумента = new RelayCommand(ПодписатьДокумент, МожноПодписатьДокумент);
    }

    public ДокументViewModel()
    {
        _документ = new Документ("Новый документ");
        КомандаПодписанияДокумента = new RelayCommand(ПодписатьДокумент, МожноПодписатьДокумент);
    }

    public int Id
    {
        get => _документ.Id;
        set
        {
            _документ.Id = value;
            OnPropertyChanged();
        }
    }
    
    public string Наименование
    {
        get => _документ.Наименование;
        set
        {
            _документ.Наименование = value;
            OnPropertyChanged();
        }
    }

    public Guid? ЦифроваяПодпись
    {
        get
        {
            return _документ.ЦифроваяПодпись;
        }
        set
        {
            _документ.ЦифроваяПодпись = value;
            OnPropertyChanged();
        }
    }

    public string? Содержание
    {
        get => _документ.Содержание;
        set
        {
            _документ.Содержание = value;
            OnPropertyChanged();
        }
    }

    public string Тип => nameof(Документ);
    
    public string ПолучитьНаименование()
    {
        return Наименование;
    }

    public string ПолучитьТип()
    {
        return Тип;
    }

    private void ПодписатьДокумент(object obj)
    {
        ЦифроваяПодпись = Guid.NewGuid();
    }

    private bool МожноПодписатьДокумент(object arg)
    {
        return ЦифроваяПодпись == null;
    }
}