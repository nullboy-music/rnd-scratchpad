using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int radius = 2;
    public static int worldSize = 10;
    [Range(0, 255)]
    public int cullingValue;

    int [,,] worldArray;
    GameObject[,,] debugPoints;

    // Start is called before the first frame update
    void Start()
    {
        this.worldArray = new int [worldSize, worldSize, worldSize];
        this.debugPoints = new GameObject[worldSize, worldSize, worldSize];

        Debug.Log(this.worldArray);
        Debug.Log(this.worldArray.Length);
        Debug.Log(this.worldArray[0,0,0]);
        
        this.GenerateWorldPointsArray(this.worldArray);
    }

    void Update (){
        this.DebugDrawPoints();
    }

    void DebugDrawPoints(){
        for (int i = 0; i<Generator.worldSize; i++)
        {
            for (int j = 0; j<Generator.worldSize; j++)
            {
                for (int k = 0; k<Generator.worldSize; k++)
                {
                    var point = this.worldArray[i, j, k];
                    GameObject sphere = this.debugPoints[i, j, k];

                    if (point < cullingValue){
                        this.debugPoints[i, j, k].SetActive(false);
                    }
                    else{
                        this.debugPoints[i, j, k].SetActive(true);
                    }
                }
            }
        }
    }

    void Draw(){

    }

    void GenerateWorldPointsArray(int[,,] worldArray){
        for (int i = 0; i<Generator.worldSize; i++)
        {
            for (int j = 0; j<Generator.worldSize; j++)
            {
                for (int k = 0; k<Generator.worldSize; k++)
                {
                    Debug.Log($"at: {i.ToString()}, {j.ToString()}, {k.ToString()}");
                    int randomVal = Mathf.RoundToInt(Random.Range(0, 255));
                    
                    worldArray[i, j, k] = randomVal;

                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = new Vector3(i, j, k);
                    float scaleFactor = 0.3f;
                    sphere.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
                    sphere.GetComponent<Renderer>().material.color = new Color(randomVal, randomVal, randomVal);

                    this.debugPoints [i,j,k] = sphere;
                }
            }
        }
    }
}
