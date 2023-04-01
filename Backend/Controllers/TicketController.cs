using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketController(IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger,
                                IUserRepository userRepository,
                                ITicketRepository ticketRepository) : base(userService, webHostEnvironment, logger)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateTicket([FromBody]TicketRequestModel model)
        {
            try
            {
                var assignor = _userRepository.FirstOrDefault(u => u.Id == model.AssignorId && !u.IsDeactivate);

                if (assignor == null)
                {
                    return ResponseUtil.GetBadRequestResult("Assignor not exist");
                }

                var assignee = _userRepository.FirstOrDefault(u => u.Id == model.AssigneeId && !u.IsDeactivate);

                if (assignee == null)
                {
                    return ResponseUtil.GetBadRequestResult("Assignee not exist");
                }

                Ticket ticket = _mapper.Map<TicketRequestModel, Ticket>(model);

                _ticketRepository.Insert(ticket);

                return ResponseUtil.GetOKResult(ticket);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-status")]
        [Authorize]
        public ResponseModel UpdateTicketStatus([FromBody]UpdateTicketStatusModel model)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                ticket.TicketStatus = model.TicketStatus;

                _ticketRepository.Update(ticket);

                return ResponseUtil.GetOKResult(ticket);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-assignee")]
        [Authorize]
        public ResponseModel UpdateTicketAssingee([FromBody] UpdateTicketAssigneeModel model)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                if (!_userRepository.Exists(u => u.Id == model.AssigneeId && !u.IsDeactivate))
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                ticket.AssigneeId = model.AssigneeId;

                _ticketRepository.Update(ticket);

                return ResponseUtil.GetOKResult(ticket);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-ticket")]
        [Authorize]
        public ResponseModel GetTicket(int ticketId)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == ticketId && !t.IsDeactivate);
                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.REPORT_NOT_FOUND);

                var result = _mapper.Map<Ticket, TicketModel>(ticket);
                return ResponseUtil.GetOKResult(result);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("search")]
        [Authorize]
        public ResponseModel SearchTicket([FromBody]SearchTicketModel searchModel)
        {
            try
            {
                return ResponseUtil.GetOKResult(null);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("submit")]
        [Authorize]
        public ResponseModel SubmitTicket([FromBody]SubmitTicketModel model, [FromForm]List<IFormFile> files)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                ticket.TicketStatus = model.TicketStatus;
                ticket.Content = model.Content;

                _ticketRepository.Update(ticket);

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        FileUtils.FileUpload(Constants.UserDataFolderName, file);
                    }
                }

                return ResponseUtil.GetOKResult(ticket);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-files")]
        [Authorize]
        public ResponseModel GetFiles(int ticketId)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == ticketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                return ResponseUtil.GetOKResult(ticket);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
