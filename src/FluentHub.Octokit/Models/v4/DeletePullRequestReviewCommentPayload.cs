namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of DeletePullRequestReviewComment
    /// </summary>
    public class DeletePullRequestReviewCommentPayload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The pull request review the deleted comment belonged to.
        /// </summary>
        public PullRequestReview PullRequestReview { get; set; }

        /// <summary>
        /// The deleted pull request review comment.
        /// </summary>
        public PullRequestReviewComment PullRequestReviewComment { get; set; }
    }
}