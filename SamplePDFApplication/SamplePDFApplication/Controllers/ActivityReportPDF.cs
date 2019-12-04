using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicPDFTestingApp.Controllers
{

    class Record
    {
        public string Date { get; set; }

        public string Type { get; set; }

        public double HoursDeducted { get; set; }

        public double HoursAdded { get; set; }

        public double Balance { get; set; }
    }


    class Header
    {
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
        public string TimeOffTypeName { get; set; }
        public string BenefitYearStart { get; set; }
        public string BenefitYearEnd { get; set; }
        public List<Record> Records { get; set; }
    }



    public class PageLayout
    {
        public PageDimensions Dimensions { get; set; }

        public float BodyTop { get; set; }

        //Additional Parameter  go here
        public PageLayout()
        {
            Dimensions = new PageDimensions(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            BodyTop = 200;
        }

    }


    public abstract class PDFReport : IPDFReport
    {

        private PageLayout pageLayout;

        private float bodyBottom = 0;

        /// <summary>
        /// Current Row Drawing Position in Pixels for the document 
        /// </summary>
        protected float currentRowPosition = 0;

        private Page currentPage;

        private string documentTitle = string.Empty;

        private string author = string.Empty;

        private Document document;

        public PDFReport()
        {
            this.document = new Document();
            this.pageLayout = new PageLayout();
            this.bodyBottom = this.pageLayout.Dimensions.Body.Bottom - this.pageLayout.Dimensions.Body.Top;
        }

        public PDFReport(string title, string author = "PayCor") : this()
        {
            this.documentTitle = title;
            this.author = author;
        }

        public void SetPageLayOut(object layout)
        {
            this.pageLayout =  (PageLayout)layout;
            this.bodyBottom = pageLayout.Dimensions.Body.Bottom - pageLayout.Dimensions.Body.Top;
        }

        protected abstract void BuildDocument();

        public byte[] GeneratePDF()
        {
            BuildDocument();

            var byteArray = document.Draw();

            return byteArray;
        }

        public void AddNewPage()
        {
            currentPage = new Page(pageLayout.Dimensions);
            currentRowPosition = pageLayout.BodyTop;
            document.Pages.Add(currentPage);
        }

        public void AddPageElement(object element)
        {
            currentPage.Elements.Add((PageElement)element);
        }

        public bool IsPageOverFlow => currentRowPosition > bodyBottom;

    }


    public class ActivityReportPDF : PDFReport
    {
        bool alternateBg = false;

        List<Record> records = new List<Record>()
        {
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "11/29/19", Type="Sick", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "12/29/18", Type="Vacation", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "06/29/17", Type="PTO", HoursDeducted = 10.3,HoursAdded=10,Balance=10},
             new Record() { Date = "04/29/19", Type="Planned", HoursDeducted = 10.3,HoursAdded=10,Balance=10},

        };

        public ActivityReportPDF() : base(title: "Activity Report")
        {
            var layout = new PageLayout();
            layout.BodyTop = 200;
            layout.Dimensions = new PageDimensions(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            this.SetPageLayOut(layout);
        }

        private void AddHeader(Header header)
        {


            AddPageElement(new Label($"Perform Accrual History for {header.TimeOffTypeName}", 0, 0, 504, 12, Font.TimesBold, 11, TextAlign.Center));
            AddPageElement(new Label($"Benefit Year:{header.BenefitYearStart} to {header.BenefitYearEnd} ", 0, 25, 504, 12, Font.TimesBold, 11, TextAlign.Center));

            //PageNumberingLabel pageNumLabel = new PageNumberingLabel("Page %%CP%% of %%TP%%", 0, 2, 504, 12, Font.TimesBold, 11, TextAlign.Right);
            //template.Elements.Add(pageNumLabel);

            AddPageElement(new Label($"Employee Name:{header.EmployeeName} ", 0, 50, 504, 12, Font.TimesBold, 11, TextAlign.Left));
            AddPageElement(new Label($"Employee Number:{header.EmployeeNumber} ", 0, 70, 504, 12, Font.TimesBold, 11, TextAlign.Left));
            AddPageElement(new Label($"Department:{header.Department} ", 0, 90, 504, 12, Font.TimesBold, 11, TextAlign.Left));

            AddPageElement(new Label("AVAILABLE BALANCE", 0, 115, 504, 12, Font.TimesBold, 11, TextAlign.Left, new WebColor("696969")));
            AddPageElement(new Label("HOURS ADDED".ToUpper(), 150, 115, 504, 12, Font.TimesBold, 11, TextAlign.Left, new WebColor("696969")));
            AddPageElement(new Label("HOURS USED", 250, 115, 504, 12, Font.TimesBold, 11, TextAlign.Left, new WebColor("696969")));
            AddPageElement(new Label("HOURS OF UPCOMING TIME OFF", 350, 115, 504, 12, Font.TimesBold, 11, TextAlign.Left, new WebColor("696969")));

            AddPageElement(new Label("50", 0, 125, 504, 12, Font.TimesBold, 18, TextAlign.Left));
            AddPageElement(new Label("75".ToUpper(), 150, 125, 504, 12, Font.TimesBold, 18, TextAlign.Left));
            AddPageElement(new Label("25", 250, 125, 504, 12, Font.TimesBold, 18, TextAlign.Left));
            AddPageElement(new Label("0", 350, 125, 504, 12, Font.TimesBold, 18, TextAlign.Left));


            const int headerX = 180;

            AddPageElement(new Rectangle(0, headerX - 10, 506, 25, RgbColor.LightGrey, new WebColor("bec3cc"), 0.0F));
            AddPageElement(new Label("Date", 2, headerX, 236, 11, Font.TimesBold, 11));
            AddPageElement(new Label("Type", 60, headerX, 156, 11, Font.TimesBold, 11));
            AddPageElement(new Label("Hours Deducted", 250, headerX, 100, 11, Font.TimesBold, 11, TextAlign.Right));
            AddPageElement(new Label("Hours Added", 340, headerX, 100, 11, Font.TimesBold, 11, TextAlign.Right));
            AddPageElement(new Label("Balance", 400, headerX, 100, 11, Font.TimesBold, 11, TextAlign.Right));

        }

        private void AddRecord(Record record, Header header)
        {
            // Adds a new page to the document if needed
            if (this.IsPageOverFlow)
            {
                alternateBg = false;
                AddNewPage();
                AddHeader(header);
            }


            // Adds alternating background to document if needed
            if (alternateBg)
            {
                AddPageElement(new Rectangle(0, currentRowPosition, 504, 18, RgbColor.LightGrey, new WebColor("dfe1e5"), 0.0F));
            }
            // Adds Labels to the document with data from current record
            AddPageElement(new Label(record.Date, 2, currentRowPosition + 3, 55, 11, Font.TimesRoman, 11));
            AddPageElement(new Label(record.Type, 60, currentRowPosition + 3, 150, 11, Font.TimesRoman, 11));
            AddPageElement(new Label(record.HoursDeducted.ToString("0.00"), 250, currentRowPosition + 3, 100, 11, Font.TimesRoman, 11, TextAlign.Right));
            AddPageElement(new Label(record.HoursAdded.ToString("0.00"), 340, currentRowPosition + 3, 100, 11, Font.TimesRoman, 11, TextAlign.Right));
            AddPageElement(new Label(record.Balance.ToString("0.00"), 400, currentRowPosition + 3, 100, 11, Font.TimesRoman, 11, TextAlign.Right));

            // Toggles alternating background
            alternateBg = !alternateBg;

            // Increments the current Y position on the page
            currentRowPosition += 18;
        }

        protected override void BuildDocument()
        {
            var headers = new List<Header>()
                    {
                         new Header() {
                              BenefitYearStart = "01-01-17",
                              BenefitYearEnd = "01-06-17",
                              Department = "IT",
                              EmployeeName = "PayCorEmployee",
                              EmployeeNumber = "#214",
                              TimeOffTypeName = "Sick Leaves",
                              Records = records
                         },
                         new Header() {
                              BenefitYearStart = "01-01-18",
                              BenefitYearEnd = "01-06-18",
                              Department = "IT",
                              EmployeeName = "PayCorEmployee",
                              EmployeeNumber = "#214",
                              TimeOffTypeName = "Planned Leaves",
                              Records = records
                         },
                         new Header() {
                              BenefitYearStart = "01-01-19",
                              BenefitYearEnd = "01-06-19",
                              Department = "IT",
                              EmployeeName = "PayCorEmployee",
                              EmployeeNumber = "#214",
                              TimeOffTypeName = "Vacation",
                              Records = records
                         },
                    };

                foreach (var header in headers)
                {
                    AddNewPage();
                    AddHeader(header);
                    foreach (var item in header.Records)
                    {
                        AddRecord(item, header);
                    }
                }
        }


    }
}
