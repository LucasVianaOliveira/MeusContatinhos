//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.AgendaUsuario = new HashSet<AgendaUsuario>();
            this.Foto = new HashSet<Foto>();
        }
    
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Idade { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public string facebookid { get; set; }
    
        public virtual ICollection<AgendaUsuario> AgendaUsuario { get; set; }
        public virtual ICollection<Foto> Foto { get; set; }
    }
}
