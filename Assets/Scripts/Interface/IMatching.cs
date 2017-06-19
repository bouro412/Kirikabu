using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    interface IMatching
    {
        IMatchedObjects[] Matching(GameObject[] Objects);
    }
}
