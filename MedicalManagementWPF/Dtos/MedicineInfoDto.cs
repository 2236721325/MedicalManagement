using MedicalManagementWPF.Dtos;

namespace MedicalManagementWPF.Dtos
{
    public class MedicineInfoDto:BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
    public class MedicineInfoCreateUpdateDto 
    {
        public string Name { get; set; }
        public string Catagory { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }
}
