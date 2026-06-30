namespace Search.Api.Helpers
{
    public static class ExcelHeaderMap
    {
        public static readonly Dictionary<string, string> Columns = new()
        {
            { "លេខក្បាលដី", "land_no" },
            { "ឈ្មោះប្តី", "husband_name" },
            { "ស្ថានភាពនៃម្ចាស់ទ្រព្យ(ប្តី)", "husband_owner_status" },
            { "ឈ្មោះប្រពន្ធ", "wife_name" },
            { "ស្ថានភាពនៃម្ចាស់ទ្រព្យ(ប្រពន្ធ)", "wife_owner_status" },
            { "ប្រភេទទ្រព្យ", "property_type" },
            { "ទំហំ(ម៉ែត្រការ៉េ)", "area_sqm" },
            { "លេខបណ្ណ", "certificate_no" }
        };
    }
}