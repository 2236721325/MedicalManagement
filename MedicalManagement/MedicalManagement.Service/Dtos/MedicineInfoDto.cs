using Base.Shared.Dtos;

namespace MedicalManagement.Service.Dtos
{
    public class MedicineInfoDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
    public class MedicineInfoCreateDto
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
    public class MedicineInfoUpdateDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
}
