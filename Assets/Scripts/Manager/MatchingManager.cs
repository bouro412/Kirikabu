using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interface;

namespace Assets.Scripts.Manager
{
    /// <summary>
    /// パターンマッチ全体の管理を行う
    /// </summary>
    class MatchingManager : MonoBehaviour
    {
        /// <summary>
        /// シングルトン
        /// </summary>
        public static MatchingManager Instance { get; private set; }
        /// <summary>
        /// 現在登録されているマッチングルールリスト
        /// </summary>
        private Rule[] _rules;

        private void Start()
        {
            Instance = this;
        }

        /// <summary>
        /// 毎フレームのルールの適用を行う
        /// </summary>
        private void Update()
        {
            foreach (var rule in _rules)
            {
                rule.ApplyRule(ObjectManager.Instance.Objects);
            }
        }
    }
}
