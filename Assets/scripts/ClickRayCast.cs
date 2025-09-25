using UnityEngine;
using UnityEngine.Events;
public class ClickRayCast : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 100;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private string coinTag = "Coin";
    [SerializeField]
    private UnityEvent onCoinCollected;
    [SerializeField]
    private bool isActive = true;
    public void SetActiive(bool active)
    {
        isActive = active;
    }

    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, raycastDistance, layerMask))
            {
                if (hitInfo.collider.CompareTag(coinTag))
                {
                    PressCoin(hitInfo.collider.gameObject);
                }

            }
        }
    }
    private void PressCoin(GameObject coin)
    {
        onCoinCollected.Invoke();
        coin.GetComponent<Coin>().Collect();
    }

}
