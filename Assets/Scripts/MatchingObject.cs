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
        public List<MatchingObject> CollideObjects { get { return _collideObjects; } }
        private List<MatchingObject> _collideObjects = new List<MatchingObject>();


        private void OnTriggerEnter(Collider other)
        {
            var mobj = other.GetComponent<MatchingObject>();
            if (mobj == null) return;
            _collideObjects.Add(mobj);
        }

        private void OnTriggerExit(Collider other)
        {
            var mobj = other.GetComponent<MatchingObject>();
            if (mobj == null) return;
            _collideObjects.Remove(mobj);
        }

        private void Update()
        {
            // Debug.Log(CollideObjects.Count());
        }

    }
}
