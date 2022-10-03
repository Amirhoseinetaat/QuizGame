using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Data
{
    [System.Serializable]
    public class Playlists
    {
        public string id { get; set; }
        public List<Question> questions { get; set; }
        public string playlist { get; set; }
    }

}