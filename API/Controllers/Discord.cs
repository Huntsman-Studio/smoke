using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers;

public class Discord : BaseApiController
{
    [HttpGet("notify")]
    public async Task<ActionResult> Notify()
    {

        string token = "";

        WebRequest wr = (HttpWebRequest)WebRequest.Create(token);

        wr.ContentType = "application/json";
        wr.Method = "POST";

        using (var sw = new StreamWriter(wr.GetRequestStream()))
        {
            string json = JsonConvert.SerializeObject(new 
            {
                username = "Hermes",
                embeds = new []
                {
                    new 
                    {
                        description = "Test nssssssssotify",
                        title = "Test sssTitle",
                        color = "1"
                    }
                }
            });

            sw.Write(json);
        }

        var respones = (HttpWebResponse)wr.GetResponse();
        
        return Ok(respones);
    }
}
