using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class DoorManager : MonoBehaviour
{
    [System.Serializable]
    public class KeyDoorPair
    {
        public KeyDoorPair(GameObject key, Animator anim, string daTrigger)
        {
            keyObject = key;
            doorAnimator = anim;
            doorAnimationTrigger = daTrigger;
        }
        public GameObject keyObject;
        public Animator doorAnimator;
        public string doorAnimationTrigger = "CollectedTrigger";
    }

    public Animator animToPass;
    public List<KeyDoorPair> keyDoorPairs = new List<KeyDoorPair>();

    //Store collected keys
    private List<GameObject> collectedKeys = new List<GameObject>();

    //Method to collect a key
    public void CollectKey(GameObject key)
    {
        collectedKeys.Add(key);
        KeyDoorPair pair = new KeyDoorPair(key, animToPass, "CollectedTrigger");

        keyDoorPairs.Add(pair);
    }

    public void TriggerDoorAnimationForKey(GameObject collectedKey)
    {
        foreach(KeyDoorPair pair in keyDoorPairs)
        {
            if(pair.keyObject == collectedKey)
            {
                //if the plaqyer has the correct key trigger the door's animation
                pair.doorAnimator.SetTrigger(pair.doorAnimationTrigger); // Matches your triggername  collected triggers
                return;
            }
        }
        //if no matching door found for the key
        Debug.LogWarning("No door found for the collected key.");
    }
}
