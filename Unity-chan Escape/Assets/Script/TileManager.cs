using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    ThirdPersonCharacter thirdPersonCharacter;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 6.0f;
    private float safeZone = 15.0f;
    private int amnTileOnScreen = 8;

    float timeLeft = 300.0f;

    public Text time;
    public Text score;

    public Text tip;

    private List<GameObject> activeTile;

    bool flag = true;

    int count = 0;

	// Use this for initialization
	void Start () {
        

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTile = new List<GameObject>();

        for (int i = 0; i < amnTileOnScreen; i++)
        {
            SpawnTile();
        }

        score.text = "Score: " + count;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLength ))
        {
            SpawnTile();
            DeleteTile();
        }


        timeLeft -= Time.deltaTime;
        time.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    public void KillMonster() {
        count++;

        score.text = "Score: " + count;
    }

    public void GameOver() {
        Debug.Log("Over");
        tip.gameObject.SetActive(true);
        tip.text = "Game Over\n Your Score is: " + count;
        score.gameObject.SetActive(false);
        time.gameObject.SetActive(false);

        if (thirdPersonCharacter == null)
            thirdPersonCharacter = GameObject.Find("unitychan").GetComponent<ThirdPersonCharacter>();

        thirdPersonCharacter.enabled = false;
    }

    private void SpawnTile(int prefabIndex = -1) {
        GameObject go = null;

        /*go = Instantiate(tilePrefabs[0]) as GameObject;
        flag = !flag;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTile.Add(go);*/

        if (flag)
        {
            go = Instantiate(tilePrefabs[0]) as GameObject;
            flag = !flag;

            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
            activeTile.Add(go);
        }
        else
        {

            int number = Random.Range(0, 7);


            switch (number)
            {
                case 0:
                    go = Instantiate(tilePrefabs[0]) as GameObject;
                    break;
                case 1:
                    go = Instantiate(tilePrefabs[1]) as GameObject;
                    break;
                case 2:
                    go = Instantiate(tilePrefabs[2]) as GameObject;
                    break;
                case 3:
                    go = Instantiate(tilePrefabs[3]) as GameObject;
                    break;
                case 4:
                    go = Instantiate(tilePrefabs[4]) as GameObject;
                    break;
                case 5:
                    go = Instantiate(tilePrefabs[5]) as GameObject;
                    break;
                case 6:
                    go = Instantiate(tilePrefabs[6]) as GameObject;
                    break;
            }

            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
            activeTile.Add(go);
        }
        //Assets / Oculus / SampleFramework / Usage / CustomHands.unity
        //go = Instantiate(tilePrefabs[0]) as GameObject;

    }

    private void DeleteTile() {
        Destroy(activeTile[0]);
        activeTile.RemoveAt(0);
    }
}
