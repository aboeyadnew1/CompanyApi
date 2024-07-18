using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; } // رقم تعريف الطلب

        public DateTime OrderDate { get; set; } // تاريخ الطلب

        // public int CustomerId { get; set; } // رقم تعريف العميل (مرتبط بموديل العميل)
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }  // التأكد من وجود هذه الخاصية
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; } // المبلغ الإجمالي
        public OrderStatus OrderStatus { get; set; } // حالة الطلب

        // إضافة المزيد من الخصائص إذا لزم الأمر، مثل تفاصيل الشحن أو معلومات أخرى عن الطلب
    }
    public enum OrderStatus
    {
        Pending,        // قيد الانتظار
        Processing,     // جاري المعالجة
        Shipped,        // تم الشحن
        Delivered,      // تم التسليم
        Cancelled       // تم الإلغاء
    }
}
