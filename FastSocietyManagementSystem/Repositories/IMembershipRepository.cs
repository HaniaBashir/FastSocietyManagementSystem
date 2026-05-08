using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    public interface IMembershipRepository
    {
        void AddMembershipRequest(
            int studentId,
            int societyId
        );

        List<MembershipRequest>
            GetPendingMembershipRequests();

        bool IsMembershipRequestExists(int studentId, int societyId);

        void UpdateMembershipStatus(
            int requestId,
            string status
        );
    }
}
