using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunManager : MonoBehaviour
{
    public Transform ShotPoint;
    public GameObject player;
    [SerializeField] private CharacterController cc;

    MovementScript playerMovment;
    public float pullSpeed = 10000;
    public GameObject[] projectile;
    public float launchVelocity;
    public GameObject currnetBall;
    public Slider powerSlider;
    Vector3 currnetBallPos;

    public bool redBulletActive = true;
    public bool greenBulletActive = false;
    public bool blackBulletActive = false;
    public bool renderLine;

    public Image redFIll;
    public Image greenFIll;
    public Image blackFIll;

    public Animation shootAnim;

    LineRenderer lineRenderer;
    public AudioClip shotingSound;
    public AudioClip tpSound;
    public AudioClip reloadSound;
    public AudioClip switchSound;
    public AudioClip emptyMag;

    public bool hasBullets = false;
    private void Awake()
    {

    }

    void Start()
    {
        playerMovment = GetComponentInParent<MovementScript>();
        powerSlider.value = 1;
        lineRenderer = GetComponent<LineRenderer>();

    }



    public int i;
    public bool isStuck = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChooseToRender();
        }

        if (renderLine)
        {
            lineRenderer.enabled = true;
        }
        if (!renderLine)
        {
            lineRenderer.enabled = false;
        }
        BulletTypeSelector();

        if (currnetBall != null)
        {
            currnetBallPos = currnetBall.transform.position;

        }
        //launchVelocity = Mathf.Clamp(launchVelocity, 1, 100);
        if (!hasBullets)
        {
            if(Input.GetMouseButtonDown(0))
            AudioManager.Instance.PlayWorp(emptyMag);
        }
        if (hasBullets)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currnetBall == null)
                {
                    currnetBall = Instantiate(projectile[i], ShotPoint.position, ShotPoint.rotation);
                    currnetBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                         (0, 0, powerSlider.value * launchVelocity));
                    //Mathf.Clamp(0, 100, launchVelocity);
                    shootAnim.Play("Shoot");
                    AudioManager.Instance.PlayPlayer(shotingSound);

                }

                else
                {
                    Debug.Log("Else");
                    if (currnetBall.layer == 11)
                    {
                        TP();
                        Destroy(currnetBall);
                        playerMovment.gravity = 20f;
                        Debug.Log("RED");

                    }

                    if (currnetBall.layer == 10)
                    {
                        cc.enabled = true;
                        //Destroy(currnetBall);
                        playerMovment.gravity = 20f;
                        // isStuck = false;
                    }

                    if (currnetBall.layer == 9)
                    {
                        cc.enabled = true;
                        Destroy(currnetBall);
                        playerMovment.gravity = 20f;
                    }

                    //TP();
                    cc.enabled = true;
                    // Destroy(currnetBall);
                    playerMovment.gravity = 20f;

                }
                return;
            }
        }


        if (currnetBallPos != null)
        {

            if (currnetBall.layer == 10)
            {
                if (isStuck)
                {
                    if (Input.GetMouseButton(0))
                        Drag();

                    if (Input.GetMouseButtonUp(0))
                    {
                        cc.enabled = true;
                        Destroy(currnetBall);
                        StartCoroutine(FixGravity());
                        isStuck = false;
                    }

                }
            }

            

        }
            

        if (currnetBall)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }


        if (Input.GetKey(KeyCode.Q))
        {
            launchVelocity -= 0.08f;
            powerSlider.value -= 0.0008f;

        }

        if (Input.GetKey(KeyCode.E))
        {
            launchVelocity += 0.08f;
            powerSlider.value += 0.0008f;
        }






        if (!currnetBall)
        {
            if (Input.GetMouseButton(1))
            {
                playerMovment.lookXLimit = 0;
                Camera.main.fieldOfView = 50;
                lineRenderer.enabled = true;
                Debug.Log("Zooming");
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerMovment.lookXLimit = playerMovment.lookXLimitDefult;
                Camera.main.fieldOfView = 105;
                Debug.Log("Stopped Zooming");
            }

        }
        else
        {
            playerMovment.lookXLimit = playerMovment.lookXLimitDefult;
            Camera.main.fieldOfView = 105;

        }







    }


    private void TP()
    {
        if (!currnetBall)
        {
            return;
        }

        cc.enabled = false;
        player.transform.position = currnetBallPos;
        cc.enabled = true;

        Debug.Log(player.transform.position.ToString());
        AudioManager.Instance.PlayPlayer(tpSound);
        Destroy(currnetBall);





    }

    private void Drag()
    {
        cc.enabled = false;

        player.transform.position = /*1.000005f **/ Vector3.Lerp(player.transform.position, currnetBallPos, Time.deltaTime);
        playerMovment.gravity = 1f;
        //cc.enabled = true;
        //cc.enabled = true;
    }

    private void BulletTypeSelector()
    {
        if (redBulletActive)
        {
            i = 0;
            redFIll.gameObject.SetActive(true); greenFIll.gameObject.SetActive(false); blackFIll.gameObject.SetActive(false);
        }
        else
            redFIll.gameObject.SetActive(false);

        if (greenBulletActive)
        {
            i = 1;
            redFIll.gameObject.SetActive(false); greenFIll.gameObject.SetActive(true); blackFIll.gameObject.SetActive(false);
        }
        else
            greenFIll.gameObject.SetActive(false);

        if (blackBulletActive)
        {
            i = 2;
            redFIll.gameObject.SetActive(false); greenFIll.gameObject.SetActive(false); blackFIll.gameObject.SetActive(true);
        }
        else
            blackFIll.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Instance.PlayPlayer(switchSound);
            redBulletActive = true;
            greenBulletActive = false;
            blackBulletActive = false;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.Instance.PlayPlayer(switchSound);
            redBulletActive = false;
            greenBulletActive = true;
            blackBulletActive = false;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.green;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioManager.Instance.PlayPlayer(switchSound);
            redBulletActive = false;
            greenBulletActive = false;
            blackBulletActive = true;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.blue;

        }

    }
    private void ChooseToRender()
    {
        renderLine = !renderLine;
        //if (renderLine)
        //{
        //    renderLine = true;
        //}
        //else
        //{
        //    renderLine = false;
        //}
    }

    IEnumerator Reload()
    {
        Destroy(currnetBall);
        AudioManager.Instance.PlayPlayer(reloadSound);
        shootAnim.Play("Reload");
        Debug.Log("Before");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("After");
        shootAnim.Stop("Reload");
    }
    IEnumerator FixGravity()
    {
        playerMovment.moveDirection.y = playerMovment.jumpSpeed / 100;

        yield return new WaitForSeconds(0.2f);
        playerMovment.gravity = 20;
        yield return new WaitForSeconds(0.2f);
    }
}
