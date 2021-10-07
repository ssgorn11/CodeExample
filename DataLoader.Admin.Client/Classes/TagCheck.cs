using DataLoader.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Admin.Client
{
    internal class TagCheck : ScheduleTagDto
    {
        public TagCheck(ScheduleTagDto dto)
        {
            Id = dto.Id;
            IdSchedule = dto.IdSchedule;
            Tag = dto.Tag;
            TypeOfIntervalSearch = dto.TypeOfIntervalSearch;
            Comment = dto.Comment;
        }
        private bool? _isCheck;
        public bool? IsCheck 
        {
            get 
            {
                return _isCheck;
            }
            set
            {
                _isCheck = value;
            }
        }
    }
}
