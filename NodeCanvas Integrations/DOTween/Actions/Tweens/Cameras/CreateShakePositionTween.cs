using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Framework;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace NodeCanvas.Tasks.DOTween.Tweens.Cameras
{
    [Category("DOTween/Tweens/Camera")]
    [Name("Create Shake Position Tween")]
    [Description("Creates a shake position tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Camera))]
    public class CreateShakePositionTween : ActionTask
    {

        public BBParameter<float> Duration;
        public FieldToUse fieldToUse = FieldToUse.Float;
        public BBParameter<float> StrengthAsFloat;
        public BBParameter<Vector3> StrengthAsVector;
        public BBParameter<int> vibrato;
        public BBParameter<float> randomness;

        [BlackboardOnly] 
        public BBParameter<Tween> CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();

                if (fieldToUse == FieldToUse.Float) {
                    descriptionBuilder.AppendFormat("Shake Tween With Strength of {0}", StrengthAsFloat.value);
                }
                else {
                    descriptionBuilder.AppendFormat("Shake Tween With Strength of {0}", StrengthAsVector.value);
                }
                descriptionBuilder.AppendFormat("\nWith vibrato of {0}", vibrato.value);

                descriptionBuilder.AppendFormat("\nWith randomness of {0}", randomness.value);

                if (!Duration.isNone && !Duration.isNull)
                { descriptionBuilder.AppendFormat("\nFor {0}", Duration); }
                
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Tweener tweener;

            if (fieldToUse == FieldToUse.Float) {
                tweener = ((Camera) agent).DOShakePosition(Duration.value, StrengthAsFloat.value, vibrato.value, randomness.value);
            } else {
                tweener = ((Camera) agent).DOShakePosition(Duration.value, StrengthAsVector.value, vibrato.value, randomness.value);

            }
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }

        protected override void OnTaskInspectorGUI() {
            object o = this;
            foreach (var field in o.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)){
                // Hide the unused field
                if (fieldToUse == FieldToUse.Vector3 && field.Name == "StrengthAsFloat")
                {
                    continue;
                }
                if (fieldToUse == FieldToUse.Float && field.Name == "StrengthAsVector") {
                    continue;
                }
                field.SetValue(o, EditorUtils.GenericField(field.Name, field.GetValue(o), field.FieldType, field, o));
                GUI.backgroundColor = Color.white;
            }

        }
    }
}