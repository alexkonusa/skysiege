using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AI_Ally : MonoBehaviour, IPointerClickHandler
{

    public GameObject closestAlly;
    public GameObject repairAndHealPanel;
    public string shipName;
    public int aiShipLevel;
    public float health;
    public float maxHealth;
    public string enemyShipTag = "Enemy";
    public float countDown = 0f;
    public float fireRate = 1f;
    public float enemyDamage;


    public bool shipFound;

    UIManager uimanager;

    void Start()
    {

        StartCoroutine(CheckForShipsTimer(10f));
        LookDirection();

        maxHealth = health;

        uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();


    }

	// Update is called once per frame
	void Update ()
    {


        //Kill the ally ship
        if (health <= 0)
        { 
            Destroy(gameObject);
            StatsManager.shipStorage++;

        }

        AttackTheEnemy();

        if (shipFound == true && closestAlly == null)
        {
            closestAlly = null;
            shipFound = false;


        }

    }

    void GetClosestEnemyShips()
    {
        //Parameters for our collider 
        Vector3 center = transform.position;
        float radius = 3.0f;
        //Collider array
        Collider[] affectedColliders = Physics.OverlapSphere(center, radius);

        if (shipFound == false)
        {
            //If there are no ships
            //Check for the tag in our current colliders hit
            foreach (Collider checkForShips in affectedColliders)
            {

                if (checkForShips.tag == enemyShipTag)
                {

                    Debug.Log("FoundShip");
                    shipFound = true;

                }
            }
        }

        if (shipFound == true)
        {
            //If we don't have a closest enemy findone.
            if (closestAlly == null)
            {
                //Get the closest ship
                float distance = Mathf.Infinity;
                Vector3 position = transform.position;

                foreach (Collider ship in affectedColliders)
                {
                    if (ship.gameObject.tag == enemyShipTag)
                    {
                        Vector3 difference = ship.transform.position - position;
                        float currentDistance = difference.sqrMagnitude;

                        if (currentDistance < distance)
                        {

                            closestAlly = ship.gameObject;
                            distance = currentDistance;

                            transform.LookAt(closestAlly.transform); // look at the closest enemy

                        }
                    }
                }
            }
        }
    }

    void AttackTheEnemy()
    {

        if (closestAlly != null)
        {

            GameObject _closestAlly = closestAlly.gameObject;
            float allyHealth = _closestAlly.GetComponent<AI_Ship>().health;
            float enemyMaxHealth = _closestAlly.GetComponent<AI_Ship>().maxHealth;

            if (allyHealth - 1 >= 0)
            {
                if (countDown <= 0)
                {

                    //attack the ship
                    _closestAlly.GetComponent<AI_Ship>().health = (_closestAlly.GetComponent<AI_Ship>().health - enemyDamage);
                    countDown = 1f / fireRate;

                    //Update the enemies healthbar here
                    Transform closestAllyCanvas = _closestAlly.transform.GetChild(0);
                    Transform ourHealthBarTransform = closestAllyCanvas.transform.GetChild(0);

                    Image enemyHealthBar = ourHealthBarTransform.GetComponent<Image>();
                    float enemysHealth = _closestAlly.GetComponent<AI_Ship>().health;
                    enemyHealthBar.fillAmount = enemysHealth / enemyMaxHealth;
                }

                countDown -= Time.deltaTime;
            }

            if (allyHealth <= 0)
            {
                closestAlly = null;

                if (closestAlly == null)
                {
                    shipFound = false;
                }
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (uimanager.panelActive == false)
        {

            CreateRepairAndHealPanel();
            uimanager.panelActive = true;

        }

    }

    void CreateRepairAndHealPanel()
    {

        GameObject repairAndHeal= (GameObject)Instantiate(repairAndHealPanel, repairAndHealPanel.transform.position, repairAndHealPanel.transform.rotation);
        repairAndHeal.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
        repairAndHeal.transform.position = GameObject.FindGameObjectWithTag("Canvas").transform.position;
        ReCall_HealPanel.selectedShip = gameObject;
    }

    void LookDirection()
    {

        GameObject hub = GameObject.FindGameObjectWithTag("Hub");
        transform.rotation = Quaternion.LookRotation (transform.position - hub.transform.position);

    }

    void OnDrawGizmos()
    {

        //We will use this to give us an idea of area covered
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3);

    }

    IEnumerator CheckForShipsTimer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            GetClosestEnemyShips();
        }

    }
}
