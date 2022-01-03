using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public struct ChildData
{
    public string Title;
    public string Note;
    //public string Note2;

    public ChildData(string t, string n1)
    {        
        Title = t;
        Note = n1;
        //Note2 = n2;
    }
}
public class Refund_Panel : MonoBehaviour
{
    public RecyclingListView theList;
    private List<ChildData> data = new List<ChildData>();

    private void Start()
    {
        theList.ItemCallback = PopulateItem;

        RetrieveData();

        // This will resize the list and cause callbacks to PopulateItem for
        // items that are needed for the view
        theList.RowCount = data.Count;
    }

    private void RetrieveData()
    {
        data.Clear();        

        // You'd obviously load real data here
        string[] randomTitles = new[] {
            "게임펍캐쉬1000",
            "게임펍캐쉬2000",
            "게임펍캐쉬3000",
            "광고제거"            
        };
        for (int i = 0; i < 10; ++i)
        {
            data.Add(new ChildData(randomTitles[Random.Range(0, randomTitles.Length)], $"KRW {i * 1000}"));
        }
    }

    private void PopulateItem(RecyclingListViewItem item, int rowIndex)
    {
        var child = item as ChildItem;
        child.ChildData = data[rowIndex];
    }

    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }
}
