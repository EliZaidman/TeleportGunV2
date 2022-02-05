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
    void Update()
    {
        BulletTypeSelector();

        if (currnetBall != null)
        {
            currnetBallPos = currnetBall.transform.position;

        }
        //launchVelocity = Mathf.Clamp(launchVelocity, 1, 100);


        if (Input.GetMouseButtonDown(0))
        {
            if (currnetBall == null)
            {
                currnetBall = Instantiate(projectile[i], ShotPoint.position, ShotPoint.rotation);
                currnetBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                     (0, 0, powerSlider.value * launchVelocity));
                //Mathf.Clamp(0, 100, launchVelocity);
                shootAnim.Play("Shoot");
            }

            else
            {
                TP();
            }
            return;
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
            renderLine = true;
            launchVelocity -= 0.08f;
            powerSlider.value -= 0.0008f;

        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            renderLine = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            renderLine = true;
            launchVelocity += 0.08f;
            powerSlider.value += 0.0008f;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            renderLine = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChooseToRender();
            
        }


        if (renderLine)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }


        if (!currnetBall)
        {
            if (Input.GetMouseButton(1))
            {
                playerMovment.lookXLimit = 0;
                Camera.main.fieldOfView = 50;
                //GetComponentInChildren<GunMove>().lookXLimit = lookXLimitDefult;
                GetComponentInChildren<LineRenderer>().enabled = true;
                Debug.Log("Zooming");
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerMovment.lookXLimit = playerMovment.lookXLimitDefult;
                Camera.main.fieldOfView = 105;
                //GetComponentInChildren<GunMove>().lookXLimit = lookXLimitDefult;
                GetComponentInChildren<LineRenderer>().enabled = false;
                Debug.Log("Stopped Zooming");
            }

        }
        else
        {
            playerMovment.lookXLimit = playerMovment.lookXLimitDefult;
            Camera.main.fieldOfView = 105;
            //GetComponentInChildren<GunMove>().lookXLimit = lookXLimitDefult;
            GetComponentInChildren<LineRenderer>().enabled = false;
            
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

        //player.transform.position = currnetBall.transform.position;
        Debug.Log(currnetBall.transform.position.ToString());
        Debug.Log(player.transform.position.ToString());    
        Destroy(currnetBall);



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
            redBulletActive = true;
            greenBulletActive = false;
            blackBulletActive = false;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            redBulletActive = false;
            greenBulletActive = true;
            blackBulletActive = false;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.green;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            redBulletActive = false;
            greenBulletActive = false;
            blackBulletActive = true;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.blue;

        }

    }
    private void ChooseToRender()
    {
        if (renderLine)
        {
            renderLine = false;
        }
        else
        {
            renderLine = true;
        }
    }

    IEnumerator Reload()
    {
        Destroy(currnetBall);
        shootAnim.Play("Reload");
        Debug.Log("Before");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("After");
        shootAnim.Stop("Reload");
    }
     
}
