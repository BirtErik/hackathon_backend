using Hackathon.Service.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Hackathon.Service.ApiQueryParams;

public abstract class BaseQueryParams
{
    private int ResultLimit;
    private int PageCheck = 1;

    /// <summary>
    /// Determines the number of data to be returned
    /// </summary>
    [DefaultValue(ApiConstants.Pagination.MaxPageSize)]
    [FromQuery(Name = "take")]
    public int Take
    {
        get { return ResultLimit; }
        set
        {
            ResultLimit = (value > ApiConstants.Pagination.MaxPageSize) || (value == 0) ? ApiConstants.Pagination.MaxPageSize : value;
        }
    }

    /// <summary>
    /// Chooses the page from which to take from
    /// </summary>
    [FromQuery(Name = "page")]
    [DefaultValue(1)]
    public int Page
    {
        get { return PageCheck; }
        set
        {
            PageCheck = value <= 0 ? 1 : value;
        }
    }

    /// <summary>
    /// Specifies what to search for
    /// </summary>
    [FromQuery(Name = "search")]
    public string? Search { get; set; } = null;

}
