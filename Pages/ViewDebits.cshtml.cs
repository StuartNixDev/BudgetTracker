using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetTracker.Pages
{
    public class ViewDebitsModel : PageModel
    {
        public List<Debit> debits = new List<Debit>();
    
        public double totalSpend = 0;
        public void OnGet()
        {
            debits = new DataAccess().GetDebits();
            debits = debits.OrderBy(o => o.ID).ToList();

            foreach (var debit in debits)
            {
                totalSpend += debit.Cost;

            }
        }  
    }
}
