﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.Karaoke.Beatmaps;
using osu.Game.Rulesets.Karaoke.Edit.Dialog.Pieces;

namespace osu.Game.Rulesets.Karaoke.Edit.Dialog
{
    /// <summary>
    ///     show list singer
    /// </summary>
    public class ListSingerDialog : DialogContainer
    {
    }

    public class ListSingerScrollContainer : TableView<Singer, SingerCell>
    {
    }

    public class SingerCell : KaraokeBaseTableViewCell<Singer>
    {
    }
}
