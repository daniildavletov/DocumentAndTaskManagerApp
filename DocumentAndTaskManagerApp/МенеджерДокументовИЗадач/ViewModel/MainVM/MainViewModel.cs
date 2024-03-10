using System.Collections.ObjectModel;
using System.Windows.Input;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.VMBuildingBlocks;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.ДокументVM;
using DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.ЗадачаVM;

namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.ViewModel.MainVM;

public class MainViewModel : ViewModelBase 
{
    public ObservableCollection<ItemViewModel> ДокументыИЗадачи { get; }

    public ICommand КомандаДобавленияДокумента { get; private set; }
    
    public ICommand КомандаДобавленияЗадачи { get; private set; }
    
    public ICommand OpenWindowCommand { get; }

    public MainViewModel()
    {
        ДокументыИЗадачи = new ObservableCollection<ItemViewModel>();
        
        var документ1 = new Документ("Заказы.docx") { Содержание = "Заказ \u21161:\n- Наименование товара: Ноутбук ASUS VivoBook\n- Количество: 2\n- Цена за единицу: 50,000 руб.\n- Общая стоимость: 100,000 руб.\n- Дата заказа: 01.04.2023\n- Статус: Доставляется\n\nЗаказ \u21162:\n- Наименование товара: Смартфон Samsung Galaxy S21\n- Количество: 1\n- Цена за единицу: 70,000 руб.\n- Общая стоимость: 70,000 руб.\n- Дата заказа: 02.04.2023\n- Статус: Подтвержден" };
        var документViewModel1 = new ДокументViewModel(документ1);
        var itemViewModel1 = new ItemViewModel { Item = документViewModel1 };
        ДокументыИЗадачи.Add(itemViewModel1);
        
        var документ2 = new Документ("Отчет по продажам.docx") { Содержание = "Отчет о продажах за апрель 2023 года:\n\nПродукт: Ноутбук ASUS VivoBook\n- Количество проданных единиц: 15\n- Общая сумма продаж: 750,000 руб.\n\nПродукт: Смартфон Samsung Galaxy S21\n- Количество проданных единиц: 20\n- Общая сумма продаж: 1,400,000 руб.\n\nПродукт: Умные часы Apple Watch Series 7\n- Количество проданных единиц: 30\n- Общая сумма продаж: 900,000 руб.\n\nОбщая сумма продаж за месяц: 3,050,000 руб.\nКоличество проданных товаров: 65 единиц.\n\nКомментарий: Продажи в апреле показали хороший рост по сравнению с предыдущим месяцем.\nОсобенно успешными оказались продажи смартфонов Samsung Galaxy S21.\nРекомендуется увеличить закупку данной модели на следующий месяц.\";" };
        var документViewModel2 = new ДокументViewModel(документ2);
        var itemViewModel2 = new ItemViewModel { Item = документViewModel2 };
        ДокументыИЗадачи.Add(itemViewModel2);
        
        var задача1 = new Задача("Подготовить заказы к выдаче")
        {
            Содержание = "Все заказы должны быть подготовлены к выдаче.\n\nВыберите товары, которые нужно подготовить к выдаче:\n\n- Ноутбук ASUS VivoBook\n- Смартфон Samsung Galaxy S21\n- Умные часы Apple Watch Series 7",
            Статус = СтатусЗадачи.Выполнена
        };
        var задачаViewModel1 = new ЗадачаViewModel(задача1);
        var itemViewModel3 = new ItemViewModel { Item = задачаViewModel1 };
        ДокументыИЗадачи.Add(itemViewModel3);
        
        var задача2 = new Задача("Опубликовать отчет");
        var задачаViewModel2 = new ЗадачаViewModel(задача2);
        var itemViewModel4 = new ItemViewModel { Item = задачаViewModel2 };
        ДокументыИЗадачи.Add(itemViewModel4);
        
        КомандаДобавленияДокумента = new RelayCommand(ДобавитьДокумент);
        КомандаДобавленияЗадачи = new RelayCommand(ДобавитьЗадачу);
        OpenWindowCommand = new RelayCommand(OpenWindow);
    }

    private void ДобавитьДокумент(object obj)
    {
        var itemViewModel = new ItemViewModel();
        
        itemViewModel.Item = new ДокументViewModel(new Документ("Новый документ"));
        ДокументыИЗадачи.Add(itemViewModel);
        OpenWindow(itemViewModel);
    }
    
    private void ДобавитьЗадачу(object obj)
    {
        var itemViewModel = new ItemViewModel();
        
        itemViewModel.Item = new ЗадачаViewModel(new Задача("Новая задача"));
        ДокументыИЗадачи.Add(itemViewModel);
        OpenWindow(itemViewModel);
    }
    
    private void OpenWindow(object itemViewModel)
    {
        var displayItem = ((ItemViewModel)itemViewModel).Item;
        
        switch (displayItem)
        {
            case ДокументViewModel документViewModel:
                ДокументViewModelWindow документViewModelWindow = new ДокументViewModelWindow();
                документViewModelWindow.DataContext = документViewModel;
                документViewModelWindow.Show();
                break;
            case ЗадачаViewModel задачаViewModel:
                ЗадачаViewModelWindow задачаViewModelWindow = new ЗадачаViewModelWindow();
                задачаViewModelWindow.DataContext = задачаViewModel;
                задачаViewModelWindow.Show();
                break;
        }
    }
}