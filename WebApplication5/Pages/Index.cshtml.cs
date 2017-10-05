using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<MessageHub> hubContext;

        public IndexModel(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async void OnGet()
        {
            await hubContext.Clients.All.InvokeAsync("send", HttpContext.Request.Headers["REMOTE_ADDR"].FirstOrDefault());
        }

    }
}
