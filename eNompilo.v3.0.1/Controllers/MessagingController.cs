using eNompilo.v3._0._1.Models.Family_Planning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eNompilo.v3._0._1.Controllers
{
    using eNompilo.v3._0._1.Areas.Identity.Data;
    using eNompilo.v3._0._1.Models.SystemUsers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Threading.Tasks;
    using eNompilo.v3._0._1.Models.Message;
    using Microsoft.EntityFrameworkCore;
    using NuGet.Protocol.Plugins;
    using Message = Models.Message.Message;

    [Authorize]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _chatHubContext;

        public MessageController( ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHubContext<ChatHub> chatHubContext)
        {
            _context = context;
            _userManager = userManager;
            _chatHubContext = chatHubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int Id)
        {
            var recid = _context.tblFamilyPlanningAppointment.Find(Id);
            var ResponsiblePractitionerId = recid?.ResponsiblePractitionerId;
            var sender = await _userManager.GetUserAsync(User);
            var receiver = await _userManager.FindByIdAsync(ResponsiblePractitionerId);

            if (sender == null || receiver == null)
            {
                return NotFound();
            }

            // Retrieve a single message for the chat between sender and receiver
            var message = _context.Messages
                .FirstOrDefault(m => (m.SenderId == sender.Id && m.ReceiverId == ResponsiblePractitionerId) ||
                                    (m.SenderId == ResponsiblePractitionerId && m.ReceiverId == sender.Id));

            if (message == null)
            {
                
                message = new Message
                {
                    SenderId = sender.Id,
                    ReceiverId = ResponsiblePractitionerId,
                    Content = "Hello, this is a test message.", // Set the initial message content
                    Timestamp = DateTime.Now
                };
                _context.Messages.Add(message);
                _context.SaveChanges();
            }

            // Set ViewBag.ReceiverId for the view
            ViewBag.ReceiverId = ResponsiblePractitionerId;

            return View(message);
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(string receiverId, string content)
            {
            var sender = await _userManager.GetUserAsync(User);
            var receiver = await _userManager.FindByIdAsync(receiverId);

            if (sender == null || receiver == null || string.IsNullOrEmpty(content))
            {
                return BadRequest("Invalid message data");
            }

            var message = new Models.Message.Message
            {
                SenderId = sender.Id,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.Now,
                SenderUser = sender.FullName,
                ReceiverUser = receiver.FullName,
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            // Notify the recipient using SignalR
            await _chatHubContext.Clients.User(receiverId).SendAsync("ReceiveMessage", message);

            // Redirect to the Chat action after sending the message
            return RedirectToAction("MessageSent");
        }

        [HttpGet]
        public IActionResult MessageSent()
        {
            
            return View();
        }

        // GET: Inbox
        public IActionResult Inbox()
        {
            var pts = _context.tblPractitioner.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (pts != null)
            {
                var ptsid = pts.UserId;
                var messages = _context.Messages.Where(u => u.ReceiverId == ptsid ).OrderByDescending(m => m.Timestamp).ToList();
                return View(messages); 
            }
            else
            {
                return View();
            }
        }


        // GET: Inbox
        public IActionResult PatientInbox()
        {
            var pts = _context.tblPatient.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (pts != null)
            {
                var ptsid = pts.UserId;
                var messages = _context.Messages.Where(u => u.SenderId == ptsid).OrderByDescending(m => m.Timestamp).ToList();
                return View(messages);
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> ViewMessage(int Id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (message == null)
            {
                return NotFound();
            }

            var viewModel = new ViewMessageViewModel
            {
                Message = message,
                SenderId = message.SenderId,
                ReplyContent = string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ReplyToMessage(ViewMessageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sender = _context.tblPractitioner.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                
                var receiverId = viewModel.Message.SenderId; 
                if (sender != null)
                {
                    if (receiverId != null)
                    {
                        var replyMessage = new Message
                        {
                            SenderId = sender.UserId,
                            ReceiverId = receiverId,
                            Content = viewModel.ReplyContent,
                            Timestamp = DateTime.Now
                        };

                        _context.Messages.Add(replyMessage);
                        _context.SaveChanges();

                        return RedirectToAction("Inbox");
                    }
                    else { NotFound(); }
                }
                else { NotFound(); }
            }

            return View("ViewMessage", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var message = await _context.Messages.FindAsync(Id);

            if (message == null)
            {
                return NotFound(); 
            }

            var viewModel = new ReplayViewModel
            {
                MessageId = message.Id,

                SenderUser = message.SenderUser,
                ReceiverUser = message.ReceiverUser,
                Content = message.Content,
            };

            var previousReplies = await _context.Replay
                .Where(r => r.MessageId == message.Id)
                .ToListAsync();

            viewModel.PreviousReplies = previousReplies;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReplayViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var message = await _context.Messages.FindAsync(viewModel.MessageId);

                if (message == null)
                {
                    return NotFound();
                }

                var replay = new Replay
                {
                    MessageId = viewModel.MessageId,
                    ReplayMessage = viewModel.ReplayMessage,
                    Sender = message.ReceiverUser,
                };

                _context.Replay.Add(replay);
                await _context.SaveChangesAsync();

                // Set a confirmation message
                TempData["ReplaySuccess"] = "Replay sent successfully.";

                return RedirectToAction("Inbox");
            }

            return View(viewModel);
        }

        //Patient Replay

        [HttpGet]
        public async Task<IActionResult> PatientCreate(int Id)
        {
            var message = await _context.Messages.FindAsync(Id);

            if (message == null)
            {
                return NotFound();
            }

            var viewModel = new ReplayViewModel
            {
                MessageId = message.Id,

                SenderUser = message.SenderUser,
                ReceiverUser = message.ReceiverUser,
                Content = message.Content,
            };

            var previousReplies = await _context.Replay
                .Where(r => r.MessageId == message.Id)
                .ToListAsync();

            viewModel.PreviousReplies = previousReplies;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientCreate(ReplayViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var message = await _context.Messages.FindAsync(viewModel.MessageId);

                if (message == null)
                {
                    return NotFound();
                }
                
                var replay = new Replay
                {
                    MessageId = viewModel.MessageId,
                    ReplayMessage = viewModel.ReplayMessage,
                    Sender = message.SenderUser,
                };

                _context.Replay.Add(replay);
                await _context.SaveChangesAsync();

                // Set a confirmation message
                TempData["ReplaySuccess"] = "Replay sent successfully.";

                return RedirectToAction("PatientInbox");
            }

            return View(viewModel);
        }
    }
}
