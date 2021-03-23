using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Admix.NetCore.Models.Enums;

namespace Admix.NetCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column("Grupo")]
        [Display(Name = "Grupo")]
        public GrupoUsuario Grupo { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [NotMapped] [Display(Name = "Senha")] public string Senha { get; set; }

        [NotMapped]
        [Display(Name = "Confirme sua senha")]
        public string ConfirmarSenha { get; set; }
    }

    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public SelectList Grupos { get; set; }
        public SelectList Status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}