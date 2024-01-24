namespace MortgageCalculator;

public abstract class Mortgage : IMortgage
{
    public double CurrentMarketValue { get; set; } 
    public double DownPayment { get; set; }    
    public double InterestRate { get; set; }
    public double Principal { get; set; }
    public int LoanTerm { get; set; }
    public int CompoundingFrequency { get; set; }
    public int PaymentFrequency { get; set; }
    public Enumerations.MortgageApproval ApprovalStatus { get; set; }
    public double HomeInsurace { get; set; }
    public double PropertyTax { get; set; }
    public double HomeAssociationLevy { get; set; }
    public double LoanInsurance { get; set; }
    public bool DoesHOAApply { get; set; }
    public bool DoesLoanInsuranceApply { get; set; }

    public Mortgage()
    {
        //default constructor
    }

    public Mortgage(double currentMarketValue, double buyerDownPayment, double interestRate, double principal, int loanTerm, int compoundingFrequency, int paymentFrequency, Enumerations.MortgageApproval approvalStatus,
                double homeInsurace, double propertyTax, double homeAssociationLevy, double loanInsurance, bool doesHOAApply, bool doesLoanInsuranceApply)
    {
        DownPayment = buyerDownPayment;
        InterestRate = interestRate;
        Principal = principal;
        LoanTerm = loanTerm;
        CompoundingFrequency = compoundingFrequency;
        PaymentFrequency = paymentFrequency;
        ApprovalStatus = approvalStatus;
        HomeInsurace = homeInsurace;
        PropertyTax = propertyTax;
        DoesHOAApply = doesHOAApply;
        DoesLoanInsuranceApply = doesLoanInsuranceApply;
        HomeAssociationLevy = homeAssociationLevy;
        LoanInsurance = loanInsurance;
    }

    public override string ToString()
    {
        if ((DoesHOAApply = true) && (DoesLoanInsuranceApply = false))
        {
            return
                $"* Current Market Value: {CurrentMarketValue}\n" +
                $"* Buyer's Down Payment: {DownPayment}\n" + 
                $"* Interest Rate: {InterestRate}\n" +
                $"* Loan Principal: {Principal}\n" +
                $"* Loan Term: {LoanTerm}\n" +
                $"* Compounding Frequency: {CompoundingFrequency}\n" +
                $"* Payment Frequency: {PaymentFrequency}\n" +
                $"* Approval Status: {ApprovalStatus}\n" +
                $"* Home Insurace {HomeInsurace}\n" +
                $"* Property Tax: {PropertyTax}\n" +
                $"* Home Association Levy: {HomeAssociationLevy}";
        }
        else if ((DoesHOAApply = false) && (DoesLoanInsuranceApply = true))
        {
            return 
                $"* Current Market Value: {CurrentMarketValue}\n" +
                $"* Buyer's Down Payment: {DownPayment}\n" +
                $"* Interest Rate: {InterestRate}\n" +
                $"* Loan Principal: {Principal}\n" +
                $"* Loan Term: {LoanTerm}\n" +
                $"* Compounding Frequency: {CompoundingFrequency}\n" +
                $"* Payment Frequency: {PaymentFrequency}\n" +
                $"* Approval Status: {ApprovalStatus}\n" +
                $"* Home Insurace {HomeInsurace}\n" +
                $"* Property Tax: {PropertyTax}\n" +
                $"* Loan Insurance: {LoanInsurance}";
        }
        else if ((DoesHOAApply = false) && (DoesLoanInsuranceApply = false))
        {
            return
                $"* Current Market Value: {CurrentMarketValue}\n" +
                $"* Buyer's Down Payment: {DownPayment}\n" + 
                $"* Interest Rate: {InterestRate}\n" +
                $"* Loan Principal: {Principal}\n" +
                $"* Loan Term: {LoanTerm}\n" +
                $"* Compounding Frequency: {CompoundingFrequency}\n" +
                $"* Payment Frequency: {PaymentFrequency}\n" +
                $"* Approval Status: {ApprovalStatus}\n" +
                $"* Home Insurace {HomeInsurace}\n" +
                $"* Property Tax: {PropertyTax}";
        }
        else
        {
            return
                $"* Current Market Value: {CurrentMarketValue}\n" +
                $"* Buye's Down Payment: {DownPayment}\n" +
                $"* Interest Rate: {InterestRate}\n" +
                $"* Loan Principal: {Principal}\n" +
                $"* Loan Term: {LoanTerm}\n" +
                $"* Compounding Frequency: {CompoundingFrequency}\n" +
                $"* Payment Frequency: {PaymentFrequency}\n" +
                $"* Approval Status: {ApprovalStatus}\n" +
                $"* Home Insurace {HomeInsurace}\n" +
                $"* Property Tax: {PropertyTax}\n" +
                $"* Home Association Levy: {HomeAssociationLevy}\n" +
                $"* Loan Insurance: {LoanInsurance}";   
        }
    }

