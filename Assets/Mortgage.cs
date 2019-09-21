using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Mortgage : MonoBehaviour
{
    public InputField PurchasePrice;
    public InputField Downpayment;
    public InputField InterestRate;
    public Dropdown AmortizationPeriod;
    public Dropdown PaymentFrequency;
    public Text Result;
    public Text SMortgage;
    public Text SInterestRate;
    public Text SLoan;
    public Text STotalPayment;
    public Text STotalInterest;
    public Text SAmortization;
    public Text SPaymentFrequency;
    public void MortgagePayment()
    {
        double principal = double.Parse(PurchasePrice.text) - double.Parse(Downpayment.text);

        double n = 0;
        double r = double.Parse(InterestRate.text) / 1200;


        //double n = double.Parse(Amortization.text) * 12;
        if (AmortizationPeriod.value == 0)
        {
            n = 15 * 12;
        }

        else if (AmortizationPeriod.value == 1)
        {
            n = 20 * 12;
        }

        else if (AmortizationPeriod.value == 2)
        {
            n = 25 * 12;
        }

        else if (AmortizationPeriod.value == 3)
        {
            n = 30 * 12;
        }
        double power = Math.Pow((1 + r), n);

        double m = (principal) * ((r * power) / (power - 1));
        m = Math.Round(m, 2);
        double TotalPay = m * n;

        if (PaymentFrequency.value == 0)
        {
            Result.text = m.ToString();
            //String.Format("{0:##-####-####}", 8958712551);
            Result.text = String.Format("{0:N}",m);
        }
        else if (PaymentFrequency.value == 1)
        {
            Result.text = String.Format("{0:N}", Math.Round((m / 2), 2));
           // Result.text = Math.Round((m / 2), 2).ToString();
        }
        else if (PaymentFrequency.value == 2)
        {
            // Result.text = Math.Round((m / 4), 2).ToString();
            Result.text = String.Format("{0:N}", Math.Round((m / 4), 2));
        }




        SInterestRate.text = InterestRate.text;

        SLoan.text = principal.ToString();
        SMortgage.text = m.ToString();
        STotalPayment.text = Math.Round(TotalPay, 2).ToString();
        STotalInterest.text = Math.Round((TotalPay - principal), 2).ToString();
        SAmortization.text = AmortizationPeriod.options[AmortizationPeriod.value].text;
        SPaymentFrequency.text = PaymentFrequency.options[PaymentFrequency.value].text;

}

    public void RefreshButton()
    {
        PurchasePrice.text = "---";
        Downpayment.text = "---";
        InterestRate.text = "---";
        PaymentFrequency.value = 0;
        AmortizationPeriod.value = 0;
        Result.text = "-----";
    }


    //double totalpayment = m * n;
    //Result.text = m.ToString();


    /* double principal = houseprice - downPayment;
            double r = interestRate / 1200;
            double n = termOfLoan * 12;
            double power = Math.Pow((1 + r), n);
            double m = (principal) * ((r * power) / (power - 1));
            double totalpayment = m * n;
            Console.WriteLine($"Your mountly mortgage is {Math.Round(m, 2)}.");
            Console.WriteLine($"Your total payment is {Math.Round(totalpayment,2)}");*/
}

