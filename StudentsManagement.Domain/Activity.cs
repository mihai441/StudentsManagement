namespace StudentsManagement.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }

        public int TeacherId{ get; set; }
        public virtual Teacher Owner { get; set; }
    }
}