    public virtual string ToPipeDelimitedString()
    {
        if ((DoesHOAApply = true) && (DoesLoanInsuranceApply = false))
        {
            return
                $"Market Value: {CurrentMarketValue}|" +
                $"Buyer's Down Payment: {DownPayment}|" + 
                $"Interest Rate: {InterestRate}|" +
                $"Loan Principal: {Principal}|" +
                $"Loan Term: {LoanTerm}|" +
                $"Compounding Frequency: {CompoundingFrequency}|" +
                $"Payment Frequency: {PaymentFrequency}|" +
                $"Approval Status: {ApprovalStatus}|" +
                $"Home Insurace {HomeInsurace}|" +
                $"Property Tax: {PropertyTax}|" +
                $"Home Association Levy: {HomeAssociationLevy}";
        }
        else if ((DoesHOAApply = false) && (DoesLoanInsuranceApply = true))
        {
            return 
                $"Market Value: {CurrentMarketValue}|" +
                $"Buyer's Down Payment: {DownPayment}|" +
                $"Interest Rate: {InterestRate}|" +
                $"Loan Principal: {Principal}|" +
                $"Loan Term: {LoanTerm}|" +
                $"Compounding Frequency: {CompoundingFrequency}|" +
                $"Payment Frequency: {PaymentFrequency}|" +
                $"Approval Status: {ApprovalStatus}|" +
                $"Home Insurace {HomeInsurace}|" +
                $"Property Tax: {PropertyTax}|" +
                $"Loan Insurance: {LoanInsurance}";
        }
        else if ((DoesHOAApply = false) && (DoesLoanInsuranceApply = false))
        {
            return
                $"Market Value: {CurrentMarketValue}|" +
                $"Buyer's Down Payment: {DownPayment}|" + 
                $"Interest Rate: {InterestRate}|" +
                $"Loan Principal: {Principal}|" +
                $"Loan Term: {LoanTerm}|" +
                $"Compounding Frequency: {CompoundingFrequency}|" +
                $"Payment Frequency: {PaymentFrequency}|" +
                $"Approval Status: {ApprovalStatus}|" +
                $"Home Insurace {HomeInsurace}|" +
                $"Property Tax: {PropertyTax}";
        }
        else
        {
            return
                $"Market Value: {CurrentMarketValue}|" +
                $"Buyer's Down Payment: {DownPayment}|" +
                $"Interest Rate: {InterestRate}|" +
                $"Loan Principal: {Principal}|" +
                $"Loan Term: {LoanTerm}|" +
                $"Compounding Frequency: {CompoundingFrequency}|" +
                $"Payment Frequency: {PaymentFrequency}|" +
                $"Approval Status: {ApprovalStatus}|" +
                $"Home Insurace {HomeInsurace}|" +
                $"Property Tax: {PropertyTax}|" +
                $"Home Association Levy: {HomeAssociationLevy}|" +
                $"Loan Insurance: {LoanInsurance}";   
        }
    }
}