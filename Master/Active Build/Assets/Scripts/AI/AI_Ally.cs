using UnityEngine;
using System.Collections;

public class AI_Ally : MonoBehaviour
{

    public GameObject closestAlly;
    public float health;
    public string enemyShipTag = "Enemy";
    public float countDown = 0f;
    public float fireRate = 1f;
    public float enemyDamage;


    public bool shipFound;


    void Start()
    {

        StartCoroutine(CheckForShipsTimer(10f));

    }

	// Update is called once per frame
	void Update ()
    {
        //Kill the ally ship
        if (health <= 0)
        {

            Destroy(gameObject);

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

            if (allyHealth - 1 >= 0)
            {
                if (countDown <= 0)
                {

                    //attack the ship
                    _closestAlly.GetComponent<AI_Ship>().health = (_closestAlly.GetComponent<AI_Ship>().health - enemyDamage);
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
                    shipFound = false;
                }
            }
        }

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
