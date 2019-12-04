using ceTe.DynamicPDF;

namespace DynamicPDFTestingApp.Controllers
{
    public interface IPDFReport
    {
        bool IsPageOverFlow { get; }

        void AddNewPage();
        void AddPageElement(object element);
        byte[] GeneratePDF();
        void SetPageLayOut(object layout);
    }
}