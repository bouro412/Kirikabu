using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Effect
{
    /// <summary>
    /// オブジェクトを消すエフェクト
    /// デフォルトですべてのマッチしたオブジェクトを消すが、
    /// オプションの指定でどちらか一方を消すこともできる
    /// </summary>
    class VanishEffect : IEffect
    {
        public enum Option
        {
            All = 1,
            First,
            Second
        }

        private Option _option;
        void IEffect.Update(IMatchedObjects matched)
        {
            var objs = matched.Objects;
            switch (_option)
            {
                case Option.All:
                    foreach(var obj in objs)
                    {
                        GameObject.DestroyImmediate(obj.gameObject);
                    }
                    break;
                case Option.First:
                    GameObject.DestroyImmediate(objs[0].gameObject);
                    break;
                case Option.Second:
                    GameObject.DestroyImmediate(objs[1].gameObject);
                    break;
                
            }
        }
        public VanishEffect()
        {
            _option = Option.All;
        }
        public VanishEffect(Option option)
        {
            _option = option;
        }
    }
}
