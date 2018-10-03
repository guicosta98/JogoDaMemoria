using System.Collections;
using UnityEngine;

public class PostScore : MonoBehaviour {

    Helper helper;

	void PostPlayerScore () {
        helper = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Helper>();
        string url = "https://us-central1-huddle-team.cloudfunctions.net/api/memory/guim1998@gmail.com";

        WWWForm formDate = new WWWForm();
        formDate.AddField("Score", helper.score.ToString());

        WWW www = new WWW(url, formDate);

        StartCoroutine(request(www));

    }
	
	IEnumerator request (WWW www)
    {
        yield return www;
        print(www.text);
    }
}
