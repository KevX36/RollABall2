using UnityEngine;
using UnityEngine.Playables;

public class powerEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staticEffect.gameObject.SetActive(false);
    }
    private bool active;
    public PlayableDirector eventPlay;
    public GameObject staticEffect;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shockwave"))
        {
            if (active == false)
            {


                eventPlay.Play();
                staticEffect.gameObject.SetActive (true);
                active = true;
            }
        }
    }
}
