using MudBlazor;

namespace NightlifeCoordinationSPA.Helpers.InputPasswordManager;

public class InputPasswordManager
{
    public bool IsShowPassword { get; set; }
    public InputType PasswordInput = InputType.Password;
    public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

    public void HandleShowPassword()
    {
        if (IsShowPassword)
        {
            IsShowPassword = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }
        else
        {
            IsShowPassword = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
}