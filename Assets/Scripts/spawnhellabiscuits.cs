using UnityEngine;

public class spawnhellabiscuits : MonoBehaviour
{
    [SerializeField] private GameObject JammyDodger;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, 1f);
    }

    private void SpawnObject()
    {
        Vector3 vector3spawnpoint = new Vector3(transform.position.x+(10*Random.value), transform.position.y + (10 * Random.value), transform.position.z + (10 * Random.value));
        Instantiate(JammyDodger, vector3spawnpoint, transform.rotation);
    }
}
