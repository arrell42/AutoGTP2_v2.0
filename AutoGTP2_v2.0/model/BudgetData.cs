using System;

namespace AutoGTP2Tests
{
    public class BudgetData : IEquatable<BudgetData>, IComparable<BudgetData>
    {
        public BudgetData(string budgetCost, string budgetPO)
        {
            BudgetCost = budgetCost;
            BudgetPO = budgetPO;            
        }

        //вспомогательный метод для сортировки
        public int CompareTo(BudgetData other)
        {
            if (other == null)
            {
                return 1;
            }
            if(BudgetCost == other.BudgetCost)
            {
                return 0;
            }
            return BudgetPO.CompareTo(other.BudgetPO);
        }

        //сравнение по наличию имени проекта
        public bool Equals(BudgetData other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return BudgetCost == other.BudgetCost;
        }

        public override int GetHashCode()
        {
            return BudgetCost.GetHashCode();
        }

        //возвращаем строковое представление объектов типа projectdata
        public override string ToString()
        {
            return "cost= " + BudgetCost; 
        }



        public string BudgetPO { get; set; }
        public string BudgetTotal { get; set; }
        public string BudgetCost { get; set; }
        

    }
}

