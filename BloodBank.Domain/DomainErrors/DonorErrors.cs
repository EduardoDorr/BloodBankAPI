namespace BloodBank.Domain.DomainErrors;

public record DonorErrors(string Code, string Message) : IError
{
    public static readonly Error CantDonate =
        new("Donation.CantDonate", "Donor can't donate");

    public static readonly Error IsMinor =
        new("Donation.IsMinor", "Donor is minor and can't donate");

    public static readonly Error DonatedRecently =
        new("Donation.DonatedRecently", "Donor recently donated and must wait for recover time");
}