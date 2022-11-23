using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxableIncome
{
    public class TaxCalculator
    {
        public decimal GetTaxableIncome(decimal grossIncome)
        {
            if (grossIncome <= 0)
            {
                throw new ArgumentException("Invalid gross income");
            }
            //calculate pension
            decimal pension = grossIncome * ((decimal)0.08);
            
            //get consolidated relief allowance
            decimal consRelief = (grossIncome - pension) * ((decimal)0.2); //20% less GI2
       
            if (grossIncome > 200000) consRelief += 200000;
            else consRelief +=  grossIncome * ((decimal)0.01);

           //calculate taxable income
            decimal taxableInc = grossIncome - consRelief - pension;
            
            return taxableInc;
        }

        public decimal GetPaye(decimal grossIncome, decimal minWage)
        {
            decimal paye = 0;
            if (grossIncome < minWage)
            {
                
                return 0;
            }
            else
            {
                // get taxable income
                decimal taxableInc = GetTaxableIncome(grossIncome);
                //first 300,000
                if (taxableInc >= 300000)
                {
                    paye += 21000;
                    taxableInc -= 300000;
                }
                else if (taxableInc > 0 && taxableInc < 300000)
                {
                    paye += taxableInc * ((decimal)0.07);
                    taxableInc -= taxableInc * ((decimal)0.07);
                    return paye;
                }
                //next 300,000
                if (taxableInc >= 300000) 
                {
                    taxableInc -= 300000;
                    paye += 33000;
                }
                else if (taxableInc > 0 && taxableInc < 300000)
                {
                    paye += taxableInc * ((decimal)0.11);
                    taxableInc -= taxableInc * ((decimal)0.11);
                    return paye;
                }
                //next 500,000
                if (taxableInc >= 500000)
                {
                    taxableInc -= 500000;
                    paye += 75000;
                }
                else if (taxableInc > 0 && taxableInc < 500000)
                {
                    paye += taxableInc * ((decimal)0.15);
                    taxableInc -= taxableInc * ((decimal)0.15);
                    return paye;
                }
                //next 500,000
                if (taxableInc >= 500000)
                {
                    taxableInc -= 500000;
                    paye += 95000;
                }
                else if (taxableInc > 0 && taxableInc < 500000)
                {
                    paye += taxableInc * ((decimal)0.19);
                    taxableInc -= taxableInc * ((decimal)0.19);
                    return paye;
                }
                //next 1,600,000
                if (taxableInc >= 1600000)
                {
                    taxableInc -= 1600000;
                    paye += 336000 ;
                }
                else if (taxableInc > 0  && taxableInc < 1600000)
                {
                    paye += taxableInc * ((decimal)0.21);
                    taxableInc -= taxableInc * ((decimal)0.21);
                    return paye;
                }
                //over 3,200,000
                else if (taxableInc > 0)
                {
                    paye += taxableInc * ((decimal)0.24);
                }
            }
            
            return paye ;
        }

        public string TaxCalc(decimal grossIncome, decimal minWage)
        {
            decimal taxableIncome = GetTaxableIncome(grossIncome);
            
            decimal paye = GetPaye(grossIncome, minWage);
            
            if (paye == 0) return $"PAYE: 0, gross Income is less than minimum wage\nTaxable income: {taxableIncome}";
           else return $"Taxable income:{taxableIncome}\nPAYE: {paye}";
        }
    }
}
