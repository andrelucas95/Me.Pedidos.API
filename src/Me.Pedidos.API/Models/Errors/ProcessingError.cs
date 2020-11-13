using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Me.Pedidos.API.Models.Errors
{
    public class ProcessingError : IActionResult
    {
        public string Status { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var json = new JsonResult(this) { StatusCode = 4222 };

            await json.ExecuteResultAsync(context);
        }
    }
}