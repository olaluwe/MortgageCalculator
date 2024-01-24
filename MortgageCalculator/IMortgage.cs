namespace MortgageCalculator;

public interface IMortgage
{
  double CurrentMarketValue { get; set; }
  double DownPayment { get; set; }
  double InterestRate { get; set; }
  double Principal { get; set; }
  int LoanTerm { get; set; }
  int CompoundingFrequency { get; set; }
  int PaymentFrequency { get; set; }
  Enumerations.MortgageApproval ApprovalStatus { get; set; }
  double HomeAssociationLevy { get; set; }
  bool DoesHOAApply { get; set; }
  double LoanInsurance { get; set; }
  bool DoesLoanInsuranceApply { get; set; }
  string ToPipeDelimitedString();
}