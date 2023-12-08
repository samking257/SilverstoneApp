using System;
using System.Collections.Generic;
using WeatherApp.Models;

public static class SearchHistoryList
{
    private static readonly List<WeatherInfoModel> searchHistory;

    static SearchHistoryList()
    {
        searchHistory = new List<WeatherInfoModel>();
    }
    private static List<WeatherInfoModel> InternalSearchHistory => searchHistory;
    public static void AddSearch(WeatherInfoModel search)
    {
        if (search == null)
        {
            throw new ArgumentException("Search cannot be null or empty.", nameof(search));
        }

        InternalSearchHistory.Add(search);
    }

    public static IReadOnlyList<WeatherInfoModel> GetSearchHistory()
    {
        return InternalSearchHistory.AsReadOnly();
    }
}
