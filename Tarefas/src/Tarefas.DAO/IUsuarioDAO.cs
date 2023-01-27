using Tarefas.DTO;

namespace Tarefas.DAO
{
    internal interface IUsuarioDAO
    {
        public void Criar(UsuarioDTO usuario);
        public List<UsuarioDTO> Consultar();
        public UsuarioDTO Consultar(int id);
        public void Atualizar(UsuarioDTO tarefa);
        public void Excluir(int id);
    }
}