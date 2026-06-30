namespace Search.Api.DTOs
{
    public class ExcelPreviewDto
    {
        public string SheetName { get; set; } = "";

        public int TotalRows { get; set; }

        public int TotalColumns { get; set; }

        public List<string> Headers { get; set; } = new();

        public List<List<string>> PreviewRows { get; set; } = new();
    }
}