namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of AddPullRequestReviewComment
    /// </summary>
    public class AddPullRequestReviewCommentInput
    {
        /// <summary>
        /// The node ID of the pull request reviewing
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `pullRequestId` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public ID? PullRequestId { get; set; }

        /// <summary>
        /// The Node ID of the review to modify.
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `pullRequestReviewId` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public ID? PullRequestReviewId { get; set; }

        /// <summary>
        /// The SHA of the commit to comment on.
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `commitOID` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public string CommitOID { get; set; }

        /// <summary>
        /// The text of the comment. This field is required
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `body` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The relative path of the file to comment on.
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `path` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The line index in the diff to comment on.
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `position` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// The comment id to reply to.
        /// **Upcoming Change on 2023-10-01 UTC**
        /// **Description:** `inReplyTo` will be removed. use addPullRequestReviewThread or addPullRequestReviewThreadReply instead
        /// **Reason:** We are deprecating the addPullRequestReviewComment mutation
        /// </summary>
        public ID? InReplyTo { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}