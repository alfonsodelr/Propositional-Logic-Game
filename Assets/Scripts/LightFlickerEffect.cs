using UnityEngine;
using System.Collections;

public class LightFlickerEffect : MonoBehaviour {

	
	Light testLight;
	public float minWaitTime = 0.01f;
	public float maxWaitTime = 0.05f;
	
	void Start () {
		testLight = GetComponent<Light>();
		StartCoroutine(Flashing());
	}
	
	IEnumerator Flashing ()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
			testLight.enabled = ! testLight.enabled;

		}
	}
}