namespace NtierArch.DAL.Entity
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Area { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public String? CreatedBy { get; private set; }
        public String? UpdatedBy { get; private set; }
        public String? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public List<Employee> employees { get; private set; }
        protected Department() { }
        public Department(string name, string area, string createdBy)
        {
            Name = name;
            Area = area;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }
        public bool Update(string name, string area, string userModified)
        {
            if (!string.IsNullOrEmpty(userModified))
            {
                Name = name;
                Area = area;
                UpdatedBy = userModified;
                UpdatedOn = DateTime.Now;
                return true;
            }
            return false;
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
    }
}
