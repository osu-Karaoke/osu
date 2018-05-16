﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// record what time the 
    /// </summary>
    public class LyricTimeLine
    {
        public LyricTimeLine()
        {
        }

        public LyricTimeLine(double time)
        {
            RelativeTime = time;
        }

        /// <summary>
        /// relative to word's strt time
        /// </summary>
        public double RelativeTime { get; set; }

        /// <summary>
        /// Tone
        /// TODO : not sure will change to enum type
        /// </summary>
        public int Tone { get; set; }
    }
}
