using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Kirikabu
{
    internal class Field : MonoBehaviour
    {
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var count = transform.childCount;
            var childlist = Enumerable.Range(0, count).Select(i => transform.GetChild(i)).ToArray();
            var patternlist = PatternManager.Instance.PatternList;
            foreach(var pattern in patternlist)
            {
                if(match(childlist, pattern))
                {
                    Debug.Log(string.Format("Pattern {0} is matched {1}, {2} and other...", pattern.gameObject.name, childlist[0].name, childlist[1].name));
                }
            }
        }

        private bool match(Transform[] objects, Pattern pattern)
        {
            var patobjs = pattern.Objects;
            // 各オブジェクトをpatternの先頭のオブジェクトに当てはめて考える
            for(int c = 0; c < objects.Length; c++)
            {
                var target = objects[c].transform;
                var pat1 = patobjs[0];
                // type, rotation, scaleの検証は省略
                var posdiff = target.localPosition - pat1.Position;
                if (patobjs.All(pat => objects.Any(obj => Vector3.Equals(obj.transform.position, pat.Position + posdiff))))
                    return true;
            }
            return false;
        }
    }
}