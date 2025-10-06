using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class coinsSpawer : MonoBehaviour

{
    [SerializeField]
    private UnityEvent<Vector3> onCoinSpawned;
    [SerializeField]
    private LaneManager laneManager;
    [SerializeField]
    private float spawnInterval = 3f;
    [SerializeField]
    private float offsetY = 0f;
    private Coroutine spawnCoroutine;
    private bool isActive = false;
    private void Activate(bool Active)
    {
        isActive = Active;
        if (isActive)
        {
            spawnCoroutine = StartCoroutine(SpawnCoins());
        }
        else
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
    }
    private IEnumerator SpawnCoins()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            Transform frame = laneManager.GetFrameInLane();
            onCoinSpawned?.Invoke(frame.position + Vector3.up * offsetY);
        }
    }
}
   
