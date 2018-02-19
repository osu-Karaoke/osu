﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.Karaoke.Objects.Drawables.Common.Pieces;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Lyric.Pieces;
using osu.Game.Rulesets.Karaoke.Tools.Translator;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Lyric
{
    public interface IAmDrawableLyric
    {
        /// <summary>
        /// Object
        /// </summary>
        Objects.Lyric Lyric { get; }

        /// <summary>
        /// Template
        /// </summary>
        LyricTemplate Template { get; set; }

        /// <summary>
        /// singer
        /// </summary>
        Singer Singer { get; set; }

        /// <summary>
        /// set preemptive time
        /// </summary>
        double PreemptiveTime { get; set; }

        /// <summary>
        /// show text and mask
        /// </summary>
        TextsAndMask TextsAndMaskPiece { get; set; }

        /// <summary>
        /// translate text
        /// </summary>
        TranslateString TranslateText { get; set; }

        /// <summary>
        /// add translate
        /// </summary>
        /// <param name="code"></param>
        /// <param name="translateResult"></param>
        void AddTranslate(TranslateCode code, string translateResult);
    }
}
