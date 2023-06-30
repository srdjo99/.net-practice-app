using FluentNHibernate.Mapping;

namespace TestFluent.Models
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Employee");
        }
    }
}