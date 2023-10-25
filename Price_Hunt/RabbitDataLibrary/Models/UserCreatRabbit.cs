using RabbitDataLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitDataLibrary.Models
{
    public class UserCreatRabbit : IRabbitModel
    {
        public int Id { get; set; } 
        public string Token { get; set; }
    }
}
