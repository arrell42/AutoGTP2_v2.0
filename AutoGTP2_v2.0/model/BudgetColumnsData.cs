using System;

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
            return ColumnName == other.ColumnName;
        }

        //возвращаем строковое представление объектов типа BudgetColumnsData
        public override string ToString()
        {
            return "colName= " + ColumnName;
        }

        public string ColumnName { get; set; }
        public string ColumnRemaining { get; set; }
        public string ColumnPO { get; set; }
        public string ColumnProjects { get; set; }
        public string ColumnTotal { get; set; }
        public string ColumnDate { get; set; }


    }
}
