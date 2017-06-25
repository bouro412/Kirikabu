using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Matching
{
    /// <summary>
    /// 指定した秒おきに発火するマッチング
    /// もう一つ別のマッチングと組み合わせて使う
    /// </summary>
    class TimerMatching : IMatching
    {
        private IMatching _anotherMatching;

        /// <summary>
        /// このタイマーが発火する間隔
        /// </summary>
        private float _timerSec;

        /// <summary>
        /// ひとつ前に発火した時刻
        /// </summary>
        private float _lastSec;

        IMatchedObjects[] IMatching.Matching(GameObject[] objects)
        {
            var time = UnityEngine.Time.time;
            // 指定時間が経過していない場合には空の配列を返す
            if (time - _lastSec < _timerSec) return new IMatchedObjects[0];
            _lastSec = time;
            return _anotherMatching.Matching(objects).Select(matched => new MatchedObjects(this, matched.Objects)).ToArray();
        }

        public TimerMatching(IMatching matching, float timerSec)
        {
            _anotherMatching = matching;
            _timerSec = timerSec;
            _lastSec = UnityEngine.Time.time;
        }
    }
}
