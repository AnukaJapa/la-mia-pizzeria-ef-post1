using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaAna.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "text")]

        public string Description { get; set; }
        [Column(TypeName = "varchar(300)")]

        public string Image { get; set; }

        //Se non fai costruttore vuoto non funzioneràa

        public Pizza() { }
        public Pizza(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }

    }

}
