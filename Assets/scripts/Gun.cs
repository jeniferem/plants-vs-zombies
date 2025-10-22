using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private GunData gunData;
    [SerializeField]
    private InstantiatepoolObjects bulletPool;
    [SerializeField]
    private Transform bulletPivot;
    private Coroutine shootCoroutine;
    private void OnEnable()
    {
        health.InitializeHealth(gunData.maxHealth);
        SoundManager.instance.Play(gunData.appearSoundName);
        shootCoroutine = StartCoroutine(ShootRoutine());
    }
    private IEnumerator ShootRoutine()
    {
        Animator animator = GetComponent<Animator>();
        while (true)
        {
            bulletPool.InstantiatepoolObject(bulletPivot);
            SoundManager.instance.Play(gunData.shootSoundName);
            yield return new WaitForSeconds(gunData.fireRate);
        }
    }
    public void Die ()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }
        SoundManager.instance.Play(gunData.dieShootName);
        gameObject.SetActive(false);
    }
}
