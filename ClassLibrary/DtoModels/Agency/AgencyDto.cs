using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.DtoModels.Agency
{
    public class AgencyDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateAgencyDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateAgencyDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
