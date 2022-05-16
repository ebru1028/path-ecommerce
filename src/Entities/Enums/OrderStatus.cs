using System.ComponentModel;

namespace Entities.Enums
{
    public enum OrderStatus
    {
        [Description("Beklemede")]
        Waiting = 1,
        
        [Description("Hazırlanıyor")]
        BeingPrepared = 2,
        
        [Description("Kargolandı")]
        Shipped = 3,
        
        [Description("iptal onayı bekleniyor")]
        PendingCancellationConfirmation=4,
        
        [Description("iptal edildi")]
        Cancelled = 5,
        
        [Description("Tamamlandı")]
        Completed = 6
    }
}