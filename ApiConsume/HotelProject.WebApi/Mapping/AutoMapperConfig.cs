using AutoMapper;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();

            CreateMap<Guest, CreateGuestDto>().ReverseMap();
            CreateMap<Guest, UpdateGuestDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();

            CreateMap<WorkLocation, CreateWorkLocationDto>().ReverseMap();
            CreateMap<WorkLocation, UpdateWorkLocationDto>().ReverseMap();
        }
    }
}
