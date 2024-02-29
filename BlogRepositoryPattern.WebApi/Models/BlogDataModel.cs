using System;
using System.Collections.Generic;

namespace BlogRepositoryPattern.WebApi.Models;

public partial class BlogDataModel
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; } = null!;

    public string? BlogAuthor { get; set; } = null!;

    public string? BlogContent { get; set; } = null!;
}

public partial class BlogResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public BlogDataModel BlogData { get; set; }
}
