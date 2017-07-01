using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Matching;
using Assets.Scripts.Effect;


namespace Assets.Scripts.UFOGame
{
    [RequireComponent(typeof(MatchingManager))]
    public class UFOGameRule : MonoBehaviour
    {
        // 1番目にUFO
        // 2番目にBullet
        public GameObject[] Prefabs;
        void Start()
        {
            var manager = MatchingManager.Instance;
            if(manager == null)
            {
                Debug.Log("Manager is null");
            }
            // 敵のポップ
            manager.AddRule(new Rule(new TimerMatching(new OneObjectMatch("Pop"), 10.0f), new GenerateEffect(Prefabs[0])));
            // 敵の移動
            manager.AddRule(new Rule(new OneObjectMatch("UFO"), new MoveEffect(transform => transform.forward.normalized * 0.1f)));
            // 敵の射撃
            manager.AddRule(new Rule(new TimerMatching(new OneObjectMatch("UFO"), 3.0f), new GenerateEffect(Prefabs[1])));
            // 弾の移動
            manager.AddRule(new Rule(new OneObjectMatch("Bullet"), new MoveEffect(transform => transform.forward.normalized * 0.2f)));
            // 武器と敵の当たり判定
            manager.AddRule(new Rule(new TwoObjectCollisionMatch("UFO", "Weapon"), new VanishEffect(VanishEffect.Option.First)));
            // 武器と弾の当たり判定
            // とりあえず消す
            manager.AddRule(new Rule(new TwoObjectCollisionMatch("Bullet", "Weapon"), new VanishEffect(VanishEffect.Option.First)));
        }
    }
}