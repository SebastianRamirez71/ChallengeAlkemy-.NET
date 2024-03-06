using challange_disney.DTO.User;

namespace challange_disney.Services.Interfaces
{
    public interface IAuthService
    {
        string Register(UserRegisterDTO User);
        string Login(UserInfo User);
    }
}
