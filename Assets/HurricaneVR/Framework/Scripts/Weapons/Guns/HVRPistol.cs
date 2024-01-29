using System.Collections;
using UnityEngine;

namespace HurricaneVR.Framework.Weapons.Guns
{
    public class HVRPistol : HVRGunBase
    {
        [SerializeField] private GameObject muzzleParticlePrefab;
        [SerializeField] private Transform particleEmmiter;
        protected override void Awake()
        {
            base.Awake();
        }
        public void SpawnParticles()
        {
            GameObject particle = GameObject.Instantiate(muzzleParticlePrefab, particleEmmiter);
            particle.transform.localPosition = Vector3.zero;
            particle.transform.localRotation = Quaternion.identity;
        }
    }
}