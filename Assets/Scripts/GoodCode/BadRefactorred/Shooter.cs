using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] float _fireRate;

    [SerializeField] private Bullet _prefab;

    [SerializeField] private Target _target;

    private readonly bool _isShooting = true;

    private WaitForSecondsRealtime _fireDelay;

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

    private void Start()
    {
        _fireDelay = new WaitForSecondsRealtime(_fireRate);
    }

    private IEnumerator Shoot()
    {
        while (_isShooting)
        {
            Fire();

            yield return _fireDelay;
        }
    }

    private void Fire()
    {
        if (_target == null)
            return;

        Vector3 shootDirection = (_target.transform.position - transform.position).normalized;

        Bullet NewBullet = Instantiate(_prefab, transform.position + shootDirection, Quaternion.identity);

        NewBullet.Init(shootDirection, _speed);
    }
}
