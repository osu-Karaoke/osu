﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// to record the string ,and which language
    /// </summary>
    public class LyricTranslate : TextComponent
    {
        public LyricTranslate()
        {
        }

        public LyricTranslate(string translateText)
        {
            Text = translateText;
        }
    }
}