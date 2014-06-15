using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5Project1
{
    class DinnerParty
    {
        int NumberOfPeople = 0;
        decimal CostOfBeveragesPerPerson = 0;
        decimal CostOfDecorations = 0;
        bool isHealthyOption = false;
        bool isFancyDecorations = false;

        public void SetHealthyOption(bool isHealthy)
        {
            isHealthyOption = isHealthy;
            CostOfBeveragesPerPerson = isHealthy ? 5 : 20;
        }

        public void CalculateCostOfDecorations()
        {
            if (isFancyDecorations)
            {
                CostOfDecorations = 15 * NumberOfPeople + 50;
            }
            else
            {
                CostOfDecorations = 7.50M * NumberOfPeople + 30;
            }
        }

        public decimal CalculateCost()
        {
            decimal totalCost = 0;
            totalCost += 25 * NumberOfPeople;
            totalCost += CostOfBeveragesPerPerson * NumberOfPeople;
            totalCost += CostOfDecorations;
            if (isHealthyOption)
            {
                totalCost *= 0.95M;
            }
            return totalCost;
        }
    }
}
