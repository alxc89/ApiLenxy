namespace ApiLenxy.Application.DTOs.Phone;

public class PhoneDTO
{
    public string PhoneNumber { get; set; }

    public static List<PhoneDTO> ToPhoneDTO(IEnumerable<Domain.Entites.Phone> phones)
    {
        var phoneDTOs = new List<PhoneDTO>();

        foreach (var phone in phones)
        {
            phoneDTOs.Add(new PhoneDTO { PhoneNumber = phone.PhoneNumber });
        }

        return phoneDTOs;
    }
}
