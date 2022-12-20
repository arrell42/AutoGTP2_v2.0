using System;
using System.Collections.Generic;

namespace AutoGTP2Tests
{
    public class BudgetColumnsData : IEquatable<BudgetColumnsData>, IComparable<BudgetColumnsData>
    {
        public BudgetColumnsData()
        {                 
        }

        //вспомогательный метод для сортировки
        public int CompareTo(BudgetColumnsData other)
        {
            if (other == null)
            {
                return 1;
            }
            return ColumnName.CompareTo(other.ColumnName);
        }


        //сравнение по наличию имени
        public bool Equals(BudgetColumnsData other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return 
                ColumnName == other.ColumnName &&
                ColumnRemaining == other.ColumnRemaining &&
                ColumnPO == other.ColumnPO &&
                ColumnProjects == other.ColumnProjects &&
                ColumnTotal == other.ColumnTotal &&
                ColumnDate == other.ColumnDate;
        }

        //возвращаем строковое представление объектов типа BudgetColumnsData
        public override string ToString()
        {
            return ColumnName + ColumnRemaining + ColumnPO + ColumnProjects  + ColumnTotal  + ColumnDate;
        }
        

        public string ColumnName { get; set; }
        public string ColumnRemaining { get; set; }
        public string ColumnPO { get; set; }
        public string ColumnProjects { get; set; }
        public string ColumnTotal { get; set; }
        public string ColumnDate { get; set; }
    }
}
