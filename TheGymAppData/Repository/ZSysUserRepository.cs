using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheGymApp.Data
{
    public class ZSysUserRepository:IZSysUserRepository
    {
        private readonly GymAppContext _context;
        public ZSysUserRepository(GymAppContext context)
        {
            _context = context;
        }

        public async Task<ZSysUser> GetMember(int Id)
        {
            return await _context.Zsysuser.Where(t => t.Id == Id).FirstOrDefaultAsync();

        }

        public async Task<IList<ZSysUser>> GetAllMembers()
        {
            return await _context.Zsysuser.ToListAsync();
        }

        public  int CreateNewMember(ZSysUser member)
        {
            _context.Zsysuser.Add(member);
              _context.SaveChanges() ;
            return member.Id;

            
        }

        public bool CreateNewUserMembershipDetails(UserMembership memberDetails)
        {
            _context.UserMemberships.Add(memberDetails);
            return  _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteMember(int Id)
        {
            var entity = await GetMember(Id);
            _context.Zsysuser.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public IAsyncEnumerable<Membership> GetAllMembership()
        {
             return _context.Memberships.ToAsyncEnumerable();
        }

    }
}
