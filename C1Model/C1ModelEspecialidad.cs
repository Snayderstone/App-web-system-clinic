﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table ("ESPECIALIDADES")]
    public class C1ModelEspecialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        public string DescripcionEspecialidad { get; set; }

    }
}