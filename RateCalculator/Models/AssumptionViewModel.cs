using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateCalculator.Models
{
    public class AssumptionViewModel
    {
        public AssumptionModel assumption {get; set; }
        public IEnumerable<SelectListItem> properties { get; set; }
        public IEnumerable<SelectListItem> occupancies { get; set; }
        public List<RateModel> rateLst { get; set; }
    }

    public class AssumptionModel
    {
        public int loanAmount { get; set; }
        public int secondLienAmount { get; set; }
        public int purchasePrice { get; set; }
        public int loanPurposeId { get; set; }
        public string loanPurpose { get; set; }
        public int cashOutAmount { get; set; }
        public int appraisalValue { get; set; }
        public int maxLineOfCredit { get; set; }
        public string mortgageInsuranceType { get; set; }
        public string dtiRatio { get; set; }
        public string selfEmployed { get; set; }
        public int selfEmployedId { get; set; }
        public string representativeFico { get; set; }
        public string loanDocumentation { get; set; }
        public string impounds { get; set; }
        public string noOfFinancedProperty { get; set; }
        public int noOfFinancedPropertiesId { get; set; }
        public string zipCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public int propertyTypeId { get; set; }
        public string propertyType { get; set; }
        public int occupancyTypeId { get; set; }
        public string occupancyType { get; set; }
        public string loanType { get; set; }
        public List<string> loanTypeList { get; set; }
        public string loanTerm { get; set; }
        public string amoritizationType { get; set; }
        public string armFixedType { get; set; }
        public int compensationModelId { get; set; }
        public string compensationModel { get; set; }
        public string compensationAmount { get; set; }
        public string desiredLockTerm { get; set; }
        public string desiredRate { get; set; }
        public bool isBrokerCompanyActive { get; set; }
        public bool isLoanLocked { get; set; }
        public bool isRequestLock { get; set; }
        public bool isInternalUser { get; set; }
        public string stateCode { get; set; }
        public int originationTYpeId { get; set; }
        public int loanDocumentationId { get; set; }
        public int lienPositionId { get; set; }
        public bool isLegacy { get; set; }
        public int interestOnlyOptionId { get; set; }
        public string firstTimeHomebuyer { get; set; }
        public int loanTypeId { get; set; }
    }
}