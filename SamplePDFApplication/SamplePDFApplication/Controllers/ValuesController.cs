using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using DynamicPDFTestingApp.Controllers;

namespace SamplePDFApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            //ceTe.DynamicPDF.Document document = new ceTe.DynamicPDF.Document();
            //document.Creator = "HelloWorld.aspx";
            //document.Author = "ceTe Software";
            //document.Title = "Hello World";
            //ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page(PageSize.A4, PageOrientation.Portrait, 54.0f);

            //string strLabel = "Hello C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com";
            //Label label = new Label(strLabel, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);

            //// Add label to page
            //page.Elements.Add(label);

            //// Add page to document
            //document.Pages.Add(page);

            ActivityReportPDF activityReport = new ActivityReportPDF();

            var doc = activityReport.GeneratePDF();

            //adding bytes to memory stream   
            var stream = new MemoryStream(doc);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };

            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "SampleActivityReport.pdf"
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            var response = ResponseMessage(result);

            return response;
        }



        [HttpGet]
        [Route("book")]
        public HttpResponseMessage GetBookForHRM(string format)
        {
            //ceTe.DynamicPDF.Document document = new ceTe.DynamicPDF.Document();
            //document.Creator = "HelloWorld.aspx";
            //document.Author = "ceTe Software";
            //document.Title = "Hello World";
            //ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page(PageSize.A4, PageOrientation.Portrait, 54.0f);

            //string strLabel = "Hello C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com";
            //Label label = new Label(strLabel, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);

            //// Add label to page
            //page.Elements.Add(label);

            //// Add page to document
            //document.Pages.Add(page);

            ActivityReportPDF activityReport = new ActivityReportPDF();

            var doc = activityReport.GeneratePDF();

            //adding bytes to memory stream   
            var stream = new MemoryStream(doc);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =              
                new MediaTypeHeaderValue("application/pdf");

            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
