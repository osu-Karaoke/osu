﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Karaoke.Objects.Text;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Common.Pieces
{
    public class KaraokeText : OsuSpriteText
    {
        public virtual FormattedText TextObject
        {
            get => _textObject;
            set
            {
                _textObject = value;
                if (_textObject == null)
                    return;

                //set text
                Text = TextObject.Text;

                //update position and size
                Position = TextObject.Position;
                TextSize = TextObject.FontSize ?? 18;
            }
        }

        private FormattedText _textObject;

        public KaraokeText(FormattedText textObject)
        {
            TextObject = textObject;
            UseFullGlyphHeight = false;
            Anchor = Anchor.TopLeft;
            Origin = Anchor.BottomLeft;
            Alpha = 1;
        }
    }
}
