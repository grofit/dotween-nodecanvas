using System.Text;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.DOTween.Tweens
{
    [Category ("DOTween/Tweens")]
    [Name ("Set Tween Speed Based")]
    [Description ("If IsSpeedBased is True, sets the tween as speed based " +
    "(the duration will represent the number of units/degrees the tween moves x second). " +
    "\n\nNOTE: if you want your speed to be constant, also set the ease to Ease.Linear. " +
    "\n\nHas no effect if the tween has already started or is inside a Sequence.")]
    [Icon ("DOTweenTween")]
    public class SetTweenSpeedBased : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Tween> Tween;

        [RequiredField]
        public BBParameter<bool> IsSpeedBased;

        protected override string info {
            get {
                var descriptionBuilder = new StringBuilder ();
                descriptionBuilder.AppendFormat ("Set Speed Based {0}", IsSpeedBased);

                return descriptionBuilder.ToString ();
            }
        }

        protected override void OnExecute ()
        {
            Tween.value.SetSpeedBased (IsSpeedBased.value);
            EndAction (true);
        }
    }
}