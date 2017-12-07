using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {

        private static List<Usuario> listaUsuarios = new List<Usuario>();

        [AcceptVerbs("POST")]
        [Route("usuario")]
        public string CadastrarUsuario(Usuario usuario)
        {
            var db = new MeusContatinhosEntities();
            Usuario UsuarioNovo = new Usuario();
            try
            {
                UsuarioNovo.Nome = usuario.Nome;
                UsuarioNovo.Idade = usuario.Idade;
                UsuarioNovo.Email = usuario.Email;
                UsuarioNovo.Descricao = usuario.Descricao;
                UsuarioNovo.facebookid = usuario.facebookid;
                UsuarioNovo.DataCadastro = DateTime.Now;

                db.Usuario.Add(UsuarioNovo);
                db.SaveChanges();

                return "Usuário cadastrado com sucesso!";
            }
            catch (Exception x)
            {
                return "Ocorreu um erro ao salvar o usuário!";
            }
            
        }

        [AcceptVerbs("PUT")]
        [Route("usuario")]
        public string AlterarUsuario(Usuario usuario)
        {
            var db = new MeusContatinhosEntities();
            //Usuario UsuarioNovo = new Usuario();

            var usuarioAlterar = db.Usuario.Where(x => x.UsuarioID == usuario.UsuarioID).FirstOrDefault();
            
            try
            {
                usuarioAlterar.Nome = usuario.Nome;
                usuarioAlterar.Idade = usuario.Idade;
                usuarioAlterar.Email = usuario.Email;
                usuarioAlterar.Descricao = usuario.Descricao;

                db.SaveChanges();

                return "Usuário alterado com sucesso!";
            }
            catch (Exception x)
            {
                return "Ocorreu um erro ao salvar o usuário!";
            }            
        }

        [AcceptVerbs("DELETE")]
        [Route("usuario/{usuarioID}")]
        public string ExcluirUsuario(int usuarioID)
        {
            var db = new MeusContatinhosEntities();
            //Usuario UsuarioNovo = new Usuario();
            try { 
            var usuarioRemover = db.Usuario.Where(x => x.UsuarioID == usuarioID).FirstOrDefault();

            db.Usuario.Remove(usuarioRemover);
            db.SaveChanges();
                        
            return "Registro excluido com sucesso!";
            }
            catch(Exception x)
            {
                return "Houve um problema ao deletar o usuário" + x.Message + "";
            }
        }

        [AcceptVerbs("GET")]
        [Route("usuario/{usuarioID}")]
        public string ConsultarUsuarioPorCodigo(int usuarioID)
        {
            try { 
            var db = new MeusContatinhosEntities();            

            var usuario = db.Usuario.Where(x => x.UsuarioID == usuarioID).ToList();

             if (usuario == null) throw new Exception("Cliente não encontrado");

                string json = JsonConvert.SerializeObject(usuario);
                return json;
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }
        [AcceptVerbs("GET")]
        [Route("usuario/login/{facebookid}")]
        public string UsuarioPorFacebookID(string facebookid)
        {
            try
            {
                var db = new MeusContatinhosEntities();

                var usuario = db.Usuario.Where(x => x.facebookid == facebookid).ToList();

                if (usuario == null) {
                    string json = "false";  //throw new Exception("Cliente não encontrado");
                    return json;
                }
                else
                {
                    string json = JsonConvert.SerializeObject(usuario);
                    return json;
                }                        
                                
            }
            catch (Exception x)
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest, x.Message);
                return JsonConvert.SerializeObject(x.Message);
            }
        }
        [AcceptVerbs("GET")]
        [Route("usuario")]
        public List<Usuario> ConsultarUsuarios()
        {
            return listaUsuarios;
        }
    }
}