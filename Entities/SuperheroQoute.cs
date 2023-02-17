using System.ComponentModel.DataAnnotations;

namespace BetterboardOpgave.Entities
{
    public class SuperheroQoute
    {
        public int Id { get; set; }


        public string? Author { get; set; }

        public string? Image { get; set; }

        [Required]
        public string? Qoute { get; set; }
    }
}
