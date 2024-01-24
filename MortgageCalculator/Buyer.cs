namespace MortgageBuyer;

public class Buyer 
{
  public double MonthlyIncome { get; set; }

  public Buyer()
  {
    //Default constructor
  }

  public Buyer(double monthlyIncome)
  {
    MonthlyIncome = monthlyIncome;
  }
}