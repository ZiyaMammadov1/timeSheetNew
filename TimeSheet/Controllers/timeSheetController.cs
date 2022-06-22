using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.TimeİntervalDtos;
using TimeSheet.Dtos.TimeSheetDtos;
using TimeSheet.Entities;
using TimeSheet.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class timeSheetController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        Answer<TimeSheetGetDto> getFinishObject;

        public timeSheetController(DataContext context, IConfiguration config, IJwtService jwtService, IMapper mapper)
        {
            _context = context;
            _config = config;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Answer<TimeSheetGetDto>> Get(string id)
        {
            var exist = _context.MainTimeSheets.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);


            if (exist != null)
            {
                var worktype = _context.WorkType.FirstOrDefault(x => x.uuid == exist.workTypeid);

                TimeSheetGetDto timeSheet = new TimeSheetGetDto()
                {
                    id = exist.uuid,
                    start = exist.startDate,
                    createdTime = exist.createdTime,
                    description = exist.description,
                    hours = exist.hours,
                    projectid = exist.projectid,
                    workTypeId = exist.workTypeid,
                    Calendar = worktype.value
                };
                var data = new Answer<TimeSheetGetDto>(200, "Ok", new List<TimeSheetGetDto>() { timeSheet });
                foreach (var item in data.Result)
                {
                    item.Calendar = worktype.value;
                }

                return data;
            }
            else
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "TimeSheet doesn't exist", null);
            }
        }


        [HttpPost]
        [Route("monthly")]
        public ActionResult<Answer<TimeSheetGetDto>> GetAllMonthly(TimeIntervalGetDto? timeInterval)
        {


            List<mainTimeSheet> times = new List<mainTimeSheet>();

            if (timeInterval.startDate != null && timeInterval.endDate != null)
            {
                times = _context.MainTimeSheets.Where(x => x.createdTime >= timeInterval.startDate && x.createdTime <= timeInterval.endDate && x.isDeleted == false).ToList();
            }
            else
            {
                DateTime date = DateTime.UtcNow;

                int currentMonth = DateTime.UtcNow.Month;

                DateTime startDate = new DateTime(date.Year, date.Month, 1).AddDays(-10);

                DateTime endDate = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(10);

                times = _context.MainTimeSheets.Where(x => x.createdTime >= startDate && x.createdTime <= endDate && x.isDeleted == false).ToList();
            }


            if (times != null)
            {
                List<TimeSheetGetDto> TimeGetList = new List<TimeSheetGetDto>();
                foreach (var time in times)
                {
                    var worktype = _context.WorkType.FirstOrDefault(x => x.uuid == time.workTypeid);
                    TimeSheetGetDto timeSheet = new TimeSheetGetDto()
                    {
                        id = time.uuid,
                        start = time.startDate,
                        createdTime = time.createdTime,
                        description = time.description,
                        hours = time.hours,
                        projectid = time.projectid,
                        workTypeId = time.workTypeid,
                        Calendar = worktype.value
                    };
                    TimeGetList.Add(timeSheet);
                }
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "Ok", TimeGetList);


            }
            else
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "Ok", null);
            }
        }


        [HttpPost]
        public ActionResult<Answer<TimeSheetGetDto>> CreateTimeSheet(TimeSheetPostDto TimeSheetPostDto)
        {
            var project = _context.Projects.FirstOrDefault(x => x.uuid == TimeSheetPostDto.projectid);

            if (project == null)
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(400, "Projectid not matched", null);

            }

            var workType = _context.WorkType.FirstOrDefault(x => x.uuid == TimeSheetPostDto.workTypeId);

            if (workType == null)
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(400, "WorkTypeid not matched", null);
            }



            if (TimeSheetPostDto.startDate > DateTime.UtcNow)
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(400, "Cannot take timeSheet for the future", null);
            }

            DateTime CurrentWeekBegin = DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek);

            if (TimeSheetPostDto.startDate < DateTime.UtcNow.AddDays(-7))
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(400, "Cannot take timeSheet for the past", null);

            }

            mainTimeSheet newTimeSheet = new mainTimeSheet()
            {
                uuid = Guid.NewGuid().ToString(),
                projectid = project.uuid,
                workTypeid = workType.uuid,
                startDate = TimeSheetPostDto.startDate,
                createdTime = DateTime.UtcNow,
                description = TimeSheetPostDto.description,
                isDeleted = false,
                hours = TimeSheetPostDto.hours

            };
            _context.MainTimeSheets.Add(newTimeSheet);
            _context.SaveChanges();

            //----------------------------------------------------------------

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddMonths(1);

            var times = _context.MainTimeSheets.Where(x => x.createdTime >= startDate && x.createdTime <= endDate && x.isDeleted == false).ToList();


            if (times != null)
            {
                List<TimeSheetGetDto> TimeGetList = new List<TimeSheetGetDto>();
                foreach (var time in times)
                {
                    var worktype = _context.WorkType.FirstOrDefault(x => x.uuid == time.workTypeid);
                    TimeSheetGetDto timeSheet = new TimeSheetGetDto()
                    {
                        id = time.uuid,
                        start = time.startDate,
                        createdTime = time.createdTime,
                        description = time.description,
                        hours = time.hours,
                        projectid = time.projectid,
                        workTypeId = time.workTypeid,
                        Calendar = worktype.value
                    };
                    TimeGetList.Add(timeSheet);
                }
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "Ok", TimeGetList);

            }
            else
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(400, "TimeSheet doesn't exist", null);

            }

        }


        [HttpDelete]
        public ActionResult<Answer<TimeSheetGetDto>> DeleteTimeSheet(string id)
        {
            var exist = _context.MainTimeSheets.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

            if (exist != null)
            {
                exist.isDeleted = true;
                _context.SaveChanges();
                return getFinishObject = new Answer<TimeSheetGetDto>(201, "Created", null);
            }
            else
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "TimeSheet doesn't exist", null);

            }

        }


        [HttpPut]
        public ActionResult<Answer<TimeSheetGetDto>> UpdateTimeSheet(TimeSheetUpdateDto TimeSheetUpdateDto)
        {
            var exist = _context.MainTimeSheets.FirstOrDefault(x => x.uuid == TimeSheetUpdateDto.id && x.isDeleted == false);

            var project = _context.Projects.FirstOrDefault(x => x.uuid == TimeSheetUpdateDto.projectid);
            if (project == null)
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "Projectid doesn't exist", null);

            }

            var worktype = _context.WorkType.FirstOrDefault(x => x.uuid == TimeSheetUpdateDto.workTypeId);
            if (worktype == null)
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "Worktypeid doesn't exist", null);
            }

            if (exist != null)
            {
                exist.description = TimeSheetUpdateDto.description;
                exist.startDate = TimeSheetUpdateDto.startDate;
                exist.projectid = TimeSheetUpdateDto.projectid;
                exist.workTypeid = TimeSheetUpdateDto.workTypeId;
                _context.SaveChanges();

                return getFinishObject = new Answer<TimeSheetGetDto>(204, "No Content", null);

            }
            else
            {
                return getFinishObject = new Answer<TimeSheetGetDto>(200, "TimeSheet doesn't exist", null);
            }

        }
    }
}
