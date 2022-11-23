using TaxableIncome;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Get_Taxable_Income_Test()
        {
            // Arrange
            decimal grossInc = 4000000;
            TaxCalculator myTaxCalculator = new TaxCalculator();

            // Act
            decimal taxableInc = myTaxCalculator.GetTaxableIncome(grossInc);
            //Assert
            var expectedResult = 2744000;
            Assert.Equal(expectedResult, taxableInc);
        }
        [Fact]
        public void lesThan_Or_Equal_Zero_Taxable_Income_Test()
        {
            // Arrange
            decimal grossInc = -40;
            TaxCalculator myTaxCalculator = new TaxCalculator();
            // Act & Assert
            Assert.Throws<ArgumentException>(()=>myTaxCalculator.GetTaxableIncome(grossInc)); 
           
        }


        [Fact]
        public void Get_Paye_lessMinWage_Test()
        {
            // Arrange
            decimal grossInc = 200000;
            decimal minWage = 360000;
            TaxCalculator myTaxCalculator = new TaxCalculator();
            // Act
            decimal paye = myTaxCalculator.GetPaye(grossInc, minWage);
            //Assert
            var expectedResult = 0;
            Assert.Equal(expectedResult, paye);
            
        }

        [Fact]
        public void Get_Paye_NotLessMinWage_Test()
        {
            // Arrange
            decimal grossInc = 4000000;
            decimal minWage = 360000;
            // Act
            TaxCalculator myTaxCalculator = new TaxCalculator();
            decimal paye = myTaxCalculator.GetPaye(grossInc, minWage);
            //Assert
            var expectedResult = 464240;
            Assert.Equal(expectedResult, paye);
             
        }

        [Fact]
        public void Get_TaxableInc_and_Paye_Test()
        {
            // Arrange
            decimal grossInc = 4000000;
            decimal minWage = 360000;
            TaxCalculator myTaxCalculator = new TaxCalculator();
            // Act
            var actualOutput = myTaxCalculator.TaxCalc(grossInc, minWage);
            //Assert
            var expectedOutput = "Taxable income:2744000.000\nPAYE: 464240.00000";
            Assert.Equal(expectedOutput, actualOutput);

        }
        [Fact]
        public void Get_TaxableInc_and_Paye_Income_Less_MinWageTest()
        {
            // Arrange
            decimal grossInc = 20000;
            decimal minWage = 360000;
            TaxCalculator myTaxCalculator = new TaxCalculator();
            // Act
            var actualOutput = myTaxCalculator.TaxCalc(grossInc, minWage);
            //Assert
            var expectedOutput = "PAYE: 0, gross Income is less than minimum wage\nTaxable income: 14520.000";
            Assert.Equal(expectedOutput, actualOutput);

        }

    }
} 