using UnityEngine;

public class spawnObjectBoring : MonoBehaviour
{
    [SerializeField] private GameObject JammyDodger;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, 4f);
    }

    private void SpawnObject()
    {
        Vector3 vector3spawnpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(JammyDodger, vector3spawnpoint, transform.rotation);
    }
}
