using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interface;
using Assets.Scripts.Matching;
using Assets.Scripts.Effect;

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
        private List<Rule> _rules;

        private void Awake()
        {
            Instance = this;
            _rules = new List<Rule>();
            //for test
            /*
            var match = new OneObjectMatch("Cube");
            var effect = new MoveEffect(new Vector3[] { new Vector3(0.1f, 0, 0) });
            _rules.Add(new Rule(match, effect));
            _rules.Add(new Rule(new TwoObjectCollisionMatch("Cube", "Wall"), new VanishEffect(VanishEffect.Option.First)));
            _rules.Add(new Rule(new TimerMatching(new OneObjectMatch("Pop"), 2.0f), new GenerateEffect(ObjectManager.Instance.PrefabList[0])));
            */    
        }

        /// <summary>
        /// 毎フレームのルールの適用を行う
        /// </summary>
        private void Update()
        {
            if (ObjectManager.Instance == null)
            {
                Debug.Log("ObjectManager is null");
                return;
            }
            foreach (var rule in _rules)
            {
                rule.ApplyRule(ObjectManager.Instance.Objects);
            }
        }

        /// <summary>
        /// ルールの追加
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(Rule rule)
        {
            _rules.Add(rule);
        }
    }
}
