﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spark;

public class StatusEffectBar : MonoBehaviour
{
    [SerializeField]
    private GameObject statusEffectPrefab = default;
    [SerializeField]
    private Player player = default;

    private List<GameObject> statusEffectInstances = new List<GameObject>();
    void Update ()
    {
        foreach(GameObject go in statusEffectInstances)
        {
            Destroy(go);
        }

        statusEffectInstances = new List<GameObject>();

        foreach (RealTimeStatusEffect effect in player.statusEffects.Values)
        {
            var instance = Instantiate(statusEffectPrefab);
            var image = instance.GetComponent<Image>();
            image.fillAmount = (effect.StackDuration % effect.StartDuration) / effect.StartDuration;
            instance.transform.Find("Stacks").GetComponent<Text>().text = effect.StackAmount.ToString();
            instance.transform.SetParent(this.transform);
            statusEffectInstances.Add(instance);
        }
    }
}
