using System;

namespace orderManagement.Dtos.Order
{
    public class OrderRequirementBaseDto
    {
        public int Id { get; set; }
        public int Material { get; set; }
        public int Thick { get; set; }
        public string Paint { get; set; }
        public DateTime? FitDate { get; set; }
        public DateTime DueDate { get; set; }
        

    }
}