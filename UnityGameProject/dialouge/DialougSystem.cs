using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougSystem : MonoBehaviour {
    public static DialougSystem Instance { get; set; }
    public GameObject DialougePanel;
    public string NpcName;
    public List<string> dialougelines = new List<string>();

    Button okbutton;
    Text DialougeText, nametext;
    int dialougeindex;

    // Use this for initialization
    void Awake() {
        okbutton = DialougePanel.transform.Find("Continue").GetComponent<Button>();
        DialougeText = DialougePanel.transform.Find("DialougeText").GetComponent<Text>();
        nametext = DialougePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        DialougePanel.SetActive(false);
        okbutton.onClick.AddListener(delegate { Continuedialouge(); } );

		if(Instance !=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}

    public void Adddialouge(string[] lines, string Name)
    {
        dialougeindex = 0;
        dialougelines = new List<string>();
        foreach (string line in lines)
        {
            dialougelines.Add(line);
        }
        this.NpcName = Name;
        Debug.Log(dialougelines.Count);
        Createdialouge();
    }

    public void Createdialouge()
    {
        DialougeText.text = dialougelines[dialougeindex];
        nametext.text = NpcName;
        DialougePanel.SetActive(true);
    }

    public void Continuedialouge()
    {
        if(dialougeindex < dialougelines.Count - 1)
        {
            dialougeindex++;
            DialougeText.text = dialougelines[dialougeindex];
        }
        else
        {
            DialougePanel.SetActive(false);
        }

    }
}
