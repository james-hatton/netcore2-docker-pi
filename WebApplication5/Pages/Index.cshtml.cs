using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using WebApplication5.Hubs;

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


            await hubContext.Clients.All.InvokeAsync("send", HttpContext.Request.Headers["HTTP_X_REAL_IP"].FirstOrDefault());
        }

    }
}
