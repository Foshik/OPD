using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OPD.DataBase.Users;

namespace OPD.DataBase.Products
{
    public class UserBasket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public UserBasket()
        {
            Products = new List<Product>();
        }
    }

}
