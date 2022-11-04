using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Survey : MonoBehaviour
{
    [SerializeField] InputField feedback1;

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf5E1BD-709Mqyb7LxtxBDzndsE-NPZj6mjObD8O1bv6F5RBg/formResponse";

    public void Send()
    {
        StartCoroutine(Post(feedback1.text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.307837587", s1);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
    }
}
