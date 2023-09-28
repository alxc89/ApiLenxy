namespace ApiLenxy.Application.DTOs.Phone;

public class PhoneDTO
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }

    public static List<PhoneDTO> ToPhoneDTO(IEnumerable<Domain.Entites.Phone> phones)
    {
        var phoneDTOs = new List<PhoneDTO>();

        foreach (var phone in phones)
        {
            phoneDTOs.Add(new PhoneDTO { Id = phone.Id, PhoneNumber = phone.PhoneNumber });
        }

        return phoneDTOs;
    }
}
