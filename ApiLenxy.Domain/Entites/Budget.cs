namespace ApiLenxy.Domain.Entites;

public class Budget : Entity
{
    public Budget(Customer customer, int typeOfPhotoShoot, string products, double totalBudgetAmount, DateTime dateHourService, string comment, string origin, string serviceLocation)
    {
        Customer = customer;
        TypeOfPhotoShoot = typeOfPhotoShoot;
        Products = products;
        TotalBudgetAmount = totalBudgetAmount;
        DateHourService = dateHourService;
        Comment = comment;
        Origin = origin;
        ServiceLocation = serviceLocation;
    }

    public Customer Customer { get; private set; }
    public int TypeOfPhotoShoot { get; private set; }
    public string Products { get; private set; }
    public double TotalBudgetAmount { get; private set; }
    public DateTime DateHourService { get; private set; }
    public string Comment { get; private set; }
    public string Origin { get; private set; }
    public string ServiceLocation { get; private set; }
}
