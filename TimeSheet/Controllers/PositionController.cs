using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class positionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<PositionGetDto> getFinishObject;
        public positionController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<PositionGetDto>> GetAll()
        {
            List<Position> positions = _context.Positions.Where(x => x.isDeleted == false).ToList();
            List<PositionGetDto> positionsDto = new List<PositionGetDto>();
            if (positions.Count < 0)
            {
                return getFinishObject = new Answer<PositionGetDto>(200, "Position is empty", null);
            }
            foreach (var position in positions)
            {
                positionsDto.Add(_mapper.Map<PositionGetDto>(position));
            }
            return getFinishObject = new Answer<PositionGetDto>(200, "Ok", positionsDto);

        }

        [HttpGet("{id}")]
        public ActionResult<Answer<PositionGetDto>> Get(string id)
        {
            var exist = _context.Positions.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(200, "Position doesn't exist", null);
            }
            return getFinishObject = new Answer<PositionGetDto>(200, "Ok", new List<PositionGetDto> { _mapper.Map<PositionGetDto>(exist) });
        }

        [HttpPost]
        public ActionResult<Answer<PositionGetDto>> CreatePosition(PositionPostDto PositionPostDto)
        {
            Position newPosition = new Position()
            {
                name = PositionPostDto.name,
                uuid = Guid.NewGuid().ToString(),
                isDeleted = false
            };

            _context.Positions.Add(newPosition);

            _context.SaveChanges();

            return getFinishObject = new Answer<PositionGetDto>(201, "Poition created", null);
        }


        [HttpDelete("{id}")]
        public ActionResult<Answer<PositionGetDto>> DeletePosition(string id)
        {
            var exist = _context.Positions.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(200, "Position not found", null);
            }

            exist.isDeleted = true;

            _context.SaveChanges();

            return getFinishObject = new Answer<PositionGetDto>(204, "No Content", null);
        }

        [HttpPut]
        public ActionResult<Answer<PositionGetDto>> UpdatePosition(PositionUpdateDto PositionUpdateDto)
        {
            var exist = _context.Positions.FirstOrDefault(x => x.uuid == PositionUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(200, "Position not found", null);
            }

            exist.name = PositionUpdateDto.name;

            _context.SaveChanges();

            return getFinishObject = new Answer<PositionGetDto>(204, "No Content", null);

        }

    }
}
