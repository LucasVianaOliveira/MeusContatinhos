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
    
    public partial class Foto
    {
        public int FotoID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public string Caminho { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
