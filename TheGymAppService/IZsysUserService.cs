using System;
using System.Collections.Generic;
using System.Text;
using TheGymApp.Service.Models;
using System.Threading.Tasks;

namespace TheGymApp.Service
{
    public interface IZsysUserService
    {
        Task<ZSysUserDTO> GetMemberDetails(int MemberId);
        void CreateNewMember(ZSysUserDTO member);
        
     }
}
