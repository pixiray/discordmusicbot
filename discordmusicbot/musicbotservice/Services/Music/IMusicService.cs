using musicbotservice.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Services.Music
{
    /// <summary>
    /// Music Service offers Command available to manage Music Playback
    /// </summary>
    interface IMusicService
    {
        Task SearchMusicAsync(string searchstring);

        /// <summary>
        /// Plays a specific song
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task PlayMusicAsync(Song song);

        /// <summary>
        /// Adds a song to Playlist
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task AddMusicAsync(Song song);

        /// <summary>
        /// Pauses the actual Song
        /// </summary>
        /// <returns></returns>
        Task PauseAsync();

        /// <summary>
        /// Skips the current Song played
        /// </summary>
        /// <returns>Next Song</returns>
        Task SkipCurrentAsync();

        /// <summary>
        /// Changes current Playmode to Shuffle
        /// </summary>
        /// <returns></returns>
        Task ShuffleAsync();

        /// <summary>
        /// Repeats a song after it is finished
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task RepeatAsync(Song song);

        /// <summary>
        /// Changes Playmode to Repeat
        /// </summary>
        /// <returns></returns>
        Task RepeatCurrentAsync();

        
    }
}
