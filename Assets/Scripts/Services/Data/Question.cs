using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Data
{
    [System.Serializable]
    public class Question
    {
        public string id { get; set; }
        public int answerIndex { get; set; }
        public List<Choice> choices { get; set; }
        public Song song { get; set; }
        public string type { get; set; }
    }
}