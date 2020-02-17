using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroProject.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AlterEgo { get; set; }
        [Required]
        public string PrimarySuperHeroAbility { get; set; }
        public string SecondarySuperHeroAbility { get; set; }
        public string CatchPhrase { get; set; }
        public string Image { get; set; }

    }
}
