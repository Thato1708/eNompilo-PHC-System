using System.Text.RegularExpressions;

namespace eNompilo.v3._0._1.Constants
{
    public static class LinkConversions
    {
        public static string GetYoutubeVideoId(string url)
        {
            var videoId = string.Empty;
            var regex = new Regex(@"youtu(?:\.be\/|be\.com\/watch\?v=|\.com\/)([\w-]{11})", RegexOptions.IgnoreCase);
            var match = regex.Match(url);
            if (match.Success)
            {
                videoId = match.Groups[1].Value;
            }
            return videoId;
        }
    }
}
