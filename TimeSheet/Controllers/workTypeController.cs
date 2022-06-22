using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.WorkTypeDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class workTypeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<WorkGetDto> getFinishObject;

        public workTypeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<WorkGetDto>> GetAll()
        {
            List<WorkType> types = _context.WorkType.Where(x => x.isDeleted == false).ToList();
            List<WorkGetDto> TypeGetList = new List<WorkGetDto>();
            foreach (var type in types)
            {
                TypeGetList.Add(_mapper.Map<WorkGetDto>(type));
            }

            if (types.Count > 0)
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "Ok", TypeGetList);

            }
            else
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "WorkType is empty", null);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Answer<WorkGetDto>> Get(string id)
        {
            var exist = _context.WorkType.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

            if (exist != null)
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "Ok", new List<WorkGetDto> { _mapper.Map<WorkGetDto>(exist) });
            }
            else
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "Type not found", null);
            }
        }


        [HttpPost]
        public ActionResult<Answer<WorkGetDto>> CreateType(WorkPostDto WorkPostDto)
        {

            WorkType newType = new WorkType()
            {
                uuid = Guid.NewGuid().ToString(),
                isDeleted = false,
                info = WorkPostDto.info,
                value = WorkPostDto.value,
                color = WorkPostDto.color,
                description = WorkPostDto.description
            };
            _context.WorkType.Add(newType);
            _context.SaveChanges();
            return getFinishObject = new Answer<WorkGetDto>(201, "Worktype added", null);
        }

        [HttpPut]
        public ActionResult<Answer<WorkGetDto>> UpdateType(WorkUpdateDto WorkUpdateDto)
        {
            var exist = _context.WorkType.FirstOrDefault(x => x.uuid == WorkUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "Type not found", null);
            }

            exist.info = WorkUpdateDto.info;
            exist.value = WorkUpdateDto.value;
            exist.color = WorkUpdateDto.color;
            exist.description = WorkUpdateDto.description;

            _context.SaveChanges();

            return getFinishObject = new Answer<WorkGetDto>(204, "Worktype updated", null);
        }


        [HttpDelete("{id}")]
        public ActionResult<Answer<WorkGetDto>> DeletedDepartment(string id)
        {
            var exist = _context.WorkType.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<WorkGetDto>(200, "Worktype not found", null);
            }
            exist.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<WorkGetDto>(204, "Worktype deleted", null);

        }
    }
}
