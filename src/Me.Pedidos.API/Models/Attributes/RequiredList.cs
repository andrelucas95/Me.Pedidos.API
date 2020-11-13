using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Me.Pedidos.API.Models.Attributes
{
    public class RequiredList : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            
            if (list != null)
            {
                return list.Count > 0;
            }

            return false;
        }
    }
}