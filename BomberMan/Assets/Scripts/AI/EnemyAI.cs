using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	bool nearBomb = false; 
	CentralAI theCentralAI; 
	float bombX; 
	float bombZ; 

	public Bomb enemysBomb;

	bool isEnemyAttacking;
	bool isEnemyTraping;

    bool isBombSet; 

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//makes ai run away form bomb
		if (nearBomb == true)
		{
			while (bombX > 0) 
			{
				transform.Translate (-0.5f, 0, 0); 
				//bombX = GetBombX - transform.position.x; 
			}
			nearBomb = false; 
		}
		if (isEnemyAttacking == true) 
		{
			// use pathfinding go along path to attack player 
		}
		if (isEnemyTraping == true) 
		{
            //use pathfinding to move away from player path 
            // sets bomb in the player path 
            Instantiate(enemysBomb, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            isBombSet = true; 
		}
	}
	public float GetX()
	{
		return transform.position.x;
	}
	public float GetZ()
	{
		return transform.position.z;
	}
	public void SetNearBomb(bool isNearBomb)
	{
		nearBomb = isNearBomb;
	}
	public void GetBombX(float theBombX)
	{
		bombX = theBombX; 
	}
	public void GetBombZ(float theBombZ)
	{
		bombZ = theBombZ; 
	}
    public bool IsBombDown()
    {
        return isBombSet; 
    }
	public void Attack()
	{
		isEnemyAttacking = true;
	}
	public void Trap()
	{
		isEnemyTraping = true;
	}
    //private void SetBomb()
    //{
       
    //}
}
