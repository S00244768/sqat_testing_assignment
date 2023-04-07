using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InsuranceService.Web.Pages
{ 
    class Always15DiscountService : DiscountService
    {
        public double GetDiscount()
        {
            return 0.85;
        }
    }
    
    public class PrivacyModel : PageModel
    {
        private InsuranceService ins;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            ins = new InsuranceService(new Always15DiscountService());
        }

        public void OnGet()
        {
        }
        
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        public string Location { get; set; }
        public void OnPost()
        {
            var premium = ins.CalcPremium(Age, Location);
             ViewData["premium"] = premium;
            _logger.LogInformation($"=> CalcPremium({Age}, {Location}) = {premium}");
        }
    }
}