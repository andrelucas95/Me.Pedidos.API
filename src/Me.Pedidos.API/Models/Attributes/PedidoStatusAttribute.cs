using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Me.Pedidos.API.Models.Attributes
{
    public class PedidoStatusAttribute : ValidationAttribute
    {
        public string[] AllowableStatus { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableStatus?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Insira um valor de status válido: {string.Join(", ", (AllowableStatus ?? new string[] { "Status não encontrado" }))}.";
            return new ValidationResult(msg);
        }
    }
}