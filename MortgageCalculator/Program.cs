using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.VisualBasic;

namespace MortgageCalculator;


public class Program
{
    public static void Main(string[] args)
    {
        bool shoulContinue = true;
        do
        {
            Console.WriteLine("Select the type of mortgage: ");
            Console.WriteLine("1) Fixed-rate mortgage");
            Console.WriteLine("2) Variable-rate mortgage");
            int input = Validation.GetValidInt("[enter 1 or 2]");
            int numOfTries = 0;
            // Create Morgage object
            if (input == 1)
            {
                FixedMortgage mortgage = new FixedMortgage();
                // Set the parameters
                mortgage.CurrentMarketValue = Validation.GetValidDouble("Please the current market value: ", 0.0, double.MaxValue);
                mortgage.DownPayment = Validation.GetValidDouble("Please enter the downpayment: ", 0.0, double.MaxValue);
                mortgage.InterestRate = Validation.GetValidDouble("Select the prevailing interest rate: [0.0 - 100]", 0.0, 100)/
                                    MortgageConstants.PERCENT;
                mortgage.LoanTerm = Validation.GetValidInt("Please enter a loan term: [15, 30]", 1, 30);
                mortgage.Principal = Validation.GetValidDouble("Please enter the price of the home: ", 0, double.MaxValue);
                mortgage.CompoundingFrequency = Validation.GetValidInt("Please enter the compounding frequency: ", 1, 12);
                mortgage.PaymentFrequency = Validation.GetValidInt("Please enter the payment frequency: ", 1, 12);
                mortgage.HomeInsurace = MortgageConstants.HOME_INSURANCE_PERCENTAGE * mortgage.Principal;
                mortgage.PropertyTax = MortgageConstants.PROPERTY_TAX_PERCENTAGE * mortgage.Principal;
                mortgage.DoesHOAApply = Validation.GetValidBool("Does HOA apply? Enter [y/n]: ");
                if (mortgage.DoesHOAApply)
                {
                    mortgage.DoesHOAApply = true;
                    mortgage.HomeAssociationLevy = Validation.GetValidDouble("Please enter the yearly HOA amount: ", 100, double.MaxValue);
                }
                else
                {
                    mortgage.DoesHOAApply = false;
                    mortgage.HomeAssociationLevy = 0.0;
                }
                double homeOriginatingFee = CalculateOriginationFee(mortgage.Principal, MortgageConstants.ORIGINATION_PERCENTAGE);
                /* Create buyer object */
                MortgageBuyer.Buyer buyer = new MortgageBuyer.Buyer();
                buyer.MonthlyIncome = Validation.GetValidDouble("Please enter your annual income: ", 1,  double.MaxValue)/MortgageConstants.PRO_RATE;
                double balance = CalculateLoanBalance(mortgage.Principal, mortgage.DownPayment, homeOriginatingFee, MortgageConstants.CLOSING_COST);
                double equityRatio = CalculateEquityRatio(balance, mortgage.CurrentMarketValue);
                if (equityRatio < MortgageConstants.EQUITY_THRESHOLD)
                {
                    mortgage.DoesLoanInsuranceApply = true;
                    mortgage.LoanInsurance = MortgageConstants.HOME_INSURANCE_PERCENTAGE * mortgage.Principal;
                }
                else
                {
                    mortgage.DoesLoanInsuranceApply = false;
                    mortgage.LoanInsurance = 0.0;
                }
                double payment = CalculatePayment(mortgage.Principal, mortgage.InterestRate, mortgage.PaymentFrequency, mortgage.LoanTerm, 
                            mortgage.HomeAssociationLevy, mortgage.LoanInsurance, mortgage.HomeInsurace, mortgage.PropertyTax);
                if ((payment/buyer.MonthlyIncome) <= 0.25)
                {
                    mortgage.ApprovalStatus = Enumerations.MortgageApproval.Approve;
                }
                else
                {
                    mortgage.ApprovalStatus = Enumerations.MortgageApproval.Deny;
                }
                Console.WriteLine($"Response to mortgage application: \n {mortgage.ToString()}");
                Console.WriteLine($"Response to mortgage application: \n {mortgage.ToPipeDelimitedString()}");
                if (mortgage.ApprovalStatus == Enumerations.MortgageApproval.Deny)
                {
                    Console.WriteLine("Consider increasing the downpayment or earn more income!");
                }
                shoulContinue = Validation.GetValidBool("Do you want to do another mortgage calculation?: [y/n]");
            }
            else
            {
                numOfTries += 1;
                Console.WriteLine("Please stay tuned for a varibale mortgage calculator!");
                shoulContinue = numOfTries < 3 && Validation.GetValidBool("Do you want to do another mortgage calculation?: [y/n]");
            }
        } while (shoulContinue);
    }

    public static double CalculateLoanBalance(double purchasePrice, double downPayment, double originationFee, double closingCost)
    {
        return purchasePrice - downPayment + originationFee + closingCost;
    }

    public static double CalculateLoanBalance(double purchasePrice, double downPayment, double originationFee, double closingCost, double equityTillDate)
    {
        return purchasePrice - (downPayment + equityTillDate) + originationFee + closingCost;
    }

    public static double CalculateOriginationFee(double purchasePrice, double originatingFeePercentage)
    {
        return originatingFeePercentage * purchasePrice;
    }
    public static double CalculatePayment(double principle, double interestRate, double paymentPerYear, int loanTerm, double hoaLevy, double homeLoanInsurance, double homeInsurance, double propertyTax)
    {
        return 
            ((principle * (interestRate/paymentPerYear) * (Math.Pow((1 + interestRate/paymentPerYear), paymentPerYear * loanTerm)))/
            ((Math.Pow((1 + interestRate/paymentPerYear), paymentPerYear * loanTerm)) - 1)) + (hoaLevy/MortgageConstants.PRO_RATE) + 
            (homeLoanInsurance/MortgageConstants.PRO_RATE) + (homeInsurance/MortgageConstants.PRO_RATE) + (propertyTax/MortgageConstants.PRO_RATE);
    }

    public static double CalculateEquityRatio(double loanBalance, double homeMaketValue)
    {
        return loanBalance/homeMaketValue;
    }
}
