using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    

    [Required(ErrorMessage = "O titulo deve ser preenchido.")]
    [MinLength(5,ErrorMessage ="O titulo deve ter pelo menos 5 carcateres")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    

    [Required(ErrorMessage = "Ter no minimo 5 caracteres")]
    [MinLength(5,ErrorMessage ="A descrição deve ter pelo menos 5 carcateres")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  

    [Required(ErrorMessage = "Concluida não foi atribuido")]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}