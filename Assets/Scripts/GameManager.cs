using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float firstSpeed;
    private float speed;
    [SerializeField] private float ratio;
    [SerializeField] private GameObject parentObject;

    [SerializeField] AudioSource soundFx;

    [SerializeField] float soundTimer;
    [SerializeField] float p_soundTimer;

    private bool isSoundPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spin();

        if(speed <0)
        {
            // TO DO - Finish the game

            speed = 0;
            ratio = 0;
            isSoundPlay = false;
        }
            
        speed -= ratio;
        soundTimer += Time.deltaTime/50;
    }

    private void Spin()
    {
        parentObject.transform.eulerAngles += new Vector3(0, 0, speed*Time.deltaTime);
        Ses();
    }

    public void SpinButtonOnClick()
    {
        speed = firstSpeed;
        ratio = Random.Range(4f, 5f);
        isSoundPlay = true;
        p_soundTimer =soundTimer= 0.2f;
    }

    private void Ses()
    {
        if(p_soundTimer < 0 && isSoundPlay)
        {
            p_soundTimer = soundTimer;
            soundFx.Play();
        }
        p_soundTimer -= Time.deltaTime;
    }
}
