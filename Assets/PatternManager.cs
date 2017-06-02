using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Kirikabu
{
    internal class PatternManager : MonoBehaviour
    {
        public List<Pattern> PatternList { get; private set; }
        public static PatternManager Instance { get; private set; }
        
        // Use this for initialization
        void Start()
        {
            Instance = this;
            var patterns = GetComponentsInChildren<Pattern>();
            PatternList = patterns.ToList();
        }
        public void AddPatern(Pattern p)
        {
            PatternList.Add(p);
        }
    }
}