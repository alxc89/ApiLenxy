using SecureIdentity.Password;

namespace ApiLenxy.Domain.Entites;
public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public int IdCompany { get; private set; }

    // Construtor para criação de novos usuários
    public User(string name, string email, string password, int idCompany)
    {
        // Lógica de validação para as propriedades obrigatórias
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome não pode ser vazio ou nulo.", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O e-mail não pode ser vazio ou nulo.", nameof(email));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("A senha não pode ser vazia ou nula.", nameof(password));
        if (idCompany <= 0 || string.IsNullOrEmpty(idCompany.ToString()))
            throw new ArgumentException("O id da empresa não pode ser vazia ou nula.", nameof(idCompany));

        Name = name;
        Email = email;
        SetPassword(password);
        IdCompany = idCompany;
    }

    // Método para alterar o nome do usuário
    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("O novo nome não pode ser vazio ou nulo.", nameof(newName));

        Name = newName;
    }

    // Método para alterar o e-mail do usuário
    public void ChangeEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
            throw new ArgumentException("O novo e-mail não pode ser vazio ou nulo.", nameof(newEmail));

        Email = newEmail;
    }

    // Método para alterar a senha do usuário
    public void ChangePassword(string currentPassword, string newPassword)
    {
        if (!VerifyPassword(currentPassword))
            throw new ArgumentException("A senha atual está incorreta.", nameof(currentPassword));

        SetPassword(newPassword);
    }

    // Método para verificar a senha atual
    public bool VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(PasswordHash))
            throw new ArgumentException("A senha atual está incorreta", nameof(password));
        return PasswordHasher.Verify(PasswordHash, password);
    }

    // Método privado para definir a senha e calcular o hash
    private void SetPassword(string password)
    {
        PasswordHash = PasswordHasher.Hash(password);
    }
}