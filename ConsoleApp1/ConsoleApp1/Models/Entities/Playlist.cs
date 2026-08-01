using System;

namespace PlaylistApp.Models.Entities
{
    public class Playlist
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; } = "";

        public string CreatorName { get; set; } = "";

        public List<VideoItem> Videos { get; set; } = new();
    }

    public class VideoItem
    {
        public string YouTubeUrl { get; set; } = "";

        public string TrackNote { get; set; } = "";
    }
}