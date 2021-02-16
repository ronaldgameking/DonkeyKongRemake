using System.Collections.Generic;
using UnityEngine;

public class DKDJ : MonoBehaviour
{
    //There will be 1 and no more
    public static DKDJ Instance;

    public GameObject barrelPrefab;
    private List<Barrel> barrels = new List<Barrel>();
    public Transform barrelAncor;

    [SerializeField] [ReadOnly] float timer;
    [SerializeField] private float barrelDelay = 1f;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (barrelPrefab == null)
        {
            Debug.LogError("Barrel prefab not set!");
            enabled = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.isPaused) return;
        if (timer >= barrelDelay)
        {
            GameObject go = Instantiate(barrelPrefab, barrelAncor);
            barrels.Add(go.GetComponent<Barrel>());
            barrelDelay = Random.Range(2.1f, 4.8f);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void Pause(bool doPause)
    {
        foreach (Barrel barrel in barrels)
        {
            if (doPause)
                barrel.BackupVelocity();
            else
                barrel.RestoreVelocity();
            
        }
    }

    public void ExpireBarrel(Barrel barrel)
    {
        Destroy(barrel.gameObject);
        barrels.Remove(barrel);
    }
}
