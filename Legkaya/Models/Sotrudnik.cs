using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legkaya.models
{
    public class Sotrudnik
    {
        public int Id { get; set; }
        public string? Personal_id { get; set; }
        public string? Last_name { get; set; }
        public string? First_name { get; set; }
        public string? Patronymic { get; set; }
        public string? Date_of_birth { get; set; }
        public string? Phone { get; set; }
        public string? Otdel { get; set; }
    }
}
