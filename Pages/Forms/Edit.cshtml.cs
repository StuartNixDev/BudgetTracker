using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace BudgetTracker.Pages.Forms
{
    public class EditModel : PageModel
    {


        public List<Debit> result = new List<Debit>();

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Cost { get; set; }
        [BindProperty]
        public string PaymentDate { get; set; }

        public double newCost;


        public void OnGet(int id) 
        {

            result = new DataAccess().FetchDebit(id);

        }

        public RedirectToPageResult OnPost(DataAccess dataAccess)
        {
            newCost = Convert.ToDouble(Cost);
            dataAccess.UpdateDebit(ID, Name, newCost, PaymentDate);
            return new RedirectToPageResult("/ViewDebits");
        }
 }
     }     


    

