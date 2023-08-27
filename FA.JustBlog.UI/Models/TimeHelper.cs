using FA.JustBlog.Core.Models;

namespace FA.JustBlog.UI.Models
{
    public static class TimeHelper
    {
        public static string GetTimePostAgo(Post post)
        {
            TimeSpan timeSincePost = DateTime.Now - post.PostedOn;

            string timeAgo = string.Empty;

            if (timeSincePost.TotalMinutes < 1)
            {
                timeAgo = "Just now";
            }
            else if (timeSincePost.TotalHours < 1)
            {
                int minutesAgo = (int)timeSincePost.TotalMinutes;
                timeAgo = $"{minutesAgo} {(minutesAgo == 1 ? "minute" : "minutes")} ago";
            }
            else if (timeSincePost.TotalDays < 1)
            {
                int hoursAgo = (int)timeSincePost.TotalHours;
                timeAgo = $"{hoursAgo} {(hoursAgo == 1 ? "hour" : "hours")} ago";
            }
            else if (timeSincePost.TotalDays < 2)
            {
                timeAgo = "Yesterday";

                return $"Posted {(string.IsNullOrEmpty(timeAgo) ? string.Empty : " " + timeAgo)} at {post.PostedOn.ToString("h:mm tt")} with Rate {post.RateCount.ToString("0.0")} by {post.ViewCount} view(s)";
            }
            else
            {
                int daysAgo = (int)timeSincePost.TotalDays;
                timeAgo = $"{daysAgo} {(daysAgo == 1 ? "day" : "days")} ago";

                return $"Posted {(string.IsNullOrEmpty(timeAgo) ? string.Empty : " " + timeAgo)} at {post.PostedOn.ToString("h:mm tt")} with Rate {post.RateCount.ToString("0.0")} by {post.ViewCount} view(s)";

            }

            return $"Posted {(string.IsNullOrEmpty(timeAgo) ? string.Empty : " " + timeAgo)} with Rate {post.RateCount.ToString("0.0")} by {post.ViewCount} view(s)";
        }

        public static string GetTimeCommentAgo(DateTime commentTime)
        {
            TimeSpan timeSinceComment = DateTime.Now - commentTime;

            if (timeSinceComment.TotalMinutes < 1)
            {
                return "Just now";
            }
            else if (timeSinceComment.TotalHours < 1)
            {
                int minutesAgo = (int)timeSinceComment.TotalMinutes;
                return $"{minutesAgo} {(minutesAgo == 1 ? "minute" : "minutes")} ago";
            }
            else if (timeSinceComment.TotalDays < 1)
            {
                int hoursAgo = (int)timeSinceComment.TotalHours;
                return $"{hoursAgo} {(hoursAgo == 1 ? "hour" : "hours")} ago";
            }
            else if (timeSinceComment.TotalDays < 2)
            {
                return "Yesterday";
            }
            else
            {
                return $"{commentTime}";
            }
        }
    }
}
