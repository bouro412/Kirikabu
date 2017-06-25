using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Matching
{
    class TwoObjectCollisionMatch : Interface.IMatching
    {
        private string _targetTag1;
        private string _targetTag2;

        IMatchedObjects[] IMatching.Matching(GameObject[] objects)
        {
            var ret = new List<IMatchedObjects>();
            var searched = new List<MatchingObject>();

            foreach (var mobj in objects.Select(a => a.GetComponent<MatchingObject>()))
            {
                if(mobj.Tag == _targetTag1)
                {
                    foreach(var mobj2 in mobj.CollideObjects.Where(mo => mo.Tag == _targetTag2 && !(searched.Contains(mo))))
                    {
                        ret.Add(new MatchedObjects(this, new MatchingObject[2] { mobj, mobj2 }));
                    }
                    searched.Add(mobj);
                }
            }

            return ret.ToArray();
        }
        public TwoObjectCollisionMatch(string tag1, string tag2)
        {
            _targetTag1 = tag1;
            _targetTag2 = tag2;
        }

    }
}
