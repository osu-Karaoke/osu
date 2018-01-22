﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mania.Beatmaps;
using osu.Game.Rulesets.Mania.Objects;
using osu.Game.Rulesets.Mania.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Mania.Mods
{
    public class ManiaModKeyCoop : Mod, IKeyBindingMod, IApplicableToBeatmapConverter<ManiaHitObject>, IApplicableToRulesetContainer<ManiaHitObject>
    {
        public override string Name => "KeyCoop";
        public override string ShortenedName => "2P";
        public override string Description => @"Double the key amount, double the fun!";
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;

        public void ApplyToBeatmapConverter(BeatmapConverter<ManiaHitObject> beatmapConverter)
        {
            var mbc = (ManiaBeatmapConverter)beatmapConverter;

            // Although this can work, for now let's not allow keymods for mania-specific beatmaps
            if (mbc.IsForCurrentRuleset)
                return;

            mbc.TargetColumns *= 2;
        }

        public void ApplyToRulesetContainer(RulesetContainer<ManiaHitObject> rulesetContainer)
        {
            var mrc = (ManiaRulesetContainer)rulesetContainer;

            var newDefinitions = new List<StageDefinition>();
            foreach (var existing in mrc.Beatmap.Stages)
            {
                newDefinitions.Add(new StageDefinition { Columns = (int)Math.Ceiling(existing.Columns / 2f) });
                newDefinitions.Add(new StageDefinition { Columns = (int)Math.Floor(existing.Columns / 2f) });
            }

            mrc.Beatmap.Stages = newDefinitions;
        }

        public PlayfieldType Variant => PlayfieldType.Dual;
    }
}
