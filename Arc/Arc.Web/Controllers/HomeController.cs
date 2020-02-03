using Arc.Application.Employees.Commands;
using Arc.Application.Employees.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Arc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<JsonResult> SaveEmployee(EmployeeVM data)
        {
            var _cmd = new CreateEmployeeCommand(data);

            var _result = await mediator.Send(_cmd);

            return Json(_result);   
        }

        public async Task<ActionResult> GetEmployeeList()
        {
            IEnumerable<EmployeeVM> _employees = new List<EmployeeVM>();

            var _cmd = new GetEmployeesQuery();

            _employees = await mediator.Send(_cmd);

            return PartialView("Partials/_EmployeeList", _employees);
        }
    }
}