﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Karaoke.Configuration;

namespace osu.Game.Rulesets.Karaoke.Objects.Types
{
    /// <summary>
    /// define the basic class of karaoke object
    /// </summary>
    public interface ILyric
    {
        /// <summary>
        /// Main Text list 
        /// </summary>
        MainTextList Lyric { get; set; }

        /// <summary>
        /// subText list
        /// </summary>
        Dictionary<int, SubText> Furigana { get; set; }

        /// <summary>
        /// romaji text list
        /// </summary>
        RomajiTextList Romaji { get; set; }

        /// <summary>
        /// list progress point
        /// </summary>
        LyricProgressPointList ProgressPoints { get; set; }

        /// <summary>
        /// list translate
        /// </summary>
        LyricTranslateList Translates { get; set; }


        /// <summary>
        /// template index
        /// </summary>
        int? TemplateIndex { get; set; }

        /// <summary>
        /// singer index
        /// </summary>
        int? SingerIndex { get; set; }

        /// <summary>
        /// translate code
        /// </summary>
        TranslateCode TranslateCode { get; set; }
    }
}