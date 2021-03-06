﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.Sprites;
using OpenTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Skinning;

namespace osu.Game.Rulesets.Osu.Objects.Drawables.Pieces
{
    public class NumberPiece : Container
    {
        private readonly SkinnableSpriteText number;

        public string Text
        {
            get { return number.Text; }
            set { number.Text = value; }
        }

        public NumberPiece()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                new SkinnableDrawable("Play/osu/number-glow", name => new CircularContainer
                {
                    Masking = true,
                    Origin = Anchor.Centre,
                    EdgeEffect = new EdgeEffectParameters
                    {
                        Type = EdgeEffectType.Glow,
                        Radius = 60,
                        Colour = Color4.White.Opacity(0.5f),
                    },
                    Child = new Box()
                }, s => s.GetTexture("Play/osu/hitcircle") == null),
                number = new SkinnableSpriteText("Play/osu/number-text", _ => new OsuSpriteText
                {
                    Font = @"Venera",
                    UseFullGlyphHeight = false,
                    TextSize = 40,
                }, restrictSize: false)
                {
                    Text = @"1"
                }
            };
        }
    }
}
