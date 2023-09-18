using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }     
        public StatusTarefas Status { get; set; } 
        public int? UsuaruioId { get; set; } 
        public virtual UsuarioModel? Usuario { get; set; }  

    }
}
