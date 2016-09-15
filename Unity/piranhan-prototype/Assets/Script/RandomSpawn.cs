using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour
{
	[SerializeField]
	GameManager manager;
	[SerializeField]
	GameObject fishPrefab;
	private float spawnPercent = 3f;
	public int spawnCount = 0;
	[SerializeField]
	Transform left = null, right = null;

	void OnDrawGizmosSelected ()
	{
		if (left == null || right == null)
			return;
		
		Gizmos.DrawLine (left.position, right.position);
	}

	void OnEnable ()
	{
		StartCoroutine (SpawnLoop ());
		GetComponent<Animation>().enabled = true;
	}
	
	void OnDisable ()
	{
		StopAllCoroutines ();
		GetComponent<Animation>().enabled = false;
	}
	
	IEnumerator SpawnLoop ()
	{
		while (true) {
			Spawn ();
			yield return new WaitForSeconds (spawnPercent);
		}
	}
	
	public void Spawn ()
	{
		// spawn limit
		if (manager.clearCount <= spawnCount)
			return;
		
		spawnCount ++;
		
		float position = Random.Range (left.transform.position.x, right.transform.position.x);
		
		GameObject fish = GameObject.Instantiate (fishPrefab) as GameObject;
		fish.transform.position = transform.position + Vector3.left * position + Vector3.forward * 20;
		fish.transform.parent = Dustbox.instance.transform;
	}
	
}
