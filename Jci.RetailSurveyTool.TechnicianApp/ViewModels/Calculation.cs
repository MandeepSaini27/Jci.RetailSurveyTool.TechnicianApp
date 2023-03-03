using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class Calculation
    {
        
        public Calculation()
        {

        }

        public int AddMethod(int firstNumber, int secondNumber)
        {
            int thirdNumber = firstNumber + secondNumber;

            return thirdNumber;
        }

        public int MultiplyMethod(int firstNumber, int secondNumber)
        {
            int thirdNumber = firstNumber * secondNumber;

            return thirdNumber;
        }

    }
}
