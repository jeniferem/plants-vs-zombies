using UnityEngine;
using UnityEngine;
 
public class BaseCharacterData : ScriptableObject
{
    [Header("Common Settings")]
    public float maxHealth;
    public ActionAssets[] actionAssets;
 
    public string GetAnimationName(ActionKey actionKey)
    {
        foreach (var actionAsset in actionAssets)
        {
            if (actionAsset.actionKey == actionKey)
            {
                return actionAsset.animationName;
            }
        }
        return string.Empty;
    }
 
    public string GetSoundName(ActionKey actionKey)
    {
        foreach (var actionAsset in actionAssets)
        {
            if (actionAsset.actionKey == actionKey)
            {
                return actionAsset.soundName;
            }
        }
        return string.Empty;
    }
}
