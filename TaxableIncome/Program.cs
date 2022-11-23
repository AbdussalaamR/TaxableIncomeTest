// See https://aka.ms/new-console-template for more information
using TaxableIncome;
TaxCalculator myTaxCalculator = new TaxCalculator();
var d = myTaxCalculator.TaxCalc(200000, 360000);
Console.WriteLine(d);   

