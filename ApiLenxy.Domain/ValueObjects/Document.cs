using Api_Lenxy.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Domain.ValueObjects;

[Owned]
public class Document
{
    public Document(string number, string type)
    {
        Number = number;
        Type = type == "CPF" ? EDocumentType.CPF : EDocumentType.CNPJ;
    }

    public Document()
    {
        
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    private bool Validate()
    {
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;
        if(Type == EDocumentType.CPF && Number.Length == 11)
            return true;
        return false;
    }
}
