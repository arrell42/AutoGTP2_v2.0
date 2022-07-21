using System.Collections.Generic;
using System;

namespace AutoGTP2Tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData(string projectName)
        {
            ProjectName = projectName;            
        }

        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        


        //вспомогательный метод для сортировки
        public int CompareTo(ProjectData other)
        {
            if(other == null)
            {
                return 1;
            }
            if(ProjectName != other.ProjectName)
            {
                return 1;
            }
            return ProjectStatus.CompareTo(other.ProjectStatus);
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
