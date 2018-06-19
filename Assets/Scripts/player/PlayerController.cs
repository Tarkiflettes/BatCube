using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float frequency = 10.0f;
    public float interactRange = 1f;

    //public ButtonController button;
    public ParticleSystem waves;
    public WavesController wavesController;
    public FrequenceWave frequenceWave;

    //COmmentaire
    private Rigidbody rb;
    private CharacterController cc;
    private Vector3 moveDirection = Vector3.zero;
    private AudioSource audio;

    private int voidLayer;

    private bool send = true;
    private bool hurtBool = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
        waves.gameObject.SetActive(false);
        voidLayer = LayerMask.NameToLayer("Player");
    }

    void FixedUpdate()
    {

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        moveDirection.y -= 20.0f * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime * speed);

        transform.rotation = Quaternion.AngleAxis(90 - angle, this.transform.up);

    }

    private void Update()
    {

        waves.playbackSpeed = frequency;

        if (Input.GetButtonDown("Wave"))
        {
            if (send && (frequenceWave.getCurrentCharge() > 0))
                StartCoroutine(sendWaves());
        }

        if (Input.GetButtonDown("Use"))
        {

            GameObject gameObject = GetClosestObject("Interactive");
            if (gameObject != null)
            {
                ButtonController b = gameObject.GetComponent<ButtonController>();
                b.Action();
            }
        }
        if (Input.GetButtonDown("Reload"))
        {
            GameObject gameObject = GetClosestObject("Prise");
            if (gameObject != null)
            {
                PriseController p = gameObject.GetComponent<PriseController>();
                p.Action();
            }
        }

        if (100 <= frequenceWave.getCurrentFrequence() && frequenceWave.getCurrentFrequence() <= 300)
        {
            waves.startSpeed = 1.0F; // White
            waves.startColor = new Color(1, 1, 1);
        }
        if (301 <= frequenceWave.getCurrentFrequence() && frequenceWave.getCurrentFrequence() <= 500)
        {
            waves.startSpeed = 2.0F; // rouge
            waves.startColor = new Color(1, 0, 0);
        }
        if (501 <= frequenceWave.getCurrentFrequence() && frequenceWave.getCurrentFrequence() <= 700)
        {
            waves.startSpeed = 3.0F; // jaune
            waves.startColor = new Color(1, 0.92F, 0.016F);
        }
        if (701 <= frequenceWave.getCurrentFrequence() && frequenceWave.getCurrentFrequence() <= 900)
        {
            waves.startSpeed = 4.0F; // vert
            waves.startColor = new Color(0, 1, 0);
        }

    }

    GameObject GetClosestObject(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        foreach (GameObject obj in objectsWithTag)
        {
            float distanceSqr = (rb.position - obj.transform.position).sqrMagnitude;
            if (distanceSqr < interactRange)
            {
                if (!closestObject)
                {
                    closestObject = obj;
                }
                if (Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
                {
                    closestObject = obj;
                }
            }
        }
        return closestObject;
    }

    IEnumerator sendWaves()
    {
        send = false;
        audio.Play();
        wavesController.transform.parent.transform.position = transform.position;
        wavesController.transform.parent.transform.rotation = transform.rotation;
        //wavesController.transform.position.x = transform.position.x;
        wavesController.GetComponent<Collider>().enabled = true;
        waves.gameObject.SetActive(true);
        waves.Play();

        frequenceWave.setCurrentCharge(frequenceWave.getCurrentCharge() - 1);

        yield return new WaitForSeconds(1);

        waves.Stop();
        audio.Stop();

        yield return new WaitForSeconds(3);

        wavesController.GetComponent<Collider>().enabled = false;
        wavesController.disable();
        waves.gameObject.SetActive(false);
        send = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            send = false;
            if (hurtBool)
                StartCoroutine(hurt());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            send = true;
        }
    }
    IEnumerator hurt()
    {
        hurtBool = false;
        frequenceWave.currentCharge--;
        yield return new WaitForSeconds(1);
        hurtBool = true;
    }
}
