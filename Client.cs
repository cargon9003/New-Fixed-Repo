namespace LifeInsuranceCode
{
    public class Client : IClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PolicyType { get; set; }
        public double PremiumAmount { get; set; }
        public DateTime PolicyStartDate { get; set; }

        public Client(int id, string firstName, string lastName, DateTime dateOfBirth, string policyType, double premiumAmount, DateTime policyStartDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            PolicyStartDate = policyStartDate;
        }
    }
}
