using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kirikabu
{
    internal class Pattern : MonoBehaviour
    {
        public enum ObjectType
        {
            Cube,
        }
        public class PatternObject
        {
            public ObjectType Type = ObjectType.Cube;
            public Vector3 Position = Vector3.zero;
            public Quaternion Rotation = Quaternion.identity;
            public Vector3 Scale = Vector3.one;
        }

        public PatternObject[] Objects { get; private set; }

        // Use this for initialization
        void Start()
        {
            var n = transform.childCount;
            Objects = new PatternObject[n];
            for(var i = 0; i < n; i++)
            {
                var child = transform.GetChild(i);
                Objects[i] = new PatternObject
                {
                    Type = ObjectType.Cube,
                    Position = child.transform.localPosition,
                    Rotation = child.transform.localRotation,
                    Scale = child.transform.localScale
                };
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}