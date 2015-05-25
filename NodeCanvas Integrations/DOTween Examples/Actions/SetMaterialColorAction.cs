using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.CInput.Examples
{
    [Category("Materials")]
    [Name("Change Material Colour")]
    public class SetMaterialColorAction : ActionTask<Renderer>
    {
        [RequiredField] public BBParameter<Color> Color;

        protected override string info
        {
            get { return string.Format("Changing Color To <b>{0}</b>", Color.value); }
        }

        protected override void OnExecute()
        {
            agent.material.color = Color.value;

            EndAction(true);
        }
    }
}