using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Hubs;
using Microsoft.AspNetCore.SignalR;
using Raspberry.IO.GeneralPurpose;

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

            var led1 = ConnectorPin.P1Pin11.Output();

            var connection = new GpioConnection(led1);

            for (var i = 0; i < 100; i++)
            {
                connection.Toggle(led1);
                System.Threading.Thread.Sleep(250);
            }

            connection.Close();

            await hubContext.Clients.All.InvokeAsync("send", HttpContext.Request.Headers["HTTP_X_REAL_IP"].FirstOrDefault());
        }

    }
}
