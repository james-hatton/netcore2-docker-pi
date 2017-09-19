using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using WebApplication5.Models;

namespace WebApplication5.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            bool stop = true;
            Message = "Your application description page.";


            ConnectionFactory conn = new ConnectionFactory();
            conn.HostName = "rabbitmq";
            conn.UserName = "guest";
            conn.Password = "guest";

            var created = conn.CreateConnection();

            var channel = created.CreateModel();


            Message = JsonConvert.SerializeObject(new Rabbitmessage { FirstName = "James", SecondName = "Hatton" });
            channel.QueueDeclare("myqueue", false, false, false, null);
            channel.QueueBind("myqueue", "amq.direct", "a", null);
            for (int i = 0; i < 20; i++)
            {
                channel.BasicPublish("amq.direct", "a", false, null, Encoding.UTF8.GetBytes(Message));
            }
        }
    }
}
