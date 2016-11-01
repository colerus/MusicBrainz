﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace MetaBrainz.MusicBrainz.Entities.Objects {

  internal sealed class Series : ISeries {

    public EntityType EntityType => EntityType.Series;

    public Guid MbId => this._json.id;

    public IEnumerable<IAlias> Aliases => this._json.aliases.WrapArray(ref this._aliases, j => new Alias(j));

    private Alias[] _aliases;

    public string Annotation => this._json.annotation;

    public string Disambiguation => this._json.disambiguation;

    public string Name => this._json.name;

    public string OrderingAttribute => this._json.ordering_attribute;

    public IEnumerable<IRelationship> Relationships => this._json.relations.WrapArray(ref this._relationships, j => new Relationship(j));

    private Relationship[] _relationships;

    public string SortName => this._json.sort_name;

    public IEnumerable<ITag> Tags => this._json.tags.WrapArray(ref this._tags, j => new Tag(j));

    private Tag[] _tags;

    public string Type => this._json.type;

    public Guid? TypeId => this._json.type_id;

    public IEnumerable<IUserTag> UserTags => this._json.user_tags.WrapArray(ref this._userTags, j => new UserTag(j));

    private UserTag[] _userTags;

    #region JSON-Based Construction

    internal Series(JSON json) {
      this._json = json;
    }

    private readonly JSON _json;

    #pragma warning disable 649

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal sealed class JSON {
      [JsonProperty] public Alias.JSON[] aliases;
      [JsonProperty] public string annotation;
      [JsonProperty(Required = Required.Always)] public Guid id;
      [JsonProperty] public string disambiguation;
      [JsonProperty(Required = Required.Always)] public string name;
      [JsonProperty("ordering-attribute")] public string ordering_attribute;
      [JsonProperty] public Relationship.JSON[] relations;
      [JsonProperty("sort-name")] public string sort_name;
      [JsonProperty] public Tag.JSON[] tags;
      [JsonProperty] public string type;
      [JsonProperty("type-id")] public Guid? type_id;
      [JsonProperty("user-tags")] public UserTag.JSON[] user_tags;
    }

    #endregion

  }

}
