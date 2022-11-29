using Base.Shared.Domains;

namespace MedicalManagement.Domain.Models
{
    //药品:药品ID，名称，医药类别，价格，生产厂家，规格。
    public class MedicineInfo : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
}
