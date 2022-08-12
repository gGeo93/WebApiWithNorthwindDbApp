using DataAccsessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public CustomerController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    [HttpGet("GetTurnoverOfAllOurCustomers")]
    public ActionResult<IQueryable<TurnoverOfEachCustomer>> GetTurnoverOfAllOurCustomers() 
    {
        var turnoversPerCustomer = unitOfWork.TurnoverPerCustomer.TurnoverPerCustomer();
        return Ok(turnoversPerCustomer);
    }
}
