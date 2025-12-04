using UnityEngine;
using System;

public class PlantManager : MonoBehaviour
{
   [SerializeField]
   private PlantAssets[] plantAssets;
   public void SetAvailablePlants(PlantType[] availablePlants)
   {
     foreach (var plantAssets in plantAssets)
        {
            if (Array.Exists(availablePlants, plant => plant == plantAssets.plantType))
            {
                plantAssets.plantButton.SetActive(true);
            }
            else
            {
               plantAssets.plantButton.SetActive(false);
            }
        } 
   }
}
