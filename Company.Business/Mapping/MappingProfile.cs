using AutoMapper;
using Company.Business.Dto.Customer;
using Company.Business.Dto.Order;
using Company.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, ReadCustomerDto>().ReverseMap(); // خريطة للقراءة والكتابة
            CreateMap<AddCustomerDto, Customer>(); // خريطة لإضافة عميل جديد
            CreateMap<ReadCustomerDto, Customer>(); // خريطة للتحديث باستخدام ReadCustomerDtoz
           //****************************////        
           CreateMap<Order, ReadOrderDto>().ReverseMap(); // خريطة للقراءة والكتابة
            CreateMap<AddOrderDto, Order>(); // خريطة لإضافة عميل جديد
            CreateMap<ReadOrderDto, Order>(); // خريطة للتحديث باستخدام ReadCustomerDtoz
        }
    }
}
