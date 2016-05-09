﻿using System;
using System.Collections.Generic;

namespace MetaBrainz.MusicBrainz.DiscId {

  internal abstract class Platform : IPlatform {

    public static IPlatform Create() {
      switch (Environment.OSVersion.Platform) {
        case PlatformID.MacOSX:
          return new Platforms.Darwin();
        case PlatformID.Win32NT:
        case PlatformID.Win32S:
        case PlatformID.Win32Windows:
        case PlatformID.WinCE:
        case PlatformID.Xbox:
          return new Platforms.Windows();
        case PlatformID.Unix:
          return Platforms.Unix.Create();
        default:
          return new Platforms.Unsupported();
      }
    }

    private readonly CdDeviceFeature _features;

    protected Platform(CdDeviceFeature features) {
      this._features = features;
    }

    public IEnumerable<string> Features {
      get {
        if (this.HasFeature(CdDeviceFeature.ReadTableOfContents   )) yield return "read";
        if (this.HasFeature(CdDeviceFeature.ReadMediaCatalogNumber)) yield return "mcn";
        if (this.HasFeature(CdDeviceFeature.ReadTrackIsrc         )) yield return "isrc";
        if (this.HasFeature(CdDeviceFeature.ReadCdText            )) yield return "text";
      }
    }

    public abstract string DefaultDevice { get; }

    public abstract string GetDeviceByIndex(int n);

    public bool HasFeature(CdDeviceFeature feature) => (feature & this._features) != 0;

    public abstract TableOfContents ReadTableOfContents(string device, CdDeviceFeature features);

    TableOfContents IPlatform.ReadTableOfContents(string device, CdDeviceFeature features) {
      features &= this._features; // Mask off unsupported features
      return this.ReadTableOfContents(device, features);
    }

  }

}