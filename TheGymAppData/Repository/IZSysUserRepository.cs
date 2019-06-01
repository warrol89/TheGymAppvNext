using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheGymApp.Data
{
    public interface IZSysUserRepository
    {
        Task<ZSysUser> GetMember(int Id);
        Task<IList<ZSysUser>> GetAllMembers();
        int CreateNewMember(ZSysUser member);
        bool CreateNewUserMembershipDetails(UserMembership memberDetails);
        Task<bool> DeleteMember(int Id);
        IAsyncEnumerable<Membership> GetAllMembership();
    }
}
