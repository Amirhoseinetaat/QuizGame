using Services.Data;
using System.Collections.Generic;

namespace Services.Abstraction
{
    public interface IPlaylist
    {
        List<Playlists> Playlists { get; }
    }
}