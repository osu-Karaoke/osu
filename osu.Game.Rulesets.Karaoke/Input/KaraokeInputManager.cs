﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Karaoke.Input;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Karaoke
{
    public class KaraokeInputManager : RulesetInputManager<KaraokeKeyAction>
    {
        public KaraokeInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }
    }
}
