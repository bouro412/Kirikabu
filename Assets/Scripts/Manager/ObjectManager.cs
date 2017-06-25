using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    /// <summary>
    /// パターンマッチ対象のオブジェクト一覧を取り出す
    /// </summary>
    class ObjectManager : MonoBehaviour
    {
        /// <summary>
        /// オブジェクトリストの取得
        /// </summary>
        public GameObject[] Objects
        {
            get
            {
                return GetComponentsInChildren<MatchingObject>().Select(a => a.gameObject).ToArray();
            }
        }

        /// <summary>
        /// プレハブリスト
        /// </summary>
        [SerializeField]
        public GameObject[] PrefabList;

        /// <summary>
        /// シングルトン
        /// </summary>
        public static ObjectManager Instance { get; private set; }

        private void Start()
        {
            Instance = this;
        }
    }

}
