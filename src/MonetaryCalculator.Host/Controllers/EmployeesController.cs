using MediatR;
using Microsoft.AspNetCore.Mvc;
using MonetaryCalculator.Domain;
using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Queries;
using MonetaryCalculator.Host.Extensions;
using MonetaryCalculator.Host.Responses;
using MonetaryCalculator.Infra.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Host.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<IEnumerable<Employee>, IEnumerable<EmployeeResumedResponse>> resumedEmployeeMapper;
        private readonly IMapper<Employee, EmployeeDetailedResponse> detailedEmployeeMapper;

        public EmployeesController(IMediator mediator, 
            IMapper<IEnumerable<Employee>, IEnumerable<EmployeeResumedResponse>> resumedEmployeeMapper, 
            IMapper<Employee, EmployeeDetailedResponse> detailedEmployeeMapper)
        {
            this.mediator = mediator;
            this.resumedEmployeeMapper = resumedEmployeeMapper;
            this.detailedEmployeeMapper = detailedEmployeeMapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IEmployeeQuery employeeQuery, CancellationToken cancellationToken)
        {
            var result = await employeeQuery.Get(cancellationToken);
            return Ok(resumedEmployeeMapper.Map(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id, [FromServices] IEmployeeQuery employeeQuery, CancellationToken cancellationToken)
        {
            var result = await employeeQuery.Get(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(detailedEmployeeMapper.Map(result));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HireEmployeeCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Created($"/employees/{result.Id}", result);
            }
            catch (BusinessException ex)
            {
                return ex.GetError();
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] UpdateEmployeeNameCommand command)
        {
            try
            {
                await mediator.Send(command);
                return NoContent();
            }
            catch (BusinessException ex)
            {
                return ex.GetError();
            }
        }

        [HttpPost("{id}/wages")]
        public async Task<ActionResult> ChangeSalary(int id, [FromBody] ChangeSalaryCommand command)
        {
            try
            {
                command.SetEmployeeId(id);
                var result = await mediator.Send(command);
                return Created(string.Empty, result);
            }
            catch (BusinessException ex)
            {
                return ex.GetError();
            }
        }

        [HttpPost("{id}/vacations")]
        public async Task<ActionResult> RegisterVacation(int id, [FromBody] RegisterVacationCommand command)
        {
            try
            {
                command.SetEmployeeId(id);
                var result = await mediator.Send(command);
                return Created(string.Empty, result);
            }
            catch (BusinessException ex)
            {
                return ex.GetError();
            }
        }
    }
}
