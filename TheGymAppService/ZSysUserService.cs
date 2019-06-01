using System;
using System.Threading.Tasks;
using TheGymApp.Data;
using TheGymApp.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace TheGymApp.Service
{
    public class ZSysUserService : IZsysUserService
    {
        private readonly IZSysUserRepository _zsysUserRepository;
       

        public ZSysUserService(IZSysUserRepository zsysUserRepository)
        {
            _zsysUserRepository = zsysUserRepository;
            
        }

        public void CreateNewMember(ZSysUserDTO Member)
        {
            int membershipId = Convert.ToInt32(Member.membership);

            var userMembershipId= _zsysUserRepository.CreateNewMember(new ZSysUser {
                FirstName = Member.firstName,LastName = Member.lastName, AddressLine1=Member.address1,AddressLine2 = Member.address2,
                DOB= Member.DOB, Email=Member.email, Notes=Member.notes, UserName=Member.UserName});
            var membershipDetails =   GetAllMembershipDetails().FirstOrDefault(t=> t.Id == membershipId).Result ;
            var membershipFees = membershipDetails.MembershipFee + Convert.ToInt32(membershipDetails.MembershipPrice);

            var userMembershipStatus = _zsysUserRepository.CreateNewUserMembershipDetails(new UserMembership
            {
                Discount_InPerc = Convert.ToInt32(Member.discount),
                MembershipStartDate = DateTime.Now,
                MembershipEndDate = DateTime.Now.AddMonths(membershipDetails.MembershipMonths),
                MembershipFee = membershipFees,
                MembershipId = membershipId,
                UserMembershipId = userMembershipId
            });
            //return await _zsysUserRepository.CreateNewMember(model);

        }

        public  IAsyncEnumerable<Membership> GetAllMembershipDetails()
        {
               return _zsysUserRepository.GetAllMembership();
        }

        public async Task<ZSysUserDTO> GetMemberDetails(int MemberId)
        {
            var memberDetails =  await _zsysUserRepository.GetMember(MemberId);
            
              return new ZSysUserDTO
              {
                  address1 = memberDetails.AddressLine1,
                  address2 = memberDetails.AddressLine2,
                  DOB = memberDetails.DOB,
                  email = memberDetails.Email,
                  firstName = memberDetails.FirstName,
                  lastName = memberDetails.LastName,
                  Id = memberDetails.Id,
                  notes = memberDetails.Notes
              };
            
        }

    }
}
