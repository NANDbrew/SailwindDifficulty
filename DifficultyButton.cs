using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SailwindDifficulty
{
    internal class DifficultyButton : GoPointerButton
    {
        public Difficulty difficulty;
        public TextMesh difficultyDesc;

        private void Awake()
        {
            difficulty = Plugin.difficulty.Value;
            difficultyDesc = transform.parent.parent.Find("description").GetComponent<TextMesh>();
            UpdateButtonText();
        }

        public override void OnActivate()
        {
            if (difficulty == Difficulty.Hard)
            {
                difficulty = Difficulty.Casual;
            }
            else
            {
                difficulty += 1;
            }
            Plugin.difficulty.Value = difficulty;
            UpdateButtonText();
            UISoundPlayer.instance.PlayUISound(UISounds.buttonClick, 1f, 1.5f);
        }

        public void UpdateButtonText()
        {
            foreach (Transform item in base.transform.parent)
            {
                if ((UnityEngine.Object)(object)item.GetComponent<TextMesh>() != null)
                {
                    item.GetComponent<TextMesh>().text = difficulty.ToString();
                }
            }
            if (difficultyDesc != null)
            {
                difficultyDesc.text = strings[(int)difficulty];
            }
        }

        readonly string[] strings = { 
            "- Double starting currency\n- No starting food\n- Start with rum instead of water\n- No survival mechanics\n- Sleeping at sea requires alcohol",
            "- Double starting currency\n- Standard starting supplies\n- Passing out from hunger or thirst disabled\n- Wake sooner after passing out from fatigue\n- Sleep, hunger and thirst deplete 30% slower",
            "- Standard starting currency\n- Standard starting supplies",
            "- Reduced starting supplies\n- External boat camera disabled\n- No starting tools" };

    }
}
