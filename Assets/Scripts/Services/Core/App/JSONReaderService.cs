
using Newtonsoft.Json;
using Services.Abstraction;
using Services.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Core.App
{
    public class JSONReaderService : IPlaylist
    {

        private List<Playlists> _playlists;
        public List<Playlists> Playlists => _playlists; 

        public void JsonToObject()
        {
            TextAsset assets = (TextAsset)Resources.Load("PlayListData", typeof(TextAsset));
            _playlists = JsonConvert.DeserializeObject<List<Playlists>>(assets.text);
        }

        public void Initialization()
        {
            JsonToObject();
            Debug.Log("Iniiiiit  " + _playlists.Count);

        }


    }
}