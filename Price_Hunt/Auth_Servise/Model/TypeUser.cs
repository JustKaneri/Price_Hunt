using Auth_Servise.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth_Servise.Model
{
    [Table("TypeUser")]
    public class TypeUser : IDbModel
    {
        /* Первичный ключ */
        [Key]
        public int Id { get; set; }

        /* Название типа пользователя */
        [StringLength(50)]
        public string Name { get; set; }
    }
}