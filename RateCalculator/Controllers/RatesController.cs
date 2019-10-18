using Newtonsoft.Json;
using RateCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RateCalculator.Controllers
{
    public class RatesController : Controller
    {
        // GET: Rates
        public ActionResult Index()
        {
            /*bind property and occupany list items */
            AssumptionViewModel assumption = new AssumptionViewModel();
            PopulateDropdownlist(assumption);
            return View(assumption);
        }

        [HttpPost]
        public async Task<ActionResult> GetRates(AssumptionViewModel assumptionVM)
        {
            PopulateDropdownlist(assumptionVM);
            assumptionVM.assumption.occupancyType = assumptionVM.occupancies.Where(p => p.Value == assumptionVM.assumption.occupancyTypeId.ToString()).FirstOrDefault().Text;
            assumptionVM.assumption.propertyType = assumptionVM.properties.Where(p => p.Value == assumptionVM.assumption.propertyTypeId.ToString()).FirstOrDefault().Text;
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44300/api/external/getretailloanproducts";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var assumption = PopulateDefaultParameters(assumptionVM.assumption);
                var jsonString = JsonConvert.SerializeObject(assumption);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                assumptionVM.rateLst = new List<RateModel>();
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    assumptionVM.rateLst = JsonConvert.DeserializeObject<List<RateModel>>(result);
                }
            }
            return PartialView("~/Views/Rates/RatesTable.cshtml", assumptionVM);
        }

        private AssumptionViewModel PopulateDropdownlist(AssumptionViewModel assumption)
        {
            var properties = new List<SelectListItem>
            {
                new SelectListItem{Text="SFR (1-unit)", Value = "1" },
                new SelectListItem{Text="Low-Rise Condo (1-4)", Value = "3" },
                new SelectListItem{Text="Mid-Rise Condo (5-8)", Value = "5" },
                new SelectListItem{Text="HIgh Rise Condo (9+)", Value = "6" },
                new SelectListItem{Text="Manufactured Home", Value = "9" },
                new SelectListItem{Text="PUD", Value = "15" },
                new SelectListItem{Text="TownHome", Value = "16" },
                new SelectListItem{Text="2 Unit", Value = "21" },
                new SelectListItem{Text="3 Unit", Value = "31" },
                new SelectListItem{Text="4 Unit", Value = "41" },
            };
            var occupancies = new List<SelectListItem>
            {
                new SelectListItem{ Text="Owner Occupied", Value = "1" },
                new SelectListItem{ Text="Second Home", Value = "2" },
                new SelectListItem{ Text="Investment Property", Value = "3" },
            };
            assumption.properties = properties;
            assumption.occupancies = occupancies;
            return assumption;
        }

        private AssumptionModel PopulateDefaultParameters(AssumptionModel assumption)
        {
            assumption.loanAmount = 400000;
            assumption.secondLienAmount = 0;
            assumption.loanPurposeId = 1;
            assumption.loanPurpose = "Home Purchase";
            assumption.cashOutAmount = 0;
            assumption.appraisalValue = 600000;
            assumption.maxLineOfCredit = 0;
            assumption.mortgageInsuranceType = "";
            assumption.dtiRatio = "22.00";
            assumption.selfEmployed = "No";
            assumption.selfEmployedId = 2;
            assumption.loanDocumentation = "Full Doc";
            assumption.impounds = "No";
            assumption.noOfFinancedProperty = "1-4";
            assumption.noOfFinancedPropertiesId = 1;
            assumption.zipCode = "94536";
            assumption.city = "Fremont";
            assumption.state = "California";
            assumption.county = "Alameda";
            assumption.loanType = "Conventional";
            assumption.loanTypeList = new List<string> { "Conventional" };
            assumption.loanTerm = "30";
            assumption.amoritizationType = "Fixed";
            assumption.armFixedType = "";
            assumption.compensationModelId = 2;
            assumption.compensationModel = "Lender Paid";
            assumption.compensationAmount = "1.750";
            assumption.desiredLockTerm = "30";
            assumption.desiredRate = "5.000";
            assumption.isBrokerCompanyActive = true;
            assumption.isLoanLocked = true;
            assumption.isRequestLock = false;
            assumption.isInternalUser = false;
            assumption.stateCode = "CA";
            assumption.originationTYpeId = 2;
            assumption.loanDocumentationId = 1;
            assumption.lienPositionId = 1;
            assumption.isLegacy = false;
            assumption.interestOnlyOptionId = 1;
            assumption.loanTypeId = 1;
            return assumption;
        }
    }
}