namespace Codelux.NetCore.Utilities
{
    public interface IPasswordStrengthValidator
    {
        PasswordScore ValidateStrength(string password);
    }
}
