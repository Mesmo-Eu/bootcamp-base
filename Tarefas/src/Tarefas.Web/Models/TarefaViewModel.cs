using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  

    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}