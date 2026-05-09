using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Services
{
    /// <summary>
    /// Handles business logic related to society memberships
    /// including applications, approvals, rejections,
    /// and duplicate membership prevention.
    /// </summary>
    public class MembershipService
    {
        private readonly IMembershipRepository
            _membershipRepository;

        public MembershipService()
        {
            _membershipRepository =
                new MembershipRepository();
        }

        /// <summary>
        /// Submits a membership request for a student
        /// to join a society.
        /// </summary>
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

        /// <summary>
        /// Retrieves all membership requests
        /// currently waiting for review.
        /// </summary>
        public List<MembershipRequest>
            GetPendingMembershipRequests()
        {
            return _membershipRepository
                .GetPendingMembershipRequests();
        }

        /// <summary>
        /// Approves a student's membership request.
        /// </summary>
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

        /// <summary>
        /// Rejects a student's membership request.
        /// </summary>
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

        /// <summary>
        /// Checks whether the student already has
        /// an existing membership request
        /// for the selected society.
        /// </summary>
        public bool IsMembershipRequestExists(
            int studentId,
            int societyId
        )
        {
            return _membershipRepository
                .IsMembershipRequestExists(
                    studentId,
                    societyId
                );
        }
    }
}