using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Models.Music
{
    /// <summary>
    /// Basic Implementation of Song Metadata
    /// </summary>
    public class Song
    {
        public string Title { get; set; }
        /// <summary>
        /// Could be Video Id in Case of Youtube or Song Id in case of Spotify
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Length of a Song
        /// </summary>
        public TimeSpan? Duration { get; set; }
        /// <summary>
        /// Starttime of a Song
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Status of the song
        /// </summary>
        public MusicStatus Status { get; set; }
        /// <summary>
        /// Provider of the song
        /// </summary>
        public MusicProvider Provider { get; set; }
        /// <summary>
        /// Url to Origin Song
        /// </summary>
        public string SongUrl { get; set; }

    }
}
