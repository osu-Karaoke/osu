﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.Karaoke.Beatmaps;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Types
{
    public interface IDrawableLyricParameter
    {
        /// <summary>
        ///     Object
        /// </summary>
        Objects.Lyric Lyric { get; }

        /// <summary>
        ///     singer
        /// </summary>
        Singer Singer { get; set; }

        /// <summary>
        ///     set preemptive time
        /// </summary>
        double PreemptiveTime { get; set; }
    }
}
