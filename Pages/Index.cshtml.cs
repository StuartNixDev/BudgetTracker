using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using System.Linq;


namespace BudgetTracker.Pages
{
    public class IndexModel : PageModel
    {

       public List<Debit> debits = new List<Debit>();
       public List<Debit> sortedList = new List<Debit>();

       public double totalSpend = 0;

        public void OnGet()
        {
            debits = new DataAccess().GetDebits();
            sortedList = debits.OrderByDescending(c => c.Cost).ToList();

            foreach(var debit in debits)
            {
                totalSpend += debit.Cost;

            }
           
        }

       
    }
}