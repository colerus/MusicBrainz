﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using MetaBrainz.MusicBrainz.Entities;

namespace MetaBrainz.MusicBrainz {

  #if NETFX_LT_4_5
  using ReleaseList = IEnumerable<IRelease>;
  #else
  using ReleaseList = IReadOnlyList<IRelease>;
  #endif

  /// <summary>The result of a lookup for a MusicBrainz disc ID: a disc or cd stub for direct ID matches, or a release list for a fuzzy lookup.</summary>
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public interface IDiscIdLookupResult {

    /// <summary>The MusicBrainz disc ID that was looked up (or "-" for a fuzzy lookup).</summary>
    string Id { get; }

    /// <summary>The disc returned by the lookup (if any was found).</summary>
    IDisc Disc { get; }

    /// <summary>The list of matching releases, if a fuzzy TOC lookup was done.</summary>
    ReleaseList Releases { get; }

    /// <summary>The CD stub returned by the lookup (if any was found).</summary>
    ICdStub Stub { get; }

  }

}
