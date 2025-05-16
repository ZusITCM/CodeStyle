using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;

    [SerializeField] private Bullet _prefab;

    [SerializeField] private Target _target;

    private readonly bool _isShooting = true;

    private WaitForSeconds _fireDelay;

    private void Awake()
    {
        _fireDelay = new WaitForSeconds(_fireRate);
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(Shoot));
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

        Bullet newBullet = Instantiate(_prefab, transform.position + shootDirection, Quaternion.identity);

        newBullet.Init(shootDirection, _speed);
    }
}
