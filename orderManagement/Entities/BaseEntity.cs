using System.ComponentModel.DataAnnotations.Schema;

namespace orderManagement.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}