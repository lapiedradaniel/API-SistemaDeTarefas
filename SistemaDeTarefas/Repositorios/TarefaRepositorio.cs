using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.interfaces;

namespace SistemaDeTarefas.Repositorios
{      //Herança da InterfaceRepositorio e implementação dos membros definidos na interface
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemadeTarefasDBContext _dbContext;
        //Construtor com injeção de dependência
        public TarefaRepositorio(SistemadeTarefasDBContext sistemadeTarefasDBContext)
        {
            _dbContext = sistemadeTarefasDBContext;
        }
        // Função Assincrona que faz a buscar por Id 
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefa
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        // Função Assincrona que faz a busca de todos os usuarios e retorna uma Lista
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefa
                .Include (x => x.Usuario)
                .ToListAsync();
        }
        // Função Assincrona que adiciona o usuario no banco
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }
        //  Função Assincrona que apaga o usuario e retorna expressão Booliana 
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Não encontrado {id}");
            }

            _dbContext.Tarefa.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        // Funão Assincrona que Atualiza por Id
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Não encontrado {id}");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefa.UsuaruioId = tarefa.UsuaruioId;

            _dbContext.Tarefa.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

       
    }
}
