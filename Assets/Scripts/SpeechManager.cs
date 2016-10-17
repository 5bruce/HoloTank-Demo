using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Rotate Model", () =>
        {
            // Call the OnRotateStart method on every descendant object.
            this.BroadcastMessage("OnRotateStart");
        });

        keywords.Add("Stop Rotation", () =>
        {
            // Call the OnRotateStart method on every descendant object.
            this.BroadcastMessage("OnRotateStop");
        });

        keywords.Add("Display Mesh", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnDisplayMesh");
        });

        keywords.Add("Hide Mesh", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnHideMesh");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}