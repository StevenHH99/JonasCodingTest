using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;

namespace BusinessLayer
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<DataEntity, BaseInfo>();
            CreateMap<Company, CompanyInfo>();
            CreateMap<Employee, EmployeeInfo>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.LastModifiedDateTime, opt => opt.MapFrom(src => src.LastModified))
                .ForMember(dest => dest.OccupationName, opt => opt.MapFrom(src => src.Occupation))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyCode));
                
            CreateMap<ArSubledger, ArSubledgerInfo>();
        }
    }

}