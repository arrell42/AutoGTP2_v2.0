using System.Collections.Generic;
using System;

namespace AutoGTP2Tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData() { }
        

        public string ProjectName { get; set; }
        public string Budget { get; set; }
        public string SubjectArea { get; set; }
        public string Vendor { get; set; }
        public string ResponsiblePM { get; set; }
        public string ClientRepresentative { get; set; }
        public string TotalAmount { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Time { get; set; }

        




        //вспомогательный метод для сортировки
        public int CompareTo(ProjectData other)
        {
            if(other == null)
            {
                return 1;
            }            
            return ProjectName.CompareTo(other.ProjectName);
        }

        //сравнение по наличию имени проекта
        public bool Equals(ProjectData other)
        {
            if(other is null)
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return ProjectName == other.ProjectName; 
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        //возвращаем строковое представление объектов типа projectdata
        public override string ToString()
        {
            return ProjectName;
        }
        
    }
}
