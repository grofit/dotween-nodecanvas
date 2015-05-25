using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

[Category("Materials")]
[Name("Change Material Colour")]
public class SetMaterialColorAction : ActionTask
{
    [RequiredField]
    public BBColor Color;

    public BBGameObject TargetIfNotSelf;

    protected override string info
    {
        get { return string.Format("Changing Color To <b>{0}</b>", Color.value); }
    }

    protected override void OnExecute()
    {
        if (TargetIfNotSelf.isNull || TargetIfNotSelf.isNone)
        { agent.renderer.material.color = Color.value; }
        else
        { TargetIfNotSelf.value.renderer.material.color = Color.value; }
    
        EndAction(true);
    }
}