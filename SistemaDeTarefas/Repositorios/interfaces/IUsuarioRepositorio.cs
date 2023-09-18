using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.interfaces
{
    public interface IUsuarioRepositorio
    {
        //Membros defenidos na interface
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario,int id);
        Task<bool> Apagar(int id);   
    }
}
