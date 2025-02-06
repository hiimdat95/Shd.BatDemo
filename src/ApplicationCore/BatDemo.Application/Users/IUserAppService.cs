using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BatDemo.Authorization.Users;
using BatDemo.Roles.Dto;
using BatDemo.Users.Dto;

namespace BatDemo.Users
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeActivate(EntityDto<long> user);
        /// <summary>
        /// Activates a user account.
        /// </summary>
        /// <param name="user">The user to activate.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Activate(EntityDto<long> user);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<RoleDto>> GetRoles();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ChangeLanguage(ChangeUserLanguageDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> ChangePassword(ChangePasswordDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto> GetUserDto(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<UserDto> GetUserDto(string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> UpdateFromCreateDto(CreateUserDto input, long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> UpdateRoleForUser(UserDto input);
    }
}








