using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShooterBad : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] float _firerate;

    [SerializeField] private GameObject _prefab;

    private readonly Transform _bullet;

    private readonly bool _isShooting = true;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(nameof(Shoot));
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        while (_isShooting)
        {
            Vector3 bulletPosition = (_bullet.position - transform.position).normalized;

            GameObject NewBullet = Instantiate(_prefab, transform.position + bulletPosition, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = bulletPosition;
            NewBullet.GetComponent<Rigidbody>().linearVelocity = bulletPosition * _speed;

            yield return new WaitForSeconds(_firerate);
        }
    }
}