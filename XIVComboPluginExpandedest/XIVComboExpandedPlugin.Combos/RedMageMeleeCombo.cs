using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal class RedMageMeleeCombo : CustomCombo
{
	protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageMeleeCombo;


	protected internal override uint[] ActionIDs { get; } = new uint[1] { 7516u };


	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
	{
		if (actionID == 7516)
		{
			RDMGauge jobGauge = CustomCombo.GetJobGauge<RDMGauge>();
			if (CustomCombo.IsEnabled(CustomComboPreset.RedMageMeleeComboPlus))
			{
				if (lastComboMove == 16530 && level >= 90)
				{
					return 25858u;
				}
				if ((lastComboMove == 7525 || lastComboMove == 7526) && level >= 80)
				{
					return 16530u;
				}
				if (jobGauge.ManaStacks == 3)
				{
					if (level < 70)
					{
						return 7525u;
					}
					if (jobGauge.BlackMana >= jobGauge.WhiteMana)
					{
						if (CustomCombo.HasEffect(1235) && !CustomCombo.HasEffect(1234) && jobGauge.BlackMana - jobGauge.WhiteMana <= 9)
						{
							return 7525u;
						}
						return 7526u;
					}
					if (CustomCombo.HasEffect(1234) && !CustomCombo.HasEffect(1235) && jobGauge.WhiteMana - jobGauge.BlackMana <= 9)
					{
						return 7526u;
					}
					return 7525u;
				}
			}
			if (lastComboMove == 7512 && level >= 50)
			{
				return CustomCombo.OriginalHook(7516u);
			}
			if ((lastComboMove == 7504 || lastComboMove == 7527) && level >= 35)
			{
				return CustomCombo.OriginalHook(7512u);
			}
			return CustomCombo.OriginalHook(7504u);
		}
		return actionID;
	}
}
