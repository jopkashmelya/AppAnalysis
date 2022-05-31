using AppAnalysis.Models;

namespace AppAnalysis;

public static class ListExtensions
{
    public static void AddSorted(this List<Event> list, Event item)
    {
        if (list.Count == 0)
        {
            list.Add(item);
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Date >= item.Date)
            {
                list.Insert(i, item);
                return;
            }
                
        }
    }
}