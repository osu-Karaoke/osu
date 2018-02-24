﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Configuration
{
    /// <summary>
    /// karaoke lyric config
    /// </summary>
    public class KaraokeLyricConfig
    {
        /// <summary>
        /// show subText
        /// </summary>
        public bool SubTextVislbility { get; set; } = true;

        /// <summary>
        /// show romaji
        /// </summary>
        public bool RomajiVislbility { get; set; } = true;

        /// <summary>
        /// romaji first
        /// </summary>
        public bool RomajiFirst { get; set; } = true;

        /// <summary>
        /// Show translate
        /// </summary>
        public bool ShowTranslate { get; set; } = true;
    }
}