using System.Linq;
using ui.ViewModels;

namespace ui.Contracts
{
    public interface IUserServices
    {
        bool ValidatePassword(LoginViewModelForPostDto user);
        IQueryable<LoginViewModelForPostDto> Queryable();
    }
}