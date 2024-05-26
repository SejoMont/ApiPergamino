﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPergamino.Models
{
    [Table("EMP")]
    public class Empleado
    {
        [Key]
        [Column("EMP_NO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("OFICIO")]
        public string Oficio { get; set; }
        [Column("DIR")]
        public int Dir { get; set; }
        [Column("FECHA_ALT")]
        public DateTime Fecha_Alt { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
        [Column("COMISION")]
        public int Comision { get; set; }
        [Column("DEPT_NO")]
        public int IdDepartamento { get; set; }

    }
}
