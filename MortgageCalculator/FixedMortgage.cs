namespace MortgageCalculator;

public class FixedMortgage : Mortgage
{
  // public int NumberOfYearlyPayment { get; set; }


  public FixedMortgage()
  {
    //default constructor
  }

  public FixedMortgage(double currentMarketValue, double buyerDownPayment, double interestRate, double principal, int loanTerm, int compoundingFrequency, int paymentFrequency, Enumerations.MortgageApproval approvalStatus,
                  double homeInsurace, double propertyTax, double homeAssociationLevy, double loanInsurance, bool doesHOAApply, bool doesLoanInsuranceApply,
                  int numberOfYearlyPayment) : base(currentMarketValue, buyerDownPayment, interestRate, principal, loanTerm, compoundingFrequency, paymentFrequency, approvalStatus, homeInsurace, propertyTax,
                  homeAssociationLevy, loanInsurance, doesHOAApply, doesLoanInsuranceApply)
  {
    // NumberOfYearlyPayment = numberOfYearlyPayment;
  }

  public string ToStringFormatted()
  {
    string output = string.Empty;

    // Local function to pad a string with spaces to make it 80 characters long
    static string PaddedString(string nextField) => $"{nextField}{"*".PadLeft(80 - nextField.Length, ' ')}\n";

    //uses the local function to do everything that 26-29 is doing in one line of code:
    output += PaddedString($"* Interest Rate: {InterestRate}");

    //these are the breakdowns of what the local function is doing:
    string nextField = $"* Interest Rate: {InterestRate}";
    int outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"* Principal: {Principal}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    output += PaddedString($"* Principal: {Principal}");

    nextField = $"Loan Term: {LoanTerm}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Down Payment: {DownPayment}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Market Value: {CurrentMarketValue}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Compounding Frequency: {CompoundingFrequency}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;


    nextField = $"Payment Frequency: {PaymentFrequency}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Approval Status: {ApprovalStatus}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Home Insurace: {HomeInsurace}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    nextField = $"Property Tax: {PropertyTax}";
    outputLength = GetPadStringLength(nextField);
    nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
    output += nextField;

    if (DoesLoanInsuranceApply)
    {
      nextField = $"Loan Insurance: {LoanInsurance}";
      outputLength = GetPadStringLength(nextField);
      nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
      output += nextField;
    }

    if (DoesHOAApply)
    {
      nextField = $"Home Association Levy: {HomeAssociationLevy}";
      outputLength = GetPadStringLength(nextField);
      nextField += $"{"*".PadLeft(outputLength, ' ')}\n";
      output += nextField;
    }

    return output;
  }

  private int GetPadStringLength(string s)
  {
    return 80 - s.Length;
  }

  public override string ToString()
  {
    return $"{base.ToString()}";
  }

  public override string ToPipeDelimitedString()
  {
    return $"{base.ToPipeDelimitedString()}";
  }
}