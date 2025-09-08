using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Testes.Services;

namespace Testes.Pages.NfeStatus
{
    public class ResultModel : PageModel
    {
        private readonly NfeStatusService _service;

        public ResultModel(NfeStatusService service)
        {
            _service = service;
        }

        [BindProperty]
        public string Uf { get; set; } = string.Empty;

        [BindProperty]
        public int Ambiente { get; set; }

        public HttpStatusCode StatusCode { get; private set; }
        public bool IsAvailable { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            StatusCode = await _service.GetStatusCodeAsync(Uf, Ambiente.ToString());
            IsAvailable = StatusCode == HttpStatusCode.OK;
            return Page();
        }
    }
}
