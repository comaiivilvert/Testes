using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Testes.Pages.NfeStatus
{
    public class IndexModel : PageModel
    {
        public string Uf { get; set; } = string.Empty;
        public int Ambiente { get; set; } = 1;

        public void OnGet()
        {
        }
    }
}
