using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckpointController : MonoBehaviour {

    public Text CheckpointText;

    private string _weightText = "5.0";
    private string _defaultText = "0.0";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Constants.Tags.PlayerTag)
        {
            CheckpointText.text = _weightText;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Constants.Tags.PlayerTag)
        {
            CheckpointText.text = _defaultText;
        }
    }
}
