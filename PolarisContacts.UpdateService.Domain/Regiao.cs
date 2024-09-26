﻿using System.ComponentModel.DataAnnotations;

namespace PolarisContacts.UpdateService.Domain
{
    public class Regiao
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "DDD")]
        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "O DDD deve ter entre 2 e 3 caracteres.")]
        public string DDD { get; set; }

        public string NomeRegiao { get; set; }

        public bool Ativo { get; set; }
    }
}
