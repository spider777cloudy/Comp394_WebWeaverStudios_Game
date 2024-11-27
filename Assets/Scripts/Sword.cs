using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordObject; // Assign your sword object in the Inspector
    public Animator swordAnimator; // Assign your sword's Animator in the Inspector
    public AudioManager audioManager;
    public float swordDisplayDuration = 3f; // Duration to display the sword

    private bool isSwordShown = false;
   /// private float timeUntilHide = 0f;


    void Start()
    {
        // Ensure the sword is initially hidden
        if (swordObject != null)
        {
            swordObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSwordShown)
            {
                ShowSword();
            }
            else
            {
                HideSword();
            }

           /* if (isSwordShown && Time.time >= timeUntilHide)
            {
                HideSword();
            }*/



            // ToggleSword();
            if (audioManager != null)
            {
                audioManager.Play("BC");
            }
        }
    }


    void ShowSword()
    {
        if (swordObject != null && swordAnimator != null)
        {
            swordObject.SetActive(true);
            swordAnimator.SetTrigger("SwordAttack");
            isSwordShown = true;
            Invoke("HideSword", swordDisplayDuration);
         //   timeUntilHide = Time.time + swordDisplayDuration;
        }
    }

    void HideSword()
    {
        if (swordObject != null)
        {
            swordObject.SetActive(false);
            isSwordShown = false;
        }
    }





    /* void ToggleSword()
     {
         if (swordObject != null && swordAnimator != null)
         {
             // Toggle the sword's visibility
             swordObject.SetActive(!swordObject.activeSelf);

             // If the sword is visible, play the animation
             if (swordObject.activeSelf)
             {
                 swordAnimator.SetTrigger("SwordAttack");
                 // Add logic for any other actions when the sword is shown
             }
             // Else, add logic for any other actions when the sword is hidden
         }
     }*/
}
