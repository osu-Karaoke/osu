﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Note
{
    public class DrawableNotes : DrawableNotes<DrawableSingleNote>
    {
        public DrawableNotes(Objects.Lyric hitObject)
            : base(hitObject)
        {
        }
    }

    /// <summary>
    ///     list of DrawableLyricNote
    /// </summary>
    public class DrawableNotes<T> : DrawableHitObject<Objects.Lyric> where T : DrawableSingleNote, new()
    {
        public BindableDouble NoteSpeed = new BindableDouble();

        public override Color4 AccentColour
        {
            set
            {
                if (ListNote != null)
                {
                    foreach (var single in ListNote)
                        single.AccentColour = value;
                }
            }
        }

        protected FillFlowContainer<T> ListNote;
        private float _lastWidth;

        public DrawableNotes(Objects.Lyric hitObject)
            : base(hitObject)
        {
            Anchor = Anchor.CentreLeft;
            Origin = Anchor.CentreLeft;

            RelativeSizeAxes = Axes.Y;

            InternalChildren = new Drawable[]
            {
                ListNote = new FillFlowContainer<T>
                {
                    Name = "Background",
                    Direction = FillDirection.Horizontal,
                    RelativeSizeAxes = Axes.Both
                },
            };

            //initial note
            InitialNote();
        }

        protected virtual void InitialNote()
        {
            foreach (var timeline in HitObject.TimeLines)
            {
                var note = new T
                {
                    HitObject = HitObject,
                    TimeLine = timeline
                };
                ListNote.Add(note);
            }
        }

        protected override void Update()
        {
            base.Update();

            //means width changed
            if (Math.Abs(_lastWidth - DrawWidth) > 0)
            {
                _lastWidth = DrawWidth;
                foreach (var note in ListNote)
                {
                    var precentage = note.Duration / HitObject.Duration;
                    note.Width = (float)(_lastWidth * precentage);
                }
            }
        }

        protected override void UpdateState(ArmedState state)
        {
            switch (state)
            {
                //case ArmedState.Hit:
                // Good enough for now, we just want them to have a lifetime end
                //    this.Delay(2000).Expire();
                //    break;
            }
        }
    }
}
