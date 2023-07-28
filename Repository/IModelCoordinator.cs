namespace _3DModels.Repository
{
    public interface IModelCoordinator
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Role { get; set; }
        string Responsibilities { get; set; }
        int? ExperienceYears { get; set; }
        DateTime? JoinDate { get; set; }
        decimal? Salary { get; set; }
    }
}
