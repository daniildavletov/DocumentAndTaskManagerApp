using System.ComponentModel;

namespace DocumentAndTaskManagerApp.МенеджерДокументовИЗадач.Model;

public enum СтатусЗадачи
{
    [Description("В работе")]
    ВРаботе,
    [Description("Выполнена")]
    Выполнена
}