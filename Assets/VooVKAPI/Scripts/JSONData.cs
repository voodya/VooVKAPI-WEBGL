using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public partial class UserData
{
    [JsonProperty("user")]
    public User User { get; set; }
}

public partial class User
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("domain")]
    public string Domain { get; set; }

    [JsonProperty("href")]
    public Uri Href { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("nickname")]
    public string Nickname { get; set; }
}

public partial class FriendsData
{
    [JsonProperty("response")]
    public Response Response { get; set; }
}

public partial class UserPhotoData
{
    [JsonProperty("response")]
    public List<Photo> Response { get; set; }
}

public partial class Photo
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("photo_max_orig")]
    public Uri PhotoMaxOrig { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("can_access_closed")]
    public bool CanAccessClosed { get; set; }

    [JsonProperty("is_closed")]
    public bool IsClosed { get; set; }
}

public partial class Response
{
    [JsonProperty("count")]
    public long Count { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }
}

public partial class Item
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    [JsonProperty("lists", NullValueHandling = NullValueHandling.Ignore)]
    public List<long> Lists { get; set; }

    [JsonProperty("track_code")]
    public string TrackCode { get; set; }

    [JsonProperty("sex")]
    public long Sex { get; set; }

    [JsonProperty("photo_100")]
    public Uri Photo100 { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("can_access_closed")]
    public bool CanAccessClosed { get; set; }

    [JsonProperty("is_closed")]
    public bool IsClosed { get; set; }
}
