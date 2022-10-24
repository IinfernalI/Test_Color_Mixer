using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class ObjectAddForce : MonoBehaviour
    {
        [SerializeField] private float _forcePower = 3.5f;
        [SerializeField] private Rigidbody _rigidbody;

        [ContextMenu("Test Push")]
        public void PushObject()
        {
            _rigidbody = _rigidbody != null ? _rigidbody : GetComponent<Rigidbody>();
            _rigidbody.AddForce(Vector3.forward * _forcePower);
        }
    }
}