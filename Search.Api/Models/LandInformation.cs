using System.ComponentModel.DataAnnotations.Schema;
namespace Search.Api.Models
{
    [Table("land_information")]
    public class LandInformation
    {
        public long Id { get; set; }

        public string? LandNo { get; set; }

        public string? HusbandName { get; set; }
        public string? HusbandOwnerStatus { get; set; }

        public string? WifeName { get; set; }
        public string? WifeOwnerStatus { get; set; }

        public string? PropertyType { get; set; }
        public decimal? AreaSqm { get; set; }

        public DateTime? HusbandDob { get; set; }
        public string? HusbandNationality { get; set; }
        public string? HusbandIdCard { get; set; }
        public string? HusbandBirthPlace { get; set; }
        public string? HusbandFatherName { get; set; }
        public string? HusbandMotherName { get; set; }
        public string? HusbandAddress { get; set; }

        public DateTime? WifeDob { get; set; }
        public string? WifeNationality { get; set; }
        public string? WifeIdCard { get; set; }
        public string? WifeBirthPlace { get; set; }
        public string? WifeFatherName { get; set; }
        public string? WifeMotherName { get; set; }
        public string? WifeAddress { get; set; }

        public string? LegalStatus { get; set; }
        public string? CertificateNo { get; set; }
        public string? LandUseImage { get; set; }
        public string? LandUseType { get; set; }
        public string? DisputedLand { get; set; }
        public string? OwnershipSource { get; set; }
        public DateTime? RecordDate { get; set; }

        public string? LegalEntityType { get; set; }
        public string? OrganizationName { get; set; }
        public string? OrganizationAddress { get; set; }
        public string? RepresentativeName { get; set; }
        public string? RepresentativeIdCard { get; set; }
        public string? RepresentativePosition { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}