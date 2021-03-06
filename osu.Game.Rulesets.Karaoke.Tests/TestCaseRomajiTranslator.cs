﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Karaoke.Online.API.Romaj.Google;
using osu.Game.Tests.Visual;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.Tests
{
    [TestFixture]
    [Ignore("getting CI working")]
    [System.ComponentModel.Description("Test karaoke romaji translate")]
    public class TestCaseRomajiTranslator : OsuTestCase
    {
        private GoogleRomajiApi googleRomajiApi { get; set; }

        public TestCaseRomajiTranslator()
        {
            googleRomajiApi = new GoogleRomajiApi();

            var translateResult = googleRomajiApi.Translate("終わるまでは終わらないよ");

            Add(new OsuSpriteText
            {
                Text = translateResult,
                //Font = @"Venera",
                UseFullGlyphHeight = false,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                TextSize = 20,
                Alpha = 1,
                //ShadowColour = _textColor,
                Position = new Vector2(100, 100),
                //BorderColour = _textColor,
            });
        }
    }
}
