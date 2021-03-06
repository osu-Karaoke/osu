﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Game.Graphics.Sprites;
using osu.Game.Graphics.UserInterface;
using osu.Game.Rulesets.Karaoke.Objects.TimeLine;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace osu.Game.Rulesets.Karaoke.Edit.Drawables.Thumbnail
{
    public class EditableProgressPoint : Container, IHasContextMenu
    {
        public MenuItem[] ContextMenuItems => new MenuItem[]
        {
            new OsuMenuItem(@"Delete", MenuItemType.Highlighted)
        };

        public int IndexOfObject => LyricProgressPoint.Key;

        //protected culculater value
        public string ProgressText
        {
            get
            {
                if (IndexOfObject == 0)
                    return DrawableKaraokeThumbnail.Lyric.Text.Substring(0, LyricProgressPoint.Key + 1);
                var thisCharIndex = LyricProgressPoint.Key;
                var lastTime = DrawableKaraokeThumbnail.Lyric.TimeLines.FindPrevioud(IndexOfObject).Value.Key;
                return DrawableKaraokeThumbnail.Lyric.Text.Substring(lastTime + 1, thisCharIndex - lastTime);
            }
        }

        //public 
        public KeyValuePair<int, TimeLine> LyricProgressPoint { get; set; }

        public DrawableKaraokeThumbnail DrawableKaraokeThumbnail { get; set; } //Parent

        public bool Hover
        {
            get => false;
            set
            {
                if (value)
                    Background.Colour = BackgroundHoverColor;
                else
                    Background.Colour = BackgroundIdolColor;
            }
        }

        public bool Selected
        {
            get => false;
            set
            {
                if (value)
                    Background.Colour = BackgroundPressColor;
                else
                    Background.Colour = BackgroundIdolColor;
            }
        }

        //protected value
        protected bool IsFocus;

        protected float? PressedRelativePositionX;
        protected float Ratio = 0.3f;

        //Drawable component
        protected OsuSpriteText ProgressDrawableText { get; set; }

        protected Box Background { get; set; } = new Box { Height = 50 };

        protected Box StartLine { get; set; } = new Box
        {
            Width = 3,
            Height = 50
        };

        protected Color4 BackgroundIdolColor { get; set; } = Color4.Black;
        protected Color4 BackgroundHoverColor { get; set; } = Color4.Purple;
        protected Color4 BackgroundPressColor { get; set; } = Color4.Blue;

        public EditableProgressPoint(DrawableKaraokeThumbnail drawableKaraokeThumbnail, KeyValuePair<int, TimeLine> lyricProgressPoin)
        {
            DrawableKaraokeThumbnail = drawableKaraokeThumbnail;
            LyricProgressPoint = lyricProgressPoin;
            ProgressDrawableText = new OsuSpriteText
            {
                Text = ProgressText,
                Position = new Vector2(5, 5)
            };
            Add(Background);
            Add(StartLine);
            Add(ProgressDrawableText);
        }

        public void ResetColor()
        {
            Hover = false;
            Selected = false;
        }

        #region Input

        protected override bool OnHover(HoverEvent e)
        {
            IsFocus = true;
            DrawableKaraokeThumbnail.HoverSelectedPoint = this;
            DrawableKaraokeThumbnail.UpdateColor();
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            IsFocus = false;
            if (DrawableKaraokeThumbnail.HoverSelectedPoint == this)
                DrawableKaraokeThumbnail.HoverSelectedPoint = null;
            DrawableKaraokeThumbnail.UpdateColor();
            base.OnHoverLost(e);
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (IsFocus)
                if (e.Key == Key.Delete)
                    DrawableKaraokeThumbnail.DeletePoint(LyricProgressPoint);

            return base.OnKeyDown(e);
        }

        #endregion

        #region Override

        //will update view
        public override float Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                Background.Width = Width;
            }
        }

        public override float Height
        {
            get => base.Height;
            set
            {
                base.Height = value;
                Background.Height = Height;
                StartLine.Height = Height;
            }
        }

        #endregion
    }
}
