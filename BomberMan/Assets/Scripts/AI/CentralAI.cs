using UnityEngine;
using System.Collections;

public class CentralAI : MonoBehaviour {

	// Use this for initialization
	public Player thePlayer;
	bool isBombActive = false;

    

	public EnemyAI[] theEnemys;  
	public BrickSpawner[] brickWalls; 

	public int[] indeXOfEnemeysAttacking = new int[2]; 

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (thePlayer.ReturnIsBombActive() == true)
		{
			//for (int i = 0; i < 4; i++) 
			//{
				//if ((theEnemys [i].GetX() + 1) > thePlayer.ReturnBombX() && (theEnemys [i].GetX() - 1) < thePlayer.ReturnBombX() && (theEnemys [i].GetZ() + 1) > thePlayer.ReturnBombX() && (theEnemys [i].GetZ() - 1) < thePlayer.ReturnBombX()) 
				//{
					//theEnemys [i].SetNearBomb (true);
					//theEnemys [i].GetBombX (thePlayer.ReturnBombX());
				//}
			//}
			//for (int i = 0; i < 6; i++) 
			//{

				//if(brickWalls[0].returnZ() + 1 > thePlayer.ReturnBombZ() && (brickWalls[0].returnZ() - 1) < thePlayer.ReturnBombZ())
				//{
				//brickWalls [0].DestroyWall (true); 
				//}
				//for (int a = 0; a < 4; a++) 
				//{
					//if (brickWalls [i].returnZ () + 1 > theEnemys[i].GetZ() || (brickWalls [i].returnZ() - 1) > theEnemys[i].GetZ())
					//{
						//brickWalls [i].rebuildWall (); 
					//}
				//}
			}
			isBombActive = false;
		//}
            for (int i = 0; i < 4; i++)
            {
                if (theEnemys[i].IsBombDown() == true)
                {
                    if (theEnemys[i].GetX() < thePlayer.transform.position.x + 1 && theEnemys[i].GetX() < thePlayer.transform.position.z + 1) ; 
                }
            }
		//find path
		//if enemy[i].path < enemy[i+1].path
		//index of enemy attacking[] = i;
		// theEnemys[index of enemy attacking [0]].attack(); 
		// theEnemys[index of enemy attacking [0]].attack(); 
	}
    public void SetBombActive(bool isActive)
	{
		isBombActive = isActive;
	}
}
