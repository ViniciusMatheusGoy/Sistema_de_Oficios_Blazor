using System.ComponentModel.DataAnnotations;

public class LoginViewModel{
    [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' é obrigatório")]
    public string? CPF { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Senha' é obrigatório")]
    public string? Senha { get; set; }
    
}