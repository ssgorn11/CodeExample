using AutoMapper;
using DataLoader.DBCore.BL;
using DataLoader.Service.Contract;
using DataLoader.DBCore.DBModel;

namespace DataLoader.DBCore
{
    /// <summary>
    /// Конфигурация автомапера
    /// </summary>
    internal class MapperConfiguration : Profile
    {
        /// <summary>
        /// Конфигурация автомапера
        /// </summary>
        public MapperConfiguration()
        {
            BusinessToEntity();
            EntityToBusiness();
            BusinessToDto();
            DtoToBusiness();
        }

        /// <summary>
        /// Конфигурируем мапирование бизнес объектов в энтити сущности
        /// </summary>
        private void BusinessToEntity()
        {
            CreateMap<ScheduleBO, ScheduleEntity>()
                .ForMember(t => t.RepeatIntervalType, opt => opt.MapFrom(s => RepeatIntervalTypeExtention.ToString(s.RepeatIntervalType)))
                .ForMember(t => t.BorderSeachIntervalType, opt => opt.MapFrom(s => BorderSeachIntervalTypeExtention.ToString(s.BorderSeachIntervalType)))
                .ForMember(t => t.BorderSeachIntervalDirection, opt => opt.MapFrom(s => BorderSeachIntervalDirectionExtention.ToString(s.BorderSeachIntervalDirection)));
            CreateMap<DPBO, DPEntity>();
            CreateMap<ErrorBO, ErrorEntity>();
            CreateMap<IntervalDirectionBO, IntervalDirectionEntity>();
            CreateMap<LogBO, LogEntity>();
            CreateMap<ScheduleStoreBO, ScheduleStoreEntity>();
            CreateMap<Tag2ScheduleBO, Tag2ScheduleEntity>()
                .ForMember(t => t.TypeOfIntervalSearch, opt => opt.MapFrom(s => TypeOfIntervalSearchExtention.ToString(s.TypeOfIntervalSearch)));
            CreateMap<Tag2TagGroupBO, Tag2TagGroupEntity>();
            CreateMap<TagBO, TagEntity>();
            CreateMap<TagGroupBO, TagGroupEntity>();
            CreateMap<TagValueBO, TagValueEntity>();
            CreateMap<TimeIntervalTypeBO, TimeIntervalTypeEntity>();
            CreateMap<TypeOfIntervalSearchBO, TypeOfIntervalSearchEntity>();
        }

        /// <summary>
        /// Конфигурируем мапирование энтити сущностей в бизнес объекты
        /// </summary>
        private void EntityToBusiness()
        {
            CreateMap<ScheduleEntity, ScheduleBO>()
                .ForMember(t => t.RepeatIntervalType, opt => opt.MapFrom(s => RepeatIntervalTypeExtention.GetEnum(s.RepeatIntervalType)))
                .ForMember(t => t.BorderSeachIntervalType, opt => opt.MapFrom(s => BorderSeachIntervalTypeExtention.GetEnum(s.BorderSeachIntervalType)))
                .ForMember(t => t.BorderSeachIntervalDirection, opt => opt.MapFrom(s => BorderSeachIntervalDirectionExtention.GetEnum(s.BorderSeachIntervalDirection)));
            CreateMap<DPEntity, DPBO>();
            CreateMap<ErrorEntity, ErrorBO>();
            CreateMap<IntervalDirectionEntity, IntervalDirectionBO>();
            CreateMap<LogEntity, LogBO>();
            CreateMap<ScheduleStoreEntity, ScheduleStoreBO>();
            CreateMap<Tag2ScheduleEntity, Tag2ScheduleBO>()
                .ForMember(t => t.TypeOfIntervalSearch, opt => opt.MapFrom(s => TypeOfIntervalSearchExtention.GetEnum(s.TypeOfIntervalSearch)));
            CreateMap<Tag2TagGroupEntity, Tag2TagGroupBO>();
            CreateMap<TagEntity, TagBO>();
            CreateMap<TagGroupEntity, TagGroupBO>();
            CreateMap<TagValueEntity, TagValueBO>();
            CreateMap<TimeIntervalTypeEntity, TimeIntervalTypeBO>();
            CreateMap<TypeOfIntervalSearchEntity, TypeOfIntervalSearchBO>();
        }

        private void BusinessToDto()
        {
            CreateMap<ScheduleBO, ScheduleDto>();
            CreateMap<TagBO, TagDto>();
        }

        private void DtoToBusiness()
        {
            CreateMap<ScheduleDto, ScheduleBO>();
            CreateMap<TagDto, TagBO>();
        }
    }

}
