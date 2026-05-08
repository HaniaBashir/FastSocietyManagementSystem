using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Services
{
    public class MembershipService
    {
        private readonly IMembershipRepository
            _membershipRepository;

        public MembershipService()
        {
            _membershipRepository =
                new MembershipRepository();
        }

        public void ApplyForMembership(
            int studentId,
            int societyId
        )
        {
            _membershipRepository
                .AddMembershipRequest(
                    studentId,
                    societyId
                );
        }

        public List<MembershipRequest>
    GetPendingMembershipRequests()
        {
            return _membershipRepository
                .GetPendingMembershipRequests();
        }

        public void ApproveMembership(
            int requestId
        )
        {
            _membershipRepository
                .UpdateMembershipStatus(
                    requestId,
                    "Approved"
                );
        }

        public void RejectMembership(
            int requestId
        )
        {
            _membershipRepository
                .UpdateMembershipStatus(
                    requestId,
                    "Rejected"
                );
        }

        public bool IsMembershipRequestExists(int studentId, int societyId)
        {
            return _membershipRepository.IsMembershipRequestExists(studentId, societyId);
        }
    }
}
