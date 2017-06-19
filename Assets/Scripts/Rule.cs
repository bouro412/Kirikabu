using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interface;

namespace Assets.Scripts
{
    /// <summary>
    /// マッチングの条件とその効果をまとめたルールそのものを表す
    /// </summary>
    class Rule
    {
        /// <summary>
        /// マッチの条件
        /// </summary>
        private IMatching _cond;

        /// <summary>
        /// マッチ後の影響
        /// </summary>
        private IEffect _effect;

        /// <summary>
        /// 提示されたオブジェクトリストにルールを適用する
        /// </summary>
        /// <param name="objects"></param>
        public void ApplyRule(GameObject[] objects)
        {

            foreach(var matched in _cond.Matching(objects))
            {
                _effect.Update(matched);
            }
        }
    }
}
