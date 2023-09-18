using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.interfaces;

namespace SistemaDeTarefas.Repositorios
{    //Herança da InterfaceRepositorio e implementação dos membros definidos na interface
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        
        private readonly SistemadeTarefasDBContext _dbContext;
        //Construtor com injeção de dependência
        public UsuarioRepositorio(SistemadeTarefasDBContext sistemadeTarefasDBContext)
        {
            _dbContext = sistemadeTarefasDBContext;
        }
        // Função Assincrona que faz a buscar por Id 
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);    
        }
        // Função Assincrona que faz a busca de todos os usuarios e retorna uma Lista
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        // Função Assincrona que adiciona o usuario no banco 
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        //  Função Assincrona que apaga o usuario e retorna expressão Booliana 
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Não encontrado {id}");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);   
            await _dbContext.SaveChangesAsync();
            return true;
        }
        // Funão Assincrona que Atualiza por Id
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Não encontrado {id}");
            }
            usuarioPorId.Nome= usuario.Nome;    
            usuarioPorId.Email= usuario.Email;  
            
            _dbContext.Usuarios.Update(usuarioPorId);   
            await _dbContext.SaveChangesAsync();   

            return usuarioPorId;    
        }

        
       
    }
}
