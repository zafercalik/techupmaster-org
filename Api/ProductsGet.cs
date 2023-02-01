using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using BlazorApp.Shared;
using System.Net.Http.Json;
using System.Net.Mail;
using Newtonsoft.Json;
using System.IO;

namespace Api
{
    public class ProductsGet
    {
        private readonly ILogger _logger;


        public ProductsGet(ILoggerFactory loggerFactory)
        {

            _logger = loggerFactory.CreateLogger<ProductsGet>();

        }




        [EnableCors("DevCorsPolicy2")]
        [Function("ProductsGet")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {

            var content = await new StreamReader(req.Body).ReadToEndAsync();


            SendMail myClass = JsonConvert.DeserializeObject<SendMail>(content);



            
            MailMessage message = new MailMessage();
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("infoargeinvex@gmail.com");
            message.To.Add(new MailAddress("fatih.emecen98@gmail.com"));
            message.Subject = myClass.Title + " " + myClass.Name;
            message.IsBodyHtml = true;
            message.Body = myClass.Body;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("infoargeinvex@gmail.com", "tpomvynthxqdxmys");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(myClass);

            return response;
        }
        /*public async Task<List<SendMail>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<List<SendMail>>("api/ProductsGet");
        }*/

    }
}
