using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth_Servise.Model
{
    [Table("Token")]
    public class Token
    {
        /* Первичный ключ */
        [Key]
        public int Id { get; set; }

        /* App токен пользователя */
        [Required]
        [StringLength(150)]  
        public string UserToken { get; set; }

        /* Дата создания*/
        public string? DateCreate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

        /* Активен ли токен */
        public bool IsVailid { get; set; } = true;

        /* Внешний ключ */
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
