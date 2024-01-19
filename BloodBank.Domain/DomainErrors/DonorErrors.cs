namespace BloodBank.Domain.DomainErrors;

public record DonorErrors(string Code, string Message) : IError
{
    public static readonly Error NotFound =
        new("Donor.NotFound", "An active donor could not be found");

    public static readonly Error CannotBeCreated =
        new("Donor.CannotBeCreated", "Something went wrong and the donor cannot be created");

    public static readonly Error CannotBeUpdated =
        new("Donor.CannotBeUpdated", "Something went wrong and the donor cannot be updated");

    public static readonly Error CantDonate =
        new("Donor.CantDonate", "Donor can't donate");

    public static readonly Error IsMinor =
        new("Donor.IsMinor", "Donor is minor and can't donate");

    public static readonly Error DonatedRecently =
        new("Donor.DonatedRecently", "Donor recently donated and must wait for recover time");
}