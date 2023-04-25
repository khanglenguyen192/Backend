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
        private readonly ITicketFileRepository _ticketFileRepository;
        private readonly IReportFileRepository _reportFileRepository;

        public TicketController(IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger,
                                IUserRepository userRepository,
                                ITicketRepository ticketRepository,
                                IReportRepository reportRepository,
                                ITicketFileRepository ticketFileRepository,
                                IReportFileRepository reportFileRepository) : base(userService, webHostEnvironment, logger, userRepository)
        {
            _ticketRepository = ticketRepository;
            _reportRepository = reportRepository;
            _ticketFileRepository = ticketFileRepository;
            _reportFileRepository = reportFileRepository;
        }

        [HttpPost]
        //[Produces("multipart/form-data")]
        [Produces("application/json")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateTicket([FromForm] TicketRequestModel model, IList<IFormFile> files)
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

                if (_ticketRepository.Insert(ticket) > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        string savedFileName = FileUtils.FileUpload(Constants.UserDataFolderName, file);
                        if (!string.IsNullOrWhiteSpace(savedFileName))
                        {
                            TicketFile ticketFile = new TicketFile
                            {
                                TicketId = ticket.Id,
                                FileName = savedFileName,
                                DisplayName = file.FileName
                            };
                            _ticketFileRepository.Insert(ticketFile);
                        }
                    }
                }

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

                List<TicketFile> ticketFiles = _ticketFileRepository.GetAll(t => t.TicketId == ticketId && !t.IsDeactivate);
                if (ticketFiles != null && ticketFiles.Any())
                {
                    result.TicketFiles = ticketFiles;
                }

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
        public ResponseModel SubmitTicket([FromForm]SubmitTicketModel model, IList<IFormFile> files)
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
        public ResponseModel CreateReport([FromForm]ReportModel model, IList<IFormFile> files)
        {
            try
            {
                var ticket = _ticketRepository.FirstOrDefault(t => t.Id == model.TicketId && !t.IsDeactivate);

                if (ticket == null)
                    return ResponseUtil.GetBadRequestResult("ticket_not_found");

                Report report = _mapper.Map<ReportModel, Report>(model);

                _reportRepository.Insert(report);

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        string savedFileName = FileUtils.FileUpload(Constants.UserDataFolderName, file);
                        if (!string.IsNullOrWhiteSpace(savedFileName))
                        {
                            ReportFile reportFile = new ReportFile
                            {
                                ReportId = report.Id,
                                FileName = savedFileName,
                                DisplayName = file.FileName
                            };
                            _reportFileRepository.Insert(reportFile);
                        }
                    }
                }
                
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
        public ResponseModel UpdateReport([FromForm] UpdateReportModel model, IList<IFormFile> files)
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

        [HttpGet]
        [Produces("application/json")]
        [Route("download-file")]
        [Authorize]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName) || fileName == null)
                {
                    return BadRequest("File Name is Empty...");
                }

                // get the filePath
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constants.UserDataFolderName, fileName);


                if (System.IO.File.Exists(filePath))
                {
                    return File(System.IO.File.OpenRead(filePath), "application/octet-stream", Path.GetFileName(filePath));
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
