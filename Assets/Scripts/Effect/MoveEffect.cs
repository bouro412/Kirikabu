using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interface;

namespace Assets.Scripts.Effect
{
    class MoveEffect : IEffect
    {
        private Vector3[] _directions;
        private Func<Transform, Vector3> _directionFunc;

        void IEffect.Update(IMatchedObjects matched)
        {
            var objs = matched.Objects;
            if (_directions != null)
            {
                for (int i = 0; i < objs.Length; i++)
                {
                    objs[i].transform.position += _directions[i];
                }
            }
            else if(_directionFunc != null)
            {
                foreach(var obj in objs)
                {
                    obj.transform.position += _directionFunc(obj.transform);
                }
            }
        }
        public MoveEffect(Vector3[] directions)
        {
            _directions = directions;
        }
        public MoveEffect(Func<Transform, Vector3> func)
        {
            _directionFunc = func;
        }
    }
}
