using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace BudgetTracker.Pages.Forms
{
    public class DeleteModel : PageModel
    {

        public List<Debit> target = new List<Debit>();

        [BindProperty]
        public int ID { get; set; }

        public void OnGet(int id)
        {
            target = new DataAccess().FetchDebit(id);
        }


        public RedirectToPageResult OnPost(DataAccess dataAccess)
         {
            dataAccess.DeleteDebit(ID);
            return new RedirectToPageResult("/ViewDebits");

         }
        
    }
}
