namespace NtierArch.DAL.Entity
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }
        public string? Image { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public String? CreatedBy { get; private set; }
        public String? UpdatedBy { get; private set; }
        public String? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }=false;
        [ForeignKey("Department")]
        public int DeptId { get; private set; }
        public Department Department { get; private set; }

        protected Employee() { }
        public Employee(string name, int age, decimal salary, String image, int deptId, string createdBy)
        {
            Name = name;
            Age = age;
            Salary = salary;
            CreatedBy = createdBy;
            CreatedOn=DateTime.Now;
            Image = image;
            DeptId = deptId;
        }
        public bool Update(string name, int age, decimal salary, int deptId, string userModified) {
            if (string.IsNullOrEmpty(userModified))
                return false;
            Name=name;
            Age = age;
            Salary = salary;
            UpdatedBy = userModified;
            UpdatedOn = DateTime.Now;
            DeptId = deptId;
            return true;
        }
        public bool ToggalStatus(string userDeleted)
        {
            if (!string.IsNullOrEmpty(userDeleted))
            {
                IsDeleted = !IsDeleted;
                DeletedBy = userDeleted;
                DeletedOn = DateTime.Now;
                return true;
            }
            return false;
        }
        public bool UpdateImage(string image, string UserModified)
        {
            if (!string.IsNullOrEmpty(UserModified))
            {
                Image = image;
                UpdatedBy = UserModified;
                return true;
            }
            return false;
        }
    }
}
