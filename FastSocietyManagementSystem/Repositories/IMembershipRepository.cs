using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles database operations related to society membership requests.
    /// </summary>
    public interface IMembershipRepository
    {
        /// <summary>
        /// Adds a new membership request for a student.
        /// </summary>
        void AddMembershipRequest(
            int studentId,
            int societyId
        );

        /// <summary>
        /// Retrieves all pending membership requests.
        /// </summary>
        List<MembershipRequest>
            GetPendingMembershipRequests();

        /// <summary>
        /// Checks whether the student has already applied
        /// for the selected society.
        /// </summary>
        bool IsMembershipRequestExists(
            int studentId,
            int societyId
        );

        /// <summary>
        /// Updates membership request status
        /// such as Approved or Rejected.
        /// </summary>
        void UpdateMembershipStatus(
            int requestId,
            string status
        );
    }
}