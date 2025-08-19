////using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WCGAcademic.InMemoryData;

//namespace WCGAcademic.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegistersController : ControllerBase
//    {

//        private readonly ICourseRegisterService _context;

//        public RegistersController(ICourseRegisterService context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public Task<CourseRegister> Get()
//        {
//            // return _register.GetCourseRegister();
//        }

//        [HttpPost]
//        public  ActionResult PostCourseRegister (CourseRegister courseRegister)
//        {
//            _context.CourseRegisters.Add(courseRegister);
//            return Ok()
            
//              //await _context.SaveChangesAsync();

//            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
//           // return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
//        }
//    }
//}
