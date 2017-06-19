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
    }
}
