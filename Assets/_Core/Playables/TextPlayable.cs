using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextChangerBehaviour : PlayableBehaviour
{
    public Text tmpTextObject;
    [TextArea] public string text = null;
    
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        tmpTextObject.text = text;
    }
}

public class TextChangerAsset : PlayableAsset
{
    public ExposedReference<Text> tmpTextObject;
    [TextArea] public string text = null;

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TextChangerBehaviour>.Create(graph);

        var textChangerBehaviour = playable.GetBehaviour();
        textChangerBehaviour.tmpTextObject = tmpTextObject.Resolve(graph.GetResolver());
        textChangerBehaviour.text = text;

        return playable;
    }
}
