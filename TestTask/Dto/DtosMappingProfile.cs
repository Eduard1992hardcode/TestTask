using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Dto
{
    public class DtosMappingProfile : Profile
    {
        public DtosMappingProfile()
        {
            CreateMap<BalanceDto, BalanceModel>()
                .ForMember(x => x.Period, opt => opt.MapFrom(y => DateTime.ParseExact(y.Period.ToString(), "yyyyMM", CultureInfo.InvariantCulture)))
                .ForMember(x => x.AccountId, opt => opt.MapFrom(y => y.Account_id))
                .ForMember(x => x.Calculation, opt => opt.MapFrom(y => y.Calculation))
                .ForMember(x => x.InBalance, opt => opt.MapFrom(y => y.In_balance));

            CreateMap<PaymentDto, PaymentModel>()
                .ForMember(x => x.Period, opt => opt.MapFrom(y => DateTime.ParseExact(y.Date, "yyyy-MM-dd HH:mm:ff", CultureInfo.InvariantCulture)))
                .ForMember(x => x.AccountId, opt => opt.MapFrom(y => y.Account_id))
                .ForMember(x => x.Sum, opt => opt.MapFrom(y => y.Sum))
                .ForMember(x => x.PaymentGuid, opt => opt.MapFrom(y => y.Payment_guid));
        }
    }
}
