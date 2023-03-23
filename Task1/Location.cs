using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1
{
    public class Location
      {
        [Key]
       public string Location_Name { get; set; }
       public string State { get; set; } = string.Empty;

       public string City { get; set; } = string.Empty;
       public string Zip { get; set; } = string.Empty;

        }
}
