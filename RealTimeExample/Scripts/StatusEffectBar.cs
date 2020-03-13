using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spark;

public class StatusEffectBar : MonoBehaviour
{
    [SerializeField]
    private GameObject statusEffectPrefab;
    [SerializeField]
    private Player player;

    private StatusEffectManager manager;
    private List<GameObject> statusEffectInstances = new List<GameObject>();

    void Start ()
    {
        manager = player.GetComponent<StatusEffectManager>();
    }

    void Update ()
    {
        foreach(GameObject go in statusEffectInstances)
        {
            Destroy(go);
        }

        statusEffectInstances = new List<GameObject>();

        foreach (StatusEffect effect in manager.StatusEffects.Values)
        {
            var instance = Instantiate(statusEffectPrefab);
            var image = instance.GetComponent<Image>();
            image.fillAmount = (effect.Duration % effect.MaxDuration) / effect.MaxDuration;
            instance.transform.Find("Stacks").GetComponent<Text>().text = effect.StackAmount.ToString();
            instance.transform.SetParent(this.transform);
            statusEffectInstances.Add(instance);
        }
    }
}
