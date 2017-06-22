using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Matching
{
    class MatchedObjects : IMatchedObjects
    {
        private IMatching _match;
        IMatching IMatchedObjects.Match
        {
            get
            {
                return _match;
            }
        }


        GameObject[] _objects;
        GameObject[] IMatchedObjects.Objects { get
            {
                return _objects;
            }
        }

        public MatchedObjects(IMatching match, GameObject[] objects)
        {
            _match = match;
            _objects = objects;
        }
    }
}
