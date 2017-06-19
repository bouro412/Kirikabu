using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interface
{
    /// <summary>
    /// マッチ後にそのオブジェクトに与える効果を表す
    /// </summary>
    interface IEffect
    {
        /// <summary>
        /// 効果
        /// </summary>
        /// <param name="matched"></param>
        void Update(IMatchedObjects matched);
    }
}
