using AutoMapper;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Dtos.TimeSheetDtos;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Dtos.WorkTypeDtos;
using TimeSheet.Entities;

namespace TimeSheet.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserGetDto, User>();
            CreateMap<Position, PositionGetDto>();
            CreateMap<Project, ProjectGetDto>();
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<WorkType, WorkGetDto>();
            CreateMap<mainTimeSheet, TimeSheetGetDto>();

            //var cfg = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<mainTimeSheet, TimeSheetGetDto>()
            //        .ForMember(z => z.start, y => y.MapFrom(x => x.startDate));
            //});
        }
    }
}
