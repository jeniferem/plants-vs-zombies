using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

public class Flower : BasePlant 
{
    [SerializeField]
    private Collider stepsDectector;
    [SerializeField]
    private FlowerData flowerData;
    [SerializeField]
    private InstantiatepoolObjects coinPool;
    [SerializeField]
    private float coinsOffsetY = 0.5f;
    [SerializeField]
    private UnityEvent<Transform> onSpawnCoin;
    private List<Step> stepsInRange = new List<Step>();
    private Coroutine spawnCoinCorutine;
    public override bool IsActive
    {
        set
        {
            base.IsActive = value;
            if (value)
            {
                stepsInRange.Clear();
            }
            stepsDectector.enabled = value;
            spawnCoinCorutine = StartCoroutine(SpawnCoinRoutine());
        }
    }
    private void OnEnable()
    {
        //SoundManager.instance.Play(flowerData.GetSoundName(ActionKey.Appear));
        health.InitializeHealth(flowerData.maxHealth);
        animator.Play(flowerData.GetAnimationName(ActionKey.Idle), 0, 0f);
    }
    private void SpawnCoinRoutine(Collider other)
    {
        if (other.TryGetComponent<Step>(out Step step))
        {
            stepsInRange.Add(step);
        }
    }
    private IEnumerator SpawnCoinRoutine()
    {
        while (isActive && health.CurrentHealth > 0)
        {
            yield return new WaitForSeconds(flowerData.spawnCoinTime);
            onSpawnCoin?.Invoke(transform);
            animator.Play(flowerData.GetAnimationName(ActionKey.Attack),0,0f);
            SoundManager.instance.Play(flowerData.GetSoundName(ActionKey.Attack));
            for (int i = 0; i < flowerData.coinAmount; i++)
            {
                if (stepsInRange.Count > 0)
                {
                    Step randomStep = stepsInRange[Random.Range(0, stepsInRange.Count)];
                    Vector3 spawnPosition = randomStep.transform.position + Vector3.up * coinsOffsetY;
                    coinPool.InstantiatepoolObject(spawnPosition);
                }
            }
        }
    }
    public void Die()
    {
        if (spawnCoinCorutine != null)
        {
            StopCoroutine(spawnCoinCorutine);
        }
        currentstep.IsOccupied = false;
        CurrentStep = null;
        IsActive = false;
        StartCoroutine(DieRoutine(flowerData.GetAnimationName(ActionKey.Die)));
        SoundManager.instance.Play(flowerData.GetSoundName(ActionKey.Die));
    }
}
