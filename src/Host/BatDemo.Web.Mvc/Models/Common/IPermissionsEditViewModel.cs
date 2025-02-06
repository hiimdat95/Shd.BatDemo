using System.Collections.Generic;
using BatDemo.Roles.Dto;

namespace BatDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}







