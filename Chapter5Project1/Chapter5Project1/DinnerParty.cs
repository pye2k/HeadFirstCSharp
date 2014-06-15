using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5Project1
{
    class DinnerParty
    {
        const int CostOfFoodPerPerson = 25;

        int NumberOfPeople = 0;
        decimal CostOfBeveragesPerPerson = 0;
        bool isHealthyOption = false;
        bool isFancyOption = false;

        public DinnerParty()
        {
            SetHealthyOption(isHealthyOption);
            SetFancyDecorations(isFancyOption);
        }

        public void SetNumberOfPeople(int num)
        {
            NumberOfPeople = num;
        }
        
        public void SetHealthyOption(bool isHealthy)
        {
            isHealthyOption = isHealthy;
            CostOfBeveragesPerPerson = isHealthy ? 5 : 20;
        }

        public void SetFancyDecorations(bool isFancy)
        {
            isFancyOption = isFancy;
        }

        public decimal CalculateCost()
        {
            decimal totalCost = 0;
            totalCost += CostOfFoodPerPerson * NumberOfPeople;
            totalCost += CostOfBeveragesPerPerson * NumberOfPeople;
            if (isFancyOption)
            {
                totalCost += 15 * NumberOfPeople + 50;
            }
            else
            {
                totalCost += 7.50M * NumberOfPeople + 30;
            }
            
            if (isHealthyOption)
            {
                totalCost *= 0.95M;
            }
            return totalCost;
        }
    }
}
