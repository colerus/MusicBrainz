﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using MetaBrainz.MusicBrainz.InternalModel.Lists;
using MetaBrainz.MusicBrainz.Resources;

#pragma warning disable 649

namespace MetaBrainz.MusicBrainz.InternalModel {

  [Serializable]
  internal sealed class Release : MbEntity, IRelease {

    #region XML Elements

    [XmlElement("alias-list")]          public AliasList          AliasList;
    [XmlElement("annotation")]          public Annotation         Annotation;
    [XmlElement("artist-credit")]       public ArtistCredit       ArtistCredit;
    [XmlElement("asin")]                public string             Asin;
    [XmlElement("barcode")]             public string             BarCode;
    [XmlElement("collection-list")]     public CollectionList     CollectionList;
    [XmlElement("country")]             public string             Country;
    [XmlElement("cover-art-archive")]   public CoverArtArchive    CoverArtArchive;
    [XmlElement("date")]                public string             Date;
    [XmlElement("disambiguation")]      public string             Disambiguation;
    [XmlElement("label-info-list")]     public LabelInfoList      LabelInfoList;
    [XmlElement("medium-list")]         public MediumList         MediumList;
    [XmlElement("packaging")]           public Packaging          Packaging;
    [XmlElement("quality")]             public string             Quality;
    [XmlElement("relation-list")]       public RelationList[]     RelationList;
    [XmlElement("release-event-list")]  public ReleaseEventList   ReleaseEventList;
    [XmlElement("release-group")]       public ReleaseGroup       ReleaseGroup;
    [XmlElement("status")]              public Status             Status;
    [XmlElement("tag-list")]            public TagList            TagList;
    [XmlElement("text-representation")] public TextRepresentation TextRepresentation;
    [XmlElement("title")]               public string             Title;
    [XmlElement("user-tag-list")]       public UserTagList        UserTagList;

    #endregion

    #region IAnnotatedResource

    IAnnotation IAnnotatedResource.Annotation => this.Annotation;

    #endregion

    #region IRelatableResource

    IEnumerable<IRelationList> IRelatableResource.RelationList => this.RelationList;

    #endregion

    #region ITaggedResource

    IResourceList<ITag> ITaggedResource.TagList => this.TagList;

    IResourceList<IUserTag> ITaggedResource.UserTagList => this.UserTagList;

    #endregion

    #region ITitledResource

    IResourceList<IAlias> ITitledResource.AliasList => this.AliasList;

    string ITitledResource.Disambiguation => this.Disambiguation;

    string ITitledResource.Title => this.Title;

    #endregion

    #region IRelease

    IArtistCredit IRelease.ArtistCredit => this.ArtistCredit;

    string IRelease.Asin => this.Asin;

    string IRelease.BarCode => this.BarCode;

    IResourceList<ICollection> IRelease.CollectionList => this.CollectionList;

    string IRelease.Country => this.Country;

    ICoverArtArchive IRelease.CoverArtArchive => this.CoverArtArchive;

    string IRelease.Date => this.Date;

    IResourceList<ILabelInfo> IRelease.LabelInfoList => this.LabelInfoList;

    IMediumList IRelease.MediumList => this.MediumList;

    ITextResource IRelease.Packaging => this.Packaging;

    string IRelease.Quality => this.Quality;

    IResourceList<IReleaseEvent> IRelease.ReleaseEventList => this.ReleaseEventList;

    IReleaseGroup IRelease.ReleaseGroup => this.ReleaseGroup;

    ITextResource IRelease.Status => this.Status;

    ITextRepresentation IRelease.TextRepresentation => this.TextRepresentation;

    #endregion

  }

}