namespace LifeInsuranceCode
{
    public interface IClient
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string PolicyType { get; set; }
        double PremiumAmount { get; set; }
        DateTime PolicyStartDate { get; set; }
    }
}
