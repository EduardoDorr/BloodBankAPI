namespace BloodBank.Domain.DomainErrors;

public record DonationErrors(string Code, string Message) : IError
{
    public static readonly Error NotFound =
        new("Donation.NotFound", "Donation could not be found");

    public static readonly Error CannotBeCreated =
        new("Donation.CannotBeCreated", "Something went wrong and the donation cannot be created");

    public static readonly Error CannotBeUpdated =
        new("Donation.CannotBeUpdated", "Something went wrong and the donation cannot be updated");

    public static readonly Error InvalidAmountOfBlood =
        new("Donation.InvalidAmountOfBlood", "The amount of blood is out range");
}