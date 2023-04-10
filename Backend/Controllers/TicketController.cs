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
        private readonly ITicketRepository _ticketRepository;
        private readonly IReportRepository _reportRepository;

        public TicketController(IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger,
                                IUserRepository userRepository,
                                ITicketRepository ticketRepository,
                                IReportRepository reportRepository) : base(userService, webHostEnvironment, logger, userRepository)
        {
            _ticketRepository = ticketRepository;
            _reportRepository = reportRepository;
        }

        [HttpPost]
        [Produces("multipart/form-data")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateTicket([FromBody]TicketRequestModel model, [FromForm] List<IFormFile> files)
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

        [HttpPost]
        [Produces("application/json")]
        [Route("create-report")]
        [Authorize]
        public ResponseModel CreateReport([FromBody] ReportModel model, IList<IFormFile> files)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                Report report = _mapper.Map<ReportModel, Report>(model);

                if (files != null)
                {
                    foreach (var file in files)
                    {
                    }
                }

                _reportRepository.Insert(report);
                return ResponseUtil.GetOKResult(report);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-report")]
        [Authorize]
        public ResponseModel UpdateReport([FromBody] UpdateReportModel model, IList<IFormFile> files)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                var report = _reportRepository.FirstOrDefault(p => p.Id == model.ReportId && !p.IsDeactivate);

                if (report == null)
                    return ResponseUtil.GetBadRequestResult("report_not_found");

                report = _mapper.Map<UpdateReportModel, Report>(model);

                if (files != null)
                {
                    foreach (var file in files)
                    {
                    }
                }

                _reportRepository.Update(report);
                return ResponseUtil.GetOKResult(report);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
