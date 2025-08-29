using System.Collections;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private AudioSource shopKeeperAudio;

    [Header("Sounds")]
    [SerializeField] private AudioClip happySell;
    [SerializeField] private AudioClip noSell;
    [SerializeField] private AudioClip squark;

    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerLocation.position, transform.position) < 10f)
        {
            Vector3 direction = (playerLocation.position - transform.position);
            direction.y = 0; // Keep the object upright
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
        }
    }

    public void shopKeeperHappy()
    {
        shopKeeperAudio.PlayOneShot(happySell);
        rb.AddForce(transform.up * 4f, ForceMode.Impulse);

    }
    public void shopKeeperReply()
    {
        if (Vector3.Distance(playerLocation.position, transform.position) < 10f)
        {
            StartCoroutine(squarkMethod());
        }
    }

    private IEnumerator squarkMethod()
    {
        yield return new WaitForSeconds(1);
        shopKeeperAudio.PlayOneShot(squark);
        rb.AddForce(transform.up * 3f, ForceMode.Impulse);
    }

    public void shopKeeperSad()
    {
        shopKeeperAudio.PlayOneShot(noSell);
        rb.AddForce(transform.up * 2f, ForceMode.Impulse);
    }
}
