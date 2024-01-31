

using Application.DTOs.HotelDtos.OrderStatus;
using Application.DTOs.HotelDtos.Organization;
using Application.DTOs.HotelDtos.Position;
using Application.DTOs.HotelDtos.Room;
using Application.DTOs.HotelDtos.RoomStatus;
using Application.DTOs.HotelDtos.RoomType;
using Application.DTOs.HotelDtos.Staff;


namespace Application.DTOs.Mappers;

public class AutoMepperProfile:Profile
{
    public AutoMepperProfile()
    {
     


        CreateMap<Guest, GuestDto>().ReverseMap();
        CreateMap<AddGuestDto, Guest>();
        CreateMap<UpdateGuestDto, Guest>();


        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<AddOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();


        CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
        CreateMap<AddOrderStatusDto, OrderStatus>();
        CreateMap<UpdateOrderStatusDto, OrderStatus>();

        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<AddPositionDto, Position>();
        CreateMap<UpdatePositionDto, Position>();

        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<AddRoomDto, Room>();
        CreateMap<UpdateRoomDto, Room>();

        CreateMap<RoomStatus, RoomStatusDto>().ReverseMap();
        CreateMap<AddRoomStatusDto, RoomStatus>();
        CreateMap<UpdateRoomStatusDto, RoomStatus>();

        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<AddRoomTypeDto, RoomType>();
        CreateMap<UpdateRoomTypeDto, RoomType>();

        CreateMap<Staff, StaffDto>().ReverseMap();
        CreateMap<AddStaffDto, Staff>();
        CreateMap<UpdateStaffDto, Staff>();

        CreateMap<Organization, OrganizationDto>().ReverseMap();
        CreateMap<AddOrganizationDto, Organization>();
        CreateMap<UpdateOrganizationDto, Organization>();


    }
}
