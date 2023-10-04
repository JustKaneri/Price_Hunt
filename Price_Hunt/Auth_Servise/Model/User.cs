using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth_Servise.Model
{
    [Table("User")]
    public class User
    {
        /* Первичный ключ */
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /* Имя */
        [Column("Name")]
        [MinLength(1)]
        [StringLength(50)]
        public string Name { get; set; }

        /* Электронная почта */
        [Column("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        /* Хэш пароля */
        [Column("PasswordHash")]
        [MinLength(8)]
        public string PasswordHash { get; set; }

        /* Ключ для хеширования пароля */
        [Column("Salt")]
        [StringLength(50)]
        public string Salt { get; set; }

        /* Дата регистрации */
        [Column("DateCreate")]
        public string DateCreate { get; set; }

        /* Внешний ключ */
        [Column("TypeUserId")]
        public int TypeUserId { get; set; }

        public TypeUser TypeUser { get; set; }
    }
}
