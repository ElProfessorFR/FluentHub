namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of DeleteLinkedBranch
    /// </summary>
    public class DeleteLinkedBranchPayload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The issue the linked branch was unlinked from.
        /// </summary>
        public Issue Issue { get; set; }
    }
}