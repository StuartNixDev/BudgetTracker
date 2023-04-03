using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetTracker.Pages.Forms
{
    public class AddDebitModel : PageModel
    {
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Cost { get; set; }
        [BindProperty]
        public string PaymentDate { get; set; }

        public double newCost;

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(DataAccess dataAccess)
        {
            newCost = Convert.ToDouble(Cost);
            dataAccess.AddDebit(ID, Name, newCost, PaymentDate);
            return new RedirectToPageResult("/ViewDebits");
        }
       
    }
}
