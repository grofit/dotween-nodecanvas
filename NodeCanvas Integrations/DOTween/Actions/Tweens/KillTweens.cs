using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Kill Tweens")]
    [Description("Kills all tweens related to the object")]
    [Icon("DOTweenTween")]
    public class KillTweens : ActionTask
    {
        public BBParameter<bool> ShouldComplete;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Killing Tweens");

                if(ShouldComplete.value)
                { descriptionBuilder.AppendFormat("\nCompleting related tweens"); }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            agent.transform.DOKill(ShouldComplete.value);
            EndAction(true);
        }
    }
}