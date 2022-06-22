using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class departmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<DepartmentGetDto> getFinishObject;

        public departmentController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<DepartmentGetDto>> GetAll()
        {
            List<Department> departments = _context.Departments.Where(x => x.isDeleted == false).ToList();
            List<DepartmentGetDto> DepartmentGetList = new List<DepartmentGetDto>();
            foreach (var department in departments)
            {
                DepartmentGetDto department1 = new DepartmentGetDto()
                {
                    id = department.uuid,
                    name = department.name
                };
                DepartmentGetList.Add(department1);
            }

            if (departments.Count > 0)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Ok", DepartmentGetList);
            }
            else
            {
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department is empty", null);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Answer<DepartmentGetDto>> Get(string id)
        {
            var exist = _context.Departments.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

           

            if (exist != null)
            {
                DepartmentGetDto department = new DepartmentGetDto()
                {
                    id = exist.uuid,
                    name = exist.name
                };
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Ok", new List<DepartmentGetDto> { _mapper.Map<DepartmentGetDto>(department) });
            }
            else
            {
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department doesn't exist", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<DepartmentGetDto>> CreateProject(DepartmentPostDto DepartmentPostDto)
        {

            Department newDepartment = new Department()
            {
                uuid = Guid.NewGuid().ToString(),
                isDeleted = false,
                name = DepartmentPostDto.name
            };
            _context.Departments.Add(newDepartment);
            _context.SaveChanges();

            return getFinishObject = new Answer<DepartmentGetDto>(201, "Department created", null);
        }

        [HttpPut]
        public ActionResult<Answer<DepartmentGetDto>> UpdateProject(DepartmentUpdateDto DepartmentUpdateDto)
        {
            var exist = _context.Departments.FirstOrDefault(x => x.uuid == DepartmentUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department not found", null);
            }

            exist.name = DepartmentUpdateDto.name;

            _context.SaveChanges();

            return getFinishObject = new Answer<DepartmentGetDto>(204, "No Content", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<Answer<DepartmentGetDto>> DeletedDepartment(int id)
        {
            var exist = _context.Departments.FirstOrDefault(x => x.id == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department not found", null);
            }
            exist.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<DepartmentGetDto>(204, "No Content", null);
        }

    }
}
