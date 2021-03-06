﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects.Localization.Types
{
    /// <summary>
    ///     most non-english MainLyric , might need romaji for foreign people
    /// </summary>
    public interface IHasRomaji
    {
        /// <summary>
        ///     Romaji
        /// </summary>
        RomajiTextList Romaji { get; }
    }
}
