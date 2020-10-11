using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    [Serializable]
    public class ContainerItem
    {
        public Guid ID;
        public string name;
        public int Maximum;
        public int amountToken;

        public ContainerItem()
        {
            ID = Guid.NewGuid();
        }

        public int Remaining
        {
            get { return Maximum - amountToken; }
        }

        public int Get(int value)
        {
            if (amountToken + value > Maximum)
            {
                var toMuch = (amountToken + value) - Maximum;
                amountToken = Maximum;
                return value - toMuch;
            }

            amountToken += value;
            return value;
        }
    }

    public List<ContainerItem> items = new List<ContainerItem>();
    // public event Action OnContainerReady;

    private void Start()
    {
        // if (OnContainerReady != null)
        //     OnContainerReady();
    }

    public Guid Add(string name, int maximum)
    {
        items.Add(new ContainerItem()
        {
            ID = Guid.NewGuid(),
            Maximum = maximum,
            name = name,
        });
        Debug.Log(items.Last().ID);
        return items.Last().ID;
    }

    public int TakeFromContainer(Guid id, int ammout)
    {
        var containerItem = GetContainerItem(id);
        if (containerItem == null)
            return -1;
        return containerItem.Get(ammout);
    }

    public int GetAmountRemaining(Guid id)
    {
        var containerItem = GetContainerItem(id);
        if (containerItem == null)
            return -1;
        return containerItem.Remaining;
    }

    private ContainerItem GetContainerItem(Guid id)
    {
        var containerItem = items.Where(x => x.ID == id).FirstOrDefault();
        return containerItem; 
    }
}