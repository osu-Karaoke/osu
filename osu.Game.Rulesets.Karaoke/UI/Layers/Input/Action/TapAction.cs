﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.Karaoke.Input;

namespace osu.Game.Rulesets.Karaoke.UI.Layers.Input.Action
{
    public class TapAction : BaseAction
    {
        public KaraokeTapAction KaraokeTapAction { get; set; }

        public bool Tap { get; set; }
    }
}
