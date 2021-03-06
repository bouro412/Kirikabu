﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interface;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Effect
{
    /// <summary>
    /// オブジェクトを生成するエフェクト
    /// 生成するオブジェクトの位置、向きはマッチした1番目のオブジェクトとの差分になる
    /// </summary>
    class GenerateEffect : IEffect
    {
        private Vector3 _positionDiff = Vector3.zero;
        private Vector3 _rotationDiff = Vector3.zero;
        private GameObject _generateObjectPrefab;

        void IEffect.Update(IMatchedObjects matched)
        {
            var pos = matched.Objects[0].transform.position + _generateObjectPrefab.transform.position + _positionDiff;
            var rot = Quaternion.Euler(matched.Objects[0].transform.rotation.eulerAngles + _generateObjectPrefab.transform.rotation.eulerAngles + _rotationDiff);
            GameObject.Instantiate(_generateObjectPrefab, pos, rot, ObjectManager.Instance.transform);
        }
        public GenerateEffect(GameObject prefab)
        {
            _generateObjectPrefab = prefab;
        }
        public GenerateEffect(GameObject prefab, Vector3 positionDiff, Vector3 rotationDiff)
        {
            _positionDiff = positionDiff;
            _rotationDiff = rotationDiff;
            _generateObjectPrefab = prefab;
        }
    }
}
