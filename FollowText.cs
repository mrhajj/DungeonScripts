using UnityEngine;

public class FollowText : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject pickupText;
    [SerializeField] private float damping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerSingleton.instance.gameObject;
        pickupText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
           pickupText.SetActive(true); 

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            pickupText.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        var lookPos = transform.position - player.transform.position;
        lookPos.y = 0f;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
