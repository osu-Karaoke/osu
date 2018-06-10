﻿using System;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Karaoke.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Note
{
    public class DrawableKaraokeNoteGroup : DrawableKaraokeNoteGroup<DrawableLyricNote>
    {
        public DrawableKaraokeNoteGroup(BaseLyric hitObject)
            : base(hitObject)
        {
        }
    }

    /// <summary>
    ///     list of DrawableLyricNote
    /// </summary>
    public class DrawableKaraokeNoteGroup<T> : DrawableBaseNote<BaseLyric> where T : DrawableLyricNote, new()
    {
        public BindableDouble NoteSpeed = new BindableDouble();

        public override Color4 AccentColour
        {
            set
            {
                foreach (var single in ListNote)
                    single.AccentColour = value;
            }
        }

        protected FillFlowContainer<T> ListNote;
        private float _lastWidth;

        public DrawableKaraokeNoteGroup(BaseLyric hitObject)
            : base(hitObject)
        {
            RelativeSizeAxes = Axes.Y;

            InternalChildren = new Drawable[]
            {
                ListNote = new FillFlowContainer<T>
                {
                    Name = "Background",
                    Direction = FillDirection.Horizontal,
                    RelativeSizeAxes = Axes.Both
                }
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

            //means width channged
            if (Math.Abs(_lastWidth - DrawWidth) > 0)
            {
                _lastWidth = DrawWidth;
                foreach (var note in ListNote)
                    note.Width = (float)(NoteSpeed.Value * note.Duration / 1000);
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

        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            AddJudgement(new KaraokeJudgement { Result = HitResult.Perfect });
        }
    }
}
