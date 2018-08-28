using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Users.Controllers.Dtos;
using Users.Core.Models;

namespace Users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain Model to DTO
            CreateMap<User, SaveUserDto>()
                  .ForMember(dto => dto.Contact, opt => opt.MapFrom(dm => new ContactDto
                  {
                      Phone = dm.ContactPhone,
                      Address = dm.ContactAddress
                  }))
                  .ForMember(dto => dto.Interests, opt => opt.MapFrom(dm => dm.Interests.Select(
                        ui => ui.InterestId
                      )));

            CreateMap<User, UserDto>()
                  .ForMember(dto => dto.Contact, opt => opt.MapFrom(dm => new ContactDto
                  {
                      Phone = dm.ContactPhone,
                      Address = dm.ContactAddress
                  }))
                  .ForMember(dto => dto.Interests, opt => opt.MapFrom(dm => dm.Interests.Select(
                        ui => new InterestDto { Id = ui.Interest.Id, Name = ui.Interest.Name }
                      )))
                  .ForMember(dto => dto.RegistrationDate, opt => opt.MapFrom(dm => dm.RegistrationDate));

            CreateMap<Interest, InterestDto>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultDto<>));


            //DTO to Domain Model
            CreateMap<SaveUserDto, User>()
                .ForMember(dm => dm.Id, opt => opt.Ignore())
                .ForMember(dm => dm.ContactPhone, opt => opt.MapFrom(dto => dto.Contact.Phone))
                .ForMember(dm => dm.ContactAddress, opt => opt.MapFrom(dto => dto.Contact.Address))
                .ForMember(dm => dm.Interests, opt => opt.Ignore())
                .AfterMap((dto, u) =>
                {
                    //the removing scenario: some interests that exist in u.Interests.InterestId is no longer chosen
                    var removedInterest = new List<UserInterest>();
                    foreach (var obj in u.Interests)
                    {
                        if (!dto.Interests.Contains(obj.InterestId))
                        {
                            removedInterest.Add(obj);
                        }
                    }

                    foreach (var item in removedInterest)
                    {
                        u.Interests.Remove(item);
                    }

                    //the adding scenario: new interests chosen that do not exist in u.Interests.InterestId
                    foreach (var id in dto.Interests)
                    {
                        if (!u.Interests.Any(el => el.InterestId == id))
                        {
                            u.Interests.Add(new UserInterest { InterestId = id });
                        }

                    }

                });


            //CreateMap<UserDto, User>()
            //    .ForMember(dm => dm.Id, opt => opt.Ignore())
            //    .ForMember(dm => dm.ContactPhone, opt => opt.MapFrom(dto => dto.Contact.Phone))
            //    .ForMember(dm => dm.ContactAddress, opt => opt.MapFrom(dto => dto.Contact.Address))
            //    .ForMember(dm => dm.RegistrationDate, opt => opt.MapFrom(dto => dto.RegistrationDate));

            CreateMap<UserQueryDto, UserQuery>();

            CreateMap<InterestDto, Interest>();
        }


    }
}
