using System.ComponentModel.DataAnnotations;

namespace StockPro.ViewModels
{
    public class EditorProductViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string Description { get; set; }
    }
}
