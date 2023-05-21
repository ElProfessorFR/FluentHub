namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of CopyProjectV2
    /// </summary>
    public class CopyProjectV2Payload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The copied project.
        /// </summary>
        public ProjectV2 ProjectV2 { get; set; }
    }
}