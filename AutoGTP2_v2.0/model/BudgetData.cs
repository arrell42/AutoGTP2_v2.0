
namespace AutoGTP2Tests
{
    public class BudgetData
    {
        public BudgetData(string budgetPO, string budgetCost)
        {
            BudgetPO = budgetPO;
            BudgetCost = budgetCost;
        }

        public string BudgetPO { get; set; }
        public string BudgetTotal { get; set; }
        public string BudgetCost { get; set; }
        

    }
}

