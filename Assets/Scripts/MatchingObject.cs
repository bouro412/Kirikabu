using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// パターンマッチの対象となるオブジェクト
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    class MatchingObject : MonoBehaviour
    {
        /// <summary>
        /// オブジェクトの種類を表すタグ
        /// </summary>
        [SerializeField]
        public String Tag;

        /// <summary>
        /// 今このオブジェクトが接触している全てのオブジェクト
        /// </summary>
        public List<MatchingObject> CollideObjects { get; private set; }

        private void Start()
        {
            CollideObjects = new List<MatchingObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var mobj = other.GetComponent<MatchingObject>();
            if (mobj == null) return;
            CollideObjects.Add(mobj);
        }

        private void OnTriggerExit(Collider other)
        {
            var mobj = other.GetComponent<MatchingObject>();
            if (mobj == null) return;
            CollideObjects.Remove(mobj);
        }

        private void Update()
        {
            // Debug.Log(CollideObjects.Count());
        }

    }
}
