using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Id = 1;
            employee.Name = "Nikesh Kamble";
            employee.DOB = DateTime.Now.AddYears(-30);

            IClonable<Employee> empCloningObject = employee;
            Employee employeeCloned = empCloningObject.Clone();
            
            Console.ReadLine();
        }
    }
    
    #region Contract
    public interface IClonable<T>
    {
        T Clone();
    }
    #endregion

    #region ContractImplementation
    public class Employee : IClonable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Employee Clone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
    #endregion 
}
