using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interface;
using Assets.Scripts;

namespace Assets.Scripts.Matching
{
    class OneObjectMatch : IMatching
    {
        private string _tag;

        public OneObjectMatch(string objectTag)
        {
            _tag = objectTag;
        }

        IMatchedObjects[] IMatching.Matching(GameObject[] objects)
        {
            var ret = new List<IMatchedObjects>();
            foreach(var obj in objects)
            {
                var mobj = obj.GetComponent<MatchingObject>();
                if(mobj != null && mobj.Tag == _tag)
                {
                    ret.Add(new MatchedObjects(this, new MatchingObject[] { mobj}));
                }
            }
            return ret.ToArray();
        }
    }
}
