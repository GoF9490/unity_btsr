using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] int _bulletCount = 5;
    Queue<GameObject> _bulletPool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(_bullet);
        bullet.GetComponent<BulletStat>().SetBC(this);
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }

    public void Dequeue(Vector3 startPoint, Vector3 endPoint)
    {
        if (_bulletPool.Count <= 0)
        {
            CreateBullet();
        }

        GameObject bullet = _bulletPool.Dequeue();
        bullet.GetComponent<BulletStat>().SetPoint(startPoint, endPoint);
        bullet.SetActive(true);
    }

    public void Enqueue(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}
