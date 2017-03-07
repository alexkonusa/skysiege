using UnityEngine;
using System.Collections;

public class AI_Ship : MonoBehaviour
{

    public GameObject closestAlly = null;
    public float health; 
    public float countDown = 0f;
    public float fireRate = 1f;
    public float enemyDamage = 1f;
    public float hubDamage = 0.2f; //Dmg we deal to the hub
    public float laserTimer = 1.0f;

    public string enemyShipTag = "AllyShip";
    public bool shipFound = false;
    public bool attackHub = false;

    GameObject hub;
    LineRenderer lineRenderer;

    public enum AttackType
    {
        Laser,
    };

    public AttackType attackType;

void Start()
    {

        StartCoroutine(CheckForShipsTimer(10));

        hub = GameObject.FindGameObjectWithTag("Hub");
        transform.LookAt(hub.transform); //Look at the hub

        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        AttackTheEnemy();

        if (shipFound == true && closestAlly == null)
        {
            closestAlly = null;
            shipFound = false;
            attackHub = true;


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
            foreach (Collider checkForShips in affectedColliders)
            {

                if (checkForShips.tag == enemyShipTag)
                {

                    Debug.Log("FoundShip");
                    shipFound = true;
                    attackHub = false; //If we found the ship don't attack the hub any more

                }
            }

            if (attackHub == true)
            {
                //Attack the hub if there are no close ships;
                AttackTheMainHub();
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

    void AttackTheMainHub()
    {
        if (closestAlly == null)
        {
            transform.LookAt(hub.transform); //Look at the hub

            switch (attackType)
            {

                case AttackType.Laser:
                    attackLaser();
                    break;

            }

                Debug.Log("FUCK YOU HUB");
                //Damage the Hub
                Hub.hubHealth = (Hub.hubHealth - hubDamage);
                Debug.Log("Hub Health: " + Hub.hubHealth);
        }

    }

    void OnDrawGizmos()
    {

        //We will use this to give us an idea of area covered
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3);

    }

    void AttackTheEnemy()
    {

        if (closestAlly != null)
        {

            GameObject _closestAlly = closestAlly.gameObject;
            float allyHealth = _closestAlly.GetComponent<AI_Ally>().health;

            if (allyHealth - 1 >= 0)
            {
                    if (countDown <= 0)
                    {

                        //attack the ship
                        _closestAlly.GetComponent<AI_Ally>().health = (_closestAlly.GetComponent<AI_Ally>().health - enemyDamage);
                        Debug.Log("I'm Attacking ally");
                        countDown = 1f / fireRate;
                    }

                countDown -= Time.deltaTime;
            }

                if (allyHealth <= 0)
            {
                closestAlly = null;
                if (closestAlly == null)
                {
                    attackHub = true;
                    shipFound = false;
                }
            }
        }

    }

    void attackLaser()
    {
        Debug.Log("Case 1");
        //Line Renderer stuff
        lineRenderer.enabled = true;
        Vector3 position = transform.position;

        Vector3 startPointOffSet = new Vector3(0f, 0.5f, 0f); //End position offset
        Vector3 endPointOffSet = new Vector3(0f, 1f, 0f); //End position offset

        lineRenderer.SetPosition(0, position + startPointOffSet);
        lineRenderer.SetPosition(1, hub.transform.position + endPointOffSet);

        StartCoroutine(LaserTimer(laserTimer));

    }

    IEnumerator CheckForShipsTimer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            GetClosestEnemyShips();
        }

    }

    IEnumerator LaserTimer(float time)
    {
        yield return new WaitForSeconds(time);
        lineRenderer.enabled = false;
    }
}
