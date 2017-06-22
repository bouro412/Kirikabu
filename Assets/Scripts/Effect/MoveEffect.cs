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
        void IEffect.Update(IMatchedObjects matched)
        {
            var objs = matched.Objects;
            for(int i = 0;i < objs.Length; i++)
            {
                objs[i].transform.position += _directions[i];
            }
        }
        public MoveEffect(Vector3[] directions)
        {
            _directions = directions;
        }
    }
}
