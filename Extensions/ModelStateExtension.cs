using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StockPro.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrors(this ModelStateDictionary ModelState)
        {
            var result = new List<string>();

            foreach (var item in ModelState.Values)
                result.AddRange(item.Errors.Select(error => error.ErrorMessage));

            return result;
        }
    }
}
